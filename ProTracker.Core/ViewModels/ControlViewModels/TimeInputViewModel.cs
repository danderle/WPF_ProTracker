using System;
using System.Timers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Diagnostics;

namespace ProTracker.Core
{
    /// <summary>
    /// The view model for the <see cref="TimeInputControl.xaml"/>
    /// </summary>
    public class TimeInputViewModel : BaseViewModel
    {
        #region Private Fields

        private string userEntry = string.Empty;

        #endregion

        #region Public Properties

        /// <summary>
        /// True to show the user time input
        /// </summary>
        public bool ShowTimeInput { get; set; } = false;

        public bool SaveTimeEnabled { get; set; } = false;

        public int Hours { get; set; }
        public int Minutes { get; set; }
        public TimeSpan UserTime { get; set; }
        /// <summary>
        /// The time the user enters
        /// </summary>
        public string UserEntry
        {
            get => userEntry;
            set => SetUserEntry(value);
        }

        private void SetUserEntry(string entry)
        {
            userEntry = entry;
            var values = userEntry.Split(":");
            if (values.Length != 2)
            {
                SaveTimeEnabled = false;
                return;
            }
            else
            {
                var timeValues = new List<int>();
                foreach (var value in values)
                {
                    try
                    {
                        var dec = Convert.ToInt32(value);
                        if(dec < 0 && dec > 99)
                        {
                            SaveTimeEnabled = false;
                            return;
                        }
                        timeValues.Add(dec);
                    }
                    catch (Exception e)
                    {
                        SaveTimeEnabled = false;
                        return;
                    }
                }
                Hours = timeValues[0];
                Minutes = timeValues[1];
            }
            SaveTimeEnabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler TimeEntered;

        #endregion

        #region Commands

        /// <summary>
        /// The command to save the entered time
        /// </summary>
        public ICommand SaveTimeInputCommand { get; set; }

        /// <summary>
        /// The command to cancel the time input
        /// </summary>
        public ICommand CancelTimeInputCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TimeInputViewModel()
        {
            //Create commands
            InitializeCommands();
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Saves the time input
        /// </summary>
        private void SaveTimeInput()
        {
            TimeEntered?.Invoke(this, EventArgs.Empty);
            ShowTimeInput = false;
        }

        /// <summary>
        /// Cancels the time input
        /// </summary>
        private void CancelTimeInput()
        {
            UserEntry = string.Empty;
        }

        #endregion
        
        #region Private Helpers

        /// <summary>
        /// Initializes all the commands
        /// </summary>
        private void InitializeCommands()
        {
            SaveTimeInputCommand = new RelayCommand(SaveTimeInput);
            CancelTimeInputCommand = new RelayCommand(CancelTimeInput);
        }

        #endregion

    }
}
