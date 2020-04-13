using System.Windows.Input;

namespace ProTracker.Core
{
    /// <summary>
    /// The view model for the <see cref="ProjectSetupPage.xaml"/>
    /// </summary>
    public class ProjectSetupPageViewModel : BaseViewModel
    {
        #region Private Members



        #endregion

        #region Public Properties



        #endregion

        #region Commands

        /// <summary>
        /// Command to create a new project
        /// </summary>
        public ICommand NewProjectCommand { get; set; }

        /// <summary>
        /// Command to continue a previous project
        /// </summary>
        public ICommand ContinueProjectCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectSetupPageViewModel()
        {
            //Create commands

        }


        #endregion
    }
}
