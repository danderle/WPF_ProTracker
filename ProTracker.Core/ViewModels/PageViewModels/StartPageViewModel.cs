﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ProTracker.Core
{
    /// <summary>
    /// The view model for the <see cref="StartPage.xaml"/>
    /// </summary>
    public class StartPageViewModel : BaseViewModel
    {
        #region Private Members



        #endregion

        #region Public Properties



        #endregion

        #region Commands

        /// <summary>
        /// Command to create a new project
        /// </summary>
        public ICommand NewProjectCommand { get; set; }

        /// <summary>
        /// Command to continue a previous project
        /// </summary>
        public ICommand GoToProjectsCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public StartPageViewModel()
        {
            //Create commands
            GoToProjectsCommand = new RelayCommand(GoToProjects);
        }

        #endregion
        #region Command Methods

        private void GoToProjects()
        {
            Ioc.Get<ApplicationViewModel>().SideMenuControlIsVisible ^= true;
            //Ioc.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Project;
        }

        #endregion
    }
}
