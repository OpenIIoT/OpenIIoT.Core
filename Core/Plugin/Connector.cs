using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Symbiote.Core.Plugin
{
    public class Connector : IPlugin
    {
        public string Name { get; private set; }
        public string FullName { get; private set; }
        public PluginManager.PluginType PluginType { get; private set; }
        public Type Type { get; private set; }
        public Assembly Assembly { get; private set; }

        public Connector(string name, string fullName, PluginManager.PluginType pluginType, Type type, Assembly assembly)
        {
            Name = name;
            FullName = fullName;
            PluginType = pluginType;
            Type = type;
            Assembly = assembly;
        }
    }
}
