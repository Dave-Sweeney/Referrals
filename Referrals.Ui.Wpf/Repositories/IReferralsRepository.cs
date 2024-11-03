using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referrals.Ui.Wpf.Repositories;

public interface IReferralsRepository
{
    Task<IEnumerable<Referral>> GetReferralsAsync();
    Task<Referral> GetReferralAsync(int id);
    Task AddReferralAsync(Referral referral);
    Task UpdateReferralAsync(Referral referral);
    Task DeleteReferralAsync(int id);
}
