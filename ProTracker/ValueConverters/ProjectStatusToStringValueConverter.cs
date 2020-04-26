using ProTracker.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace ProTracker
{
    /// <summary>
    /// Converts a <see cref="ProjectStatus"/> to a string
    /// </summary>
    public class ProjectStatusToString : BaseValueConverter<ProjectStatusToString>
    {
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            string retValue = string.Empty;
            switch((ProjectStatus)value)
            {
                case ProjectStatus.InProgress:
                    retValue = "In Progress";
                    break;
                default:
                    retValue = value.ToString();
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
