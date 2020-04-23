namespace ProTracker.Core
{
    /// <summary>
    /// A view model used for the design time data for a <see cref="ProjectItemViewModel"/>
    /// </summary>
    public class ProjectItemDesignModel: ProjectItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ProjectItemDesignModel Instance => new ProjectItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectItemDesignModel()
        {
            GeneralData = new GeneralDataItemViewModel
            {
                Name = "Tetris",
                Description = "A Tetris clone",
                IconFont = "f113",
                IconRgbBackground = "#009900",
                Selected = true,
            };
        }

        #endregion

    }
}
