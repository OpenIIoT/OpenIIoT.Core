using Symbiote.Core.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Platform.UNIX
{
    public class PlatformConnectorItem : IConnectorItem
    {
        public IConnectorItem Parent { get; private set; }
        public string Name { get; private set; }
        public string Path { get; private set; }
        public string FQN { get; private set; }
        public Type Type { get; private set; }
        public string SourceAddress { get; private set; }
        public List<IConnectorItem> Children { get; private set; }
        public string InstanceName { get; private set; }

        public PlatformConnectorItem(string name) : this(name, typeof(void), "", false, "") { }
        public PlatformConnectorItem(string name, Type type) : this(name, type, "", false, "") { }
        public PlatformConnectorItem(string name, bool isRoot, string instanceName) : this(name, typeof(void), "", isRoot, instanceName) { }
        public PlatformConnectorItem(string name, Type type, string sourceAddress) : this(name, type, sourceAddress, false, "") { }
        public PlatformConnectorItem(string name, Type type, string sourceAddress, bool isRoot, string instanceName)
        {
            Name = name;
            Path = "";
            FQN = "";
            Type = type;
            SourceAddress = sourceAddress;
            Children = new List<IConnectorItem>();

            if (isRoot)
            {
                InstanceName = instanceName;
                this.FQN = InstanceName;
                this.SetParent(this);
            }
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
    }
}
