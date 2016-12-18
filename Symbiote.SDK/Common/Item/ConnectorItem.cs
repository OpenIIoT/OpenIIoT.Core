/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ▄████████                                                                           ▄█
      █   ███    ███                                                                         ███
      █   ███    █▀   ██████  ██▄▄▄▄  ██▄▄▄▄     ▄█████  ▄██████     ██     ██████     █████ ███▌     ██       ▄█████    ▄▄██▄▄▄
      █   ███        ██    ██ ██▀▀▀█▄ ██▀▀▀█▄   ██   █  ██    ██ ▀███████▄ ██    ██   ██  ██ ███▌ ▀███████▄   ██   █   ▄█▀▀██▀▀█▄
      █   ███        ██    ██ ██   ██ ██   ██  ▄██▄▄    ██    ▀      ██  ▀ ██    ██  ▄██▄▄█▀ ███▌     ██  ▀  ▄██▄▄     ██  ██  ██
      █   ███    █▄  ██    ██ ██   ██ ██   ██ ▀▀██▀▀    ██    ▄      ██    ██    ██ ▀███████ ███      ██    ▀▀██▀▀     ██  ██  ██
      █   ███    ███ ██    ██ ██   ██ ██   ██   ██   █  ██    ██     ██    ██    ██   ██  ██ ███      ██      ██   █   ██  ██  ██
      █   ████████▀   ██████   █   █   █   █    ███████ ██████▀     ▄██▀    ██████    ██  ██ █▀      ▄██▀     ███████   █  ██  █
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Represents a single data entity provided by a Connector plugin.
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
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;
using NLog.xLogger;
using Symbiote.SDK.Plugin.Connector;
using Utility.OperationResult;

namespace Symbiote.SDK
{
    /// <summary>
    ///     Represents a single data entity provided by a Connector plugin.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The primary differences between this class and the base Item are:
    ///         <list>
    ///             <item>The ConnectorItem stores no values. Furthermore it does not implement persistence.</item>
    ///             <item>
    ///                 The ConnectorItem reads and writes directly to the parent Connector Plugin using the Fully Qualified Name
    ///                 of the item.
    ///             </item>
    ///             <item>
    ///                 The ConnectorItem is written via Write() only from the parent Connector Plugin. This in turn fires the
    ///                 OnChange event, which updates any subscribed Model Items. Model items wishing to write to this item must
    ///                 use WriteToSource().
    ///             </item>
    ///         </list>
    ///     </para>
    /// </remarks>
    public class ConnectorItem : Item
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConnectorItem"/> class with the specified Fully Qualified Name to be
        ///     used as the root of a model.
        /// </summary>
        /// <param name="connector">The Connector to which this Item belongs.</param>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="isRoot">True if the item is to be created as a root model item, false otherwise.</param>
        public ConnectorItem(IConnector connector, string fqn, bool isRoot) : this(connector, fqn, string.Empty, isRoot)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConnectorItem"/> class with the specified Fully Qualified Name and type.
        /// </summary>
        /// <param name="connector">The Connector to which this Item belongs.</param>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="sourceFQN">The Fully Qualified Name of the source Item.</param>
        public ConnectorItem(IConnector connector, string fqn, string sourceFQN) : this(connector, fqn, sourceFQN, false)
        {
        }

        /// <summary>
        ///     Creates an instance of an Item with the given Fully Qualified Name and type. If isRoot is true, marks the Item as
        ///     the root item in a model.
        /// </summary>
        /// <param name="connector">The instance of <see cref="IConnector"/> hosting this <see cref="Item"/>.</param>
        /// <param name="fqn">The Fully Qualified Name of the <see cref="Item"/> create.</param>
        /// <param name="sourceFQN">The Fully Qualified Name of the source item.</param>
        /// <param name="isRoot">True if the item is to be created as a root model item, false otherwise.</param>
        public ConnectorItem(IConnector connector, string fqn, string sourceFQN = "", bool isRoot = false) : base(fqn, default(ConnectorItem), sourceFQN, isRoot)
        {
            Connector = connector;
        }

        #endregion Public Constructors

        #region Public Events

        /// <summary>
        ///     The Changed event; fires when the value of the item changes.
        /// </summary>
        public override event EventHandler<ItemChangedEventArgs> Changed;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        ///     The <see cref="IConnector"/> instance to which this <see cref="Item"/> belongs.
        /// </summary>
        [JsonIgnore]
        public IConnector Connector { get; private set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Adds the supplied <see cref="ConnectorItem"/> to this ConnectorItem's <see cref="Item.Children"/> collection.
        /// </summary>
        /// <param name="item">The ConnectorItem to add.</param>
        /// <returns>A Result containing the result of the operation and the added ConnectorItem.</returns>
        /// <threadsafety instance="true"/>
        public Result<ConnectorItem> AddChild(ConnectorItem item)
        {
            Result<ConnectorItem> retVal = new Result<ConnectorItem>();
            Result<Item> addResult = base.AddChild((Item)item);

            retVal.ReturnValue = (ConnectorItem)addResult.ReturnValue;
            retVal.Incorporate(addResult);
            return retVal;
        }

        /// <summary>
        ///     Returns the value of this <see cref="ConnectorItem"/>'s <see cref="Item.Value"/> property.
        /// </summary>
        /// <returns>The retrieved value.</returns>
        public override object Read()
        {
            return ReadFromSource();
        }

        public override async Task<object> ReadAsync()
        {
            return await Task.Run(() => Read());
        }

        public override object ReadFromSource()
        {
            if (Connector is IReadable)
            {
                return ((IReadable)Connector).Read(this).ReturnValue;
            }
            else
                return null;
        }

        public override async Task<object> ReadFromSourceAsync()
        {
            return await Task.Run(() => ReadFromSource());
        }

        public Result<ConnectorItem> RemoveChild(ConnectorItem pluginItem)
        {
            Result<ConnectorItem> retVal = new Result<ConnectorItem>();
            Result<Item> removeResult = base.RemoveChild(pluginItem);

            retVal.ReturnValue = (ConnectorItem)removeResult.ReturnValue;
            retVal.Incorporate(removeResult);
            return retVal;
        }

        /// <summary>
        ///     Sets this <see cref="Item"/>'s parent Item to the specified Item.
        /// </summary>
        /// <param name="parent">The <see cref="Item"/> to which this Item's Parent property is to be set.</param>
        /// <returns>An <see cref="Result{T}"/> containing the result of the operation and this <see cref="Item"/>.</returns>
        public Result<ConnectorItem> SetParent(ConnectorItem parent)
        {
            Result<ConnectorItem> retVal = new Result<ConnectorItem>();
            Result<Item> setResult = base.SetParent((Item)parent);

            retVal.ReturnValue = (ConnectorItem)setResult.ReturnValue;
            retVal.Incorporate(setResult);
            return retVal;
        }

        public override Result SubscribeToSource()
        {
            Result retVal = new Result();

            if (Connector is ISubscribable)
            {
                retVal = ((ISubscribable)Connector).Subscribe((ConnectorItem)this);
            }
            else
            {
                retVal = new Result().AddError("The source Connector is not subscribable");
            }

            return retVal;
        }

        /// <summary>
        ///     Notifies this <see cref="ConnectorItem"/> that the number of subscribers has changed.
        /// </summary>
        public override void SubscriptionsChanged()
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

        /// <summary>
        ///     Called by the parent Connector plugin to update the value of the ConnectorItem. Updates the internal value of the
        ///     ConnectorItem and fires the Change event to notify any subscribed Items of the update.
        /// </summary>
        /// <remarks>Should never be called by anything other than the parent Connector plugin.</remarks>
        /// <param name="value">The value with which to update the ConnectorItem.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public override Result Write(object value)
        {
            lock (valueLock)
            {
                var previousValue = Value;
                Value = value;
                base.OnChange(previousValue, Value);
            }
            return new Result();
        }

        public override async Task<Result> WriteAsync(object value)
        {
            return await Task.Run(() => Write(value));
        }

        /// <summary>
        ///     Called by Items using this ConnectorItem as a source, passes updated values to the Connector plugin for writing to
        ///     the source of the item.
        /// </summary>
        /// <remarks>
        ///     Any and all writes to ConnectorItems (other than by the Connector plugin) should be performed with WriteToSource.
        /// </remarks>
        /// <param name="value">The value with which to update the ConnectorItem.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public override Result WriteToSource(object value)
        {
            if (Connector is IWriteable)
            {
                // update the internal value and notify subscribed Items of the update
                Write(value);
                // write the value to the parent Connector plugin
                return ((IWriteable)Connector).Write(this, value);
            }
            else
                return new Result().AddError("The source Connector is not writeable.");
        }

        public override async Task<Result> WriteToSourceAsync(object value)
        {
            return await Task.Run(() => WriteToSource(value));
        }

        #endregion Public Methods
    }
}