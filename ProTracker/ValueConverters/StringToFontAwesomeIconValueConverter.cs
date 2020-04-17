using Ninject;
using ProTracker.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace ProTracker
{
    /// <summary>
    /// Converts a string to font Awesome icon
    /// </summary>
    public class StringToFontAwesomeIcon : BaseValueConverter<StringToFontAwesomeIcon>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the appropriate page
            string icon = string.Format("{0}{1}{2}", "&#x", (string)value, ";");
            return icon;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
