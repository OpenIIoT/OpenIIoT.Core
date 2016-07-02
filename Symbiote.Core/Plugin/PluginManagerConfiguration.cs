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
        public List<Plugin> Plugins { get; set; }

        public PluginManagerConfiguration()
        {
            Instances = new List<PluginManagerConfigurationPluginInstance>();
            Plugins = new List<Plugin>();
        }
    }

    public class PluginManagerConfigurationPluginInstance
    {
        public string InstanceName { get; set; }
        public string AssemblyName { get; set; }
        public string Configuration { get; set; }
    }
}
