using Referrals.Ui.Wpf.Extensions;
using Referrals.Ui.Wpf.Models;
using Referrals.Ui.Wpf.Repositories;
using System.Collections.ObjectModel;

namespace Referrals.Ui.Wpf.ViewModels;

public class ReferralsViewModel
{
    private readonly IReferralsRepository _referralsRepository;
    public ObservableCollection<ReferralViewModel> Referrals { get; set; } = [];

    private ReferralsViewModel(IReferralsRepository referralsRepository)
    {
        _referralsRepository = referralsRepository;
    }

    public static ReferralsViewModel Initialize(IReferralsRepository referralsRepository)
    {
        return new ReferralsViewModel(referralsRepository);
    }

    public async Task LoadReferrals()
    {
        var referrals = await _referralsRepository.GetReferralsAsync();

        foreach (var referral in referrals)
        {
            Referrals.Add(referral.Map());
        }
    }
}