using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Symbiote.Core.Plugin
{
    public class Plugin : IPlugin
    {
        public string Name { get; private set; }
        public string Namespace { get; private set; }
        public PluginManager.PluginType PluginType { get; private set; }
        public Type Type { get; private set; }
        public Assembly Assembly { get; private set; }

        public Plugin(string name, string ns, PluginManager.PluginType pluginType, Type type, Assembly assembly)
        {
            Name = name;
            Namespace = ns;
            PluginType = pluginType;
            Type = type;
            Assembly = assembly;
        }
    }
}
