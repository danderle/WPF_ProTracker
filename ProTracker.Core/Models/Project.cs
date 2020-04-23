using System;
using System.Globalization;

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
        #region Private Fields

        /// <summary>
        /// To format the <see cref="DateTimeOffset"/> use the "en-us" style format
        /// </summary>
        private static string dateFormat = "dd/MM/yyyy";

        /// <summary>
        /// To format the <see cref="DateTimeOffset"/> use the "en-us" culture style
        /// </summary>
        private static CultureInfo cultureInfo = new CultureInfo("en-us");

        #endregion

        #region Public Properties

        /// <summary>
        /// The day the project was created
        /// </summary>
        public string StartDate { get; set; } = DateTimeOffset.UtcNow.ToString(dateFormat, cultureInfo);

        /// <summary>
        /// The last time project was worked on
        /// </summary>
        public string LastEdit { get; set; } = DateTimeOffset.UtcNow.ToString(dateFormat, cultureInfo);

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
    }
}
