using System.Collections.Generic;

namespace ProTracker.Core
{
    /// <summary>
    /// A view model for each the project list creating the overview
    /// </summary>
    public class GeneralDataItemListViewModel : BaseViewModel
    {
        /// <summary>
        /// The project list items for the project list
        /// </summary>
        public List<ProjectItemViewModel> LoadedProjects { get; set; } = new List<ProjectItemViewModel>();
    }
}
