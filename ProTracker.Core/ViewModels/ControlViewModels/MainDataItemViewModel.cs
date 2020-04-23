using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProTracker.Core
{
    /// <summary>
    /// A view model for each the project list creating the overview
    /// </summary>
    public class MainDataItemViewModel : BaseViewModel
    {
        /// <summary>
        /// To format the <see cref="DateTimeOffset"/> use the "en-us" style format
        /// </summary>
        protected static string dateFormat = "dd/MM/yyyy";

        /// <summary>
        /// To format the <see cref="DateTimeOffset"/> use the "en-us" culture style
        /// </summary>
        protected static CultureInfo cultureInfo = new CultureInfo("en-us");

        /// <summary>
        /// The day the project was created
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// The last time project was worked on
        /// </summary>
        public string LastEdit { get; set; }

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

        public MainDataItemViewModel()
        {

        }

        public MainDataItemViewModel(Project project)
        {
            StartDate = project.MainData.StartDate;
            LastEdit = project.MainData.LastEdit;
            TotalDays = project.MainData.TotalDays;
            TotalHours = project.MainData.TotalHours;
            RestMinutes = project.MainData.RestMinutes;
            Status = project.MainData.Status;
        }
    }
}
