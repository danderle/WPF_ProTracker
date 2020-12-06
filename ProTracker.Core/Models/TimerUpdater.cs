using System;
using System.Diagnostics;
using System.Timers;

namespace ProTracker.Core
{
    /// <summary>
    /// Class to stopwatch time and update elapsed time
    /// </summary>
    public class TimerUpdater
    {
        #region Constants

        private const int updateTime = 1000;

        #endregion

        #region Private Fields

        /// <summary>
        /// Keeps track of the time when working
        /// </summary>
        private Stopwatch stopwatch = new Stopwatch();

        /// <summary>
        /// Updates the stopwatch to the UI after each second
        /// </summary>
        private Timer stopwatchUpdate { get; set; } = new Timer(updateTime);

        #endregion

        #region Event Handlers

        /// <summary>
        /// Will trigger an update when the stopwatchUpdate elapses
        /// </summary>
        public event EventHandler Update;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TimerUpdater()
        {
            stopwatchUpdate.Elapsed += StopwatchUpdate_Elapsed;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Starts the stopwatch and update events
        /// </summary>
        public void Start()
        {
            stopwatch.Start();
            stopwatchUpdate.Start();
        }

        /// <summary>
        /// Stops the stopwatch and update events
        /// </summary>
        public void Stop()
        {
            stopwatch.Stop();
            stopwatchUpdate.Stop();
        }

        /// <summary>
        /// Resets the stopwatch
        /// </summary>
        public void Reset()
        {
            stopwatch.Reset();
        }
        
        /// <summary>
        /// Subtracts as <see cref="TimeSpan"/> from the stopwatch
        /// </summary>
        /// <param name="timeSpan">The time to subtract</param>
        /// <returns>The difference</returns>
        public TimeSpan Subtract(TimeSpan timeSpan)
        {
            return stopwatch.Elapsed.Subtract(timeSpan);
        }

        /// <summary>
        /// Gets the elapsed time
        /// </summary>
        /// <returns></returns>
        public TimeSpan Elapsed()
        {
            return stopwatch.Elapsed;
        }

        #endregion

        #region Events

        /// <summary>
        /// The stopwatch update event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopwatchUpdate_Elapsed(object sender, ElapsedEventArgs e)
        {
            Update?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
