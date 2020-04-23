namespace ProTracker.Core
{
    /// <summary>
    /// A view model used for the design time data for a <see cref="GeneralDataItemViewModel"/>
    /// </summary>
    public class GeneralDataItemDesignModel : GeneralDataItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static GeneralDataItemDesignModel Instance => new GeneralDataItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public GeneralDataItemDesignModel()
        {
            Name = "Tetris";
            Description = "A Tetris clone";
            IconFont = "f113";
            IconRgbBackground = "#009900";
            Selected = true;
            Editing = true;
            DeleteMode = false;
            Delete = false;
        }

        #endregion
    }
}
