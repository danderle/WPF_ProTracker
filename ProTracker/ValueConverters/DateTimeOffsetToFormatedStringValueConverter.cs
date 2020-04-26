using System;
using System.Globalization;

namespace ProTracker
{
    /// <summary>
    /// Converts a DateTimeOffset to a formatted string
    /// </summary>
    public class DateTimeOffsetToFormatedString : BaseValueConverter<DateTimeOffsetToFormatedString>
    {
        /// <summary>
        /// To format the <see cref="DateTimeOffset"/> use the "en-us" style format
        /// </summary>
        private static string dateFormat = "dd/MM/yyyy";

        /// <summary>
        /// To format the <see cref="DateTimeOffset"/> use the "en-us" culture style
        /// </summary>
        private static CultureInfo cultureInfo = new CultureInfo("en-us");

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTime = (DateTimeOffset)value;
            return dateTime.ToString(dateFormat, culture);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
