using System;
using System.Reflection;

namespace Symbiote.Core.Plugin
{
    /// <summary>
    /// The PluginAssembly class represents a plugin for which the assembly file has been loaded.
    /// </summary>
    public class PluginAssembly : IPlugin
    {
        /// <summary>
        /// The name of the Plugin.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The Fully Qualified Name of the Plugin.
        /// </summary>
        public string FQN { get; private set; }

        /// <summary>
        /// The version of the Plugin.
        /// </summary>
        /// <remarks>Formatting is disretionary.  Any comparisons between versions will be "equals" rather than greater than/less than.</remarks>
        public string Version { get; private set; }

        /// <summary>
        /// The type of Plugin.
        /// </summary>
        public PluginType PluginType { get; private set; }

        /// <summary>
        /// The cryptographic fingerprint of the Plugin.
        /// </summary>
        /// <remarks>The SHA256 checksum of the Plugin assembly hashed again using the SHA256 algorithm and salted with the FQN + Version.</remarks>
        public string Fingerprint { get; private set; }

        /// <summary>
        /// The Type of the Plugin contained within the Plugin assembly.
        /// </summary>
        public Type Type { get; private set; }

        /// <summary>
        /// The Plugin assembly.
        /// </summary>
        public Assembly Assembly { get; private set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <param name="name">The name of the Plugin.</param>
        /// <param name="fqn">The Fully Qualified Name of the Plugin.</param>
        /// <param name="version">The version of the Plugin.</param>
        /// <param name="pluginType">The type of Plugin.</param>
        /// <param name="fingerprint">The cryptographic fingerprint of the Plugin.</param>
        /// <param name="type">The Type of the Plugin contained within the Plugin assembly.</param>
        /// <param name="assembly">The Plugin assembly.</param>
        public PluginAssembly(string name, string fqn, string version, PluginType pluginType, string fingerprint, Type type, Assembly assembly)
        {
            Name = name;
            FQN = fqn;
            Version = Version;
            PluginType = pluginType;
            Fingerprint = fingerprint;
            Type = type;
            Assembly = assembly;
        }

        /// <summary>
        /// Unloads the assembly.
        /// </summary>
        public void Unload()
        {
            this.Unload();
        }
    }
}
