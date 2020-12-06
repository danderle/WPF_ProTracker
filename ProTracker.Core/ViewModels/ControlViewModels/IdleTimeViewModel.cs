using System;
using System.Windows.Input;

namespace ProTracker.Core
{
    /// <summary>
    /// The view model for the <see cref="IdleTimeControl.xaml"/>
    /// </summary>
    public class IdleTimeViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// True to show the idle control
        /// </summary>
        public bool ShowIdleControl { get; protected set; } = false;

        /// <summary>
        /// The time since in idle
        /// </summary>
        public string TimeInIdle { get; set; } = string.Empty;

        /// <summary>
        /// The time updater object
        /// </summary>
        public TimerUpdater TimeUpdate { get; set; } = new TimerUpdater();

        #endregion

        #region Delegates

        /// <summary>
        /// The delegate to execute when the idle time is to be saved
        /// </summary>
        public Action<TimeSpan> SaveIdleTimeToProject;

        #endregion

        #region Commands

        /// <summary>
        /// The command to save the time
        /// </summary>
        public ICommand SaveTimeCommand { get; set; }

        /// <summary>
        /// The command to discard the time
        /// </summary>
        public ICommand DiscardTimeCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public IdleTimeViewModel()
        {
            //Create commands
            InitializeCommands();

            TimeUpdate.Update += TimeUpdate_Update;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Starts the idle time clock
        /// </summary>
        public void Start()
        {
            ShowIdleControl = true;
            TimeUpdate.Start();
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Command mehtods to Discard the time
        /// </summary>
        private void DiscardTime()
        {
            ShowIdleControl = false;
            TimeInIdle = string.Empty;
            TimeUpdate.Stop();
            TimeUpdate.Reset();
        }

        /// <summary>
        /// Command method to save the time
        /// </summary>
        private void SaveTime()
        {
            ShowIdleControl = false;
            var duration = TimeUpdate.Elapsed();
            SaveIdleTimeToProject?.Invoke(duration);
        }

        #endregion

        #region Events

        /// <summary>
        /// The update event to show the total idle time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeUpdate_Update(object sender, EventArgs e)
        {
            var duration = TimeUpdate.Elapsed();
            TimeInIdle = duration.ToString("hh\\:mm\\:ss");
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Initializes all the commands
        /// </summary>
        private void InitializeCommands()
        {
            SaveTimeCommand = new RelayCommand(SaveTime);
            DiscardTimeCommand = new RelayCommand(DiscardTime);
        }

        #endregion

    }
}
