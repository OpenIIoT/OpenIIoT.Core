using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Model
{
    [JsonObject]
    public class Item : Composite
    {
        public Item() : base() { }
        public Item(string name) : base(name) { }
        public Item(string name, Type type) : base(name, type) { }
        public Item(string name, bool isRootItem) : base(name, isRootItem) { }
        public Item(string name, Type type, bool isRootItem) : base(name, type, isRootItem) { }
    }
}
