namespace ProTracker.Core
{
    /// <summary>
    /// A view model for each project item in overview project list
    /// </summary>
    public class ProjectItemControlViewModel : BaseViewModel
    {
        
        /// <summary>
        /// The icon used for this project
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// The RGB values for the background´color of the icon in hex
        /// </summary>
        public string IconRGBbackground { get; set; }

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


    }
}
