using Microsoft.Data.Sqlite;
using Referrals.Library.Configuration;
using Referrals.Library.Models;
using System.Data.Common;

namespace Referrals.Library.Repositories;

public class NotesRepository : INotesRepository
{
    private readonly IDbConnectionFactory _factory;
    public NotesRepository(IDbConnectionFactory factory)
    {
        _factory = factory;
        InitializeDatabase();
    }
    public void InitializeDatabase()
    {
        using var _dbConnection = _factory.CreateConnection();
        _dbConnection.Open();
        var command = _dbConnection.CreateCommand();
        command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Notes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ReferralId INTEGER NOT NULL,
                    Note TEXT NOT NULL,
                    NoteDate TEXT NOT NULL,
                    NoteAuthor TEXT NOT NULL
                )";
        command.ExecuteNonQuery();
        _dbConnection.Close();
    }
    public void AddNote(Note note)
    {
        using var _dbConnection = (SqliteConnection)_factory.CreateConnection();
        _dbConnection.Open();

        var command = _dbConnection.CreateCommand();
        command.CommandText = @"
                INSERT INTO Notes (ReferralId, Note, NoteDate, NoteAuthor)
                VALUES ($referralId, $note, $noteDate, $noteAuthor)";
        command.Parameters.AddWithValue("$referralId", note.ReferralId);
        command.Parameters.AddWithValue("$note", note.NoteText);
        command.Parameters.AddWithValue("$noteDate", note.NoteDate);
        command.Parameters.AddWithValue("$noteAuthor", note.NoteAuthor);
        command.ExecuteNonQuery();

        _dbConnection.Close();
    }
    public Note? GetNote(int referralId, int noteId)
    {
        using var _dbConnection = (SqliteConnection) _factory.CreateConnection();
        _dbConnection.Open();

        var command = _dbConnection.CreateCommand();
        command.CommandText = @"
                SELECT Id, ReferralId, Note, NoteDate, NoteAuthor 
                FROM Notes 
                WHERE ReferralId = $referralId AND Id = $noteId";
        command.Parameters.AddWithValue("$referralId", referralId);
        command.Parameters.AddWithValue("$noteId", noteId);
        var reader = command.ExecuteReader();

        var note = new Note();
        while (reader.Read())
        {
            note.Id = reader.GetInt32(0);
            note.ReferralId = reader.GetInt32(1);
            note.NoteText = reader.GetString(2);
            note.NoteDate = reader.GetDateTime(3);
            note.NoteAuthor = reader.GetString(4);
        }

        _dbConnection.Close();
        return note;
    }

    public IEnumerable<Note>? GetAllNotes(int referralId)
    {
        using var _dbConnection = (SqliteConnection)_factory.CreateConnection();
        _dbConnection.Open();
        var command = _dbConnection.CreateCommand();
        command.CommandText = @"
                SELECT Id, ReferralId, Note, NoteDate, NoteAuthor 
                FROM Notes 
                WHERE ReferralId = $referralId";
        command.Parameters.AddWithValue("$referralId", referralId);
        var reader = command.ExecuteReader();
        var notes = new List<Note>();

        while (reader.Read())
        {
            notes.Add(new Note
            {
                Id = reader.GetInt32(0),
                ReferralId = reader.GetInt32(1),
                NoteText = reader.GetString(2),
                NoteDate = reader.GetDateTime(3),
                NoteAuthor = reader.GetString(4)
            });
        }
        _dbConnection.Close();
        return notes;
    }

    public void DeleteNote(int referralId, int noteId)
    {
        using var _dbConnection = (SqliteConnection)_factory.CreateConnection();
        _dbConnection.Open();
        var command = _dbConnection.CreateCommand();

        command.CommandText = @"
                DELETE FROM Notes 
                WHERE ReferralId = $referralId AND Id = $noteId";
        command.Parameters.AddWithValue("$referralId", referralId);
        command.Parameters.AddWithValue("$noteId", noteId);
        command.ExecuteNonQuery();

        _dbConnection.Close();
    }

    public void UpdateNote(Note note)
    {
        using var _dbConnection = (SqliteConnection)_factory.CreateConnection();
        _dbConnection.Open();
        var command = _dbConnection.CreateCommand();
        command.CommandText = @"
                UPDATE Notes SET Note = $note, NoteDate = $noteDate, NoteAuthor = $noteAuthor 
                WHERE ReferralId = $referralId AND Id = $noteId";
        command.Parameters.AddWithValue("$note", note.NoteText);
        command.Parameters.AddWithValue("$noteDate", note.NoteDate);
        command.Parameters.AddWithValue("$noteAuthor", note.NoteAuthor);
        command.Parameters.AddWithValue("$referralId", note.ReferralId);
        command.Parameters.AddWithValue("$noteId", note.Id);
        command.ExecuteNonQuery();
        
        _dbConnection.Close();
    }

}
