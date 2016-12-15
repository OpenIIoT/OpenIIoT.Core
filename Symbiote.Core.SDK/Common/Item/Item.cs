/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█
      █   ███
      █   ███▌     ██       ▄█████    ▄▄██▄▄▄
      █   ███▌ ▀███████▄   ██   █   ▄█▀▀██▀▀█▄
      █   ███▌     ██  ▀  ▄██▄▄     ██  ██  ██
      █   ███      ██    ▀▀██▀▀     ██  ██  ██
      █   ███      ██      ██   █   ██  ██  ██
      █   █▀      ▄██▀     ███████   █  ██  █
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Represents a single data entity within the application Model.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016 JP Dillingham (jp@dillingham.ws)
      █
      █  This program is free software: you can redistribute it and/or modify
      █  it under the terms of the GNU Affero General Public License as published by
      █  the Free Software Foundation, either version 3 of the License, or
      █  (at your option) any later version.
      █
      █  This program is distributed in the hope that it will be useful,
      █  but WITHOUT ANY WARRANTY; without even the implied warranty of
      █  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      █  GNU Affero General Public License for more details.
      █
      █  You should have received a copy of the GNU Affero General Public License
      █  along with this program.  If not, see <http://www.gnu.org/licenses/>.
      █
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Symbiote.SDK.Plugin.Connector;
using Utility.OperationResult;

namespace Symbiote.SDK
{
    /// <summary>
    ///     Represents a single data entity within the application Model.
    /// </summary>
    public class Item : ICloneable
    {
        #region Protected Fields

        /// <summary>
        ///     Lock for the Children property.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]
        protected object childrenLock = new object();

        /// <summary>
        ///     Lock for the Parent property.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]
        protected object parentLock = new object();

        /// <summary>
        ///     Lock for the Value property.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]
        protected object valueLock = new object();

        #endregion Protected Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        public Item() : this(string.Empty, default(Item), string.Empty, true)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Item"/> class with the specified Fully Qualified Name to be used as
        ///     the root of a model.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="isRoot">True if the item is to be created as a root model item, false otherwise.</param>
        public Item(string fqn, bool isRoot) : this(fqn, default(Item), string.Empty, isRoot)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Item"/> class with the specified Fully Qualified Name and type.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="sourceFQN">The Fully Qualified Name of the source item.</param>
        /// <remarks>This constructor is used for deserialization.</remarks>
        public Item(string fqn, string sourceFQN) : this(fqn, default(Item), sourceFQN, false)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Item"/> class with the specified Fully Qualified name and source Item.
        /// </summary>
        /// <param name="fqn"></param>
        /// <param name="sourceItem"></param>
        public Item(string fqn, Item sourceItem) : this(fqn, sourceItem, sourceItem?.FQN, false)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Item"/> class with the specified Fully Qualified Name and type. If
        ///     isRoot is true, marks the Item as the root item in a model.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="sourceFQN">The Fully Qualified Name of the source item.</param>
        /// <param name="isRoot">True if the item is to be created as a root model item, false otherwise.</param>
        public Item(string fqn, Item sourceItem = default(Item), string sourceFQN = "", bool isRoot = false)
        {
            FQN = fqn;

            if (sourceItem != default(Item))
            {
                SourceItem = sourceItem;
                SourceFQN = sourceItem.FQN;
            }
            else
            {
                SourceFQN = sourceFQN;
            }

            Value = default(object);

            // generate Name and Path from FQN
            string[] splitFQN = fqn.Split('.');

            // create a unique Guid for this item. useful for debugging.
            Guid = Guid.NewGuid();

            // instantiate the list of children
            Children = new List<Item>();

            // if we are creating the root item, make Parent self-referential.
            if (isRoot)
            {
                FQN = Name;
                //Path = FQN;
                Parent = this;
            }

            Writeable = true;
        }

        #endregion Public Constructors

        #region Public Events

        /// <summary>
        ///     The Changed event; fires when the value of the item changes.
        /// </summary>
        public virtual event EventHandler<ItemChangedEventArgs> Changed;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        ///     Gets the collection of Items contained within this Item.
        /// </summary>
        public List<Item> Children { get; private set; }

        /// <summary>
        ///     Gets or sets the Fully Qualified Name of the item.
        /// </summary>
        public string FQN { get; private set; }

        /// <summary>
        ///     Gets a Guid for the Item, generated when it is instantiated.
        /// </summary>
        public Guid Guid { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether the Item's <see cref="Children"/> collection is empty.
        /// </summary>
        public bool HasChildren
        {
            get
            {
                return Children.Count > 0;
            }
        }

        /// <summary>
        ///     Gets a value indicating whether the Item's <see cref="Parent"/> property has been set.
        /// </summary>
        public bool IsOrphaned
        {
            get
            {
                return Parent == default(Item);
            }
        }

        /// <summary>
        ///     Gets or sets the name of the Item; corresponds to the final tuple of the FQN.
        /// </summary>
        public string Name
        {
            get
            {
                return FQN.Substring(FQN.LastIndexOf('.') + 1);
            }
        }

        /// <summary>
        ///     Gets the Item's parent Item.
        /// </summary>
        public Item Parent { get; private set; }

        /// <summary>
        ///     Gets or sets the path to the Item; corresponds to the FQN less the final tuple (the name).
        /// </summary>
        public string Path
        {
            get
            {
                return FQN.Substring(0, FQN.LastIndexOf(".") == -1 ? 0 : FQN.LastIndexOf("."));
            }
        }

        /// <summary>
        ///     Gets or sets the fully qualified name name of the source item.
        /// </summary>
        public string SourceFQN { get; set; }

        /// <summary>
        ///     Gets or sets the Item instance resolved from the SourceFQN.
        /// </summary>
        public Item SourceItem { get; set; }

        /// <summary>
        ///     Gets or sets the value of the composite item.
        /// </summary>
        public object Value { get; protected set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the Item's value is writeable.
        /// </summary>
        public bool Writeable { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Adds the supplied item to this Item's Children collection.
        /// </summary>
        /// <param name="item">The Item to add.</param>
        /// <threadsafety instance="true"/>
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
                    // lock the Children collection
                    lock (childrenLock)
                    {
                        // add the new item
                        Children.Add(setResult.ReturnValue);
                        retVal.ReturnValue = setResult.ReturnValue;
                    }
                }

                retVal.Incorporate(setResult);
            }

            return retVal;
        }

        /// <summary>
        ///     Creates and returns a clone of the Item.
        /// </summary>
        /// <remarks>We aren't using .MemberWiseClone() because of the GUID. We need a "deep copy".</remarks>
        /// <returns>A clone of the Item.</returns>
        public virtual object Clone()
        {
            Item retVal = new Item(FQN, SourceItem, SourceFQN, Parent == this);
            retVal.Parent = Parent;
            retVal.Children = Children.Clone<Item>();
            retVal.Value = Value;
            retVal.SourceItem = SourceItem;
            retVal.Writeable = Writeable;
            return retVal;
        }

        /// <summary>
        ///     Returns the value of this Item's Value property.
        /// </summary>
        /// <returns>The retrieved value.</returns>
        public virtual object Read()
        {
            return Value;
        }

        /// <summary>
        ///     Asynchronously returns the value of this Item's Value property.
        /// </summary>
        /// <returns>The retrieved value.</returns>
        public virtual async Task<object> ReadAsync()
        {
            return await Task.Run(() => Read());
        }

        /// <summary>
        ///     Reads this Item's Value from its SourceItem. If this Item has children, ReadFromSource() is also executed on each child.
        /// </summary>
        /// <returns>The retrieved value.</returns>
        public virtual object ReadFromSource()
        {
            object retVal;

            // recursively call ReadFromSource() on each child below this Item
            if (HasChildren)
            {
                foreach (Item child in Children)
                {
                    child.ReadFromSource();
                }
            }

            // ensure the SourceItem exists before trying to read it
            if ((SourceItem != null) && (SourceItem != default(Item)))
            {
                retVal = SourceItem.ReadFromSource();

                // check to see if the value read from the source is the same as the Value property. if it isn't, update the Value
                // property with the latest.
                if (retVal != Value)
                {
                    Write(retVal);
                }
            }

            return Read();
        }

        /// <summary>
        ///     Asynchronously reads this Item's Value from its SourceItem. If this item has children, ReadFromSource() is also
        ///     executed on each child.
        /// </summary>
        /// <returns>The retrieved value.</returns>
        public virtual async Task<object> ReadFromSourceAsync()
        {
            return await Task.Run(() => ReadFromSource());
        }

        /// <summary>
        ///     Removes the specified child Item from this Item's Children collection.
        /// </summary>
        /// <param name="item">The Item to remove.</param>
        /// <threadsafety instance="true"/>
        /// <returns>A Result containing the result of the operation and the removed Item.</returns>
        public virtual Result<Item> RemoveChild(Item item)
        {
            Result<Item> retVal = new Result<Item>();
            System.Diagnostics.Debug.WriteLine("Removing " + item.FQN);

            // locate the item
            retVal.ReturnValue = Children.Find(i => i.FQN == item.FQN);

            // ensure that it was found in the collection
            if (retVal.ReturnValue == default(Item))
            {
                retVal.AddError("Failed to find the item '" + item.FQN + "' in the list of children for '" + FQN + "'.");
            }
            else
            {
                // lock the Children collection
                lock (childrenLock)
                {
                    IList<Item> childrenToRemove = retVal.ReturnValue.Children.Clone();

                    // if it was found, recursively remove all children before removing the found Item
                    foreach (Item child in childrenToRemove)
                    {
                        retVal.ReturnValue.RemoveChild(child);
                    }

                    // remove the item itself
                    Children.Remove(retVal.ReturnValue);
                }
            }

            return retVal;
        }

        /// <summary>
        ///     Notifies this <see cref="Item"/> that the number of subscribers has changed.
        /// </summary>
        public virtual void SubscriptionsChanged()
        {
        }

        /// <summary>
        ///     Adds the SourceItemChanged event handler for this Item to the SourceItem's Changed event.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual Result SubscribeToSource()
        {
            Result retVal = new Result();

            if (SourceItem != default(Item) && (SourceItem != null))
            {
                SourceItem.Changed += SourceItemChanged;
                SourceItem.SubscriptionsChanged();
            }
            else
            {
                retVal.AddError("Unable to subscribe to the source item; it has not been set.");
            }

            return retVal;
        }

        /// <summary>
        ///     Returns the serialization of the Item using the default ContractResolver.
        /// </summary>
        /// <returns>The serialization of the Item.</returns>
        public virtual string ToJson()
        {
            return ToJson(new ContractResolver(new List<string>(new string[] { "Parent", "SourceItem", "Children" }), ContractResolverType.OptOut, true));
        }

        /// <summary>
        ///     Returns the serialization of the Item using the supplied ContractResolver.
        /// </summary>
        /// <param name="contractResolver">The ContractResolver with which the Item is to be serialized.</param>
        /// <returns>The serialization of the Item.</returns>
        public virtual string ToJson(DefaultContractResolver contractResolver)
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { ContractResolver = contractResolver });
        }

        /// <summary>
        ///     Returns the string representation of the object.
        /// </summary>
        /// <returns>The string representation of the object.</returns>
        public override string ToString()
        {
            return FQN;
        }

        /// <summary>
        ///     Removes the SourceItemChanged event handler for this Item from the SourceItem's Changed event.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual Result UnsubscribeFromSource()
        {
            Result retVal = new Result();

            if ((SourceItem != default(Item)) && (SourceItem != null))
            {
                SourceItem.Changed -= SourceItemChanged;
                SourceItem.SubscriptionsChanged();
            }
            else
            {
                retVal.AddError("Unable to unsubscribe from the source item; it has not been set.");
            }

            return retVal;
        }

        /// <summary>
        ///     Writes the provided value to this Item's Value property.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <threadsafety instance="true"/>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual Result Write(object value)
        {
            Result retVal = new Result();

            if (!Writeable)
            {
                retVal.AddError("Unable to write to '" + FQN + "'; the item is not writeable.");
            }
            else
            {
                lock (valueLock)
                {
                    var previousValue = Value;
                    Value = value;
                    OnChange(previousValue, Value);
                }
            }

            return retVal;
        }

        /// <summary>
        ///     Asynchronously writes the provided value to this Item's Value property.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual async Task<Result> WriteAsync(object value)
        {
            return await Task.Run(() => Write(value));
        }

        /// <summary>
        ///     Writes the provided value to this Item's SourceItem.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual Result WriteToSource(object value)
        {
            Result retVal = new Result();

            if ((SourceItem != default(Item)) && (SourceItem != null))
            {
                if (!SourceItem.Writeable)
                {
                    retVal.AddError("Unable to write to the source item for '" + FQN + "'; the source item is not writeable.");
                }
                else
                {
                    retVal.Incorporate(SourceItem.WriteToSource(value));
                }
            }

            if (retVal.ResultCode != ResultCode.Failure)
            {
                Write(value);
            }

            return retVal;
        }

        /// <summary>
        ///     Asynchronously writes the provided value to this Item's SourceItem.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual async Task<Result> WriteToSourceAsync(object value)
        {
            return await Task.Run(() => SourceItem.WriteToSource(value));
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     Raises the Changed event with a new instance of ItemEventArgs containing the specified value.
        /// </summary>
        /// <param name="value">The value for the raised event.</param>
        protected virtual void OnChange(object previousValue, object value)
        {
            if (Changed != null)
            {
                Changed(this, new ItemChangedEventArgs(previousValue, value));
            }
        }

        /// <summary>
        ///     Sets the Item's parent Item to the supplied Item.
        /// </summary>
        /// <param name="parent">The Item to set as the Item's parent.</param>
        /// <threadsafety instance="true"/>
        /// <returns>A Result containing the result of the operation and the current Item.</returns>
        protected virtual Result<Item> SetParent(Item parent)
        {
            Result<Item> retVal = new Result<Item>();

            // update the Path and FQN to match the parent values this is set in the constructor however this code will prevent
            // issues if items are moved.

            // lock the Parent property
            lock (parentLock)
            {
                //Path = parent.FQN;
                FQN = (this != parent ? parent.FQN + "." : "") + Name;

                Parent = parent;
            }

            retVal.ReturnValue = this;
            return retVal;
        }

        /// <summary>
        ///     Event Handler for the Changed event belonging to the SourceItem.
        /// </summary>
        /// <param name="sender">The Item that raised the event.</param>
        /// <param name="e">The EventArgs for the event.</param>
        protected virtual void SourceItemChanged(object sender, ItemChangedEventArgs e)
        {
            Write(e.Value);
        }

        #endregion Protected Methods
    }
}