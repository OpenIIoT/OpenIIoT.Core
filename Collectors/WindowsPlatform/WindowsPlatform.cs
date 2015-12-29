using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbiote.Core;
using Symbiote.Core.Plugin;

namespace Symbiote.Plugin.Connector
{
    public class WindowsPlatform : IConnector
    {
        public string Name { get; private set; }
        public string Namespace { get; private set; }
        public double Version { get; private set; }

        private List<IConnectorItem> items;

        public WindowsPlatform()
        {
            Name = "Windows Platform";
            Namespace = "Symbiote.Plugin.Connector";
            Version = 0.1;

            items = new List<IConnectorItem>();
            items.Add(new WindowsPlatformConnectorItem("FirstRoot", "::root1"));
            items.Add(new WindowsPlatformConnectorItem("SecondRoot", "::root2"));
            items.Add(new WindowsPlatformConnectorItem("ThirdRoot", "::root3"));
        }

        public List<IConnectorItem> Browse(IConnectorItem root)
        {
            return items;
        }
    }

    public class WindowsPlatformConnectorItem : IConnectorItem
    {
        public IConnectorItem Parent { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }

        public WindowsPlatformConnectorItem(string name, string address) : this(name, address, null) { }

        public WindowsPlatformConnectorItem(string name, string address, IConnectorItem parent)
        {
            if (parent != null) Parent = parent;
            Name = name;
            Address = address;
        }
    }
}
