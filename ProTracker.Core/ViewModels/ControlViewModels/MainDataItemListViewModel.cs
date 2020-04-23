using System.Collections.Generic;
using System.Globalization;

namespace ProTracker.Core
{
    /// <summary>
    /// A view model for each the project list creating the overview
    /// </summary>
    public class MainDataItemListViewModel : BaseViewModel
    {
        /// <summary>
        /// To format the <see cref="DateTimeOffset"/> use the "en-us" style format
        /// </summary>
        protected static string dateFormat = "dd/MM/yyyy";

        /// <summary>
        /// To format the <see cref="DateTimeOffset"/> use the "en-us" culture style
        /// </summary>
        protected static CultureInfo cultureInfo = new CultureInfo("en-us");

        /// <summary>
        /// The project list items for the project list
        /// </summary>
        public List<MainDataItemViewModel> Items { get; set; }
    }
}
