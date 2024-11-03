using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Referrals.DataProcessing.Models;

namespace Referrals.DataProcessing.Repositories;

public interface IReferralsRepository
{
    Task AddReferralAsync(Referral referral);
}
