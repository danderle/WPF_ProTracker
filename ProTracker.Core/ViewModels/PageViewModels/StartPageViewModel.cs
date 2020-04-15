using System.Windows.Input;

namespace ProTracker.Core
{
    /// <summary>
    /// The view model for the <see cref="StartPage.xaml"/>
    /// </summary>
    public class StartPageViewModel : BaseViewModel
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
        /// Command to go to the projects
        /// </summary>
        public ICommand GoToProjectsCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public StartPageViewModel()
        {
            //Create commands
            GoToProjectsCommand = new RelayCommand(GoToProjects);
            NewProjectCommand = new RelayCommand(NewProject);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Opens the projects page
        /// </summary>
        private void GoToProjects()
        {
            Ioc.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Project);
        }

        /// <summary>
        /// Opens the new project page
        /// </summary>
        private void NewProject()
        {
            Ioc.Get<ApplicationViewModel>().GoToPage(ApplicationPage.CreateProject);
        }




        #endregion
    }
}
