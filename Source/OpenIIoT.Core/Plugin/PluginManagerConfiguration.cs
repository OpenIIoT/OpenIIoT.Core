using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[module: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleType", Justification = "Reviewed.")]

namespace OpenIIoT.Core.Plugin
{
    /// <summary>
    ///     PluginManagerConfiguration contains the configuration model for the PluginManager.
    /// </summary>
    public class PluginManagerConfiguration
    {
        #region Public Constructors

        public PluginManagerConfiguration()
        {
            Instances = new List<PluginManagerConfigurationPluginInstance>();
            InstalledPlugins = new List<Plugin>();
        }

        #endregion Public Constructors

        #region Public Properties

        public List<Plugin> InstalledPlugins { get; set; }

        public List<PluginManagerConfigurationPluginInstance> Instances { get; set; }

        #endregion Public Properties
    }

    public class PluginManagerConfigurationPluginInstance
    {
        #region Public Properties

        public string AssemblyName { get; set; }

        public string InstanceName { get; set; }

        #endregion Public Properties
    }
}