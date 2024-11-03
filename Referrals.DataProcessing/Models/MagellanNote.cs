namespace Referrals.DataProcessing.Models;

public class MagellanNote
{
    public DateTime NoteDate { get; set; } = DateTime.Now;
    public string Note { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
}