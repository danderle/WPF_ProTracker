using System.Windows.Input;

namespace ProTracker.Core
{
    /// <summary>
    /// A view model for each project item in overview project list
    /// </summary>
    public class GeneralDataItemViewModel : BaseViewModel
    {
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

        public bool Editing { get; set; } = false;

        public bool Clickable { get; set; } = true;

        public bool DeleteMode { get; set; } = false;

        public bool Delete { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public ICommand SelectedCommand { get; set; }

        public GeneralDataItemViewModel()
        {
                
        }

        public GeneralDataItemViewModel(Project project, ICommand command)
        {
            Name = project.GeneralData.Name;
            Description = project.GeneralData.Description;
            IconFont = project.GeneralData.IconFont;
            IconRgbBackground = project.GeneralData.IconRgbBackground;
            SelectedCommand = command;
        }

    }
}
