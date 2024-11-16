namespace Referrals.Ui.Winforms;

public class ReferralViewModel
{
    public int? DaysOpen => (DateTime.Now - ReferralDate).Days;
    public int Id { get; set; }
    public string ReferralNumber { get; set; } = string.Empty;
    public DateTime ReferralDate { get; set; } = DateTime.Now;
    public string ParentName { get; set; } = string.Empty;
    public string ParentEmail { get; set; } = string.Empty;
    public string ParentPhone { get; set; } = string.Empty;
    public string FormattedParentPhone => FormatPhoneNumber(ParentPhone);
    public bool OkToText { get; set; }
    public string ChildName { get; set; } = string.Empty;
    public int ChildAge { get; set; }
    public string? Comments { get; set; }
    private string FormatPhoneNumber(string phoneNumber)
    {
        var trimPhoneNumber = phoneNumber.Trim();
        if (trimPhoneNumber.Length == 10)
        {
            return string.Format("({0}) {1}-{2}",
                trimPhoneNumber.Substring(0, 3),
                trimPhoneNumber.Substring(3, 3),
                trimPhoneNumber.Substring(6, 4));
        }
        return phoneNumber; // Return as is if not 10 digits
    }
}

