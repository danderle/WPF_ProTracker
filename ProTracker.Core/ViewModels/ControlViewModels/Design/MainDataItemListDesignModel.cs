using System;
using System.Collections.Generic;

namespace ProTracker.Core
{
    /// <summary>
    /// A view model used for the design time data for a <see cref="MainDataItemListViewModel"/>
    /// </summary>
    public class MainDataItemListDesignModel : MainDataItemListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static MainDataItemListDesignModel Instance => new MainDataItemListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainDataItemListDesignModel()
        {
            Items = new List<MainDataItemViewModel>
            {
                new MainDataItemViewModel
                {
                    StartDate = DateTimeOffset.UtcNow,
                    LastEdit = DateTimeOffset.UtcNow,
                    Status = ProjectStatus.Delayed,
                    TotalDays = 10,
                    TotalHours = 4,
                    RestMinutes = 40,
        },
                new MainDataItemViewModel
                {
                    StartDate = DateTimeOffset.UtcNow,
                    LastEdit = DateTimeOffset.UtcNow,
                    Status = ProjectStatus.Delayed,
                    TotalDays = 10,
                    TotalHours = 4,
                    RestMinutes = 40,
                },
                new MainDataItemViewModel
                {
                    StartDate = DateTimeOffset.UtcNow,
                    LastEdit = DateTimeOffset.UtcNow,
                    Status = ProjectStatus.Delayed,
                    TotalDays = 10,
                    TotalHours = 4,
                    RestMinutes = 40,
                },
                
            };
        }

        #endregion

    }
}
