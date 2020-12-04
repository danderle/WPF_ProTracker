namespace ProTracker.Core
{
    /// <summary>
    /// A view model used for the design time data for a <see cref="TimeInputViewModel"/>
    /// </summary>
    public class TimeInputDesignModel : TimeInputViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static TimeInputDesignModel Instance => new TimeInputDesignModel();

        #endregion
        
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TimeInputDesignModel()
        {
            UserEntry = "24:11:33";
            SaveTimeEnabled = false;
        }

        #endregion
    }
}
