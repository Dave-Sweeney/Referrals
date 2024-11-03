using Referrals.DataProcessing.Models;
using System.Data.SqlClient;

namespace Referrals.DataProcessing.Extensions;

public static class ReferralDtoExtensions
{
    public static Referral Map(this ReferralDto dto)
    {
        var parentName = dto.Parent?.Split(',');
        var parentFirstName = parentName?[1].Trim() ?? string.Empty;
        var parentLastName = parentName?[0].Trim() ?? string.Empty;

        var phone = dto.Phone.Replace("-", "") ?? string.Empty;

        var children = new List<Child>();

        var commentsString = CommentsStringToList(dto.Comments);

        var notesString = dto.ContactStatusNotes;
        var notes = NotesStringToList(notesString);
        if (dto.Child != ",")
        {
            var childName = dto.Child.Split(',');
            var childFirstName = childName[1].Trim();
            var childLastName = childName[0].Trim();
            var childAge = dto.ChildAge ?? 0;

            children.Add(new Child
            {
                FirstName = childFirstName,
                LastName = childLastName,
                Age = childAge
            });
        }
        
        return new Referral
        {
            ReferralId = dto.ReferralId,
            ReferralDate = dto.ReferralDate?.ToString("yyyy-MM-dd"),
            Parent = new Parent
            {
                FirstName = parentFirstName,
                LastName = parentLastName,
                Email = dto.Email,
                Phone = dto.Phone,
                OkToText = false,
                ZipCode = dto.SearchZipCode,
                Comment = dto.Comments
            },
            Children = children,
            Comments = [],
            Status = new MagellanStatus
            {
                ContactStatus = dto.ContactStatus ?? "Open",
                Notes = notes,
                ClosedStatus = dto.ClosedStatus,
                ClosedDate = dto.ClosedDate,
                ClosedNotes = dto.ClosedNotes,
                ClosedReason = dto.ClosedReason
            }
        };
    }

    private static string CommentsStringToList(string? comments)
    {
        if (string.IsNullOrEmpty(comments))
        {
            return string.Empty;
        }

        var commentsList = comments.Split(';').ToList();
        return string.Join(Environment.NewLine, commentsList);
    }

    private static List<MagellanNote> NotesStringToList(string? notes)
    {
        var magellanNotes = new List<MagellanNote>();

        if (string.IsNullOrEmpty(notes))
        {
            return magellanNotes;
        }

        var notesStrings = notes.Split("\n");

        foreach(var noteString in notesStrings)
        {
            var fields = noteString.Split(": ");
            var note = fields[1].Trim() ?? string.Empty;
            var dateString = fields[0].Split("by")[0].Trim() ?? string.Empty;
            DateTime.TryParse(dateString, out var noteDate);
            var authorString = fields[0].Split("by")[1].Trim() ?? string.Empty;

            magellanNotes.Add(new MagellanNote
            {
                Note = note,
                NoteDate = noteDate,
                Author = authorString
            });
        }
        return magellanNotes;
    }
}
