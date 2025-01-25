using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Referrals.Ui.Wpf.Themes;

class AppStyles
{
    public static void ApplyStyles(string stylePath)
    {
        ResourceDictionary Style = new()
        {
            Source = new Uri(stylePath, UriKind.Relative)
        };

        App.Current.Resources.Clear();
        App.Current.Resources.MergedDictionaries.Add(Style);
    }
}
