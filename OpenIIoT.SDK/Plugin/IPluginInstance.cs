namespace OpenIIoT.SDK.Plugin
{
    using OpenIIoT.SDK;
    using OpenIIoT.SDK.Common;

    /// <summary>
    ///     Defines the interface for PluginInstance objects.
    /// </summary>
    public interface IPluginInstance : IPlugin, IStateful
    {
        #region Properties

        /// <summary>
        ///     Gets the name of the PluginInstance. This is the unique name by which the PluginManager persists the PluginInstance.
        /// </summary>
        string InstanceName { get; }

        #endregion Properties
    }
}