using System;

namespace ProTracker.Core
{
    /// <summary>
    /// General Project Data
    /// </summary>
    public class General
    {
        #region Public Properties

        /// <summary>
        /// Project name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the project
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The status of the project
        /// </summary>
        public ProjectStatus Status { get; set; }

        /// <summary>
        /// The icon font
        /// </summary>
        public string IconFont { get; set; } = "f113";

        /// <summary>
        /// The rgb colors for the background of the icon
        /// </summary>
        public string IconRgbBackground { get; set; } = "#000099"; 

        #endregion
    }

    /// <summary>
    /// Project data to track
    /// </summary>
    public class Data
    {
        #region Public Properties

        /// <summary>
        /// The day in ticks the project was created
        /// </summary>
        public long StartDate { get; set; } = DateTimeOffset.UtcNow.UtcTicks;

        /// <summary>
        /// The last time project was worked on
        /// </summary>
        public long LastEdit { get; set; } = DateTimeOffset.UtcNow.UtcTicks;

        /// <summary>
        /// Total amount of days the project was worked on
        /// </summary>
        public int TotalDays { get; set; } = 1;

        /// <summary>
        /// Total hours the project was worked on
        /// </summary>
        public int TotalHours { get; set; }

        /// <summary>
        /// The rest minutes when project is saved
        /// </summary>
        public int RestMinutes { get; set; } 

        #endregion
    }

    /// <summary>
    /// Represents a project for the database
    /// </summary>
    public class Project
    {
        #region Public Properties

        /// <summary>
        /// General Project Data
        /// </summary>
        public General GeneralData { get; set; } = new General();

        /// <summary>
        ///  Project data to track
        /// </summary>
        public Data MainData { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Project()
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the general dat from the view model to this objects
        /// </summary>
        /// <param name="generalData"></param>
        public void SetGeneralData(GeneralDataItemViewModel generalData)
        {
            GeneralData.Name = generalData.Name;
            GeneralData.Description = generalData.Description;
            GeneralData.Status = GeneralData.Status;
        }

        /// <summary>
        /// Sets the main data from the view model top this object
        /// </summary>
        /// <param name="mainData"></param>
        public void SetMainData(MainDataItemViewModel mainData)
        {
            MainData.LastEdit = mainData.LastEdit.UtcTicks;
            MainData.TotalDays = mainData.TotalDays;
            MainData.TotalHours = mainData.TotalHours;
            MainData.RestMinutes = mainData.RestMinutes;
        }

        #endregion
    }
}
