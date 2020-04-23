using System.Windows.Input;

namespace ProTracker.Core
{
    /// <summary>
    /// A view model for each project item in overview project list
    /// </summary>
    public class ProjectItemViewModel : BaseViewModel
    {
        #region Public properties

        /// <summary>
        /// The general data view model
        /// </summary>
        public GeneralDataItemViewModel GeneralData { get; set; }

        /// <summary>
        /// The main data view model
        /// </summary>
        public MainDataItemViewModel MainData { get; set; } = new MainDataItemViewModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectItemViewModel()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        /// <param name="selectedCommand"></param>
        public ProjectItemViewModel(Project project, ICommand selectedCommand)
        {
            GeneralData = new GeneralDataItemViewModel(project, selectedCommand);
            MainData = new MainDataItemViewModel(project);
        }

        #endregion
    }
}
