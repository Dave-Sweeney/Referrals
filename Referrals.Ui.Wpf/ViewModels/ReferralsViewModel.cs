using Referrals.Ui.Wpf.Models;
using Referrals.Ui.Wpf.Repositories;
using System.Collections.ObjectModel;

namespace Referrals.Ui.Wpf.ViewModels
{
    public class ReferralsViewModel
    {
        private readonly IReferralsRepository _referralsRepository;
        public ObservableCollection<Referral> Referrals { get; set; } = [];


        public ReferralsViewModel(IReferralsRepository referralsRepository)
        {
            _referralsRepository = referralsRepository;

            var referrals = _referralsRepository.GetReferralsAsync().Result;

            foreach (var referral in referrals)
            {
                Referrals.Add(referral);
            }

        }
    }
}