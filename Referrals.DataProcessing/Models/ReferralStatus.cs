namespace Referrals.DataProcessing.Models;

public class ReferralStatus
{
    public string ContactStatus { get; set; } = string.Empty;
    public DateOnly ContactStatusDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public string ContactStatusNotes { get; set; } = string.Empty;
    public ClosedStatus Status { get; set; }
    public DateOnly? ClosedDate { get; set; }
    public string? ClosedNotes { get; set; }
    public string? ClosedReason { get; set; }
}

public enum ClosedStatus
{
    Open,
    Closed
}
