using Dapper;
using Referrals.DataProcessing.Configuration;
using Referrals.DataProcessing.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Transactions;

namespace Referrals.DataProcessing.Repositories;

public class ReferralsRepository : IReferralsRepository
{
    private readonly ISqlConnectionFactory _connectionFactory;
    public ReferralsRepository(ISqlConnectionFactory connectionFactory)
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

        _connectionFactory = connectionFactory;
    }

    public async Task AddReferralAsync(Referral referral)
    {
        using (var connection = _connectionFactory.CreateConnection())
        {
            await connection.OpenAsync();
            var transaction = await connection.BeginTransactionAsync();
            
            try
            {
                var result = await connection.ExecuteAsync(
                    "REFERRAL_UPSERT_SP", new
                    {
                        referral_id = referral.ReferralId,
                        referral_date = referral.ReferralDate,
                        search_zip = referral.Parent.ZipCode,
                        parent_first_name = referral.Parent.FirstName,
                        parent_last_name = referral.Parent.LastName,
                        parent_phone = referral.Parent.Phone,
                        parent_ok_to_text = referral.Parent.OkToText,
                        parent_email = referral.Parent.Email,
                        parent_comment = referral.Parent.Comment,
                        magellan_closed_date = referral.Status.ClosedDate,
                        magellan_contact_status = referral.Status.ContactStatus,
                        magellan_closed_status = referral.Status.ClosedStatus,
                        magellan_closed_notes = referral.Status.ClosedNotes,
                        magellan_closed_reason = referral.Status.ClosedReason,
                    }, 
                    commandType: CommandType.StoredProcedure, 
                    transaction: transaction);

                if (referral.Children is not null && referral.Children.Any())
                {
                    foreach (var child in referral.Children)
                    {
                        await connection.ExecuteAsync(
                            "CHILD_INSERT_SP", new
                            {
                                referral_id = referral.ReferralId,
                                child_first_name = child.FirstName,
                                child_last_name = child.LastName,
                                child_age = child.Age
                            },
                            commandType: CommandType.StoredProcedure,
                            transaction: transaction);
                    }
                }

                if (referral.Status.Notes is not null)
                {
                    foreach (var note in referral.Status.Notes)
                    {
                        await connection.ExecuteAsync(
                            "MAGELLAN_STATUS_NOTES_INSERT_SP", new
                            {
                                referral_id = referral.ReferralId,
                                author = note.Author,
                                note = note.Note,
                                note_date = note.NoteDate
                            },
                            commandType: CommandType.StoredProcedure,
                            transaction: transaction);
                    }
                }

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new InvalidDataException("Failed to add referral", ex);
            }
        }
    }
}
