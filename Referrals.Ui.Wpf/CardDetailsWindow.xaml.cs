using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Referrals.Ui.Wpf.Models;

namespace Referrals.Ui.Wpf
{
    /// <summary>
    /// Interaction logic for CardDetailsWindow.xaml
    /// </summary>
    public partial class CardDetailsWindow : Window
    {
        public CardDetailsWindow(Referral referral)
        {
            InitializeComponent();
            this.DataContext = referral;
        }
    }
}
