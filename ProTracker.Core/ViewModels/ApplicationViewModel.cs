
namespace ProTracker.Core
{
    /// <summary>
    /// The application state as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Start;

        /// <summary>
        /// True if the side menu is visible
        /// </summary>
        public bool SideMenuControlIsVisible { get; set; } = false;

        #endregion

        #region Public Methods

        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page"></param>
        public void GoToPage(ApplicationPage page)
        {
            CurrentPage = page;

            //Show side menu or not
            SideMenuControlIsVisible = page == ApplicationPage.Project;
        } 

        #endregion
    }
}
