using System;
using System.Timers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Diagnostics;

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

        /// <summary>
        /// true when working
        /// </summary>
        private bool working { get; set; } = false;

        /// <summary>
        /// Updates the stopwatch to the UI after each second
        /// </summary>
        public Timer stopwatchUpdate { get; set; } = new Timer(1000);

        /// <summary>
        /// Keeps track of the time when working
        /// </summary>
        public Stopwatch stopwatch { get; set; } = new Stopwatch();

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
        /// Project timer when working
        /// </summary>
        public string ProjectTimer { get; set; } = "00:00:00";

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

        /// <summary>
        /// True to show the save button
        /// </summary>
        public bool ShowSaveButton { get; set; } = false;

        /// <summary>
        /// The button content for starting or stopping the work timer
        /// </summary>
        public string WorkButtonState { get; set; } = "Start";

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

        /// <summary>
        /// Command to save the timed time to the project
        /// </summary>
        public ICommand SaveTimeCommand { get; set; }

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
            SaveTimeCommand = new RelayCommand(SaveTime);

            LoadProjectsFromDatabase();

            stopwatchUpdate.Elapsed += StopwatchUpdate_Elapsed;
        }


        #endregion

        #region Command Methods

        /// <summary>
        /// Saves the stopped time to the project
        /// </summary>
        private void SaveTime()
        {
            ShowSaveButton = false;
            var duration = stopwatch.Elapsed;
            CurrentProject.MainData.RestMinutes += duration.Minutes;
            if(CurrentProject.MainData.RestMinutes >= 60)
            {
                CurrentProject.MainData.RestMinutes -= 60;
                CurrentProject.MainData.TotalHours++;
            }
            CurrentProject.MainData.TotalHours += duration.Hours;
            if(CurrentProject.MainData.LastEdit.Date != DateTimeOffset.Now.Date)
            {
                CurrentProject.MainData.LastEdit = DateTimeOffset.Now;
                CurrentProject.MainData.TotalDays++;
            }
            CurrentProject.PrepareToSerialize();
            SaveProjectsToBeSerialized();
            XmlDatabase.Serialize(projectList);
            stopwatch.Reset();
            ProjectTimer = "00:00:00";
            WorkButtonState = "Start";
        }

        /// <summary>
        /// Gets the Xml project objects from the view models to be serialized
        /// </summary>
        private void SaveProjectsToBeSerialized()
        {
            projectList.Clear();
            foreach(var vmProject in LoadedProjects)
            {
                projectList.Add(vmProject.XmlProject);
            }
        }

        /// <summary>
        /// Enables or Disables the deletion mode, if disableing then all the checked items are deleted from the list
        /// </summary>
        private void Delete()
        {
            //Cannot be in editing mode and delete mode
            if(Editing)
            {
                return;
            }

            //Disables deletion mode and delets the checked items from list
            if(Deleting)
            {
                Deleting ^= true;
                for(int index = LoadedProjects.Count-1; index >= 0; index--)
                {
                    //True if the project is to be deleted
                    if(LoadedProjects[index].GeneralData.Delete)
                    {
                        //If the current project is deleted, set the first item in the list as the current
                        if(CurrentProject.GeneralData.Name == LoadedProjects[index].GeneralData.Name)
                        {
                            LoadedProjects[0].GeneralData.Selected = true;
                            SelectProject();
                        }
                        LoadedProjects.RemoveAt(index);
                    }
                    else
                    {
                        LoadedProjects[index].GeneralData.DeleteMode = Deleting;
                    }
                }
                //Disables the deletion mode
                foreach (var project in LoadedProjects)
                {
                    project.GeneralData.DeleteMode = Deleting;
                }
                SaveProjectsToBeSerialized();
                XmlDatabase.Serialize(projectList);
                if(LoadedProjects.Count == 0)
                {
                    CurrentProject = null;
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
            //Cannot be in delete and edit mode at same time
            if(Deleting)
            {
                return;
            }

            //True when disabeling editing mode and closes editing mode for each project in list
            if(Editing)
            {
                Editing ^= true;
                CurrentProject.GeneralData.Editing = Editing;
                CurrentProject.PrepareToSerialize();
                SaveProjectsToBeSerialized();
                XmlDatabase.Serialize(projectList);
            }
            else
            {
                Editing ^= true; 
                CurrentProject.GeneralData.Editing = Editing;
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
            //If the save button is shown save data before swithcing to another project
            if(ShowSaveButton)
            {
                SaveTime();
            }
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
            if(!working)
            {
                SideMenuControlIsVisible ^= true;
            }
        }

        /// <summary>
        /// Starts or resumes the work timer stopwatch
        /// </summary>
        private void StartWork()
        {
            //true if working and wanting to stop
            if(working)
            {
                WorkButtonState = "Resume";
                working ^= true;
                stopwatchUpdate.Stop();
                stopwatch.Stop();
                ShowSaveButton = true;
            }
            else
            {
                //if a project is selected work timer is started
                if(CurrentProject != null)
                {
                    WorkButtonState = "Stop";
                    working ^= true;
                    stopwatch.Start();
                    stopwatchUpdate.Start();
                    ShowSaveButton = false;
                }
            }
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// The Timer interval elapsed event, updates the project timer stopwatch style
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopwatchUpdate_Elapsed(object sender, ElapsedEventArgs e)
        {
            var duration = stopwatch.Elapsed;
            ProjectTimer = duration.ToString("hh\\:mm\\:ss");
        }

        /// <summary>
        /// Loads each project from the database list into the <see cref="ProjectItemViewModel"/> list
        /// </summary>
        private void SetProjectListItemViewModel(List<Project> projectList)
        {
            var loadedProjects = new ObservableCollection<ProjectItemViewModel>();
            foreach (var project in projectList)
            {
                var item = new ProjectItemViewModel(project, SelectProjectCommand);
                loadedProjects.Add(item);
            }
            LoadedProjects = loadedProjects;

            //Selects the first item on default
            if(LoadedProjects.Count > 0)
            {
                CurrentProject = LoadedProjects[0];
                LoadedProjects[0].GeneralData.Selected = true;
            }
        }

        /// <summary>
        /// Loads / deserializes the database into a list of <see cref="Project"/> objects 
        /// </summary>
        private void LoadProjectsFromDatabase()
        {
            projectList = XmlDatabase.GetProjectList();
            SetProjectListItemViewModel(projectList);
        }

        #endregion

    }
}
