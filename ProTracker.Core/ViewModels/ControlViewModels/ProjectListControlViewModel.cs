using System.Collections.Generic;

namespace ProTracker.Core
{
    /// <summary>
    /// A view model for each the project list creating the overview
    /// </summary>
    public class ProjectListControlViewModel : BaseViewModel
    {
        /// <summary>
        /// The project list items for the project list
        /// </summary>
        public List<ProjectItemControlViewModel> Items { get; set; }
    }
}
