using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Symbiote.Core.Plugin.Connector;

namespace Symbiote.Core.Model
{
    /// <summary>
    /// A semi-generic container impementing the Composite design pattern
    /// </summary>
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
        public string Path { get; set; }

        /// <summary>
        /// The fully qualified name name of the source item.
        /// </summary>
        public string SourceFQN { get; set; }

        /// <summary>
        /// The Item instance resolved from the SourceFQN.
        /// </summary>
        public Item SourceItem { get; set; }
        
        /// <summary>
        /// A Guid for the Item, generated when it is instantiated.
        /// </summary>
        public Guid Guid { get; private set; }

        /// <summary>
        /// True if this item is writeable, false otherwise.  If false, write methods will throw an error when called.
        /// </summary>
        public bool Writeable { get; set; }

        /// <summary>
        /// The value of the composite item.
        /// </summary>
        public object Value { get; protected set; }
        
        /// <summary>
        /// The collection of Items contained within this Item.
        /// </summary>
        public List<Item> Children { get; private set; }

        #endregion

        #region Events

        /// <summary>
        /// The Changed event; fires when the value of the item changes.
        /// </summary>
        public event EventHandler<ItemEventArgs> Changed;

        /// <summary>
        /// The EventHandler for the Changed event.
        /// </summary>
        /// <typeparam name="ItemEventArgs">The Type of EventArgs for the EventHandler.</typeparam>
        /// <param name="sender">The Item that raised the event.</param>
        /// <param name="e">The instance of ItemEventArgs belonging to the event.</param>
        public delegate void EventHandler<ItemEventArgs>(Item sender, ItemEventArgs e);

        #endregion

        #region Constructors

        /// <summary>
        /// An empty constructor used for instantiating the root node of a model.
        /// </summary>
        public Item() : this("", "", true) { }

        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name to be used as the root of a model.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="isRoot">True if the item is to be created as a root model item, false otherwise.</param>
        public Item(string fqn, bool isRoot) : this(fqn, "", isRoot) { }

        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name and type.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="sourceFQN">The Fully Qualified Name of the source item.</param>
        /// <remarks>This constructor is used for deserialization.</remarks>
        public Item(string fqn, string sourceFQN) : this(fqn, sourceFQN, false) { }

        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name and type.  If isRoot is true, marks the Item as the root item in a model.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="sourceFQN">The Fully Qualified Name of the source item.</param>
        /// <param name="isRoot">True if the item is to be created as a root model item, false otherwise.</param>
        public Item(string fqn, string sourceFQN = "", bool isRoot = false) 
        {
            FQN = fqn;
            SourceFQN = sourceFQN;

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

            Writeable = true;
        }

        #endregion

        #region Instance Methods

        #region ICloneable Implementation

        /// <summary>
        /// Creates and returns a clone of the Item.
        /// </summary>
        /// <remarks>We aren't using .MemberWiseClone() because of the GuID.  We need a "deep copy".</remarks>
        /// <returns>A clone of the Item.</returns>
        public virtual object Clone()
        {
            Item retVal = new Item(FQN, SourceFQN, (Parent == this));
            retVal.Name = Name;
            retVal.Path = Path;
            retVal.Parent = Parent;
            retVal.Children = Children.Clone<Item>();
            return retVal;
        }

        #endregion

        #region Overridden Methods

        /// <summary>
        /// Returns the string representation of the object.
        /// </summary>
        /// <returns>The string representation of the object.</returns>
        public override string ToString()
        {
            return FQN;
        }

        #endregion

        /// <summary>
        /// Sets the Item's parent Item to the supplied Item.
        /// </summary>
        /// <param name="parent">The Item to set as the Item's parent.</param>
        /// <returns>A Result containing the result of the operation and the current Item.</returns>
        public virtual Result<Item> SetParent(Item parent)
        {
            Result<Item> retVal = new Result<Item>();

            // update the Path and FQN to match the parent values
            // this is set in the constructor however this code will prevent issues if items are moved.
            Path = parent.FQN;
            FQN = Path + '.' + Name;
            Parent = parent;

            retVal.ReturnValue = this;
            return retVal;
        }

        /// <summary>
        /// Adds the supplied item to this Item's Children collection.
        /// </summary>
        /// <param name="item">The Item to add.</param>
        /// <returns>A Result containing the result of the operation and the added Item.</returns>
        public virtual Result<Item> AddChild(Item item)
        {
            Result<Item> retVal = new Result<Item>();
           
            if (item != default(Item))
            {
                // set the new child's parent to this before adding it
                Result<Item> setResult = item.SetParent(this);

                // ensure that went ok
                if (setResult.ResultCode != ResultCode.Failure)
                {
                    // add the new item
                    Children.Add(setResult.ReturnValue);
                    retVal.ReturnValue = setResult.ReturnValue;
                }

                retVal.Incorporate(setResult);
            }

            return retVal;
        }

        /// <summary>
        /// Removes the specified child Item from this Item's Children collection.
        /// </summary>
        /// <param name="item">The Item to remove.</param>
        /// <returns>A Result containing the result of the operation and the removed Item.</returns>
        public virtual Result<Item> RemoveChild(Item item)
        {
            Result<Item> retVal = new Result<Item>();

            retVal.ReturnValue = Children.Find(i => i.FQN == item.FQN);

            if (retVal.ReturnValue == default(Item))
                retVal.AddError("Failed to find the item '" + item.FQN + "' in the list of children for '" + FQN + "'.");
            else
            {
                if (!Children.Remove(retVal.ReturnValue))
                    retVal.AddError("Failed to remove the item '" + item.FQN + "' from '" + FQN + "'.");
            }
            
            return retVal;
        }

        /// <summary>
        /// Returns true if the Item has children, false otherwise.
        /// </summary>
        /// <returns>True if the Item has children, false otherwise.</returns>
        public virtual bool HasChildren()
        {
            return (Children.Count > 0);
        }

        /// <summary>
        /// Returns the value of this Item's Value property.
        /// </summary>
        /// <returns>The retrieved value.</returns>
        public virtual object Read()
        {
            return Value;
        }

        /// <summary>
        /// Asynchronously returns the value of this Item's Value property.
        /// </summary>
        /// <returns>The retrieved value.</returns>
        public virtual async Task<object> ReadAsync()
        {
            return await Task.Run(() => Read());
        }

        /// <summary>
        /// Reads this Item's Value from its SourceItem.  If this Item has children,
        /// ReadFromSource() is also executed on each child.
        /// </summary>
        /// <returns>The retrieved value.</returns>
        public virtual object ReadFromSource()
        {
            object retVal;

            // recursively call ReadFromSource() on each child below this Item
            if (HasChildren())
                foreach (Item child in Children)
                    child.ReadFromSource();

            // ensure the SourceItem exists before trying to read it
            if ((SourceItem != null) && (SourceItem != default(Item)))
            {
                retVal = SourceItem.ReadFromSource();
                Write(retVal);
            }

            return Read();
        }

        /// <summary>
        /// Asynchronously reads this Item's Value from its SourceItem.  If this item has children,
        /// ReadFromSource() is also executed on each child.
        /// </summary>
        /// <returns>The retrieved value.</returns>
        public virtual async Task<object> ReadFromSourceAsync()
        {
            return await Task.Run(() => ReadFromSource());
        }

        /// <summary>
        /// Adds the SourceItemChanged event handler for this Item to the SourceItem's Changed event.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual Result SubscribeToSource()
        {
            Result retVal = new Result();

            try
            {
                SourceItem.Changed += SourceItemChanged;

                // if we are subscribing to a ConnectorItem, subscribe the source item to it's connector's ItemChanged event.
                if (SourceItem is ConnectorItem)
                {
                    Result sourceSubscription = ((ConnectorItem)SourceItem).SubscribeToSource();

                    if (sourceSubscription.ResultCode == ResultCode.Failure)
                        retVal.AddWarning("Failed to subscribe SourceItem to it's Connector source.");

                    retVal.Incorporate(sourceSubscription);
                }
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception caught while subscribing '" + FQN + "' to source item '" + SourceItem.FQN + "': " + ex.Message);
            }
            return retVal;
        }

        /// <summary>
        /// Removes the SourceItemChanged event handler for this Item from the SourceItem's Changed event.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual Result UnsubscribeFromSource()
        {
            Result retVal = new Result();

            try
            {
                SourceItem.Changed -= SourceItemChanged;
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception caught while unsubscribing '" + FQN + "' from source item '" + SourceItem.FQN + "': " + ex.Message);
            }

            return retVal;
        }

        /// <summary>
        /// Writes the provided value to this Item's Value property.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual Result Write(object value)
        {
            Result retVal = new Result();

            if (!Writeable)
                retVal.AddError("Unable to write to '" + FQN + "'; the item is not writeable.");
            else
            {
                Value = value;
                OnChange(value);
            }

            return retVal;
        }

        /// <summary>
        /// Asynchronously writes the provided value to this Item's Value property.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual async Task<Result> WriteAsync(object value)
        {
            return await Task.Run(() => Write(value));
        }

        /// <summary>
        /// Writes the provided value to this Item's SourceItem.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual Result WriteToSource(object value)
        {
            Result retVal = new Result();

            if (!SourceItem.Writeable)
                retVal.AddError("Unable to write to the source item for '" + FQN + "'; the source item is not writeable.");
            else if ((SourceItem == null) || (SourceItem == default(Item)))
                retVal.AddError("Unable to write to the source item for '" + FQN + "'; the source item is null.");
            else
            {
                Result writeResult = SourceItem.WriteToSource(value);
                if (writeResult.ResultCode != ResultCode.Failure)
                    Write(value);

                retVal.Incorporate(writeResult);
            }

            return retVal;
        }

        /// <summary>
        /// Asynchronously writes the provided value to this Item's SourceItem.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual async Task<Result> WriteToSourceAsync(object value)
        {
            return await Task.Run(() => SourceItem.WriteToSource(value));
        }

        /// <summary>
        /// Returns the serialization of the Item using the default ContractResolver.
        /// </summary>
        /// <returns>The serialization of the Item.</returns>
        public virtual string ToJson()
        {
            return ToJson(new ContractResolver(new List<string>(new string[] { "Parent", "SourceItem", "Children" }), ContractResolver.ContractResolverType.OptOut, true));
        }

        /// <summary>
        /// Returns the serialization of the Item using the supplied ContractResolver.
        /// </summary>
        /// <param name="contractResolver">The ContractResolver with which the Item is to be serialized.</param>
        /// <returns>The serialization of the Item.</returns>
        public virtual string ToJson(DefaultContractResolver contractResolver)
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { ContractResolver = contractResolver });
        }

        /// <summary>
        /// Raises the Changed event with a new instance of ItemEventArgs containing the specified value.
        /// </summary>
        /// <param name="value">The value for the raised event.</param>
        protected virtual void OnChange(object value)
        {
            if (Changed != null)
                Changed(this, new ItemEventArgs(value));
        }

        #region Event Handlers

        /// <summary>
        /// Event Handler for the Changed event belonging to the SourceItem.
        /// </summary>
        /// <param name="sender">The Item that raised the event.</param>
        /// <param name="e">The EventArgs for the event.</param>
        protected virtual void SourceItemChanged(Item sender, ItemEventArgs e)
        {
            Write(e.Value);
        }

        #endregion

        #endregion
    }
}
