using Referrals.Ui.Wpf.Models;
using Referrals.Ui.Wpf.Repositories;
using Referrals.Ui.Wpf.Themes;
using Referrals.Ui.Wpf.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Referrals.Ui.Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(IReferralsRepository referralsRepository)
    {
        InitializeComponent();

        // Instantiate the ViewModel
        var viewModel = ReferralsViewModel.Initialize(referralsRepository);

        // Set the DataContext
        this.DataContext = viewModel;

        // Set the initial theme
        ApplyTheme("Themes/Dark.xaml");
        ApplyStyle("Themes/Styles.xaml");
    }

    private static void ApplyTheme(string themePath)
    {
        AppTheme.ChangeTheme(themePath);
    }

    private static void ApplyStyle(string stylePath) 
    {
        AppStyles.ApplyStyles(stylePath);
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
        if (sender is Border border && border.DataContext is ReferralViewModel referral)
        {
            var referralDetailWindow = new CardDetailsWindow(referral)
            {
                Owner = this
            };
            referralDetailWindow.ShowDialog();
        }
    }
}