using System.Windows.Input;

namespace ProTracker.Core
{
    /// <summary>
    /// A view model for the general data of a project
    /// </summary>
    public class GeneralDataItemViewModel : BaseViewModel
    {
        #region Public properties

        /// <summary>
        /// The icon used for this project
        /// </summary>
        public string IconFont { get; set; }

        /// <summary>
        /// The RGB values for the background color of the icon in hex
        /// </summary>
        public string IconRgbBackground { get; set; }

        /// <summary>
        /// The name for the project
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A short description for the project
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// True if the project is selected
        /// </summary>
        public bool Selected { get; set; } = false;

        /// <summary>
        /// True when in editing mode
        /// </summary>
        public bool Editing { get; set; } = false;

        /// <summary>
        /// True when in delete mode
        /// </summary>
        public bool DeleteMode { get; set; } = false;

        /// <summary>
        /// True if checked to be deleted
        /// </summary>
        public bool Delete { get; set; } = false;

        #endregion

        #region Command Methods

        /// <summary>
        /// The selection command, selects and highlights the item
        /// </summary>
        public ICommand SelectedCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public GeneralDataItemViewModel()
        {
        }
       
        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="project"></param>
        /// <param name="command"></param>
        public GeneralDataItemViewModel(Project project, ICommand command)
        {
            Name = project.GeneralData.Name;
            Description = project.GeneralData.Description;
            IconFont = project.GeneralData.IconFont;
            IconRgbBackground = project.GeneralData.IconRgbBackground;
            SelectedCommand = command;
        }

        #endregion
        

    }
}
