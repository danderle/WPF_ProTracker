using ProTracker.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace ProTracker
{
    /// <summary>
    /// Converts a <see cref="ProjectStatus"/> to a font awesome font
    /// </summary>
    public class ProjectStatusToFontAwesome : BaseValueConverter<ProjectStatusToFontAwesome>
    {
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            string retValue = string.Empty;
            switch((ProjectStatus)value)
            {
                case ProjectStatus.InProgress:
                    retValue = "\uf04b";
                    break;
                case ProjectStatus.Finished:
                    retValue = "\uf04d";
                    break;
                case ProjectStatus.Delayed:
                    retValue = "\uf04c";
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
