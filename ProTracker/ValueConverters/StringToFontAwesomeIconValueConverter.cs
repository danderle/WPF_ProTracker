using Ninject;
using ProTracker.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;

namespace ProTracker
{
    /// <summary>
    /// Converts a string to font Awesome icon
    /// </summary>
    public class StringToFontAwesomeIcon : BaseValueConverter<StringToFontAwesomeIcon>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var orig = (string)value;
            var retVal = "Error";
            if(orig.Length % 2 == 0)
            {
                var bytes = new List<byte>();
                for (int i = 0; i < orig.Length; i += 2)
                {
                    byte bite = System.Convert.ToByte(orig.Substring(i, 2), 16);
                    bytes.Add(bite);
                }
                bytes.Reverse();
                retVal = Encoding.Unicode.GetString(bytes.ToArray());
            }
            return retVal;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
