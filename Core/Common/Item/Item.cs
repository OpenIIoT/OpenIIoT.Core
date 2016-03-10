using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Symbiote.Core;

namespace Symbiote.Core
{
    /// <summary>
    /// A semi-generic container impementing the Composite design pattern
    /// </summary>
    [JsonObject]
    public class Item : ICloneable
    {
        #region Properties

        /// <summary>
        /// The Item's parent Item.
        /// </summary>
        public Item Parent { get; private set; }

        /// <summary>
        /// The name of the Item; corresponds to the final tuple of the FQN.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Fully Qualified Name of the item.
        /// </summary>
        public string FQN { get; set; }
        
        /// <summary>
        /// The path to the Item; corresponds to the FQN less the final tuple (the name).
        /// </summary>
        /// <remarks>Non-serializing.</remarks>
        public string Path { get; set; }

        /// <summary>
        /// The fully qualified name name of the source item
        /// </summary>
        public string SourceAddress { get; set; }

        /// <summary>
        /// The Item instance resolved from the SourceAddress.
        /// </summary>
        public Item SourceItem { get; set; }
        
        /// <summary>
        /// The Type of the item.
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// A Guid for the Item, generated when it is instantiated.
        /// </summary>
        public Guid Guid { get; private set; }

        /// <summary>
        /// True if this item is a data structure containing members, false otherwise.
        /// </summary>
        public bool IsDataStructure { get { return (Type == typeof(Structure)); } }

        /// <summary>
        /// True if this item is an array or a collection, false otherwise.
        /// </summary>
        public bool IsArray { get { return ((Type.IsArray) || (Type.Namespace.Contains("System.Collections"))); } }

        /// <summary>
        /// True if this item is part of a data structure, false otherwise.
        /// </summary>
        public bool IsDataMember { get { return (((Parent == null) || (Parent == this)) ? false : ((Parent.IsDataStructure) || (Parent.IsDataMember))); } }

        /// <summary>
        /// True if this item is readable, false otherwise.  If false, read methods will throw an error when called.
        /// </summary>
        public bool IsReadable { get { return true; } }

        /// <summary>
        /// True if this item is writeable, false otherwise.  If false, write methods will throw an error when called.
        /// </summary>
        public bool IsWriteable { get { return true; } }

         /// <summary>
        /// The value of the composite item.
        /// </summary>
        public object Value { get; protected set; }
        
        /// <summary>
        /// The collection of Items contained within this Item.
        /// </summary>
        public List<Item> Children { get; private set; }

        #endregion

        public event EventHandler<ItemEventArgs> Changed;
        public delegate void EventHandler<ItemEventArgs>(Item sender, ItemEventArgs e);

        #region Constructors

        /// <summary>
        /// An empty constructor used for instantiating the root node of a model.
        /// </summary>
        public Item() : this("", typeof(object), "", true) { }

        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name to be used as the root of a model.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="isRoot">True if the item is to be created as a root model item, false otherwise.</param>
        public Item(string fqn, bool isRoot) : this(fqn, typeof(object), "", isRoot) { }

        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name and type.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="type">The Type of the Item's value.</param>
        /// <param name="sourceAddress">The Fully Qualified Name of the source item.</param>
        /// <remarks>This constructor is used for deserialization.</remarks>
        [JsonConstructor]
        public Item(string fqn, Type type, string sourceAddress) : this(fqn, type, sourceAddress, false) { }

        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name and type.  If isRoot is true, marks the Item as the root item in a model.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="type">The Type of the Item's value.</param>
        /// <param name="sourceAddress">The Fully Qualified Name of the source item.</param>
        /// <param name="isRoot">True if the item is to be created as a root model item, false otherwise.</param>
        public Item(string fqn, Type type = null, string sourceAddress = "", bool isRoot = false) 
        {
            FQN = fqn;
            Type = (type == null ? typeof(object) : type);
            SourceAddress = sourceAddress;

            Value = "";

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

        #endregion

        #region Instance Methods

        /// <summary>
        /// Sets the Item's parent Item to the supplied Item.
        /// </summary>
        /// <param name="parent">The Item to set as the Item's parent.</param>
        /// <returns>The current Item.</returns>
        public virtual Item SetParent(Item parent)
        {
            // update the Path and FQN to match the parent values
            // this is set in the constructor however this code will prevent issues if items are moved.
            Path = parent.FQN;
            FQN = Path + '.' + Name;
            Parent = parent;

            return this;
        }

        public virtual Item AddChild(Item item)
        {
            Children.Add(item.SetParent(this));
            return item;
        }

        public virtual Item RemoveChild(Item item)
        {
            Item retVal = Children.Find(i => i.FQN == item.FQN);
            Children.Remove(retVal);
            return retVal;
        }

        public bool HasChildren()
        {
            return (Children.Count > 0);
        }

        public virtual object Read()
        {
            if (!IsReadable)
                throw new ItemNotReadableException("Error reading from '" + this.FQN + "'; the item is not readable.");

            return Value;
        }

        public virtual Task<object> ReadAsync()
        {
            if (!IsReadable)
                throw new ItemNotReadableException("Error reading from '" + this.FQN + "'; the item is not readable.");

            // TODO: implement this
            return null;
        }

        public virtual object ReadFromSource()
        {
            if (!IsReadable)
                throw new ItemNotReadableException("Error reading from '" + this.FQN + "'; the item is not readable.");

            if ((SourceItem == null) || (SourceItem == default(Item)))
                throw new SourceItemInvalidException("Error reading '" + this.FQN + "' from source; the source Item is invalid.");

            // experimental!
            // if this item is a data structure or is a member of a data structure, call ReadFromSource() for all children.
            // eventually this code needs to be updated to find the parent data structure and call ReadFromSource() on it if this is a data member
            // this OR is really not correct but it works for now.
            if ((IsDataStructure) || (IsDataMember))
            {
                foreach (Item child in Children)
                    child.ReadFromSource();
            }

            object retVal = SourceItem.ReadFromSource();

            if ((retVal != null) && (retVal != default(object)))
                Write(retVal);

            return Value;
        }

        public virtual Task<object> ReadFromSourceAsync()
        {
            if (!IsReadable)
                throw new ItemNotReadableException("Error reading from '" + this.FQN + "'; the item is not readable.");

            // TODO: implement this
            return null;
        }

        public virtual OperationResult SubscribeToSource()
        {
            OperationResult retVal = new OperationResult();
            SourceItem.Changed += SourceItemChanged;
            return retVal;
        }

        public virtual OperationResult UnsubscribeFromSource()
        {
            OperationResult retVal = new OperationResult();
            SourceItem.Changed -= SourceItemChanged;
            return retVal;
        }

        public virtual OperationResult Write(object value)
        {
            OperationResult retVal = new OperationResult();

            if (!IsWriteable)
            {
                retVal.AddError("Error writing to '" + this.FQN + "'; the item is not writeable.");
            }
            else
            {
                Value = value;
                OnChange(value);
            }

            return retVal;
        }

        public virtual Task<OperationResult> WriteAsync(object value)
        {
            if (!IsWriteable)
                throw new ItemNotWriteableException("Error writing to '" + this.FQN + "'; the item is not writeable.");

            // TODO: implement this
            return null;
        }

        public virtual OperationResult WriteToSource(object value)
        {
            OperationResult retVal;

            if (!IsWriteable)
                retVal = new OperationResult().AddError("Error writing to '" + this.FQN + "'; the item is not writeable.");

            else if ((SourceItem == null) || (SourceItem == default(Item)))
                retVal = new OperationResult().AddError("Error writing to '" + this.FQN + "'; the item is not writeable.");

            else
                retVal = SourceItem.WriteToSource(value);


            if (retVal.ResultCode != OperationResultCode.Failure) Write(value);
            return retVal;
        }

        public virtual Task<OperationResult> WriteToSourceAsync(object value)
        {
            if (!IsWriteable)
                throw new ItemNotWriteableException("Error writing to '" + this.FQN + "'; the item is not writeable.");

            // TODO: implement this
            return null;
        }

        public virtual string ToJson()
        {
            return ToJson(new ContractResolver(new List<string>(new string[] { "Parent", "SourceItem", "Children" }), ContractResolverType.OptOut, true));
        }

        public virtual string ToJson(DefaultContractResolver contractResolver)
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { ContractResolver = contractResolver });
        }

        public virtual bool IsValid()
        {
            return ((FQN != null) && (FQN.Length > 1) && (Type != null));
        }

        /// <summary>
        /// Creates and returns a clone of the Item.
        /// </summary>
        /// <returns>A clone of the Item.</returns>
        /// <remarks>We aren't using .MemberWiseClone() because of the GuID.  We need a "deep copy".</remarks>
        public virtual object Clone()
        {
            Item retVal = new Item(FQN, Type, SourceAddress, (Parent == this));
            retVal.Name = Name;
            retVal.Path = Path;
            retVal.Parent = Parent;
            retVal.Children = Children.Clone<Item>();
            return retVal;
        }

        public override string ToString()
        {
            return FQN;
        }

        #endregion

        #region Events

        protected virtual void SourceItemChanged(Item sender, ItemEventArgs e)
        {
            Write(e.Value);
        }

        protected virtual void OnChange(object value)
        {
            if (Changed != null)
                Changed(this, new ItemEventArgs(value));
        }

        #endregion
    }
}
