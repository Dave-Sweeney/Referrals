using Referrals.Ui.Wpf.Repositories;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Referrals.Ui.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IReferralsRepository referralsRepository)
        {
            InitializeComponent();

            // Instantiate the ViewModel
            var viewModel = new ReferralsViewModel(referralsRepository);

            // Set the DataContext
            this.DataContext = viewModel;

            // Set the initial theme
            ApplyTheme("Themes/Dark.xaml");
        }

        private void ApplyTheme(string themePath)
        {
            AppTheme.ChangeTheme(themePath);
        }
        private void ScrollLeft_Click(object sender, RoutedEventArgs e)
        {
            CardPanelScroll(-400);
        }

        private void ScrollRight_Click(object sender, RoutedEventArgs e)
        {
            CardPanelScroll(400);
        }

        private void CardPanelScroll(double offset)
        {
            if (CardPanel.Parent is ScrollViewer scrollViewer)
            {
                double newOffset = scrollViewer.HorizontalOffset + offset;
                scrollViewer.ScrollToHorizontalOffset(newOffset);
            }
        }

        private void Card_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Border border)
            {
                var scaleTransform = new ScaleTransform(1.0, 1.0);
                border.RenderTransform = scaleTransform;
                border.RenderTransformOrigin = new Point(0.5, 0.5);

                var scaleAnimation = new DoubleAnimation(1.2, TimeSpan.FromMilliseconds(200));
                scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimation);
                scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimation);
            }
        }

        private void Card_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Border border)
            {
                if (border.RenderTransform is ScaleTransform scaleTransform)
                {
                    var scaleAnimation = new DoubleAnimation(1.0, TimeSpan.FromMilliseconds(200));
                    scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimation);
                    scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimation);
                }
            }
        }

        private void DarkTheme_Click(object sender, RoutedEventArgs e)
        {
            ApplyTheme("Themes/Dark.xaml");
        }

        private void LightTheme_Click(object sender, RoutedEventArgs e)
        {
            ApplyTheme("Themes/Light.xaml");
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                // Toggle window state on double-click
                this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            }
            else
            {
                // Allow dragging the window
                this.DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Card_MouseClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border && border.DataContext is Referral referral)
            {
                var referralDetailWindow = new CardDetailsWindow(referral);
                referralDetailWindow.Owner = this;
                referralDetailWindow.ShowDialog();
            }
        }
    }

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

    public class Referral
    {
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public string? AdditionalInfo { get; set; }
    }
}