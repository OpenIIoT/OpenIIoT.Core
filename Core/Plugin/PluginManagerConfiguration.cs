using System.Collections.Generic;

namespace Symbiote.Core.Plugin
{
    /// <summary>
    /// PluginManagerConfiguration contains the configuration model for the PluginManager.
    /// </summary>
    public class PluginManagerConfiguration
    {
        public bool AuthorizeNewPlugins { get; set; }
        public List<PluginManagerConfigurationPluginAssembly> Assemblies { get; set; }
        public List<PluginManagerConfigurationPluginInstance> Instances { get; set; }
        public List<Plugin> InstalledPlugins { get; set; }

        public PluginManagerConfiguration()
        {
            Assemblies = new List<PluginManagerConfigurationPluginAssembly>();
            Instances = new List<PluginManagerConfigurationPluginInstance>();
            InstalledPlugins = new List<Plugin>();
        }
    }

    public class PluginManagerConfigurationPluginAssembly
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Version { get; set; }
        public string PluginType { get; set; }
        public string FileName { get; set; }
        public string Checksum { get; set; }
        public PluginAuthorization Authorization { get; set; }

    }
    public class PluginManagerConfigurationPluginInstance
    {
        public string InstanceName { get; set; }
        public string AssemblyName { get; set; }
        public string Configuration { get; set; }
        public PluginManagerConfigurationPluginInstanceAutoBuild AutoBuild { get; set; }
    }

    public class PluginManagerConfigurationArchive
    {

    }

    public class PluginManagerConfigurationPluginInstanceAutoBuild
    {
        public bool Enabled { get; set; }
        public string ParentFQN { get; set; }
    }
}
