using System.Windows;

namespace Referrals.Ui.Wpf;

class AppTheme
{
    public static void ChangeTheme(string themePath)
    {
        ResourceDictionary Theme = new ResourceDictionary
        {
            Source = new Uri(themePath, UriKind.Relative)
        };

        App.Current.Resources.Clear();
        App.Current.Resources.MergedDictionaries.Add(Theme);
    }
}
