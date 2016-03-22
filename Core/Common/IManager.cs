namespace Symbiote.Core
{
    /// <summary>
    /// Defines the interface used for the various Managers within the application.
    /// </summary>
    public interface IManager
    {
        /// <summary>
        /// Indicates the status of the Manager; true if the Manager is running, false otherwise.
        /// </summary>
        bool Running { get; }

        /// <summary>
        /// Starts the Manager.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        OperationResult Start();

        /// <summary>
        /// Restarts the Manager.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        OperationResult Restart();

        /// <summary>
        /// Stops the Manager.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        OperationResult Stop();
    }
}
