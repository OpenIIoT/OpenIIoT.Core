using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Symbiote.Core
{
    /// <summary>
    /// A semi-generic container impementing the Composite design pattern
    /// </summary>
    [JsonObject]
    public abstract class Composite : IComposite
    {
        private object Value;

        // only serialize FQN and Type; the rest is either internal or can be derived
        /// <summary>
        /// The Fully Qualified Name of the item.
        /// </summary>
        public string FQN { get; set; }
        /// <summary>
        /// The Type of the item.
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// The Item's parent Item.
        /// </summary>
        /// <remarks>Non-serializing.</remarks>
        [JsonIgnore]
        public IComposite Parent { get; private set; }
        /// <summary>
        /// The name of the Item; corresponds to the final tuple of the FQN.
        /// </summary>
        /// <remarks>Non-serializing.</remarks>
        [JsonIgnore]
        public string Name { get; set; }
        /// <summary>
        /// The path to the Item; corresponds to the FQN less the final tuple (the name).
        /// </summary>
        /// <remarks>Non-serializing.</remarks>
        [JsonIgnore]
        public string Path { get; set; }
        /// <summary>
        /// The fully qualified name name of the source item
        /// </summary>
        public string SourceAddress { get; set; }
        /// <summary>
        /// A Guid for the Item, generated when it is instantiated.
        /// </summary>
        /// <remarks>Non-serializing.</remarks>
        [JsonIgnore]
        public Guid Guid { get; set; }
        /// <summary>
        /// The collection of Items contained within this Item.
        /// </summary>
        /// <remarks>Non-serializing.</remarks>
        [JsonIgnore]
        public List<IComposite> Children { get; private set; }

        /// <summary>
        /// An empty constructor used for instantiating the root node of a model.
        /// </summary>
        public Composite() : this("", true) { }
        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name and of type 'object'.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        public Composite(string fqn) : this(fqn, typeof(object), "", false) { }
        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name and type.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="type">The Type of the Item's value.</param>
        /// <remarks>This constructor is used for deserialization.</remarks>
        [JsonConstructor]
        public Composite(string fqn, Type type) : this(fqn, type, "", false) { }
        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name, type, and with the given Source Address.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="type">The Type of the Item's value.</param>
        /// <param name="sourceAddress">The Source Address for the Item's value.</param>
        public Composite(string fqn, Type type, string sourceAddress) : this(fqn, type, sourceAddress, false) { }
        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name and of type 'object'.  If isRoot is true, marks the Item as the root item in a model.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="isRoot">True if the item is to be created as a root model item, false otherwise.</param>
        public Composite(string fqn, bool isRoot) : this(fqn, typeof(object), "", isRoot) { }
        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name and of type 'object' and with Source Address of the given source address.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="sourceAddress">The Source Address for the Item's value.</param>
        public Composite(string fqn, string sourceAddress) : this(fqn, typeof(object), sourceAddress, false) { }

        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name and type.  If isRoot is true, marks the Item as the root item in a model.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="type">The Type of the Item's value.</param>
        /// <param name="sourceAddress">The Fully Qualified Name of the source item.</param>
        /// <param name="isRoot">True if the item is to be created as a root model item, false otherwise.</param>
        public Composite(string fqn, Type type, string sourceAddress, bool isRoot) 
        {
            FQN = fqn;
            Type = type;
            SourceAddress = sourceAddress;

            // generate Name and Path from FQN
            string[] splitFQN = fqn.Split('.');

            // set the name.  if it is blank after the split, there was only one tuple in the FQN, so name = fqn
            Name = splitFQN[splitFQN.Length - 1];
            if (Name == "") Name = FQN;

            Path = String.Join(".",splitFQN.Take(splitFQN.Length - 1));

            // create a unique Guid for this item.  useful for debugging.
            Guid = System.Guid.NewGuid();

            // instantiate the list of children
            Children = new List<IComposite>();

            // if we are creating the root item, make Parent self-referential.
            if (isRoot)
            {
                FQN = Name;
                Path = "";
                Parent = this;
            }

        }

        /// <summary>
        /// Sets the Item's parent Item to the supplied Item.
        /// </summary>
        /// <param name="parent">The Item to set as the Item's parent.</param>
        /// <returns>The current Item.</returns>
        public IComposite SetParent(IComposite parent)
        {
            // update the Path and FQN to match the parent values
            // this is set in the constructor however this code will prevent issues if items are moved.
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

        public IComposite RemoveChild(IComposite item)
        {
            IComposite retVal = Children.Find(i => i.FQN == item.FQN);
            Children.Remove(retVal);
            return retVal;
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
            return ((FQN != null) && (FQN.Length > 1) && (Type != null));
        }
    }
}
