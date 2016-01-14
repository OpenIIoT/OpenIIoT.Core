using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbiote.Core.Plugin;
using Newtonsoft.Json;

namespace Symbiote.Core
{
    public abstract class Composite : IComposite
    {
        private object Value;

        [JsonIgnore]
        public IComposite Parent { get; private set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string FQN { get; set; }
        public Type Type { get; set; }
        [JsonIgnore]
        public List<IComposite> Children { get; private set; }

        public Composite() : this(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, true) { }
        public Composite(string name) : this(name, typeof(object), false) { }
        public Composite(string name, Type type) : this(name, type, false) { }
        public Composite(string name, bool isRoot) : this(name, typeof(object), isRoot) { }
        public Composite(string name, string path, string fqn, Type type) : this(name, type) { } // used for deserialization from config
        public Composite(string name, Type type, bool isRoot) 
        {
            Name = name;
            Children = new List<IComposite>();

            if (isRoot)
            {
                Path = Name;
                FQN = Name;
                Parent = this;
            }
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
    }
}
