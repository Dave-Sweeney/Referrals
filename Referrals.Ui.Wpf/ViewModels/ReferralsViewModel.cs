using Referrals.Ui.Wpf.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Referrals.Ui.Wpf.ViewModels;

public class ReferralsViewModel
{
    public IEnumerable<ReferralViewModel> Referrals { get; set; } = [];

}
