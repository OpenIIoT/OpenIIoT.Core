using Symbiote.Core.SDK.Plugin;
using System;
using System.Collections.Generic;

namespace Symbiote.Core.Plugin
{
    /// <summary>
    /// PluginManagerConfiguration contains the configuration model for the PluginManager.
    /// </summary>
    public class PluginManagerConfiguration
    {
        public List<PluginManagerConfigurationPluginInstance> Instances { get; set; }
        public List<Plugin> InstalledPlugins { get; set; }

        public PluginManagerConfiguration()
        {
            Instances = new List<PluginManagerConfigurationPluginInstance>();
            InstalledPlugins = new List<Plugin>();
        }
    }

    public class PluginManagerConfigurationPluginInstance
    {
        public string InstanceName { get; set; }
        public string AssemblyName { get; set; }
    }
}
