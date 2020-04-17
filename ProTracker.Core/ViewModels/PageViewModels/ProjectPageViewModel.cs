using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ProTracker.Core
{
    /// <summary>
    /// The view model for the <see cref="ProjectPage.xaml"/>
    /// </summary>
    public class ProjectPageViewModel : BaseViewModel
    {
        #region Private Members



        #endregion

        #region Public Properties

        /// <summary>
        /// The project list for the side menu control
        /// </summary>
        public ProjectListControlViewModel ProjectList { get; set; } = new ProjectListControlViewModel();

        /// <summary>
        /// True if the side menu is visible
        /// </summary>
        public bool SideMenuControlIsVisible { get; set; } = true;

        #endregion

        #region Commands

        /// <summary>
        /// Command to start the working timer on currently selected project 
        /// </summary>
        public ICommand StartWorkCommand { get; set; }

        /// <summary>
        /// Command to toggle the side menu visibility
        /// </summary>
        public ICommand HideOpenSideMenuCommand { get; set; }

        /// <summary>
        /// Command to switch to the create a project page
        /// </summary>
        public ICommand AddProjectCommand { get; set; }

        /// <summary>
        /// Command to edit the Project name or description
        /// </summary>
        public ICommand EditCommand { get; set; }

        /// <summary>
        /// Command to delete a project
        /// </summary>
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// Command to go to the settings page
        /// </summary>
        public ICommand SettingsCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectPageViewModel()
        {
            //Create commands
            StartWorkCommand = new RelayCommand(StartWork);
            HideOpenSideMenuCommand = new RelayCommand(HideOpenSideMenu);

            ProjectList.Items = XmlDatabase.GetProjectList();
        }

        private void HideOpenSideMenu()
        {
            SideMenuControlIsVisible ^= true;
        }

        private void StartWork()
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
