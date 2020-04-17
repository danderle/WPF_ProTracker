﻿using ProTracker.Core;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProTracker
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        #region Dependency Properties

        /// <summary>
        /// The current page to show in the page host
        /// </summary>
        public BasePage CurrentPage
        {
            get => (BasePage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        /// <summary>
        /// Registers <see cref="CurrentPage"/> as a dependancy property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage), typeof(PageHost), new UIPropertyMetadata(CurrentPagePropertyChanged));

        #endregion

        #region Constructor

        public PageHost()
        {
            InitializeComponent();

            //if in design mode, show the current page,
            //as the dependency property does not fire
            if(DesignerProperties.GetIsInDesignMode(this))
            {
                NewPage.Content = (BasePage)new ApplicationPageValueConverter().Convert(Ioc.Get<ApplicationViewModel>().CurrentPage);
            }
        }

        #endregion

        #region Property Changed events

        /// <summary>
        /// Called when the <see cref="CurrentPage"/> value has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void CurrentPagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //Get the frames
            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;

            //Store the current page content as the old page
            var oldPageContent = newPageFrame.Content;

            //Remove the current page from the new page frame
            newPageFrame.Content = null;

            //Move the previous page int the old page frame
            oldPageFrame.Content = oldPageContent;

            //Animate out previous page when the loaded event is fired
            //Right after thic call due to moving frames
            if(oldPageContent is BasePage oldPage)
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
