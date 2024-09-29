using Referrals.Library.Models;

namespace Referrals.Library.Repositories;

public interface IReferralsRepository
{
    void AddReferral(Referral referral);
    Referral? GetReferral(int id);
    IEnumerable<Referral> GetAllReferrals();
    void UpdateReferral(Referral referral);
    void DeleteReferral(int id);
}
