using Newtonsoft.Json;
using Symbiote.Core.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Platform.UNIX
{
    public class PlatformConnectorItem : Composite
    {
        public PlatformConnectorItem() : base() { }
        public PlatformConnectorItem(string fqn) : base(fqn) { }
        [JsonConstructor]
        public PlatformConnectorItem(string fqn, Type type) : base(fqn, type) { }
        public PlatformConnectorItem(string fqn, Type type, string sourceAddress) : base(fqn, type, sourceAddress) { }
        public PlatformConnectorItem(string fqn, bool isRootItem) : base(fqn, isRootItem) { }
        public PlatformConnectorItem(string fqn, string sourceAddress) : base(fqn, sourceAddress) { }
        public PlatformConnectorItem(string fqn, Type type, string sourceAddress, bool isRootItem) : base(fqn, type, sourceAddress, isRootItem) { }

        public override string ToString()
        {
            string children = "";

            foreach (PlatformConnectorItem pci in Children)
            {
                children += ", " + pci.ToString();
            }

            return "Name = " + Name + "; Path = " + Path + "; FQN = " + FQN + "; Type: " + Type.ToString() + " Guid: " + Guid + " Children: [" + children + "]";
        }
    }
}
