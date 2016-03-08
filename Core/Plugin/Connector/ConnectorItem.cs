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
            Plugin.Changed += SourceChanged; 
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

        public override OperationResult Write(object value)
        {
            return WriteToSource(value);
        }
        public override OperationResult WriteToSource(object value)
        {
            return Plugin.Write(this.FQN, value);
        }

        /// <summary>
        /// Raised when any item from the source connector changes.  This is due to the fact that there is no hard link between a specific
        /// ConnectorItem and an item within the Connector.
        /// </summary>
        /// <param name="sender">The connector that raised the event.</param>
        /// <param name="e">The ConnectorEventArgs for the event.</param>
        public void SourceChanged(object sender, ConnectorEventArgs e)
        {
            if (e.FQN == FQN)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("Plugin Item changed: " + e.FQN + "; " + e.Value);
                base.OnChange(e.Value);
            }
        }
    }
}
