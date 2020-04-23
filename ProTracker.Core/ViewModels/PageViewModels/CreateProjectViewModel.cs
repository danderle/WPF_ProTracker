using System;
using System.Windows.Input;
using System.Xml.Linq;

namespace ProTracker.Core
{
    /// <summary>
    /// The view model for the <see cref="CreateProjectPage.xaml"/>
    /// </summary>
    public class CreateProjectViewModel : BaseViewModel
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
        /// A flag letting us know if the project name already exists
        /// </summary>
        public bool ProjectExists { get; set; }

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
        public CreateProjectViewModel()
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
            //Create a new project
            var project = new Project
            {
                GeneralData = new General
                {
                    Name = this.Name,
                    Description = this.Description,
                },
                MainData = new Data()
            };

            //Gets all the projects out of the database
            var projects = XmlDatabase.GetProjectList();

            //Checks if the given name already exists
            ProjectExists = XmlDatabase.ProjectExists(projects, Name);
            
            if(!ProjectExists)
            {
                // Adds the new project to the rest and writes to xml file
                projects.Add(project);
                XmlDatabase.Serialize(projects);

                // Switch to the Project page
                Ioc.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Project);
            }
        }

        #endregion

        #region Private Helpers

        
        #endregion
    }
}
