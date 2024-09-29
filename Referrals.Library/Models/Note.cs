using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referrals.Library.Models;

public class Note
{
    public int Id { get; set; }
    public int ReferralId { get; set; }
    public string NoteText { get; set; } = string.Empty;
    public DateTime NoteDate { get; set; } = DateTime.Now;
    public string NoteAuthor { get; set; } = string.Empty;
}
