using OpenIIoT.SDK.Plugin;

namespace OpenIIoT.Core.Plugin
{
    /// <summary>
    ///     The Plugin class represents Plugins that have been installed but not yet loaded.
    ///
    ///     The heirarchy of Plugin objects is: PluginPackage Plugin PluginAssembly PluginInstance
    ///
    ///     PluginPackage instances are installed, creating Plugin instances. Plugin instances are loaded, creating PluginAssembly
    ///     instances. PluginAssembly instances are instantiated, creating PluginInstance instances.
    /// </summary>
    public class Plugin : IPlugin
    {
        /// <summary>
        ///     The name of the Plugin.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///     The Fully Qualified Name of the Plugin.
        /// </summary>
        public string FQN { get; private set; }

        /// <summary>
        ///     The version of the Plugin.
        /// </summary>
        /// <remarks>
        ///     Formatting is disretionary. Any comparisons between versions will be "equals" rather than greater than/less than.
        /// </remarks>
        public string Version { get; private set; }

        /// <summary>
        ///     The type of Plugin.
        /// </summary>
        public PluginType PluginType { get; private set; }

        /// <summary>
        ///     The cryptographic fingerprint of the Plugin.
        /// </summary>
        /// <remarks>
        ///     The SHA256 checksum of the Plugin assembly hashed again using the SHA256 algorithm and salted with the FQN + Version.
        /// </remarks>
        public string Fingerprint { get; private set; }

        /// <summary>
        ///     The default constructor.
        /// </summary>
        /// <param name="name">The name of the Plugin.</param>
        /// <param name="fqn">The Fully Qualified Name of the Plugin.</param>
        /// <param name="version">The version of the Plugin.</param>
        /// <param name="pluginType">The type of Plugin.</param>
        /// <param name="fingerprint">The cryptographic fingerprint of the Plugin.</param>
        public Plugin(string name, string fqn, string version, PluginType pluginType, string fingerprint)
        {
            Name = name;
            FQN = fqn;
            Version = version;
            PluginType = pluginType;
            Fingerprint = fingerprint;
        }

        /// <summary>
        ///     Sets the Fingerprint property to the supplied value.
        /// </summary>
        /// <param name="fingerprint">The value to which the property should be set.</param>
        public void SetFingerprint(string fingerprint)
        {
            Fingerprint = fingerprint;
        }

        /// <summary>
        ///     Compares this object to the specified object and returns true if the objects are equal.
        /// </summary>
        /// <param name="obj">The object to which this object should be compared.</param>
        /// <returns>True if this object and the specified object are equal, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            NLog.Logger l = NLog.LogManager.GetCurrentClassLogger();

            if (obj.GetType().IsAssignableFrom(GetType()))
            {
                Plugin p = (Plugin)obj;
                if (Name == p.Name)
                    if (FQN == p.FQN)
                        if (Version == p.Version)
                            if (PluginType == p.PluginType)
                                if (Fingerprint == p.Fingerprint)
                                    return true;
            }

            return false;
        }

        /// <summary>
        ///     Returns this object's HashCode.
        /// </summary>
        /// <returns>This object's HashCode.</returns>
        public override int GetHashCode()
        {
            return FQN.GetHashCode();
        }
    }
}