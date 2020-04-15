using System;
using System.Windows.Input;
using System.Xml.Linq;

namespace ProTracker.Core
{
    /// <summary>
    /// The view model for the <see cref="CreateProjectPage.xaml"/>
    /// </summary>
    public class CreateProjectPageViewModel : BaseViewModel
    {
        #region Private Members

        #endregion

        #region Public Properties

        /// <summary>
        /// The name of the new project
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A short description about the new project
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A flag letting us know if the project saving failed
        /// </summary>
        public bool CreateFailed { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Command to create the new setup
        /// </summary>
        public ICommand CreateCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateProjectPageViewModel()
        {
            //Create commands
            CreateCommand = new RelayCommand(Create);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Creates the new project and saves the data in an xml file
        /// then loads the project page
        /// </summary>
        private void Create()
        {
            //Checks if the given name already exists
            CreateFailed = XmlDatabase.CreateProject(Name, Description);
            
            if(!CreateFailed)
            {
                Ioc.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Project);
            }
        }

        #endregion

        #region Private Helpers

        
        #endregion
    }
}
