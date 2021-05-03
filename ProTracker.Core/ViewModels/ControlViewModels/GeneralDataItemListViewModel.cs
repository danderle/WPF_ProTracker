using System.Collections.Generic;

namespace ProTracker.Core
{
    /// <summary>
    /// A view model for the entire project list
    /// </summary>
    public class GeneralDataItemListViewModel : BaseViewModel
    {
        /// <summary>
        /// The entire project list
        /// </summary>
        public List<ProjectItemViewModel> LoadedProjects { get; set; } = new List<ProjectItemViewModel>();
    }
}
