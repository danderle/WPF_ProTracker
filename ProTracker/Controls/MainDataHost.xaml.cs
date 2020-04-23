using ProTracker.Core;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProTracker
{
    /// <summary>
    /// Interaction logic for MainDataHost.xaml
    /// </summary>
    public partial class MainDataHost : UserControl
    {
        

        #region Dependency Properties

        /// <summary>
        /// The current project to show in the main data host
        /// </summary>
        public UserControl CurrentProject
        {
            get => (UserControl)GetValue(CurrentProjectProperty);
            set => SetValue(CurrentProjectProperty, value);
        }

        /// <summary>
        /// Registers <see cref="CurrentProject"/> as a dependancy property
        /// </summary>
        public static readonly DependencyProperty CurrentProjectProperty =
            DependencyProperty.Register(nameof(CurrentProject), typeof(UserControl), typeof(UserControl), new UIPropertyMetadata(CurrentProjectPropertyChanged));

        #endregion

        #region Constructor

        public MainDataHost()
        {
            InitializeComponent();

            //if in design mode, show the current page,
            //as the dependency property does not fire
            if(DesignerProperties.GetIsInDesignMode(this))
            {
                NewPage.Content = new MainDataItemControl();
            }
        }

        #endregion

        #region Property Changed events

        /// <summary>
        /// Called when the <see cref="CurrentProject"/> value has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void CurrentProjectPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //Get the frames
            var newPageFrame = (d as MainDataHost).NewPage;
            var oldPageFrame = (d as MainDataHost).OldPage;

            //Store the current page content as the old page
            var oldPageContent = newPageFrame.Content;

            //Remove the current page from the new page frame
            newPageFrame.Content = null;

            //Move the previous page int the old page frame
            oldPageFrame.Content = oldPageContent;

            //Animate out previous page when the loaded event is fired
            //Right after thic call due to moving frames
            if(oldPageContent is MainDataItemControl oldPage)
            {
                oldPage.ShouldAnimateOut = true;

                //Once it is done , remove it
                Task.Delay((int)(oldPage.SlideSeconds * 1000)).ContinueWith((t) =>
                {
                    //Remove old page go back to UI thread
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        oldPageFrame.Content = null;
                    });
                });
            }

            //Set the new page content
            newPageFrame.Content = e.NewValue;

        }

        #endregion
    }
}
