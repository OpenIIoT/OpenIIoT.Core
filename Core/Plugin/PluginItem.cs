using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Plugin
{
    public class PluginItem : Item
    {
        [JsonIgnore]
        public IConnector Plugin { get; private set; }

        /// <summary>
        /// An empty constructor used for instantiating the root node of a model.
        /// </summary>
        public PluginItem() : base("", typeof(object), "", true) { }

        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name to be used as the root of a model.
        /// </summary>
        /// <param name="plugin">The instance of IConnector hosting this PluginItem.</param>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="isRoot">True if the item is to be created as a root model item, false otherwise.</param>
        public PluginItem(IConnector plugin, string fqn, bool isRoot) : this(plugin, fqn, typeof(object), "", isRoot) { }

        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name and type.
        /// </summary>
        /// <param name="plugin">The instance of IConnector hosting this PluginItem.</param>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="type">The Type of the Item's value.</param>
        /// <param name="sourceAddress">The Fully Qualified Name of the source item.</param>
        /// <remarks>This constructor is used for deserialization.</remarks>
        public PluginItem(IConnector plugin, string fqn, Type type, string sourceAddress) : this(plugin, fqn, type, sourceAddress, false) { }

        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name and type.  If isRoot is true, marks the Item as the root item in a model.
        /// </summary>
        /// <param name="plugin">The instance of IConnector hosting this PluginItem.</param>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="type">The Type of the Item's value.</param>
        /// <param name="sourceAddress">The Fully Qualified Name of the source item.</param>
        /// <param name="isRoot">True if the item is to be created as a root model item, false otherwise.</param>
        public PluginItem(IConnector plugin, string fqn, Type type = null, string sourceAddress = "", bool isRoot = false) : base(fqn, type, sourceAddress)
        {
            Plugin = plugin;
        }

        public PluginItem SetParent(PluginItem parent)
        {
            return (PluginItem)base.SetParent((Item)parent);
        }

        public PluginItem AddChild(PluginItem pluginItem)
        {
            return (PluginItem)base.AddChild((Item)pluginItem);
        }

        public PluginItem RemoveChild(PluginItem pluginItem)
        {
            return (PluginItem)base.RemoveChild(pluginItem);
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
    }
}
