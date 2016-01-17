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
        public ModelItem(string name) : base(name) { }
        public ModelItem(string name, Type type) : base(name, type) { }
        public ModelItem(string name, bool isRootItem) : base(name, isRootItem) { }
        public ModelItem(string name, Type type, bool isRootItem) : base(name, type, isRootItem) { }

        public override string ToString()
        {
            return "Name = " + Name + "; Path = " + Path + "; FQN = " + FQN + "; Type: " + Type.ToString();
        }
    }
}
