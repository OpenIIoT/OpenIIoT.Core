namespace Symbiote.Core.Plugin
{
    /// <summary>
    /// Defines the interface for PluginInstance objects.
    /// </summary>
    public interface IPluginInstance : IPlugin
    {
        #region Properties

        /// <summary>
        /// The name of the PluginInstance.  This is the unique name by which the PluginManager
        /// persists the PluginInstance.
        /// </summary>
        string InstanceName { get; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Starts the PluginInstance.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        OperationResult Start();

        /// <summary>
        /// Restarts the PluginInstance.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        OperationResult Restart();

        /// <summary>
        /// Stops the PluginInstance.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        OperationResult Stop();

        #endregion
    }
}