using ProTracker.Core;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Media;

namespace ProTracker
{
    /// <summary>
    /// Converts a <see cref="ProjectStatus"/> to a solid color brush
    /// </summary>
    public class ProjectStatusToRgb : BaseValueConverter<ProjectStatusToRgb>
    {
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            SolidColorBrush retValue = new SolidColorBrush();
            switch((ProjectStatus)value)
            {
                case ProjectStatus.InProgress:
                    retValue = new SolidColorBrush(Color.FromRgb(0x00, 0x66, 0x33));
                    break;
                case ProjectStatus.Finished:
                    retValue = new SolidColorBrush(Color.FromRgb(0x33, 0x00, 0x66));
                    break;
                case ProjectStatus.Delayed:
                    retValue = new SolidColorBrush(Color.FromRgb(0x66, 0x33, 0x00));
                    break;
            }
            return retValue;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
