using Referrals.Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referrals.Library.Repositories;

public interface INotesRepository
{
    void AddNote(Note note);
    Note? GetNote(int referralId, int noteId);
    IEnumerable<Note>? GetAllNotes(int referralId);

    void DeleteNote(int referralId, int noteId);
    void UpdateNote(Note note);
}
