using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;

namespace ProTracker
{
    /// <summary>
    /// A base page for all pages to gain base functionality
    /// </summary>
    public class BasePage<VM> : Page
        where VM : BaseViewModel, new()
    {
        #region Private Member

        /// <summary>
        /// The View Model associated with this page
        /// </summary>
        private VM viewModel;

        #endregion

        #region Public Properties

        /// <summary>
        /// The animation to play when a page is loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// The animation to play when a page is unloaded
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// The time slide animations need to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f; 

        /// <summary>
        /// The View Model associated with this page
        /// </summary>
        public VM ViewModel
        {
            get { return viewModel; }
            set
            {
                // If nothing has changed, return
                if (viewModel == value)
                    return;

                // Update the value
                viewModel = value;

                // Set the data context for this page
                this.DataContext = viewModel;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage()
        {
            //If no animation is set, dont show anything
            if(PageLoadAnimation != PageAnimation.None)
            {
                Visibility = Visibility.Collapsed;
            }

            //Listen for the page loading
            Loaded += BasePage_Loaded;

            // Create a default view model
            this.ViewModel = new VM();
        }

        /// <summary>
        /// Listens for the page being loaded tp then do animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            await AnimateInAsync();
        }

        /// <summary>
        /// Animates the page in
        /// </summary>
        /// <returns></returns>
        public async Task AnimateInAsync()
        {
            ///Make sure that an animation is set
            if(PageLoadAnimation == PageAnimation.None)
            {
                return;
            }

            switch(PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    //Start the animation
                    await this.SlideAndFadeInFromRight(SlideSeconds);
                    break;
                case PageAnimation.SlideAndFadeOutToLeft:

                    break;

            }
        }

        /// <summary>
        /// Animates the page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOutAsync()
        {
            ///Make sure that an animation is set
            if (PageUnloadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    //Start the animation
                    await this.SlideAndFadeInFromRight(SlideSeconds);
                    break;
                case PageAnimation.SlideAndFadeOutToLeft:
                    //Sart the animation
                    await this.SlideAndFadeOutToLeft(SlideSeconds);
                    break;

            }
        }
        #endregion
    }
}
