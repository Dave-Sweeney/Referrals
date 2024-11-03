using FlatFiles;
using Microsoft.Extensions.Logging;
using Referrals.DataProcessing.Models;
using System.IO;

namespace Referrals.DataProcessing.Repositories;

public class FileReader : IFileReader
{
    private readonly IReferralsRepository _referralsRepository;
    private readonly ILogger<FileReader> _logger;

    public FileReader(IReferralsRepository referralsRepository, ILogger<FileReader> log)
    {
        _referralsRepository = referralsRepository;
        _logger = log;
    }

    public async Task<List<ReferralDto>> ReadFileAsync(Stream file)
    {
        try
        {
            using var fileReader = new StreamReader(file);

            var schema = GetSchema();
            var csvFileReader = new DelimitedReader(fileReader, schema, new DelimitedOptions
            {
                IsFirstRecordSchema = true,
                
            });

            var dataReader = new FlatFileDataReader(csvFileReader, new FlatFileDataReaderOptions
            {
                IsNullStringAllowed = true
            });

            var referrals = new List<ReferralDto>();

            while (dataReader.Read())
            {
                var referralId = dataReader.GetString(4);
                _logger.LogInformation($"Processing referral {referralId}");

                //var area = dataReader.GetNullableString(0);
                //var region = dataReader.GetNullableString(1);
                //var subRegion = dataReader.GetNullableString(2);
                //var unit = dataReader.GetNullableString(3);
                //// referralId
                //var searchZipCode = dataReader.GetNullableString(5);
                //var child = dataReader.GetString(6);
                //var childAge = dataReader.GetNullableInt32(7);
                //var parent = dataReader.GetString(8);
                //var phone = dataReader.GetString(9);
                //var email = dataReader.GetString(10);
                //var address = dataReader.GetNullableString(11);
                //var address2 = dataReader.GetNullableString(12);
                //var city = dataReader.GetNullableString(13);
                //var state = dataReader.GetNullableString(14);
                //var comments = dataReader.GetNullableString(15);
                //var cadet = dataReader.GetString(16);
                //var volunteer = dataReader.GetString(17);
                //var referralDate = dataReader.GetDateTime(18);
                //var contactStatus = dataReader.GetNullableString(19);
                //var contactStatusDate = dataReader.GetNullableDateTime(20);
                //var contactStatusNotes = dataReader.GetNullableString(21);
                //var closedStatus = dataReader.GetNullableString(22);
                //var closedDate = dataReader.GetNullableDateTime(23);
                //var closedNotes = dataReader.GetNullableString(24);
                //var closedReason = dataReader.GetNullableString(25);

                var referral = new ReferralDto
                {
                    Area = dataReader.GetNullableString(0),
                    Region = dataReader.GetNullableString(1),
                    SubRegion = dataReader.GetNullableString(2),
                    Unit = dataReader.GetNullableString(3),
                    ReferralId = referralId,
                    SearchZipCode = dataReader.GetNullableString(5),
                    Child = dataReader.GetString(6),
                    ChildAge = dataReader.GetNullableInt32(7),
                    Parent = dataReader.GetString(8),
                    Phone = dataReader.GetString(9),
                    Email = dataReader.GetString(10),
                    Address = dataReader.GetNullableString(11),
                    Address2 = dataReader.GetNullableString(12),
                    City = dataReader.GetNullableString(13),
                    State = dataReader.GetNullableString(14),
                    Comments = dataReader.GetNullableString(15),
                    Cadet = dataReader.GetString(16),
                    Volunteer = dataReader.GetString(17),
                    ReferralDate = dataReader.GetDateTime(18),
                    ContactStatus = dataReader.GetNullableString(19),
                    ContactStatusDate = dataReader.GetNullableDateTime(20),
                    ContactStatusNotes = dataReader.GetNullableString(21),
                    ClosedStatus = dataReader.GetNullableString(22),
                    ClosedDate = dataReader.GetNullableDateTime(23),
                    ClosedNotes = dataReader.GetNullableString(24),
                    ClosedReason = dataReader.GetNullableString(25)
                };
                referrals.Add(referral);
            }

            return referrals;
        }
        catch (System.InvalidCastException ex)
        {
            _logger.LogError($"Error casting data: {ex.Message}");
            throw;
        }
        catch (NullReferenceException ex)
        {
            _logger.LogError($"Null Found.  Expected Not-Null: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error reading file");
            throw;
        }
    }

    private static DelimitedSchema GetSchema()
    {
        var schema = new DelimitedSchema();
        
        schema.AddColumn(new StringColumn("AREA"))
            .AddColumn(new StringColumn("REGION"))
            .AddColumn(new StringColumn("SUB_REGION"))
            .AddColumn(new StringColumn("UNIT"))
            .AddColumn(new StringColumn("REFERRAL ID"))
            .AddColumn(new StringColumn("SEARCH ZIP CODE"))
            .AddColumn(new StringColumn("CHILD"))
            .AddColumn(new Int32Column("CHILD AGE"))
            .AddColumn(new StringColumn("PARENT"))
            .AddColumn(new StringColumn("PHONE"))
            .AddColumn(new StringColumn("EMAIL"))
            .AddColumn(new StringColumn("ADDRESS"))
            .AddColumn(new StringColumn("ADDRESS2"))
            .AddColumn(new StringColumn("CITY"))
            .AddColumn(new StringColumn("STATE"))
            .AddColumn(new StringColumn("COMMENTS"))
            .AddColumn(new StringColumn("CADET"))
            .AddColumn(new StringColumn("VOLUNTEER"))
            .AddColumn(new DateTimeColumn("REFRRAL DATE"))
            .AddColumn(new StringColumn("CONTACT STATUS"))
            .AddColumn(new DateTimeColumn("CONTACT STATUS DATE"))
            .AddColumn(new StringColumn("CONTACT STATUS NOTES"))
            .AddColumn(new StringColumn("CLOSED STATUS"))
            .AddColumn(new DateTimeColumn("CLOSED DATE"))
            .AddColumn(new StringColumn("CLOSED NOTES"))
            .AddColumn(new StringColumn("CLOSED REASON"));

        return schema;
    }
}
