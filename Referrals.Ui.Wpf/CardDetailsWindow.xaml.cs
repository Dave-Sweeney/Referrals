using Referrals.Ui.Wpf.ViewModels;
using System.Windows;

namespace Referrals.Ui.Wpf
{
    /// <summary>
    /// Interaction logic for CardDetailsWindow.xaml
    /// </summary>
    public partial class CardDetailsWindow : Window
    {
        public CardDetailsWindow(ReferralViewModel referral)
        {
            InitializeComponent();
            this.DataContext = referral;
        }
    }
}
