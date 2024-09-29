namespace Referrals.Library.Models;

public class Referral
{
    public int Id { get; set; }
    public string ReferralNumber { get; set; } = string.Empty;
    public DateTime ReferralDate { get; set; } = DateTime.Now;
    public string ParentName { get; set; } = string.Empty;
    public string ParentEmail { get; set; } = string.Empty;
    public string ParentPhone { get; set; } = string.Empty;
    public bool OkToText { get; set; }
    public string ChildName { get; set; } = string.Empty;
    public int ChildAge { get; set; }
    public string? Comments { get; set; }
    public List<Note>? Notes { get; set; } = [];

}
