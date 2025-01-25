using Referrals.Ui.Wpf.Models;
using Referrals.Ui.Wpf.ViewModels;

namespace Referrals.Ui.Wpf.Extensions;

public static class ReferralsExtensions
{
    public static ReferralViewModel Map(this Referral referral)
    {
        return new ReferralViewModel
        {
            ParentFirstName = referral.Name.Split(' ')[0],
            ParentLastName = referral.Name.Split(' ')[1],
            ReferralDate = referral.Date,
            Comment = referral.AdditionalInfo
        };
    }
}
