namespace Symbiote.Core.Plugin
{
    /// <summary>
    /// Defines the interface for PluginInstance objects.
    /// </summary>
    public interface IPluginInstance : IPlugin, IStateful
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
        /// <returns>A Result containing the result of the operation.</returns>
        Result Start();

        /// <summary>
        /// Restarts the PluginInstance.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        Result Restart();

        /// <summary>
        /// Stops the PluginInstance.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        Result Stop();

        #endregion
    }
}