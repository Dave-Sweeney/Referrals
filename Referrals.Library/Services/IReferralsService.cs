using Referrals.Library.Models;

namespace Referrals.Library.Services;

public interface IReferralsService
{
    void AddReferral(Referral referral);
    void DeleteReferral(int id);
    Referral? GetReferral(int id);
    IEnumerable<Referral> GetReferrals();
    void UpdateReferral(Referral referral);
}
