namespace Referrals.DataProcessing.Models;

public class ReferralDto
{
    public string? Area { get; set; }
    public string? Region { get; set; }
    public string? SubRegion { get; set; } 
    public string? Unit { get; set; } 
    public string? ReferralId { get; set; } 
    public string? SearchZipCode { get; set; } 
    public string? Child { get; set; } 
    public int? ChildAge { get; set; }
    public string? Parent { get; set; } 
    public string? Phone { get; set; } 
    public string? Email { get; set; } 
    public string? Address { get; set; }
    public string? Address2 { get; set; }
    public string? City { get; set; } 
    public string? State { get; set; }
    public string? Comments { get; set; }
    public string? Cadet { get; set; }
    public string? Volunteer { get; set; }
    public DateTime? ReferralDate { get; set; }
    public string? ContactStatus { get; set; }
    public DateTime? ContactStatusDate { get; set; }
    public string? ContactStatusNotes { get; set; }
    public string? ClosedStatus { get; set; }
    public DateTime? ClosedDate { get; set; }
    public string? ClosedNotes { get; set; }
    public string? ClosedReason { get; set; }


}
