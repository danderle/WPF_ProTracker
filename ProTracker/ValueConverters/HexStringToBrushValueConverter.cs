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
    /// Converts a hex string to a color brush
    /// </summary>
    public class HexStringToBrush : BaseValueConverter<HexStringToBrush>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var hexString = (string)value;
            var bytes = new List<byte>();
            for(int i = 0; i < hexString.Length; i += 2)
            {
                var bite = System.Convert.ToByte(hexString.Substring(i, 2), 16);
                bytes.Add(bite);
            }
            return bytes.Count == 3 ? new SolidColorBrush(Color.FromRgb(bytes[0], bytes[1], bytes[2])) : new SolidColorBrush(Color.FromRgb(255,255,255));
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
