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
using OpenIIoT.SDK.Common.Provider.ItemProvider;

namespace OpenIIoT.SDK.Common
{
    /// <summary>
    ///     Represents a single data entity within the application Model.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         <see cref="Item"/> instances are addressed primarily by their <see cref="FQN"/> property; the Fully Qualified Name
    ///         of the item. The <see cref="Path"/> and <see cref="Name"/> properties provide the path and name of the Item,
    ///         corresponding to the FQN less the final period-separated tuple and the final tuple, respectively. Each Item has an
    ///         <see cref="AccessMode"/> property which may be <see cref="ItemAccessMode.ReadOnly"/> or
    ///         <see cref="ItemAccessMode.ReadWrite"/>, depending on whether the Item is capable of being written. All Items are
    ///         capable of being read. The <see cref="Guid"/> property is generated on creation and provides a unique identifier
    ///         for the Item.
    ///     </para>
    ///     <para>
    ///         The Item's <see cref="Value"/> property contains the Item's present value, and the <see cref="Quality"/> property
    ///         indicates whether the Value is <see cref="ItemQuality.Good"/>, <see cref="ItemQuality.Bad"/>, or, if the Item has
    ///         been created but not yet read or written, <see cref="ItemQuality.Uninitialized"/> . The <see cref="Timestamp"/>
    ///         property contains the timestamp at which the Value was last updated.
    ///     </para>
    ///     <para>
    ///         The Item class is a composite object; it is composed of other Item instances contained within the
    ///         <see cref="Children"/> and <see cref="Parent"/> properties. Children are added and removed via the
    ///         <see cref="AddChild(Item)"/> and <see cref="RemoveChild(Item)"/> methods, and the <see cref="HasChildren"/>
    ///         property returns a value indicating whether the Children collection is empty. Finally, the <see cref="IsOrphaned"/>
    ///         property returns a value indicating whether the Parent property is set to an instance of an Item.
    ///     </para>
    ///     <para>
    ///         Instances of the <see cref="Item"/> class are one of two basic types; those that originate from an
    ///         <see cref="ItemProvider"/> and those that don't. The <see cref="Provider"/> property of Items originating from an
    ///         ItemProvider will contain an instance of an ItemProvider, and the <see cref="Source"/> property will return
    ///         <see cref="ItemSource.Provider"/>. Items that don't originate from an ItemProvider will have a null Provider and
    ///         the Source will be <see cref="ItemSource.Item"/> if the source is another Item, <see cref="ItemSource.Unresolved"/>
    ///         if the <see cref="SourceFQN"/> is non-null but <see cref="SourceItem"/> property is null, and
    ///         <see cref="ItemSource.Unknown"/> if neither the SourceFQN nor SourceItem properties are non-null.
    ///     </para>
    ///     <para>
    ///         Instances that don't originate from an ItemProvider read and write data to and from other Item instances when the
    ///         <see cref="ReadFromSource"/> and <see cref="WriteToSource(object)"/> methods are invoked. These invocations are
    ///         cascaded through each successive Item until an Item which originates from an ItemProvider is encountered, at which
    ///         point data is read from and written to the source <see cref="Provider"/> directly, at which point the
    ///         <see cref="Value"/> property is updated and the <see cref="OnChange(object, object, ItemQuality, ItemQuality)"/>
    ///         event is fired.
    ///     </para>
    ///     <para>
    ///         The <see cref="Read"/> and <see cref="Write(object)"/> methods update the Value property and fire the OnChange
    ///         method but do not cascade reads or writes to the underlying source.
    ///     </para>
    ///     <para>
    ///         In addition to the read and write methods, Items can be subscribed to their source Item with the
    ///         <see cref="SubscribeToSource"/> method, and conversely unsubscribed using <see cref="UnsubscribeFromSource"/>. When
    ///         an Item is subscribed the <see cref="SourceItemChanged(object, ItemChangedEventArgs)"/> event handler is bound to
    ///         the OnChange event of the source Item, and each time the event fires the subscribed Item's Value is updated and the
    ///         OnChange event is fired, cascading the event through any subscribers of the Item. The
    ///         <see cref="IsSubscribedToSource"/> property returns a value indicating whether the Item is subscribed to its source Item.
    ///     </para>
    ///     <para>
    ///         The <see cref="SubscriptionsChanged"/> method is to be invoked by Items subscribing to the Item's updates; when an
    ///         Item's Source is <see cref="ItemSource.Provider"/>, the Item must be subscribed to it's source Item when downstream
    ///         Items subscribe to it. In other words, when an Item subscribes to an Item originating from an ItemProvider, the
    ///         subscribed Item will then automatically subscribe to its source Item. Furthermore, when an Item unsubscribes from
    ///         an Item originating from an ItemProvider the Item will be unsubscrubed from its source Item upon the unsubscription
    ///         of the final Item (when the event has no more handlers attached). Items not originating from an ItemProvider must
    ///         be explicitly subscribed and unsubscribed.
    ///     </para>
    ///     <para>
    ///         The <see cref="Clone"/> and <see cref="CloneAs(string)"/> methods are used to create clones of the Item (CloneAs
    ///         returning the Item with a different FQN) to allow the manipulation of Item trees.
    ///     </para>
    ///     <para>
    ///         The <see cref="Lock"/> property provides an instance of the <see cref="ReaderWriterLockSlim"/> class which external
    ///         code can use to lock the object to ensure thread safety.
    ///     </para>
    ///     <para>The implementation of the <see cref="ICloneable"/> interface for this class returns a shallow copy.</para>
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]
    public class Item : ICloneable
    {
        #region Protected Fields

        /// <summary>
        ///     Lock for the <see cref="Item.Children"/> property.
        /// </summary>
        protected ReaderWriterLockSlim childrenLock = new ReaderWriterLockSlim();

        /// <summary>
        ///     Lock for the <see cref="Item.Children"/> property of child Items accessed while being removed.
        /// </summary>
        protected ReaderWriterLockSlim grandchildrenLock = new ReaderWriterLockSlim();

        /// <summary>
        ///     Lock for the <see cref="Item.Parent"/> property.
        /// </summary>
        protected ReaderWriterLockSlim parentLock = new ReaderWriterLockSlim();

        /// <summary>
        ///     Lock for the <see cref="Item.Provider"/> property.
        /// </summary>
        protected ReaderWriterLockSlim providerLock = new ReaderWriterLockSlim();

        /// <summary>
        ///     Lock for the <see cref="Item.SourceItem"/> property.
        /// </summary>
        protected ReaderWriterLockSlim sourceItemLock = new ReaderWriterLockSlim();

        /// <summary>
        ///     Lock for the <see cref="Item.Value"/> property.
        /// </summary>
        protected ReaderWriterLockSlim valueLock = new ReaderWriterLockSlim();

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
            Lock = new ReaderWriterLockSlim();

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
        ///     Gets a value indicating whether the Item is subscribed to its source Item.
        /// </summary>
        public bool IsSubscribedToSource { get; private set; }

        /// <summary>
        ///     Gets the lock for this Item to be used to help ensure thread safety.
        /// </summary>
        public ReaderWriterLockSlim Lock { get; private set; }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <remarks>Corresponds to the final tuple of the <see cref="FQN"/> property.</remarks>
        public string Name
        {
            get
            {
                string fqn = FQN;
                return fqn.Substring(fqn.LastIndexOf('.') + 1);
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
                string fqn = FQN;
                return fqn.Substring(0, fqn.LastIndexOf(".") == -1 ? 0 : fqn.LastIndexOf("."));
            }
        }

        /// <summary>
        ///     Gets the Item Provider from which the Item originates.
        /// </summary>
        public IItemProvider Provider { get; private set; }

        /// <summary>
        ///     Gets the quality of the <see cref="Item.Value"/> property.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemQuality Quality { get; private set; }

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

                try
                {
                    if (Provider != default(IItemProvider))
                    {
                        retVal = ItemSource.Provider;
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
                    SourceFQN = value.FQN;
                }

                sourceItem = value;
            }
        }

        /// <summary>
        ///     Gets the timestamp of the last update to the <see cref="Item.Value"/> property.
        /// </summary>
        public DateTime Timestamp { get; private set; }

        /// <summary>
        ///     Gets the Item's value.
        /// </summary>
        public object Value { get; private set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Adds the supplied <see cref="Item"/> to the <see cref="Children"/> collection. Do not invoke this method on Items
        ///     which are managed by the application's Model Manager.
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

            if (item == default(Item))
            {
                retVal.AddError("Invalid Item; specified Item is null.");
            }
            else if (ReferenceEquals(item, this))
            {
                retVal.AddError("Invalid Item; an Item cannot be added as a child of itself.");
            }
            else if (IsAncestor(item))
            {
                retVal.AddError("Unable to add the Item to the Children for this Item; doing so would create a circular reference.");
            }
            else
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

            return retVal;
        }

        /// <summary>
        ///     Creates and returns a clone of this Item.
        /// </summary>
        /// <remarks>We aren't using .MemberWiseClone() because of the GUID. We need a "deep copy".</remarks>
        /// <returns>A shallow copy of this Item.</returns>
        /// <threadsafety instance="true"/>
        public virtual object Clone()
        {
            parentLock.EnterReadLock();
            childrenLock.EnterReadLock();
            valueLock.EnterReadLock();
            sourceItemLock.EnterReadLock();

            Item retVal;

            try
            {
                retVal = new Item(FQN, SourceItem, SourceFQN);
                retVal.Parent = Parent;
                retVal.Children = Children.Clone<Item>();
                retVal.Value = Value;
                retVal.Quality = Quality;
                retVal.Timestamp = Timestamp;
                retVal.AccessMode = AccessMode;
            }
            finally
            {
                sourceItemLock.ExitReadLock();
                valueLock.ExitReadLock();
                childrenLock.ExitReadLock();
                parentLock.ExitReadLock();
            }

            return retVal;
        }

        /// <summary>
        ///     Creates and returns a clone of this Item with the specified Fully Qualified Name.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name with which this Item's FQN is to be replaced.</param>
        /// <returns>A shallow copy of this Item with the FQN substituted for the specified value.</returns>
        /// <threadsafety instance="true"/>
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
        ///     <see cref="ItemSource.Provider"/>, the value is retrieved from the <see cref="Provider"/> object's
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
            else if (Source == ItemSource.Provider)
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
        ///     Removes the specified Item from the <see cref="Children"/> collection. Do not invoke this method on Items which are
        ///     managed by the application's Model Manager.
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
                    IsSubscribedToSource = true;
                }
                finally
                {
                    sourceItemLock.ExitWriteLock();
                }
            }
            else if (Source == ItemSource.Provider)
            {
                providerLock.EnterWriteLock();

                try
                {
                    if (Provider is ISubscribable)
                    {
                        ((ISubscribable)Provider).Subscribe(this, value => ChangeValue(value));
                        IsSubscribedToSource = true;
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
        /// <remarks>
        ///     If the <see cref="SourceItem"/> of this Item is <see cref="ItemSource.Provider"/>, either subscribe to or
        ///     unsubscribe from the source, depending on whether any listeners are attached to the <see cref="Changed"/> event.
        /// </remarks>
        public virtual void SubscriptionsChanged()
        {
            IItemProvider provider;

            providerLock.EnterReadLock();

            try
            {
                provider = Provider;
            }
            finally
            {
                providerLock.ExitReadLock();
            }

            if (Source == ItemSource.Provider && provider is ISubscribable)
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
            return FQN;
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
                    IsSubscribedToSource = false;
                }
                finally
                {
                    sourceItemLock.ExitWriteLock();
                }
            }
            else if (Source == ItemSource.Provider)
            {
                providerLock.EnterWriteLock();

                try
                {
                    ((ISubscribable)Provider).UnSubscribe(this, value => ChangeValue(value));
                    IsSubscribedToSource = false;
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

            ItemSource source = Source;

            sourceItemLock.EnterWriteLock();
            providerLock.EnterWriteLock();

            try
            {
                if (source == ItemSource.Item)
                {
                    result = SourceItem.WriteToSource(value);
                }
                else if (source == ItemSource.Provider && Provider is IWriteable)
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
        ///     Recursively examines the hierarchy in which this <see cref="Item"/> resides to determine whether the specified
        ///     <see cref="Item"/> is among its ancestors.
        /// </summary>
        /// <param name="item">The Item for which to search.</param>
        /// <returns>A value indicating whether the specified Item exists among this Item's ancestors.</returns>
        protected bool IsAncestor(Item item)
        {
            return IsAncestor(this, item);
        }

        /// <summary>
        ///     Recursively examines the <see cref="Parent"/> of the specified <see cref="Item"/> to determine whether the
        ///     specified <see cref="Item"/> is among its ancestors.
        /// </summary>
        /// <param name="parent">The Item for which the Parent should be examined.</param>
        /// <param name="item">The Item for which to search.</param>
        /// <returns>A value indicating whether the specified Item exists among the specified Item's ancestors.</returns>
        protected bool IsAncestor(Item parent, Item item)
        {
            if (ReferenceEquals(parent, item))
            {
                return true;
            }
            else if (parent.Parent == default(Item) | ReferenceEquals(parent, parent.Parent))
            {
                return false;
            }
            else
            {
                return IsAncestor(parent.Parent, item);
            }
        }

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

            string name = Name;

            parentLock.EnterWriteLock();

            try
            {
                FQN = (this != parent ? parent.FQN + "." : string.Empty) + name;
                Parent = parent;
            }
            finally
            {
                parentLock.ExitWriteLock();
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

            try
            {
                previousValue = Value;
                previousQuality = Quality;
            }
            finally
            {
                valueLock.ExitReadLock();
            }

            // update the Value, Timestamp and Quality fields of the Item
            valueLock.EnterWriteLock();

            try
            {
                Value = value;
                Quality = quality;
                Timestamp = DateTime.UtcNow;
            }
            finally
            {
                valueLock.ExitWriteLock();
            }

            // raise the Changed event
            OnChange(value, previousValue, quality, previousQuality);
        }

        #endregion Private Methods
    }
}