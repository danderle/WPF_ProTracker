using System;
using System.Timers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProTracker.Core
{
    /// <summary>
    /// The view model for the <see cref="ProjectPage.xaml"/>
    /// </summary>
    public class ProjectViewModel : BaseViewModel
    {
        #region Constants

        private const uint USER_INACTIVITY_TIME = 120000; //120000ms -> 2 minutes
        private const int CHECK_ACTIVITY = 5000; //the time period to check user activity every 5seconds

        #endregion

        #region Private Members

        /// <summary>
        /// true when working
        /// </summary>
        private bool working { get; set; } = false;

        /// <summary>
        /// Checks for inactivity
        /// </summary>
        private Timer activityTimer { get; set; } = new Timer(CHECK_ACTIVITY);

        /// <summary>
        /// Holds all projects loaded from the database
        /// </summary>
        private List<Project> projectList;

        #endregion

        #region Public Properties

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
        /// On value update brings the window to the front
        /// </summary>
        public bool BringWindowToFront { get; set; }

        /// <summary>
        /// Project timer when working
        /// </summary>
        public string ProjectTimer { get; set; } = "00:00:00";

        /// <summary>
        /// The button content for starting or stopping the work timer
        /// </summary>
        public string WorkButtonState { get; set; } = "Start";

        /// <summary>
        /// Starts a stopwatch and signals the elapsed event every second to update UI time
        /// </summary>
        public TimerUpdater TimeUpdate { get; set; } = new TimerUpdater();

        /// <summary>
        /// The updates the idle time when user has been inactive
        /// </summary>
        public IdleTimeViewModel IdleTimer { get; set; } = new IdleTimeViewModel();

        /// <summary>
        /// The time the user can manualy input
        /// </summary>
        public TimeInputViewModel TimeInput { get; set; } = new TimeInputViewModel();

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

        /// <summary>
        /// Command to cancel the time
        /// </summary>
        public ICommand CancelTimeCommand { get; set; }

        /// <summary>
        /// Command to edit the time manualy
        /// </summary>
        public ICommand UserTimeEditCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectViewModel()
        {
            //Create commands
            InitializeCommands();

            LoadProjectsFromDatabase();

            RegisterEvents();
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Command method to enter time manually
        /// </summary>
        private void UserTimeEdit()
        {
            CancelTime();
            TimeInput.ShowTimeInput = true;
        }

        /// <summary>
        /// Command method to discard time
        /// </summary>
        private void CancelTime()
        {
            ShowSaveButton = false;
            ResetTimerAndWorkButton();
        }

        /// <summary>
        /// Saves the stopped time to the project
        /// </summary>
        private void SaveTime()
        {
            ShowSaveButton = false;
            var duration = TimeUpdate.Elapsed();
            AddTimeToCurrentProject(duration);
            ResetTimerAndWorkButton();
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
                TimeUpdate.Stop();
                ShowSaveButton = true;
                activityTimer.Stop();
            }
            else
            {
                //if a project is selected work timer is started
                if(CurrentProject != null)
                {
                    WorkButtonState = "Stop";
                    working ^= true;
                    TimeUpdate.Start();
                    activityTimer.Start();
                    ShowSaveButton = false;
                }
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// The Timer interval elapsed event, updates the project timer stopwatch style
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_Elapsed(object sender, EventArgs e)
        {
            var duration = TimeUpdate.Elapsed();
            ProjectTimer = duration.ToString("hh\\:mm\\:ss");
        }

        /// <summary>
        /// The event when a user inputs a time manualy
        /// </summary>
        /// <param name="userTimeEntered">Time to save</param>
        private void TimeInput_TimeEntered(TimeSpan userTimeEntered)
        {
            AddTimeToCurrentProject(userTimeEntered);
        }

        /// <summary>
        /// Triggers every second to check if the user has been inactive
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActivityTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var idleTime = IdleTimeFinder.GetIdleTime();
            if (idleTime > USER_INACTIVITY_TIME)
            {
                var duration = TimeUpdate.Subtract(new TimeSpan(0, 0, 0, 0, (int)USER_INACTIVITY_TIME));
                AddTimeToCurrentProject(duration);
                ResetTimerAndWorkButton();
                activityTimer.Stop();
                IdleTimer.Start();
                BringWindowToFront = !BringWindowToFront;
                //Ioc.Get<ApplicationViewModel>().WindowToTheFront?.Invoke();
            }
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Create commands
        /// </summary>
        private void InitializeCommands()
        {
            StartWorkCommand = new RelayCommand(StartWork);
            HideOpenSideMenuCommand = new RelayCommand(HideOpenSideMenu);
            SelectProjectCommand = new RelayCommand(SelectProject);
            AddProjectCommand = new RelayCommand(AddProject);
            EditCommand = new RelayCommand(Edit);
            DeleteCommand = new RelayCommand(Delete);
            SaveTimeCommand = new RelayCommand(SaveTime);
            CancelTimeCommand = new RelayCommand(CancelTime);
            UserTimeEditCommand = new RelayCommand(UserTimeEdit);
        }

        /// <summary>
        /// Registers all the events
        /// </summary>
        private void RegisterEvents()
        {
            activityTimer.Elapsed += ActivityTimer_Elapsed;
            TimeUpdate.Update += Update_Elapsed;
            TimeInput.TimeEntered += TimeInput_TimeEntered;
            IdleTimer.SaveIdleTimeToProject += AddTimeToCurrentProject;
        }

        /// <summary>
        /// Resets the stopwatch and timer display
        /// </summary>
        private void ResetTimerAndWorkButton()
        {
            TimeUpdate.Reset();
            ProjectTimer = "00:00:00";
            WorkButtonState = "Start";
            working = false;
        }

        /// <summary>
        /// Adds a <see cref="TimeSpan"/> time to the currently selected project
        /// </summary>
        /// <param name="duration">The time to be added to the project</param>
        private void AddTimeToCurrentProject(TimeSpan duration)
        {
            CurrentProject.MainData.RestMinutes += duration.Minutes;
            if (CurrentProject.MainData.RestMinutes >= 60)
            {
                CurrentProject.MainData.RestMinutes -= 60;
                CurrentProject.MainData.TotalHours++;
            }
            CurrentProject.MainData.TotalHours += duration.Hours;
            if (CurrentProject.MainData.LastEdit.Date != DateTimeOffset.Now.Date)
            {
                CurrentProject.MainData.TotalDays++;
            }
            CurrentProject.MainData.LastEdit = DateTimeOffset.Now;
            CurrentProject.PrepareToSerialize();
            SaveProjectsToBeSerialized();
            XmlDatabase.Serialize(projectList);
            LoadProjectsFromDatabase();
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
            SortProjectList();
            SetProjectListItemViewModel(projectList);
        }

        private void SortProjectList()
        {
            //Sorts from most recently worked on to last worked on
            projectList.Sort((Project a, Project b) => -a.MainData.LastEdit.CompareTo(b.MainData.LastEdit));
            var a = DateTimeOffset.UtcNow.UtcTicks;
            var b = DateTimeOffset.UtcNow.UtcTicks;
            var r = a.CompareTo(b);
        }

        #endregion

    }
}
