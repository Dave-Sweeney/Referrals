using Microsoft.Data.Sqlite;
using Referrals.Library.Configuration;
using Referrals.Library.Models;
using SQLitePCL;
using System.Data.Common;

namespace Referrals.Library.Repositories;

public class ReferralsRepository : IReferralsRepository
{
    private readonly IDbConnectionFactory _factory;
    private readonly INotesRepository _notesRepository;

    public ReferralsRepository(IDbConnectionFactory factory, INotesRepository notesRepository)
    {
        _factory = factory;
        _notesRepository = notesRepository;
        Batteries.Init();
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        using var _dbConnection = _factory.CreateConnection();
        _dbConnection.Open();
        var command = _dbConnection.CreateCommand();
        command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Referrals (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ReferralNumber TEXT NOT NULL,
                    ReferralDate TEXT NOT NULL,
                    ParentName TEXT NOT NULL,
                    ParentEmail TEXT NOT NULL,
                    ParentPhone TEXT NOT NULL,
                    OkToText BOOLEAN NOT NULL,
                    ChildName TEXT NOT NULL,
                    ChildAge INTEGER NOT NULL,
                    Comments TEXT
                )";
        command.ExecuteNonQuery();
    }

    public void AddReferral(Referral referral)
    {
        using var _dbConnection = (SqliteConnection)_factory.CreateConnection();
        _dbConnection.Open();

        var command = _dbConnection.CreateCommand();
        command.CommandText = @"
                INSERT INTO Referrals (ReferralNumber, ReferralDate, ParentName, ParentEmail, ParentPhone, OkToText, ChildName, ChildAge, Comments)
                VALUES ($referralNumber, $referralDate, $parentName, $parentEmail, $parentPhone, $okToText, $childName, $childAge, $comments)";
        command.Parameters.AddWithValue("$referralNumber", referral.ReferralNumber);
        command.Parameters.AddWithValue("$referralDate", referral.ReferralDate);
        command.Parameters.AddWithValue("$parentName", referral.ParentName);
        command.Parameters.AddWithValue("$parentEmail", referral.ParentEmail);
        command.Parameters.AddWithValue("$parentPhone", referral.ParentPhone);
        command.Parameters.AddWithValue("$okToText", referral.OkToText);
        command.Parameters.AddWithValue("$childName", referral.ChildName);
        command.Parameters.AddWithValue("$childAge", referral.ChildAge);
        command.Parameters.AddWithValue("$comments", referral.Comments);
        command.ExecuteNonQuery();

        if (referral.Notes is not null)
        {
            foreach (var note in referral.Notes)
            {
                _notesRepository.AddNote(note);
            }
        }

        _dbConnection.Close();
    }

    public Referral? GetReferral(int id)
    {
        using var _dbConnection = (SqliteConnection)_factory.CreateConnection();
        _dbConnection.Open();

        var query = _dbConnection.CreateCommand();

        query.CommandText = @"
            SELECT Id, ReferralDate, ParentName, ParentEmail, ParentPhone, OkToText, ChildName, ChildAge, Comments
            FROM Referrals
            WHERE Id = $id";
        query.Parameters.AddWithValue("$id", id);
        
        using (var reader = query.ExecuteReader())
        {
            if (reader.Read())
            {
                _dbConnection.Close();
                return new Referral
                {
                    Id = reader.GetInt32(0),
                    ReferralDate = reader.GetDateTime(1),
                    ParentName = reader.GetString(2),
                    ParentEmail = reader.GetString(3),
                    ParentPhone = reader.GetString(4),
                    OkToText = reader.GetBoolean(5),
                    ChildName = reader.GetString(6),
                    ChildAge = reader.GetInt32(7),
                    Comments = reader.IsDBNull(8) ? null : reader.GetString(8),
                    Notes = _notesRepository.GetAllNotes(id)?.ToList()
                };
            }
            else
            {
                _dbConnection.Close();
                return null;
            }
        }
    }

    public IEnumerable<Referral> GetAllReferrals()
    {
        using var _dbConnection = (SqliteConnection)_factory.CreateConnection();
        _dbConnection.Open();

        var query = _dbConnection.CreateCommand();

        query.CommandText = @"
                SELECT Id, ReferralNumber, ReferralDate, ParentName, ParentEmail, ParentPhone, OkToText, ChildName, ChildAge, Comments
                FROM Referrals";

        var referrals = new List<Referral>();
        using var reader = query.ExecuteReader();
        while (reader.Read())
        {
            referrals.Add(new Referral
            {
                Id = reader.GetInt32(0),
                ReferralNumber = reader.GetString(1),
                ReferralDate = reader.GetDateTime(2),
                ParentName = reader.GetString(3),
                ParentEmail = reader.GetString(4),
                ParentPhone = reader.GetString(5),
                OkToText = reader.GetBoolean(6),
                ChildName = reader.GetString(7),
                ChildAge = reader.GetInt32(8),
                Comments = reader.IsDBNull(9) ? null : reader.GetString(9),
                Notes = _notesRepository.GetAllNotes(reader.GetInt32(0))?.ToList()
            });
        }
        _dbConnection.Close();

        return referrals;
    }

    public void UpdateReferral(Referral referral)
    {
        using var _dbConnection = (SqliteConnection)_factory.CreateConnection();
        _dbConnection.Open();

        var command = _dbConnection.CreateCommand();
        command.CommandText = @"
                UPDATE Referrals
                SET ReferralNumber = $referralNumber,
                    ReferralDate = $referralDate,
                    ParentName = $parentName,
                    ParentEmail = $parentEmail,
                    ParentPhone = $parentPhone,
                    OkToText = $okToText,
                    ChildName = $childName,
                    ChildAge = $childAge,
                    Comments = $comments
                WHERE Id = $id";

        command.Parameters.AddWithValue("$referralNumber", referral.ReferralNumber);
        command.Parameters.AddWithValue("$referralDate", referral.ReferralDate);
        command.Parameters.AddWithValue("$parentName", referral.ParentName);
        command.Parameters.AddWithValue("$parentEmail", referral.ParentEmail);
        command.Parameters.AddWithValue("$parentPhone", referral.ParentPhone);
        command.Parameters.AddWithValue("$okToText", referral.OkToText);
        command.Parameters.AddWithValue("$childName", referral.ChildName);
        command.Parameters.AddWithValue("$childAge", referral.ChildAge);
        command.Parameters.AddWithValue("$comments", referral.Comments);
        command.Parameters.AddWithValue("$id", referral.Id);

        command.ExecuteNonQuery();
        _dbConnection.Close();
    }

    public void DeleteReferral(int id)
    {
        using var _dbConnection = (SqliteConnection)_factory.CreateConnection();
        _dbConnection.Open();

        foreach (var note in _notesRepository.GetAllNotes(id) ?? [])
        {
            if (note != null)
            {
                _notesRepository.DeleteNote(id, note.Id);
            }
        }

        var command = _dbConnection.CreateCommand();
        command.CommandText = "DELETE FROM Referrals WHERE Id = $id";
        command.Parameters.AddWithValue("$id", id);

        command.ExecuteNonQuery();
        _dbConnection.Close();
    }

}
