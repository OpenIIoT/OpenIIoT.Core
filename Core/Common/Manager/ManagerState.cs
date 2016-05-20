namespace Symbiote.Core
{
    /// <summary>
    /// Enumeration of the different Manager states.
    /// </summary>
    public enum ManagerState
    {
        /// <summary>
        /// The default value
        /// </summary>
        Unknown,

        /// <summary>
        /// The Manager is starting
        /// </summary>
        Starting,

        /// <summary>
        /// The Manager is running
        /// </summary>
        Running,

        /// <summary>
        /// The Manager is stopping
        /// </summary>
        Stopping,

        /// <summary>
        /// The Manager has stopped
        /// </summary>
        Stopped,

        /// <summary>
        /// The Manager is faulted
        /// </summary>
        Faulted
    }
}
