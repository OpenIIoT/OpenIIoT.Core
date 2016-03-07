using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Plugin
{
    public class PluginManagerConfiguration
    {
        public bool AuthorizeNewPlugins { get; set; }
        public List<PluginManagerConfigurationPluginAssembly> Assemblies { get; set; }
        public List<PluginManagerConfigurationPluginInstance> Instances { get; set; }

        public PluginManagerConfiguration()
        {
            Assemblies = new List<PluginManagerConfigurationPluginAssembly>();
            Instances = new List<PluginManagerConfigurationPluginInstance>();
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

    public class PluginManagerConfigurationPluginInstanceAutoBuild
    {
        public bool Enabled { get; set; }
        public string ParentFQN { get; set; }
    }
}
