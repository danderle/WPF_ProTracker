namespace ProTracker.Core
{
    /// <summary>
    /// The status of a project
    /// </summary>
    public enum ProjectStatus
    {
        /// <summary>
        /// Project in progress
        /// </summary>
        InProgress = 0,

        /// <summary>
        /// Project is closed
        /// </summary>
        CLosed,

        /// <summary>
        /// Project is delayed
        /// </summary>
        Delayed,

        /// <summary>
        /// Project is finished
        /// </summary>
        Finished,
    }
}
