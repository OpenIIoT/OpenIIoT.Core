using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Model
{
    [JsonObject]
    public class ModelItem : Composite
    {
        public ModelItem() : base() { }
        public ModelItem(string fqn) : base(fqn) { }
        [JsonConstructor]
        public ModelItem(string fqn, Type type) : base(fqn, type) { }
        public ModelItem(string fqn, Type type, string sourceAddress) : base(fqn, type, sourceAddress) { }
        public ModelItem(string fqn, bool isRootItem) : base(fqn, isRootItem) { }
        public ModelItem(string fqn, string sourceAddress) : base(fqn, sourceAddress) { }
        public ModelItem(string fqn, Type type, string sourceAddress, bool isRootItem) : base(fqn, type, sourceAddress, isRootItem) { }

        public override string ToString()
        {
            string children = "";

            foreach(ModelItem mi in Children)
            {
                children += ", " + mi.ToString();
            }

            return "Name = " + Name + "; Path = " + Path + "; FQN = " + FQN + "; Type: " + Type.ToString() + " Guid: " + Guid + " Children: [" + children + "]";
        }
    }
}
