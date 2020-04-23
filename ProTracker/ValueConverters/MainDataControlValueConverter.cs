using ProTracker.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace ProTracker
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public class MainDataControlValueConverter : BaseValueConverter<MainDataControlValueConverter>
    {
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            return new MainDataItemControl();
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
