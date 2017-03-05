using System;
using System.Reflection;

namespace OpenIIoT.SDK.Extensibility.Plugin
{
    /// <summary>
    ///     The PluginAssembly class represents a plugin for which the assembly file has been loaded.
    /// </summary>
    public interface IPluginAssembly : IPlugin
    {
        /// <summary>
        ///     The Type of the Plugin contained within the Plugin assembly.
        /// </summary>
        Type Type { get; }

        /// <summary>
        ///     The Plugin assembly.
        /// </summary>
        Assembly Assembly { get; }
    }
}