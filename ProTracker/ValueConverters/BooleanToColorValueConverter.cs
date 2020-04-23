using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace ProTracker
{
    /// <summary>
    /// Converts the <see cref="Boolean"/> to an actual view/page
    /// </summary>
    public class BooleanToColorValueConverter : BaseValueConverter<BooleanToColorValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? new SolidColorBrush(Color.FromRgb(0xff,0x80,0)): new SolidColorBrush(Color.FromRgb(255,255,255));
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
