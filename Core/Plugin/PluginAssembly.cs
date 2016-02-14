using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Symbiote.Core.Plugin
{
    public class PluginAssembly : IPluginAssembly
    {
        public string Name { get; private set; }
        public string FQN { get; private set; }
        public Version Version { get; private set; }
        public PluginType PluginType { get; private set; }
        public Type Type { get; private set; }
        public Assembly Assembly { get; private set; }

        public PluginAssembly(string name, string fqn, Version version, PluginType pluginType, Type type, Assembly assembly)
        {
            Name = name;
            FQN = fqn;
            Version = Version;
            PluginType = pluginType;
            Type = type;
            Assembly = assembly;
        }

        public void Unload()
        {
            this.Unload();
        }
    }
}
