using System;
using System.Reflection;

namespace Symbiote.Core.SDK.Plugin
{
    /// <summary>
    /// The PluginAssembly class represents a plugin for which the assembly file has been loaded.
    /// </summary>
    public interface IPluginAssembly : IPlugin
    {
        /// <summary>
        /// The version of the Plugin.
        /// </summary>
        /// <remarks>Formatting is disretionary.  Any comparisons between versions will be "equals" rather than greater than/less than.</remarks>
        string Version { get; }

        /// <summary>
        /// The type of Plugin.
        /// </summary>
        PluginType PluginType { get; }

        /// <summary>
        /// The cryptographic fingerprint of the Plugin.
        /// </summary>
        /// <remarks>The SHA256 checksum of the Plugin assembly hashed again using the SHA256 algorithm and salted with the FQN + Version.</remarks>
        string Fingerprint { get; }

        /// <summary>
        /// The Type of the Plugin contained within the Plugin assembly.
        /// </summary>
        Type Type { get; }

        /// <summary>
        /// The Plugin assembly.
        /// </summary>
        Assembly Assembly { get; }
    }
}
