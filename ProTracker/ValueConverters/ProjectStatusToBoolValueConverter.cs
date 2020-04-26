using ProTracker.Core;
using System;
using System.Globalization;

namespace ProTracker
{
    /// <summary>
    /// Converts the <see cref="ProjectStatus"/> to a bool and back
    /// </summary>
    public class ProjectStatusToBool : BaseValueConverter<ProjectStatusToBool>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var checkboxStatus = (ProjectStatus)Enum.Parse(value.GetType(), (string)parameter);
            return (ProjectStatus)value == checkboxStatus;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.Parse(targetType, (string)parameter);
        }
    }
}
