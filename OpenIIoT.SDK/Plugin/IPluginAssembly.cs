using System;
using System.Reflection;

namespace OpenIIoT.SDK.Plugin
{
    /// <summary>
    ///     The PluginAssembly class represents a plugin for which the assembly file has been loaded.
    /// </summary>
    public interface IPluginAssembly : IPlugin
    {
        #region Public Properties

        /// <summary>
        ///     Gets the Plugin assembly.
        /// </summary>
        Assembly Assembly { get; }

        /// <summary>
        ///     Gets the Type of the Plugin contained within the Plugin assembly.
        /// </summary>
        Type Type { get; }

        #endregion Public Properties
    }
}