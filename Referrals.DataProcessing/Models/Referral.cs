namespace Referrals.DataProcessing.Models;

public class Referral
{
    public string ReferralId { get; set; } = string.Empty;
    public string ReferralDate { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
    public Parent Parent { get; set; } = new Parent();
    public IEnumerable<Child>? Children { get; set; }
    public IEnumerable<Comment>? Comments { get; set; }
    public MagellanStatus Status { get; set; } = new MagellanStatus();
}