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
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Utility.OperationResult;

namespace Symbiote.SDK
{
    /// <summary>
    ///     Represents a single data entity within the application Model.
    /// </summary>
    /// <remarks>The implementation of the <see cref="ICloneable"/> interface for this class returns a shallow copy.</remarks>
    public class Item : ICloneable
    {
        #region Protected Fields

        /// <summary>
        ///     Lock for the <see cref="Item.Children"/> property.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]
        protected object childrenLock = new object();

        /// <summary>
        ///     Lock for the <see cref="Item.Parent"/> property.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]
        protected object parentLock = new object();

        /// <summary>
        ///     Lock for the <see cref="Item.Value"/> property.
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
        /// <param name="sourceFQN">The Fully Qualified Name of the source Item.</param>
        public Item(string fqn, string sourceFQN) : this(fqn, default(Item), sourceFQN, false)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Item"/> class with the specified Fully Qualified name and source Item.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="sourceItem">The source Item.</param>
        public Item(string fqn, Item sourceItem) : this(fqn, sourceItem, sourceItem?.FQN, false)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Item"/> class with the specified Fully Qualified Name and type. If
        ///     isRoot is true, marks the Item as the root item in a model.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="sourceItem">The source Item.</param>
        /// <param name="sourceFQN">The Fully Qualified Name of the source Item.</param>
        /// <param name="isRoot">True if the Item is to be created as a root model Item, false otherwise.</param>
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
                Parent = this;
            }

            Writeable = true;
        }

        #endregion Public Constructors

        #region Public Events

        /// <summary>
        ///     Fires when the <see cref="Value"/> property changes.
        /// </summary>
        public virtual event EventHandler<ItemChangedEventArgs> Changed;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        ///     Gets the collection of children <see cref="Item"/> s.
        /// </summary>
        public List<Item> Children { get; private set; }

        /// <summary>
        ///     Gets the Fully Qualified Name.
        /// </summary>
        public string FQN { get; private set; }

        /// <summary>
        ///     Gets the <see cref="Guid"/>.
        /// </summary>
        /// <remarks>Generated upon instantiation.</remarks>
        public Guid Guid { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether the <see cref="Children"/> collection is empty.
        /// </summary>
        public bool HasChildren
        {
            get
            {
                return Children.Count > 0;
            }
        }

        /// <summary>
        ///     Gets a value indicating whether the <see cref="Parent"/> property has been set.
        /// </summary>
        public bool IsOrphaned
        {
            get
            {
                return Parent == default(Item);
            }
        }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <remarks>Corresponds to the final tuple of the <see cref="FQN"/> property.</remarks>
        public string Name
        {
            get
            {
                return FQN.Substring(FQN.LastIndexOf('.') + 1);
            }
        }

        /// <summary>
        ///     Gets the parent Item.
        /// </summary>
        public Item Parent { get; private set; }

        /// <summary>
        ///     Gets the path.
        /// </summary>
        /// <remarks>Corresponds to the value of the <see cref="FQN"/> property, less the final tuple.</remarks>
        public string Path
        {
            get
            {
                return FQN.Substring(0, FQN.LastIndexOf(".") == -1 ? 0 : FQN.LastIndexOf("."));
            }
        }

        /// <summary>
        ///     Gets or sets the Fully Qualified Name of the source Item.
        /// </summary>
        public string SourceFQN { get; set; }

        /// <summary>
        ///     Gets or sets the Item instance resolved from the <see cref="SourceFQN"/> property.
        /// </summary>
        public Item SourceItem { get; set; }

        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        public object Value { get; protected set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the <see cref="Value"/> property is capable of being written to.
        /// </summary>
        public bool Writeable { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Adds the supplied <see cref="Item"/> to the <see cref="Children"/> collection.
        /// </summary>
        /// <param name="item">The Item to add.</param>
        /// <returns>A Result containing the result of the operation and the added Item.</returns>
        /// <threadsafety instance="true"/>
        public virtual Result<Item> AddChild(Item item)
        {
            Result<Item> retVal = new Result<Item>();

            if (item != default(Item))
            {
                // set the new child's parent to this before adding it
                Result<Item> setResult = item.SetParent(this);

                // lock the Children collection
                lock (childrenLock)
                {
                    // add the new item
                    Children.Add(setResult.ReturnValue);
                    retVal.ReturnValue = setResult.ReturnValue;
                }

                retVal.Incorporate(setResult);
            }
            else
            {
                retVal.AddError("Invalid Item; specified Item is null or default.");
            }

            return retVal;
        }

        /// <summary>
        ///     Creates and returns a clone of this Item.
        /// </summary>
        /// <remarks>We aren't using .MemberWiseClone() because of the GUID. We need a "deep copy".</remarks>
        /// <returns>A shallow copy of this Item.</returns>
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
        ///     Creates and returns a clone of this Item with the specified Fully Qualified Name.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name with which this Item's FQN is to be replaced.</param>
        /// <returns>A shallow copy of this Item with the FQN substituted for the specified value.</returns>
        public virtual object CloneAs(string fqn)
        {
            Item retVal = (Item)Clone();
            retVal.FQN = fqn;
            return retVal;
        }

        /// <summary>
        ///     Returns the value of the <see cref="Value"/> property.
        /// </summary>
        /// <returns>The retrieved value.</returns>
        public virtual object Read()
        {
            return Value;
        }

        /// <summary>
        ///     Asynchronously returns the value of the <see cref="Value"/> property.
        /// </summary>
        /// <returns>The retrieved value.</returns>
        public virtual async Task<object> ReadAsync()
        {
            return await Task.Run(() => Read());
        }

        /// <summary>
        ///     Reads this Item's value from its <see cref="SourceItem"/> and updates the <see cref="Value"/> property with the
        ///     result. If this Item has children, ReadFromSource() is also executed on each child.
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
        ///     Asynchronously reads the value from the <see cref="SourceItem"/> and updates the <see cref="Value"/> property with
        ///     the result. If this Item has children, ReadFromSource() is also executed on each child.
        /// </summary>
        /// <returns>The retrieved value.</returns>
        public virtual async Task<object> ReadFromSourceAsync()
        {
            return await Task.Run(() => ReadFromSource());
        }

        /// <summary>
        ///     Removes the specified Item from the <see cref="Children"/> collection.
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
        ///     Notifies this Item that the number of subscribers to the <see cref="Changed"/> event has changed.
        /// </summary>
        public virtual void SubscriptionsChanged()
        {
        }

        /// <summary>
        ///     Adds the <see cref="SourceItemChanged(object, ItemChangedEventArgs)"/> event handler to the
        ///     <see cref="SourceItem"/>'s <see cref="Changed"/> event.
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
        ///     Returns the serialization of this Item using the default <see cref="ContractResolver"/>.
        /// </summary>
        /// <returns>The serialization of the Item.</returns>
        public virtual string ToJson()
        {
            return ToJson(new ContractResolver(new List<string>(new string[] { "Parent", "SourceItem", "Children" }), ContractResolverType.OptOut, true));
        }

        /// <summary>
        ///     Returns the serialization of this Item using the supplied <see cref="ContractResolver"/>.
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
        ///     Removes the <see cref="SourceItemChanged"/> event handler from the <see cref="SourceItem"/>'s <see cref="Changed"/> event.
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
        ///     Writes the provided value to the <see cref="Value"/> property.
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
                    OnChange(value, previousValue);
                }
            }

            return retVal;
        }

        /// <summary>
        ///     Asynchronously writes the provided value to the <see cref="Value"/> property.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual async Task<Result> WriteAsync(object value)
        {
            return await Task.Run(() => Write(value));
        }

        /// <summary>
        ///     Writes the provided value to the <see cref="SourceItem"/>.
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
        ///     Asynchronously writes the provided value to the <see cref="SourceItem"/>.
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
        ///     Raises the <see cref="Changed"/> event with a new instance of <see cref="ItemChangedEventArgs"/> containing the
        ///     specified value.
        /// </summary>
        /// <param name="value">The value for the raised event.</param>
        /// <param name="previousValue">The value of the Item prior to the event.</param>
        protected virtual void OnChange(object value, object previousValue)
        {
            if (Changed != null)
            {
                Changed(this, new ItemChangedEventArgs(value, previousValue));
            }
        }

        /// <summary>
        ///     Sets the parent Item to the supplied Item.
        /// </summary>
        /// <param name="parent">The Item to set as the Item's parent.</param>
        /// <threadsafety instance="true"/>
        /// <returns>A Result containing the result of the operation and the current Item.</returns>
        protected virtual Result<Item> SetParent(Item parent)
        {
            Result<Item> retVal = new Result<Item>();

            // lock the Parent property
            lock (parentLock)
            {
                FQN = (this != parent ? parent.FQN + "." : string.Empty) + Name;
                Parent = parent;
            }

            retVal.ReturnValue = this;
            return retVal;
        }

        /// <summary>
        ///     Event Handler for the <see cref="Changed"/> event belonging to the SourceItem.
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