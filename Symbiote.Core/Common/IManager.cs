namespace Symbiote.Core
{
    /// <summary>
    /// Defines the interface used for the various Managers within the application.
    /// </summary>
    public interface IManager: IStateful
    {
        /// <summary>
        /// Starts the Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        Result Start();

        /// <summary>
        /// Restarts the Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        Result Restart();

        /// <summary>
        /// Stops the Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        Result Stop();
    }
}
