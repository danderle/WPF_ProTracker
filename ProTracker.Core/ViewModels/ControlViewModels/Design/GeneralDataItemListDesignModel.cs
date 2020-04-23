using System.Collections.Generic;

namespace ProTracker.Core
{
    /// <summary>
    /// A view model used for the design time data for a <see cref="GeneralDataItemListViewModel"/>
    /// </summary>
    public class GeneralDataItemListDesignModel : GeneralDataItemListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static GeneralDataItemListDesignModel Instance => new GeneralDataItemListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public GeneralDataItemListDesignModel()
        {
            LoadedProjects = new List<ProjectItemViewModel>
            {
                new ProjectItemViewModel
                {
                    GeneralData = new GeneralDataItemViewModel
                    {
                        Name = "Tetris",
                        IconFont = "f113",
                        IconRgbBackground = "#009900",
                        Description = "Tetris clone game",
                        Selected = true,
                        Editing = false,
                    },
                },
                new ProjectItemViewModel
                {
                    GeneralData = new GeneralDataItemViewModel
                    {
                        Name = "Other Project",
                        IconFont = "f113",
                        IconRgbBackground = "#009966",
                        Description = "Tetris clone game",
                        Selected = false,
                        Editing = false,
                    },
                },
                new ProjectItemViewModel
                {
                    GeneralData = new GeneralDataItemViewModel
                    {
                        Name = "Tetris",
                        IconFont = "f113",
                        IconRgbBackground = "#002288",
                        Description = "Tetris clone game",
                        Selected = false,
                        Editing = false,
                    },
                },
                new ProjectItemViewModel
                {
                    GeneralData = new GeneralDataItemViewModel
                    {
                        Name = "Tetris",
                        IconFont = "f113",
                        IconRgbBackground = "#224499",
                        Description = "Tetris clone game",
                        Selected = false,
                        Editing = false,
                    },
                },
            };
        }

        #endregion

    }
}
