using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ProTracker.Core
{
    /// <summary>
    /// The view model for the <see cref="ProjectPage.xaml"/>
    /// </summary>
    public class ProjectViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// Holds all projects loaded from the database
        /// </summary>
        private List<Project> projectList;

        #endregion

        #region Public Properties

        /// <summary>
        /// The currently selected project
        /// </summary>
        public ProjectItemViewModel CurrentProject { get; set; }

        /// <summary>
        /// The previous selected project
        /// </summary>
        public ProjectItemViewModel PreviousProject { get; set; }

        /// <summary>
        /// The loaded projects
        /// </summary>
        public ObservableCollection<ProjectItemViewModel> LoadedProjects { get; set; }

        /// <summary>
        /// Loads the CurrentProject
        /// </summary>
        public bool Load { get; set; } = true;

        /// <summary>
        /// Unloads the previous project
        /// </summary>
        public bool Unload { get; set; } = false;

        /// <summary>
        /// True if in editing mode
        /// </summary>
        public bool Editing { get; set; } = false;

        /// <summary>
        /// True if in deleting mode
        /// </summary>
        public bool Deleting { get; set; } = false;

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

        /// <summary>
        /// Command when selecting a project
        /// </summary>
        public ICommand SelectProjectCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectViewModel()
        {
            //Create commands
            StartWorkCommand = new RelayCommand(StartWork);
            HideOpenSideMenuCommand = new RelayCommand(HideOpenSideMenu);
            SelectProjectCommand = new RelayCommand(SelectProject);
            AddProjectCommand = new RelayCommand(AddProject);
            EditCommand = new RelayCommand(Edit);
            DeleteCommand = new RelayCommand(Delete);
            LoadProjectsFromDatabase();
            SetGeneralDataList();
        }



        #endregion

        #region Command Methods

        /// <summary>
        /// Enables or Disables the deletion mode, if disableing then all the checked items are deleted from the list
        /// </summary>
        private void Delete()
        {
            //Disables deletion mode and delets the checked items from list
            if(Deleting)
            {
                Deleting ^= true;
                for(int index = LoadedProjects.Count-1; index >= 0; index--)
                {
                    //True if the project is to be deleted
                    if(LoadedProjects[index].GeneralData.Delete)
                    {
                        LoadedProjects.RemoveAt(index);
                    }
                    else
                    {
                        LoadedProjects[index].GeneralData.DeleteMode = Deleting;
                    }
                }
                //Enables the deletion mode
                foreach (var project in LoadedProjects)
                {
                    project.GeneralData.DeleteMode = Deleting;
                }
            }
            //Enables the deletion mode
            else
            {
                Deleting ^= true;
                foreach (var project in LoadedProjects)
                {
                    project.GeneralData.DeleteMode = Deleting;
                }
            }
        }

        /// <summary>
        /// Enables or disables the edit mode, if enabled the user can edit the Project name and description
        /// </summary>
        private void Edit()
        {
            //True when disabeling editing mode and closes editing mode for each project in list
            if(Editing)
            {
                Editing ^= true;
                foreach (var project in LoadedProjects)
                {
                    project.GeneralData.Editing = Editing;
                }
            }
            else
            {
                Editing ^= true;
                foreach(var project in LoadedProjects)
                {
                    project.GeneralData.Editing = Editing;
                }
            }
        }

        /// <summary>
        /// Switches to the create a project page
        /// </summary>
        private void AddProject()
        {
            Ioc.Get<ApplicationViewModel>().GoToPage(ApplicationPage.CreateProject);
        }

        /// <summary>
        /// Selects a project and loads the selected project main data and unloads the previous
        /// </summary>
        private void SelectProject()
        {
            if(!CurrentProject.GeneralData.Editing)
            {
                foreach (var project in LoadedProjects)
                {
                    if (project.GeneralData.Selected)
                    {
                        Load ^= true;
                        Unload ^= true;
                        PreviousProject = CurrentProject;
                        CurrentProject = project;
                        Load ^= true;
                        Unload ^= true;
                    }
                }
            }

        }

        /// <summary>
        /// Collapses or shows the side menu
        /// </summary>
        private void HideOpenSideMenu()
        {
            SideMenuControlIsVisible ^= true;
        }


        private void StartWork()
        {
            throw new NotImplementedException();
        }

        
        #endregion

        /// <summary>
        /// Loads each project from the database list into the <see cref="ProjectItemViewModel"/> list
        /// </summary>
        private void SetGeneralDataList()
        {
            var loadedProjects = new ObservableCollection<ProjectItemViewModel>();
            foreach (var project in projectList)
            {
                var item = new ProjectItemViewModel(project, SelectProjectCommand);
                loadedProjects.Add(item);
            }
            LoadedProjects = loadedProjects;

            //Selects the first item on default
            CurrentProject = LoadedProjects[0];
            LoadedProjects[0].GeneralData.Selected = true;
        }

        /// <summary>
        /// Loads / deserializes the database into a list of <see cref="Project"/> objects 
        /// </summary>
        private void LoadProjectsFromDatabase()
        {
            projectList = XmlDatabase.GetProjectList();
        }


    }
}
