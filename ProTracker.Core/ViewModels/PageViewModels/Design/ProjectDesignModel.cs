namespace ProTracker.Core
{
    /// <summary>
    /// A view model used for the design time data for a <see cref="ProjectViewModel"/>
    /// </summary>
    public class ProjectDesignModel : ProjectViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ProjectDesignModel Instance => new ProjectDesignModel();

        #endregion

        
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectDesignModel()
        {
            TimeInput.ShowTimeInput = false;
            ShowSaveButton = true;
        }

        #endregion

    }
}
