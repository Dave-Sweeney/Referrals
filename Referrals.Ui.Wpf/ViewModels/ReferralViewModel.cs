namespace Referrals.Ui.Wpf.ViewModels;

public class ReferralViewModel
{
    public int? DaysOpen => DateTime.Now.Subtract(ReferralDate).Days;
    public DateTime ReferralDate { get; set; } = DateTime.Now;
    public string? ParentFirstName { get; set; }
    public string? ParentLastName { get; set; }
    public string? Comment { get; set; }
}
