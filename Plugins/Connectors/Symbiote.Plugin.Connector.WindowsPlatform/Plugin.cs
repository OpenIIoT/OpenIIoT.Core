using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbiote.Core.Plugin;

namespace Symbiote.Plugin.Connector.WindowsPlatform
{
    public class Plugin : IConnector
    {
        public string Name { get; private set; }
        public string Namespace { get; private set; }
        public PluginManager.PluginType PluginType { get; private set; }
        public double Version { get; private set; }

        private IConnectorItem itemRoot;

        public Plugin()
        {
            Name = "Windows Platform Connector";
            Namespace = "Symbiote.Plugin.Connector.WindowsPlatform";
            PluginType = PluginManager.PluginType.Connector;
            Version = 0.1;

            // instantiate an item root
            itemRoot = new PluginConnectorItem("itemRoot");
            itemRoot.SetParent(itemRoot);

            // add plugin identification items
            var ci = itemRoot.AddChild(new PluginConnectorItem("SymbiotePlugin"));
            ci.AddChild(new PluginConnectorItem("Name", typeof(string), "immediate:" + Name));
            ci.AddChild(new PluginConnectorItem("Namespace", typeof(string), "immediate:" + Namespace));
            ci.AddChild(new PluginConnectorItem("PluginType", typeof(PluginManager.PluginType), "immediate:" + Namespace));
        }

        public List<IConnectorItem> Browse(IConnectorItem root)
        {
            return (root == null ? itemRoot.Children : root.Children);
        }
    }

    public class PluginConnectorItem : IConnectorItem
    {
        public IConnectorItem Parent { get; private set; }
        public string Name { get; private set; }
        public string Path { get; private set; }
        public string FQN { get; private set; }
        public Type Type { get; private set; }
        public string SourceAddress { get; private set; }
        public List<IConnectorItem> Children { get; private set; }

        public PluginConnectorItem(string name) : this(name, typeof(void), "") { }
        public PluginConnectorItem(string name, Type type, string sourceAddress)
        {
            Name = name;
            Path = "";
            FQN = "";
            Type = type;
            SourceAddress = sourceAddress;
            Children = new List<IConnectorItem>();
        }

        public bool HasChildren()
        {
            return (Children.Count > 0);
        }

        public IConnectorItem AddChild(IConnectorItem child)
        {
            Children.Add(child.SetParent(this));
            return child;
        }

        public IConnectorItem SetParent(IConnectorItem parent)
        {
            Path = parent.FQN;
            FQN = Path + "." + Name;
            return this;
        }

        public void Refresh()
        {

        }
    }
}
