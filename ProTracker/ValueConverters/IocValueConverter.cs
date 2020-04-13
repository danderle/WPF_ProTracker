using Ninject;
using ProTracker.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace ProTracker
{
    /// <summary>
    /// Converts a string to a service pulled from the IoC container
    /// </summary>
    public class IocValueConverter : BaseValueConverter<IocValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the appropriate page
            switch ((string)value)
            {
                case nameof(ApplicationViewModel):
                    return Ioc.Get<ApplicationViewModel>();
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
