using System;
using System.Collections.Generic;
using System.Windows.Input;

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

        /// <summary>
        /// True to enable the save time button
        /// </summary>
        public bool SaveTimeEnabled { get; set; } = false;

        /// <summary>
        /// The hours
        /// </summary>
        public int Hours { get; set; }

        /// <summary>
        /// The minutes
        /// </summary>
        public int Minutes { get; set; }

        /// <summary>
        /// The time the user enters
        /// </summary>
        public string UserEntry
        {
            get => userEntry;
            set => SetUserEntry(value);
        }

        #endregion

        #region Delegates

        /// <summary>
        /// The action to execute when the user saves the entered time
        /// </summary>
        public Action<TimeSpan> TimeEntered;

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
            TimeEntered?.Invoke(new TimeSpan(Hours, Minutes, 0));
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

        /// <summary>
        /// Checks if the time entered is valid and if so create time values
        /// </summary>
        /// <param name="entry"></param>
        private void SetUserEntry(string entry)
        {
            userEntry = entry;
            //Split the string betweeen colons should be length = 2
            var values = userEntry.Split(":");
            if (values.Length != 2)
            {
                SaveTimeEnabled = false;
                return;
            }
            //values == 2
            else
            {
                var timeValues = new List<int>();
                foreach (var value in values)
                {
                    try
                    {
                        //Verify that the values are between 0 - 100
                        var dec = Convert.ToInt32(value);
                        if (dec < 0 && dec > 99)
                        {
                            SaveTimeEnabled = false;
                            return;
                        }
                        //add time to list
                        timeValues.Add(dec);
                    }
                    catch (Exception)
                    {
                        SaveTimeEnabled = false;
                        return;
                    }
                }
                //Save hous and minutes
                Hours = timeValues[0];
                Minutes = timeValues[1];
            }
            SaveTimeEnabled = true;
        }

        #endregion

    }
}
