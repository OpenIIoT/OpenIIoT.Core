using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Symbiote.Core
{
    /// <summary>
    /// A semi-generic container impementing the Composite design pattern
    /// </summary>
    [JsonObject]
    public class Item 
    {
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
        public Item Parent { get; private set; }
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
        /// The value of the composite item.
        /// </summary>
        /// <remarks>The access modifier used is protected to restrict access to this class and others derived from it</remarks>
        [JsonIgnore]
        protected object Value { get; set; }

        /// <summary>
        /// A Guid for the Item, generated when it is instantiated.
        /// </summary>
        /// <remarks>Non-serializing.</remarks>
        [JsonIgnore]
        public Guid Guid { get; set; }

        public bool IsDataStructure { get; private set; }

        [JsonIgnore]
        public bool IsDataMember { get; private set; }

        /// <summary>
        /// The collection of Items contained within this Item.
        /// </summary>
        /// <remarks>Non-serializing.</remarks>
        [JsonIgnore]
        public List<Item> Children { get; private set; }

        public bool IsReadable { get { return true; } }
        public bool IsWriteable { get { return true; } }

        /// <summary>
        /// An empty constructor used for instantiating the root node of a model.
        /// </summary>
        public Item() : this("", typeof(object), "", false, false, true) { }

        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name to be used as the root of a model.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="isRoot">True if the item is to be created as a root model item, false otherwise.</param>
        public Item(string fqn, bool isRoot) : this(fqn, typeof(object), "", false, false, isRoot) { }

        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name and type.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="type">The Type of the Item's value.</param>
        /// <param name="sourceAddress">The Fully Qualified Name of the source item.</param>
        /// <param name="isDataStructure">True if the item is a data structure containing members (rather than a logical grouping such as a folder), false otherwise.</param>
        /// <remarks>This constructor is used for deserialization.</remarks>
        [JsonConstructor]
        public Item(string fqn, Type type, string sourceAddress, bool isDataStructure) : this(fqn, type, sourceAddress, isDataStructure, false, false) { }

        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name and type.  If isRoot is true, marks the Item as the root item in a model.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="type">The Type of the Item's value.</param>
        /// <param name="sourceAddress">The Fully Qualified Name of the source item.</param>
        /// <param name="isDataStructure">True if the item is a data structure containing members (rather than a logical grouping such as a folder), false otherwise.</param>
        /// <param name="isDataMember">True if the item is a data member contained within a data structure, false otherwise.</param>
        /// <param name="isRoot">True if the item is to be created as a root model item, false otherwise.</param>
        public Item(string fqn, Type type = null, string sourceAddress = "", bool isDataStructure = false, bool isDataMember = false, bool isRoot = false) 
        {
            FQN = fqn;
            Type = (type == null ? typeof(object) : type);
            SourceAddress = sourceAddress;
            IsDataStructure = isDataStructure;
            IsDataMember = isDataMember;

            // generate Name and Path from FQN
            string[] splitFQN = fqn.Split('.');

            // set the name.  if it is blank after the split, there was only one tuple in the FQN, so name = fqn
            Name = splitFQN[splitFQN.Length - 1];
            if (Name == "") Name = FQN;

            Path = String.Join(".",splitFQN.Take(splitFQN.Length - 1));

            // create a unique Guid for this item.  useful for debugging.
            Guid = System.Guid.NewGuid();

            // instantiate the list of children
            Children = new List<Item>();

            // if we are creating the root item, make Parent self-referential.
            if (isRoot)
            {
                FQN = Name;
                Path = FQN;
                Parent = this;
            }

        }

        /// <summary>
        /// Sets the Item's parent Item to the supplied Item.
        /// </summary>
        /// <param name="parent">The Item to set as the Item's parent.</param>
        /// <returns>The current Item.</returns>
        public Item SetParent(Item parent)
        {
            // update the Path and FQN to match the parent values
            // this is set in the constructor however this code will prevent issues if items are moved.
            Path = parent.FQN;
            FQN = Path + '.' + Name;
            Parent = parent;

            if (parent.IsDataStructure || parent.IsDataMember)
                DesignateAsDataMember();

            return this;
        }

        public Item AddChild(Item item)
        {
            Children.Add(item.SetParent(this));
            return item;
        }

        public Item RemoveChild(Item item)
        {
            Item retVal = Children.Find(i => i.FQN == item.FQN);
            Children.Remove(retVal);
            return retVal;
        }

        public bool HasChildren()
        {
            return (Children.Count > 0);
        }

        public Item DesignateAsDataStucture()
        {
            IsDataStructure = true;

            // if a parent is a data structure, all items beneath it are data members
            // designate all first-generation children as members; the designation will recurse through the 
            // DesignateAsDataMember() function.
            foreach (Item child in Children)
                child.DesignateAsDataMember();

            return this;
        }

        public Item DesignateAsDataMember()
        {
            if (Parent.IsDataStructure || Parent.IsDataMember)
            {
                IsDataMember = true;

                // if a parent item is a data member, that item's children are also members.
                // designate all if the first-generation children as members; the designation will recurse.
                foreach (Item child in Children)
                    child.DesignateAsDataMember();

                return this;
            }
            else
                throw new ParentNotDataStructureNorMemberException("Unable to set item as data member; parent is neither a data structure nor member.");
        }

        public virtual object Read()
        {
            if (!IsReadable)
                throw new ItemNotReadableException("Error writing to '" + this.FQN + "'; the item is not writeable.");

            return Value;
        }

        public virtual Task<object> ReadAsync()
        {
            if (!IsReadable)
                throw new ItemNotReadableException("Error writing to '" + this.FQN + "'; the item is not writeable.");

            return null;
        }

        public virtual bool Write(object value)
        {
            if (!IsWriteable)
                throw new ItemNotWriteableException("Error writing to '" + this.FQN + "'; the item is not writeable.");

            Value = value;
            return true;
        }

        public virtual Task<bool> WriteAsync(object value)
        {
            if (!IsWriteable)
                throw new ItemNotWriteableException("Error writing to '" + this.FQN + "'; the item is not writeable.");

            return null;
        }

        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public virtual bool IsValid()
        {
            return ((FQN != null) && (FQN.Length > 1) && (Type != null));
        }
    }
}
