using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbiote.Core.Plugin;
using Newtonsoft.Json;

namespace Symbiote.Core
{
    [JsonObject]
    public abstract class Composite : IComposite
    {
        private object Value;

        // only serialize FQN and Type; the rest is either internal or can be derived
        public string FQN { get; set; }
        public Type Type { get; set; }

        // don't serialize these fields
        [JsonIgnore]
        public IComposite Parent { get; private set; }
        [JsonIgnore]
        public string Name { get; set; }
        [JsonIgnore]
        public string Path { get; set; }
        [JsonIgnore]
        public Guid Guid { get; set; }
        [JsonIgnore]
        public List<IComposite> Children { get; private set; }

        public Composite() : this("", true) { }
        public Composite(string fqn) : this(fqn, typeof(object), false) { }
        public Composite(string fqn, Type type) : this(fqn, type, false) { }
        public Composite(string fqn, bool isRoot) : this(fqn, typeof(object), isRoot) { }
        public Composite(string fqn, Type type, bool isRoot) 
        {
            FQN = fqn;
            Type = type;

            // generate Name and Path from FQN
            string[] splitFQN = fqn.Split('.');
            Name = splitFQN[splitFQN.Length - 1];
            Path = String.Join(".",splitFQN.Take(splitFQN.Length - 1));

            // create a unique Guid for this item.  useful for debugging.
            Guid = System.Guid.NewGuid();

            // instantiate the list of children
            Children = new List<IComposite>();

            // if we are creating the root item, make Parent self-referential.
            if (isRoot)
                Parent = this;
        }

        public IComposite SetParent(IComposite parent)
        {
            Path = parent.FQN;
            FQN = Path + '.' + Name;
            Parent = parent;
            return this;
        }

        public IComposite AddChild(IComposite item)
        {
            Children.Add(item.SetParent(this));
            return this;
        }

        public object Write(object value)
        {
            Value = value;
            // todo: persistence goes here
            return this;
        }

        public object Read()
        {
            return Value;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public bool IsValid()
        {
            return ((Name != null) && (Name.Length > 1) && (Type != null));
        }
    }
}
