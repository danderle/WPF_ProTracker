namespace ProTracker.Core
{
    /// <summary>
    /// A view model used for the design time data for a <see cref="IdleTimeViewModel"/>
    /// </summary>
    public class IdleTimeDesignModel : IdleTimeViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static IdleTimeDesignModel Instance => new IdleTimeDesignModel();

        #endregion
        
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public IdleTimeDesignModel()
        {
            ShowIdleControl = true;
            TimeInIdle = "10:11";
        }

        #endregion
    }
}
