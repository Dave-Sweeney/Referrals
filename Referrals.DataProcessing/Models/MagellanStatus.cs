namespace Referrals.DataProcessing.Models;

public class MagellanStatus
{
    public string ContactStatus { get; set; } = string.Empty;
    public IEnumerable<MagellanNote>? Notes { get; set; }
    public string? ClosedStatus { get; set; }
    public DateTime? ClosedDate { get; set; }
    public string? ClosedNotes { get; set; }
    public string? ClosedReason { get; set; }
}