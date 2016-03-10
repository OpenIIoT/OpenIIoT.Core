using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Plugin.Connector
{
    /// <summary>
    /// The ConnectorItem is an extension of the Item class.  This class represents Items that are provided by Connector Plugins.
    /// The primary differences between the two types are:
    ///     The ConnectorItem stores no values.  Furthermore it does not implement persistence.
    ///     The ConnectorItem reads and writes directly to the parent Connector Plugin using the Fully Qualified Name of the item.
    ///     The ConnectorItem listens for the Changed event from the parent Connector Plugin and, when fired, fires its own Changed() event.
    ///         Because the only link between a ConnectorItem and the Connector Plugin, the FQN is passed in the EventArgs and the ConnectorItem
    ///         is responsible ensuring that it only forwards events that pertain to itself.
    /// </summary>
    public class ConnectorItem : Item
    {
        [JsonIgnore]
        public IConnector Plugin { get; private set; }

        /// <summary>
        /// An empty constructor used for instantiating the root node of a model.
        /// </summary>
        public ConnectorItem() : base("", typeof(object), "", true) { }

        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name to be used as the root of a model.
        /// </summary>
        /// <param name="plugin">The instance of IConnector hosting this PluginItem.</param>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="isRoot">True if the item is to be created as a root model item, false otherwise.</param>
        public ConnectorItem(IConnector plugin, string fqn, bool isRoot) : this(plugin, fqn, typeof(object), "", isRoot) { }

        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name and type.
        /// </summary>
        /// <param name="plugin">The instance of IConnector hosting this PluginItem.</param>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="type">The Type of the Item's value.</param>
        /// <param name="sourceAddress">The Fully Qualified Name of the source item.</param>
        /// <remarks>This constructor is used for deserialization.</remarks>
        public ConnectorItem(IConnector plugin, string fqn, Type type, string sourceAddress) : this(plugin, fqn, type, sourceAddress, false) { }

        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name and type.  If isRoot is true, marks the Item as the root item in a model.
        /// </summary>
        /// <param name="plugin">The instance of IConnector hosting this PluginItem.</param>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="type">The Type of the Item's value.</param>
        /// <param name="sourceAddress">The Fully Qualified Name of the source item.</param>
        /// <param name="isRoot">True if the item is to be created as a root model item, false otherwise.</param>
        public ConnectorItem(IConnector plugin, string fqn, Type type = null, string sourceAddress = "", bool isRoot = false) : base(fqn, type, sourceAddress)
        {
            Plugin = plugin;
        }

        public ConnectorItem SetParent(ConnectorItem parent)
        {
            return (ConnectorItem)base.SetParent((Item)parent);
        }

        public ConnectorItem AddChild(ConnectorItem pluginItem)
        {
            return (ConnectorItem)base.AddChild((Item)pluginItem);
        }

        public ConnectorItem RemoveChild(ConnectorItem pluginItem)
        {
            return (ConnectorItem)base.RemoveChild(pluginItem);
        }

        public override object Read()
        {
            return ReadFromSource();
        }

        public override object ReadFromSource()
        {
            return Plugin.Read(this.FQN);
        }

        /// <summary>
        /// Called by the parent Connector plugin to update the value of the ConnectorItem.
        /// Updates the internal value of the ConnectorItem and fires the Change event to notify any subscribed Items of the update.
        /// </summary>
        /// <remarks>Should never be called by anything other than the parent Connector plugin.</remarks>
        /// <param name="value">The value with which to update the ConnectorItem.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public override OperationResult Write(object value)
        {
            Value = value;
            base.OnChange(value);
            return new OperationResult();
        }

        /// <summary>
        /// Called by Items using this ConnectorItem as a source, passes updated values to the Connector plugin for writing to the source of the item.
        /// </summary>
        /// <remarks>Any and all writes to ConnectorItems (other than by the Connector plugin) should be performed with WriteToSource.</remarks>
        /// <param name="value">The value with which to update the ConnectorItem.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public override OperationResult WriteToSource(object value)
        {
            // update the internal value and notify subscribed Items of the update
            Write(value);
            // write the value to the parent Connector plugin
            return Plugin.Write(this.FQN, value);
        }
    }
}
