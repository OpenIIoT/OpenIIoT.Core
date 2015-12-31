using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbiote.Core.Plugin;

namespace Symbiote.Plugin.Connector.UNIXPlatform
{
    public class Plugin : IConnector
    {
        public string Name { get; private set; }
        public string Namespace { get; private set; }
        public double Version { get; private set; }

        private List<IConnectorItem> items;

        public Plugin()
        {
            Name = "UNIX Platform Connector";
            Namespace = "Symbiote.Plugin.Connector.UNIXPlatform";
            Version = 0.1;

            items = new List<IConnectorItem>();
            items.Add(new PluginConnectorItem("FirstRoot", "::root1"));
            items.Add(new PluginConnectorItem("SecondRoot", "::root2"));
            items.Add(new PluginConnectorItem("ThirdRoot", "::root3"));
        }

        public List<IConnectorItem> Browse(IConnectorItem root)
        {
            return items;
        }
    }

    public class PluginConnectorItem : IConnectorItem
    {
        public IConnectorItem Parent { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }

        public PluginConnectorItem(string name, string address) : this(name, address, null) { }

        public PluginConnectorItem(string name, string address, IConnectorItem parent)
        {
            if (parent != null) Parent = parent;
            Name = name;
            Address = address;
        }
    }
}
