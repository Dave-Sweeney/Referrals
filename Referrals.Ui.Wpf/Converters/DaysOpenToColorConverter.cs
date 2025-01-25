using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Referrals.Ui.Wpf.Converters;

public class DaysOpenToColorConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
      
      if (value is int daysOpen)
      {
        if (daysOpen >= 0 && daysOpen <= 14)
        {
          return GetForegroundBrushFromTheme("ForegroundBrush") ?? Brushes.Black;
        }
        else if (daysOpen >= 15 && daysOpen <= 29)
        {
          return Brushes.Orange;
        }
        else if (daysOpen >30 && daysOpen <= 59)
        {
          return Brushes.Yellow;
        }
        else if (daysOpen >= 60)
        {
          return Brushes.Red;
        }
      }
      return Brushes.Black;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }

  private Brush? GetForegroundBrushFromTheme(string resourceKey)
  {
    foreach (var dictionary in Application.Current.Resources.MergedDictionaries)
    {
      if (dictionary.Contains(resourceKey))
      {
        return dictionary[resourceKey] as Brush;
      }
    }
    return null;
  }
}
