namespace Symbiote.Core.Plugin
{
    /// <summary>
    /// Defines the interface for Plugin objects.
    /// </summary>
    public interface IPlugin
    {
        #region Properties

        /// <summary>
        /// The name of the Plugin.  Typically a single word but may be a phrase.
        /// Equal to the last tuple of the FQN.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The Fully Qualified Name of the Plugin.  The FQN shall use the following pattern:
        ///     Symbiote.Plugin.[Connector|Endpoint].Name
        ///     
        /// The final tuple, Name, shall match the Name property.
        /// </summary>
        string FQN { get; }

        /// <summary>
        /// The version of the Plugin.  This is a free-text field allowing any format
        /// the Plugin author desires.
        /// </summary>
        string Version { get; }

        /// <summary>
        /// The enumerated type of the Plugin.  This shall match the thrid tuple of the FQN.
        /// </summary>
        PluginType PluginType { get; }

        #endregion
    }
}
