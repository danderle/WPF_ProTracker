using ProTracker.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProTracker
{
    /// <summary>
    /// Locates view models from the Ioc container for binding in the xaml files
    /// </summary>
    public class ViewModelLocator
    {
        #region Public Propeties
        
        /// <summary>
        /// Singleton instance of the locator
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        /// <summary>
        /// The application view model
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => Ioc.Get<ApplicationViewModel>();

        #endregion
    }
}
