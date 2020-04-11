using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Windows;

namespace ProTracker
{
    /// <summary>
    /// Converts the <see cref="Boolean"/> to an actual view/page
    /// </summary>
    public class BooleanToVibilityValueConverter : BaseValueConverter<BooleanToVibilityValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
