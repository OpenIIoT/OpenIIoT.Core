using Newtonsoft.Json;

namespace Symbiote.Core.Plugin.Connector
{
    /// <summary>
    /// The ConnectorItem is an extension of the Item class.  This class represents Items that are provided by Connector Plugins.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The primary differences between the two types are:
    /// <list>
    ///     <item>The ConnectorItem stores no values.  Furthermore it does not implement persistence.</item>
    ///     <item>The ConnectorItem reads and writes directly to the parent Connector Plugin using the Fully Qualified Name of the item.</item>
    ///     <item>
    ///         The ConnectorItem is written via Write() only from the parent Connector Plugin.  This in turn fires the OnChange event, 
    ///         which updates any subscribed Model Items.  Model items wishing to write to this item must use WriteToSource().
    ///     </item>
    /// </list>
    /// </para>
    /// </remarks>
    public class ConnectorItem : Item
    {
        #region Properties

        /// <summary>
        /// The <see cref="IConnector"/> instance to which this <see cref="Item"/> belongs.
        /// </summary>
        [JsonIgnore]
        public IConnector Connector { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// An empty constructor used for instantiating the root node of a model.
        /// </summary>
        public ConnectorItem() : base("", "", true) { }

        /// <summary>
        /// Creates an instance of an <see cref="Item"/> with the given Fully Qualified Name to be used as the root of a model.
        /// </summary>
        /// <param name="connector">The instance of <see cref="IConnector"/> hosting this <see cref="Item"/>.</param>
        /// <param name="fqn">The Fully Qualified Name of the <see cref="Item"/> to create.</param>
        /// <param name="isRoot">True if the item is to be created as a root model item, false otherwise.</param>
        public ConnectorItem(IConnector connector, string fqn, bool isRoot) : this(connector, fqn, "", isRoot) { }

        /// <summary>
        /// Creates an instance of an <see cref="Item"/> with the given Fully Qualified Name and Source Fully Qualified Name.
        /// </summary>
        /// <param name="connector">The instance of <see cref="IConnector"/> hosting this <see cref="Item"/>.</param>
        /// <param name="fqn">The Fully Qualified Name of the <see cref="Item"/> to create.</param>
        /// <param name="sourceFQN">The Fully Qualified Name of the source item.</param>
        public ConnectorItem(IConnector connector, string fqn, string sourceFQN) : this(connector, fqn, sourceFQN, false) { }

        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name and type.  If isRoot is true, marks the Item as the root item in a model.
        /// </summary>
        /// <param name="connector">The instance of <see cref="IConnector"/> hosting this <see cref="Item"/>.</param>
        /// <param name="fqn">The Fully Qualified Name of the <see cref="Item"/> create.</param>
        /// <param name="sourceFQN">The Fully Qualified Name of the source item.</param>
        /// <param name="isRoot">True if the item is to be created as a root model item, false otherwise.</param>
        public ConnectorItem(IConnector connector, string fqn, string sourceFQN = "", bool isRoot = false) : base(fqn, sourceFQN)
        {
            Connector = connector;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public OperationResult<ConnectorItem> SetParent(ConnectorItem parent)
        {
            OperationResult<ConnectorItem> retVal = new OperationResult<ConnectorItem>();
            OperationResult<Item> setResult = base.SetParent((Item)parent);

            retVal.Result = (ConnectorItem)setResult.Result;
            retVal.Incorporate(setResult);
            return retVal;
        }

        public OperationResult<ConnectorItem> AddChild(ConnectorItem pluginItem)
        {
            OperationResult<ConnectorItem> retVal = new OperationResult<ConnectorItem>();
            OperationResult<Item> addResult = base.AddChild((Item)pluginItem);

            retVal.Result = (ConnectorItem)addResult.Result;
            retVal.Incorporate(addResult);
            return retVal;
        }

        public OperationResult<ConnectorItem> RemoveChild(ConnectorItem pluginItem)
        {
            OperationResult<ConnectorItem> retVal = new OperationResult<ConnectorItem>();
            OperationResult<Item> removeResult = base.RemoveChild(pluginItem);

            retVal.Result = (ConnectorItem)removeResult.Result;
            retVal.Incorporate(removeResult);
            return retVal;
        }

        public override object Read()
        {
            return ReadFromSource();
        }

        public override object ReadFromSource()
        {
            return Connector.Read(this);
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
            if (Connector is IWriteable)
            {
                // update the internal value and notify subscribed Items of the update
                Write(value);
                // write the value to the parent Connector plugin
                return ((IWriteable)Connector).Write(this, value);
            }
            else
                return new OperationResult().AddError("The source Connector is not writeable.");
        }

        public override OperationResult SubscribeToSource()
        {
            if (Connector is ISubscribable)
                return ((ISubscribable)Connector).Subscribe(this);
            else
                return new OperationResult().AddError("The source Connector is not subscribable");
        }

        #endregion
    }
}
