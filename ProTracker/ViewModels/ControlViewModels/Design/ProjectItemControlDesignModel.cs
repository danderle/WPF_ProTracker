namespace ProTracker
{
    /// <summary>
    /// A view model used for the design time data for a <see cref="ProjectItemControlViewModel"/>
    /// </summary>
    public class ProjectItemControlDesignModel : ProjectItemControlViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ProjectItemControlDesignModel Instance => new ProjectItemControlDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectItemControlDesignModel()
        {
            Name = "Tetris";
            Icon = "\uf113";
            IconRGBbackground = "#009900";
            Description = "Tetris game";
            Selected = true;
        }

        #endregion

    }
}
