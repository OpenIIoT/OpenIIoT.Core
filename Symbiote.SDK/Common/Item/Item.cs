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
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Utility.OperationResult;

namespace Symbiote.SDK
{
    /// <summary>
    ///     Represents a single data entity within the application Model.
    /// </summary>
    /// <remarks>The implementation of the <see cref="ICloneable"/> interface for this class returns a shallow copy.</remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]
    public class Item : ICloneable
    {
        #region Protected Fields

        /// <summary>
        ///     Lock for the <see cref="Item.Children"/> property.
        /// </summary>
        protected ReaderWriterLockSlim childrenLock = new ReaderWriterLockSlim();

        /// <summary>
        ///     Lock for the <see cref="Item.Parent"/> property.
        /// </summary>
        protected ReaderWriterLockSlim parentLock = new ReaderWriterLockSlim();

        /// <summary>
        ///     Lock for the <see cref="Item.Value"/> property.
        /// </summary>
        protected ReaderWriterLockSlim valueLock = new ReaderWriterLockSlim();

        /// <summary>
        ///     Lock for the <see cref="Item.SourceFQN"/> property.
        /// </summary>
        protected ReaderWriterLockSlim sourceFQNLock = new ReaderWriterLockSlim();

        /// <summary>
        ///     Lock for the <see cref="Item.Provider"/> property.
        /// </summary>
        protected ReaderWriterLockSlim providerLock = new ReaderWriterLockSlim();

        /// <summary>
        ///     Lock for the <see cref="Item.SourceItem"/> property.
        /// </summary>
        protected ReaderWriterLockSlim sourceItemLock = new ReaderWriterLockSlim();

        /// <summary>
        ///     Lock for the <see cref="Item.FQN"/> property.
        /// </summary>
        protected ReaderWriterLockSlim fqnLock = new ReaderWriterLockSlim();

        /// <summary>
        ///     Lock for the <see cref="Item.Quality"/> property.
        /// </summary>
        protected ReaderWriterLockSlim qualityLock = new ReaderWriterLockSlim();

        /// <summary>
        ///     Lock for the <see cref="Item.Timestamp"/> property.
        /// </summary>
        protected ReaderWriterLockSlim timestampLock = new ReaderWriterLockSlim();

        /// <summary>
        ///     Lock for the <see cref="Item.Children"/> property of child Items accessed while being removed.
        /// </summary>
        protected ReaderWriterLockSlim grandchildrenLock = new ReaderWriterLockSlim();

        #endregion Protected Fields

        #region Private Fields

        /// <summary>
        ///     The resolved source Item.
        /// </summary>
        private Item sourceItem;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Item"/> class with the specified Fully Qualified name.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        public Item(string fqn = "") : this(fqn, default(Item), string.Empty, ItemAccessMode.ReadWrite, default(IItemProvider))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Item"/> class with the specified Fully Qualified name and access mode.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="accessMode">The access mode of the Item.</param>
        /// <param name="provider">The Item Provider from which the Item originates.</param>
        public Item(string fqn, ItemAccessMode accessMode, IItemProvider provider = default(IItemProvider)) : this(fqn, default(Item), string.Empty, accessMode, provider)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Item"/> class with the specified Fully Qualified name and provider.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="provider">The Item Provider from which the Item originates.</param>
        public Item(string fqn, IItemProvider provider) : this(fqn, default(Item), string.Empty, ItemAccessMode.ReadWrite, provider)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Item"/> class with the specified Fully Qualified name, source Item,
        ///     and provider.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="sourceItem">The source Item.</param>
        /// <param name="provider">The Item Provider from which the Item originates.</param>
        public Item(string fqn, Item sourceItem, IItemProvider provider) : this(fqn, sourceItem, string.Empty, ItemAccessMode.ReadWrite, provider)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Item"/> class with the specified Fully Qualified name, source item,
        ///     access mode and provider.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="sourceItem">The source Item.</param>
        /// <param name="accessMode">The access mode of the Item.</param>
        /// <param name="provider">The Item Provider from which the Item originates.</param>
        public Item(string fqn, Item sourceItem, ItemAccessMode accessMode = ItemAccessMode.ReadWrite, IItemProvider provider = default(IItemProvider)) : this(fqn, sourceItem, string.Empty, accessMode, provider)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Item"/> class with the specified Fully Qualified name, source FQN, and provider.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="sourceFQN">The Fully Qualified Name of the source Item.</param>
        /// <param name="provider">The Item Provider from which the Item originates.</param>
        public Item(string fqn, string sourceFQN, IItemProvider provider) : this(fqn, default(Item), sourceFQN, ItemAccessMode.ReadWrite, provider)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Item"/> class with the specified Fully Qualified name, source FQN,
        ///     access mode, and provider.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="sourceFQN">The Fully Qualified Name of the source Item.</param>
        /// <param name="accessMode">The access mode of the Item.</param>
        /// <param name="provider">The Item Provider from which the Item originates.</param>
        public Item(string fqn, string sourceFQN, ItemAccessMode accessMode = ItemAccessMode.ReadWrite, IItemProvider provider = default(IItemProvider)) : this(fqn, default(Item), sourceFQN, accessMode, provider)
        {
        }

        #endregion Public Constructors

        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Item"/> class with the specified Fully Qualified Name, source Item,
        ///     source FQN, access mode and provider.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="sourceItem">The source Item.</param>
        /// <param name="sourceFQN">The Fully Qualified Name of the source Item.</param>
        /// <param name="accessMode">The access mode of the Item.</param>
        /// <param name="provider">The Item Provider from which the Item originates.</param>
        private Item(string fqn, Item sourceItem = default(Item), string sourceFQN = "", ItemAccessMode accessMode = ItemAccessMode.ReadWrite, IItemProvider provider = default(IItemProvider))
        {
            FQN = fqn;
            SourceItem = sourceItem;
            SourceFQN = SourceItem == default(Item) ? sourceFQN : SourceItem.FQN;
            AccessMode = accessMode;
            Provider = provider;

            Value = default(object);
            Timestamp = default(DateTime);
            Quality = ItemQuality.Uninitialized;

            Guid = Guid.NewGuid();

            Children = new List<Item>();
        }

        #endregion Private Constructors

        #region Public Events

        /// <summary>
        ///     Fires when the <see cref="Value"/> property changes.
        /// </summary>
        public virtual event EventHandler<ItemChangedEventArgs> Changed;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        ///     Gets the access mode for the Item.
        /// </summary>
        public ItemAccessMode AccessMode { get; private set; }

        /// <summary>
        ///     Gets the Item's value.
        /// </summary>
        public object Value { get; private set; }

        /// <summary>
        ///     Gets the timestamp of the last update to the <see cref="Item.Value"/> property.
        /// </summary>
        public DateTime Timestamp { get; private set; }

        /// <summary>
        ///     Gets the quality of the <see cref="Item.Value"/> property.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemQuality Quality { get; private set; }

        /// <summary>
        ///     Gets the collection of children <see cref="Item"/> s.
        /// </summary>
        public IList<Item> Children { get; private set; }

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
        /// <threadsafety instance="true"/>
        public bool HasChildren
        {
            get
            {
                bool retVal;

                childrenLock.EnterReadLock();

                try
                {
                    retVal = Children.Count > 0;
                }
                finally
                {
                    childrenLock.ExitReadLock();
                }

                return retVal;
            }
        }

        /// <summary>
        ///     Gets a value indicating whether the <see cref="Parent"/> property has been set.
        /// </summary>
        /// <threadsafety instance="true"/>
        public bool IsOrphaned
        {
            get
            {
                bool retVal;

                parentLock.EnterReadLock();

                try
                {
                    retVal = Parent == default(Item);
                }
                finally
                {
                    parentLock.ExitReadLock();
                }

                return retVal;
            }
        }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <remarks>Corresponds to the final tuple of the <see cref="FQN"/> property.</remarks>
        /// <threadsafety instance="true"/>
        public string Name
        {
            get
            {
                string retVal;

                fqnLock.EnterReadLock();

                try
                {
                    retVal = FQN.Substring(FQN.LastIndexOf('.') + 1);
                }
                finally
                {
                    fqnLock.ExitReadLock();
                }

                return retVal;
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
        /// <threadsafety instance="true"/>
        public string Path
        {
            get
            {
                string retVal;

                fqnLock.EnterReadLock();

                try
                {
                    retVal = FQN.Substring(0, FQN.LastIndexOf(".") == -1 ? 0 : FQN.LastIndexOf("."));
                }
                finally
                {
                    fqnLock.ExitReadLock();
                }

                return retVal;
            }
        }

        /// <summary>
        ///     Gets the Item Provider from which the Item originates.
        /// </summary>
        public IItemProvider Provider { get; private set; }

        /// <summary>
        ///     Gets the source of the Item.
        /// </summary>
        /// <threadsafety instance="true"/>
        public ItemSource Source
        {
            get
            {
                ItemSource retVal;

                providerLock.EnterReadLock();
                sourceItemLock.EnterReadLock();
                sourceFQNLock.EnterReadLock();

                try
                {
                    if (Provider != default(IItemProvider))
                    {
                        retVal = ItemSource.ItemProvider;
                    }
                    else if (SourceItem != default(Item))
                    {
                        retVal = ItemSource.Item;
                    }
                    else if (SourceFQN != string.Empty)
                    {
                        retVal = ItemSource.Unresolved;
                    }
                    else
                    {
                        retVal = ItemSource.Unknown;
                    }
                }
                finally
                {
                    sourceFQNLock.ExitReadLock();
                    sourceItemLock.ExitReadLock();
                    providerLock.ExitReadLock();
                }

                return retVal;
            }
        }

        /// <summary>
        ///     Gets or sets the Fully Qualified Name of the source Item.
        /// </summary>
        public string SourceFQN { get; set; }

        /// <summary>
        ///     Gets or sets the Item instance resolved from the <see cref="SourceFQN"/> property.
        /// </summary>
        /// <remarks>
        ///     When this property is updated the <see cref="SourceFQN"/> property is updated with the value of the
        ///     <see cref="Item.FQN"/> property of the source <see cref="Item"/>.
        /// </remarks>
        /// <threadsafety instance="true"/>
        public Item SourceItem
        {
            get
            {
                return sourceItem;
            }

            set
            {
                // if the new value is a legitimate Item, set the value of the SourceFQN property to the FQN of the new SourceItem value.
                if (value != default(Item))
                {
                    sourceFQNLock.EnterWriteLock();

                    try
                    {
                        SourceFQN = value.FQN;
                    }
                    finally
                    {
                        sourceFQNLock.ExitWriteLock();
                    }
                }

                sourceItem = value;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Adds the supplied <see cref="Item"/> to the <see cref="Children"/> collection.
        /// </summary>
        /// <remarks>
        ///     This method should be avoided for Items within the application Model; use the public methods in the
        ///     <see cref="Model"/> namespace instead.
        /// </remarks>
        /// <param name="item">The Item to add.</param>
        /// <returns>A Result containing the result of the operation and the added Item.</returns>
        /// <threadsafety instance="true"/>
        public virtual Result<Item> AddChild(Item item)
        {
            Result<Item> retVal = new Result<Item>();

            if (item != default(Item))
            {
                childrenLock.EnterWriteLock();

                try
                {
                    Children.Add(item);
                    retVal.ReturnValue = item;
                    retVal.Incorporate(item.SetParent(this));
                }
                finally
                {
                    childrenLock.ExitWriteLock();
                }
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
            Item retVal = new Item(FQN, SourceItem, SourceFQN);
            retVal.Parent = Parent;
            retVal.Children = Children.Clone<Item>();
            retVal.Value = Value;
            retVal.Quality = Quality;
            retVal.Timestamp = Timestamp;
            retVal.SourceItem = SourceItem;
            retVal.AccessMode = AccessMode;
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
        /// <threadsafety instance="true"/>
        public virtual object Read()
        {
            object retVal;

            valueLock.EnterReadLock();

            try
            {
                retVal = Value;
            }
            finally
            {
                valueLock.ExitReadLock();
            }

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
        ///     Reads this Item's value from it's source and, if the read value is different from the present value of the
        ///     <see cref="Value"/> property, updates the Value and fires the <see cref="Changed"/> event by invoking the
        ///     <see cref="Write"/> method and passing the read value.
        /// </summary>
        /// <remarks>
        ///     If the <see cref="ItemSource"/> of the Item is <see cref="ItemSource.Item"/>, the value is retrieved from the
        ///     <see cref="ReadFromSource"/> method of the <see cref="SourceItem"/>. If the ItemSource is
        ///     <see cref="ItemSource.ItemProvider"/>, the value is retrieved from the <see cref="Provider"/> object's
        ///     <see cref="IItemProvider.Read(Item)"/> method. If the ItemSource is <see cref="ItemSource.Unknown"/>, the present
        ///     value of the <see cref="Value"/> property is returned. If the ItemSource is <see cref="ItemSource.Unresolved"/>, a
        ///     null value is returned.
        /// </remarks>
        /// <returns>The retrieved value.</returns>
        /// <threadsafety instance="true"/>
        public virtual object ReadFromSource()
        {
            // recursively call ReadFromSource() on each child in this Item's children collection this allows us to update whole
            // branches of the model with a single read
            if (HasChildren)
            {
                IList<Item> children;

                childrenLock.EnterReadLock();

                try
                {
                    children = Children;
                }
                finally
                {
                    childrenLock.ExitReadLock();
                }

                foreach (Item child in Children)
                {
                    child.ReadFromSource();
                }
            }

            // prepare a variable to hold the read result
            object value = new object();
            ItemQuality quality = ItemQuality.Good;

            // if the source is an Item, return the result from that Item's ReadFromSource() method. This will recursively refresh
            // each Item in the chain until the last Item (that which the Source = ItemProvider) is refreshed directly from the source.
            if (Source == ItemSource.Item)
            {
                sourceItemLock.EnterReadLock();

                try
                {
                    value = SourceItem.ReadFromSource();
                }
                finally
                {
                    sourceItemLock.ExitReadLock();
                }
            }
            else if (Source == ItemSource.ItemProvider)
            {
                // if the source of this Item is an ItemProvider and it implements IReadable, return the value of the Read() method
                // for the provider. this will be the final read in the chain.
                providerLock.EnterReadLock();

                try
                {
                    value = Provider.Read(this);
                }
                catch (Exception)
                {
                    value = null;
                    quality = ItemQuality.Bad;
                }
                finally
                {
                    providerLock.ExitReadLock();
                }
            }
            else if (Source == ItemSource.Unknown)
            {
                // if the source of this Item is unknown, the authoritative source for the Item's value is itself, so return the
                // Value property.
                valueLock.EnterReadLock();

                try
                {
                    value = Value;
                }
                finally
                {
                    valueLock.ExitReadLock();
                }
            }
            else if (Source == ItemSource.Unresolved)
            {
                // if the source of this Item is an unresolved FQN, return null.
                value = null;
                quality = ItemQuality.Bad;
            }

            ChangeValue(value, quality);

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
        /// <returns>A Result containing the result of the operation and the removed Item.</returns>
        /// <threadsafety instance="true"/>
        public virtual Result<Item> RemoveChild(Item item)
        {
            Result<Item> retVal = new Result<Item>();

            if (item != default(Item))
            {
                // attempt to fetch the item from the Children collection
                childrenLock.EnterReadLock();

                try
                {
                    retVal.ReturnValue = Children.Where(i => i.FQN == item.FQN).FirstOrDefault();
                }
                finally
                {
                    childrenLock.ExitReadLock();
                }

                if (retVal.ReturnValue == default(Item))
                {
                    retVal.AddError("Failed to find the item '" + item.FQN + "' in the list of children for '" + FQN + "'.");
                }
                else
                {
                    childrenLock.EnterWriteLock();
                    grandchildrenLock.EnterReadLock();

                    try
                    {
                        // begin by recursively removing all children from the item being removed
                        IList<Item> childrenToRemove = retVal.ReturnValue.Children.Clone();

                        foreach (Item child in childrenToRemove)
                        {
                            retVal.ReturnValue.RemoveChild(child);
                        }

                        Children.Remove(retVal.ReturnValue);
                    }
                    finally
                    {
                        grandchildrenLock.ExitReadLock();
                        childrenLock.ExitWriteLock();
                    }
                }
            }
            else
            {
                retVal.AddError("Invalid Item; specified Item is null or default.");
            }

            return retVal;
        }

        /// <summary>
        ///     Adds the <see cref="SourceItemChanged(object, ItemChangedEventArgs)"/> event handler to the
        ///     <see cref="SourceItem"/>'s <see cref="Changed"/> event.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        /// <threadsafety instance="true"/>
        public virtual Result SubscribeToSource()
        {
            Result retVal = new Result();

            if (Source == ItemSource.Item)
            {
                sourceItemLock.EnterWriteLock();

                try
                {
                    SourceItem.Changed += SourceItemChanged;
                    SourceItem.SubscriptionsChanged();
                }
                finally
                {
                    sourceItemLock.ExitWriteLock();
                }
            }
            else if (Source == ItemSource.ItemProvider)
            {
                providerLock.EnterWriteLock();

                try
                {
                    if (Provider is ISubscribable)
                    {
                        ((ISubscribable)Provider).Subscribe(this, value => ChangeValue(value));
                    }
                    else
                    {
                        retVal.AddError("Unable to subscribe to source; the source Item Provider is not subscribable.");
                    }
                }
                finally
                {
                    providerLock.ExitWriteLock();
                }
            }
            else
            {
                retVal.AddError("Unable to subscribe to source; the source Item is either not specified or hasn't been resolved.");
            }

            return retVal;
        }

        /// <summary>
        ///     Notifies this Item that the number of subscribers to the <see cref="Changed"/> event has changed.
        /// </summary>
        public virtual void SubscriptionsChanged()
        {
            if (Source == ItemSource.ItemProvider)
            {
                if (Changed != null)
                {
                    SubscribeToSource();
                }
                else
                {
                    UnsubscribeFromSource();
                }
            }
        }

        /// <summary>
        ///     Returns the serialization of this Item using the default <see cref="ContractResolver"/>.
        /// </summary>
        /// <returns>The serialization of the Item.</returns>
        public virtual string ToJson()
        {
            return ToJson(new ContractResolver(new List<string>(new string[] { "Parent", "SourceItem", "Children" }), ContractResolverType.OptOut));
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
        /// <threadsafety instance="true"/>
        public override string ToString()
        {
            fqnLock.EnterReadLock();

            try
            {
                return FQN;
            }
            finally
            {
                fqnLock.ExitReadLock();
            }
        }

        /// <summary>
        ///     Removes the <see cref="SourceItemChanged"/> event handler from the <see cref="SourceItem"/>'s <see cref="Changed"/> event.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        /// <threadsafety instance="true"/>
        public virtual Result UnsubscribeFromSource()
        {
            Result retVal = new Result();

            if (Source == ItemSource.Item)
            {
                sourceItemLock.EnterWriteLock();

                try
                {
                    SourceItem.Changed -= SourceItemChanged;
                    SourceItem.SubscriptionsChanged();
                }
                finally
                {
                    sourceItemLock.ExitWriteLock();
                }
            }
            else if (Source == ItemSource.ItemProvider)
            {
                providerLock.EnterWriteLock();

                try
                {
                    if (Provider is ISubscribable)
                    {
                        ((ISubscribable)Provider).UnSubscribe(this, value => ChangeValue(value));
                    }
                    else
                    {
                        retVal.AddError("Unable to unsubscribe from source; the source Item Provider is not subscribable.");
                    }
                }
                finally
                {
                    providerLock.ExitWriteLock();
                }
            }
            else
            {
                retVal.AddError("Unable to unsubscribe from source; the source Item is either not specified or hasn't been resolved.");
            }

            return retVal;
        }

        /// <summary>
        ///     Writes the provided value to the <see cref="Value"/> property.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <threadsafety instance="true"/>
        /// <returns>A value indicating whether the operation succeeded.</returns>
        public virtual bool Write(object value)
        {
            bool retVal = false;

            if (AccessMode == ItemAccessMode.ReadWrite)
            {
                ChangeValue(value);
                retVal = true;
            }

            return retVal;
        }

        /// <summary>
        ///     Asynchronously writes the provided value to the <see cref="Value"/> property.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>A value indicating whether the operation succeeded.</returns>
        public virtual async Task<bool> WriteAsync(object value)
        {
            return await Task.Run(() => Write(value));
        }

        /// <summary>
        ///     Writes the provided value to the Item's <see cref="SourceItem"/> or <see cref="Provider"/>, depending on the value
        ///     of the <see cref="Source"/> property.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>A value indicating whether the write operation succeeded.</returns>
        /// <threadsafety instance="true"/>
        public virtual bool WriteToSource(object value)
        {
            bool result = false;

            sourceItemLock.EnterWriteLock();
            providerLock.EnterWriteLock();

            try
            {
                if (Source == ItemSource.Item)
                {
                    result = SourceItem.WriteToSource(value);
                }
                else if (Source == ItemSource.ItemProvider && Provider is IWriteable)
                {
                    result = ((IWriteable)Provider).Write(this, value);
                }
            }
            finally
            {
                providerLock.ExitWriteLock();
                sourceItemLock.ExitWriteLock();
            }

            if (result)
            {
                ChangeValue(value);
            }

            return result;
        }

        /// <summary>
        ///     Asynchronously writes the provided value to the Item's <see cref="SourceItem"/> or <see cref="Provider"/>,
        ///     depending on the value of the <see cref="Source"/> property.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>A value indicating whether the write operation succeeded.</returns>
        public virtual async Task<bool> WriteToSourceAsync(object value)
        {
            return await Task.Run(() => WriteToSource(value));
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     Raises the <see cref="Changed"/> event with a new instance of <see cref="ItemChangedEventArgs"/> containing the
        ///     specified value.
        /// </summary>
        /// <param name="value">The value for the raised event.</param>
        /// <param name="previousValue">The value of the Item prior to the event.</param>
        /// <param name="quality">The Quality of the item.</param>
        /// <param name="previousQuality">The quality of the Item prior to the event.</param>
        protected virtual void OnChange(object value, object previousValue, ItemQuality quality, ItemQuality previousQuality)
        {
            if (Changed != null)
            {
                Changed(this, new ItemChangedEventArgs(value, previousValue, quality, previousQuality));
            }
        }

        /// <summary>
        ///     Sets the parent Item to the supplied Item.
        /// </summary>
        /// <param name="parent">The Item to set as the Item's parent.</param>
        /// <returns>A Result containing the result of the operation and the current Item.</returns>
        /// <threadsafety instance="true"/>
        protected virtual Result SetParent(Item parent)
        {
            Result retVal = new Result();

            if (parent != default(Item))
            {
                string name = Name;

                parentLock.EnterWriteLock();
                fqnLock.EnterWriteLock();

                try
                {
                    FQN = (this != parent ? parent.FQN + "." : string.Empty) + name;
                    Parent = parent;
                }
                finally
                {
                    fqnLock.ExitWriteLock();
                    parentLock.ExitWriteLock();
                }
            }
            else
            {
                retVal.AddError("The provided parent Item is invalid.");
            }

            return retVal;
        }

        /// <summary>
        ///     Event Handler for the <see cref="Changed"/> event belonging to the <see cref="SourceItem"/>.
        /// </summary>
        /// <param name="sender">The Item that raised the event.</param>
        /// <param name="e">The EventArgs for the event.</param>
        protected virtual void SourceItemChanged(object sender, ItemChangedEventArgs e)
        {
            ChangeValue(e.Value, e.Quality);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        ///     Updates the <see cref="Value"/> property with the specified value and fires the
        ///     <see cref="OnChange(object, object, ItemQuality, ItemQuality)"/> event.
        /// </summary>
        /// <param name="value">The updated value to which the <see cref="Value"/> property is to be set.</param>
        /// <param name="quality">The updated quality to which the <see cref="Quality"/> property is to be set.</param>
        /// <threadsafety instance="true"/>
        private void ChangeValue(object value, ItemQuality quality = ItemQuality.Good)
        {
            // retrieve present values
            object previousValue;
            ItemQuality previousQuality;

            valueLock.EnterReadLock();
            qualityLock.EnterReadLock();

            try
            {
                previousValue = Value;
                previousQuality = Quality;
            }
            finally
            {
                valueLock.ExitReadLock();
                qualityLock.ExitReadLock();
            }

            // update the Value, Timestamp and Quality fields of the Item
            valueLock.EnterWriteLock();
            timestampLock.EnterWriteLock();
            qualityLock.EnterWriteLock();

            try
            {
                Value = value;
                Quality = quality;
                Timestamp = DateTime.UtcNow;
            }
            finally
            {
                valueLock.ExitWriteLock();
                timestampLock.ExitWriteLock();
                qualityLock.ExitWriteLock();
            }

            // raise the Changed event
            OnChange(value, previousValue, quality, previousQuality);
        }

        #endregion Private Methods
    }
}