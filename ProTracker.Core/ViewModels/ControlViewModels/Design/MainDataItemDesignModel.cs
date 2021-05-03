using System;
using System.Globalization;

namespace ProTracker.Core
{
    /// <summary>
    /// A view model used for the design time data for a <see cref="MainDataItemViewModel"/>
    /// </summary>
    public class MainDataItemDesignModel : MainDataItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static MainDataItemDesignModel Instance => new MainDataItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainDataItemDesignModel()
        {
            StartDate = DateTimeOffset.UtcNow;
            LastEdit = DateTimeOffset.UtcNow;
            Status = ProjectStatus.Delayed;
            TotalDays = 10;
            TotalHours = 4;
            RestMinutes = 40;
        }

        #endregion
    }
}
