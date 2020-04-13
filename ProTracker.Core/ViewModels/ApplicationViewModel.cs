
namespace ProTracker.Core
{
    /// <summary>
    /// The application state as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Start;

        /// <summary>
        /// True if the side menu is visible
        /// </summary>
        public bool SideMenuControlIsVisible { get; set; } = false;
    }
}
