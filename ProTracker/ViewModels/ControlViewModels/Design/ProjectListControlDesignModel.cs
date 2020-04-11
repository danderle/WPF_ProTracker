using System.Collections.Generic;

namespace ProTracker
{
    /// <summary>
    /// A view model used for the design time data for a <see cref="ProjectListControlViewModel"/>
    /// </summary>
    public class ProjectListControlDesignModel : ProjectListControlViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ProjectListControlDesignModel Instance => new ProjectListControlDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectListControlDesignModel()
        {
            Items = new List<ProjectItemControlViewModel>
            {
                new ProjectItemControlViewModel
                {
                    Name = "Tetris",
                    Icon = "\uf113",
                    IconRGBbackground = "#009900",
                    Description = "Tetris clone game",
                    Selected = true,
                },
                new ProjectItemControlViewModel
                {
                    Name = "Other Project",
                    Icon = "\uf113",
                    IconRGBbackground = "#009966",
                    Description = "Tetris clone game",
                    Selected = false,
                },
                new ProjectItemControlViewModel
                {
                    Name = "Tetris",
                    Icon = "\uf113",
                    IconRGBbackground = "#669900",
                    Description = "Tetris clone game",
                    Selected = false,
                },
                new ProjectItemControlViewModel
                {
                    Name = "Tetris",
                    Icon = "\uf113",
                    IconRGBbackground = "#002288",
                    Description = "Tetris clone game",
                    Selected = false,
                },
                new ProjectItemControlViewModel
                {
                    Name = "Tetris",
                    Icon = "\uf113",
                    IconRGBbackground = "#224499",
                    Description = "Tetris clone game",
                    Selected = false,
                },
            };
        }

        #endregion

    }
}
