using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Symbiote.Core.Plugin
{
    public class PluginAssembly : IPlugin
    {
        public string Name { get; private set; }
        public string FQN { get; private set; }
        public string Version { get; private set; }
        public PluginType PluginType { get; private set; }
        public string Fingerprint { get; private set; }
        public Type Type { get; private set; }
        public Assembly Assembly { get; private set; }

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

        public void Unload()
        {
            this.Unload();
        }
    }
}
