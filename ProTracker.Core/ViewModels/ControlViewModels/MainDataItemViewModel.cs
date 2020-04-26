using System;

namespace ProTracker.Core
{
    /// <summary>
    /// A view model for each the project list creating the overview
    /// </summary>
    public class MainDataItemViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The day the project was created
        /// </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// The last time project was worked on
        /// </summary>
        public DateTimeOffset LastEdit { get; set; }

        /// <summary>
        /// The status of the project
        /// </summary>
        public ProjectStatus Status { get; set; }

        /// <summary>
        /// Total amount of days the project was worked on
        /// </summary>
        public int TotalDays { get; set; }

        /// <summary>
        /// Total hours the project was worked on
        /// </summary>
        public int TotalHours { get; set; }

        /// <summary>
        /// The rest minutes when project is saved
        /// </summary>
        public int RestMinutes { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainDataItemViewModel()
        {
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="project"></param>
        public MainDataItemViewModel(Project project)
        {
            StartDate = new DateTimeOffset(project.MainData.StartDate, new TimeSpan(0));
            LastEdit = new DateTimeOffset(project.MainData.LastEdit, new TimeSpan(0));
            TotalDays = project.MainData.TotalDays;
            TotalHours = project.MainData.TotalHours;
            RestMinutes = project.MainData.RestMinutes;
        } 
        
        #endregion
    }
}
