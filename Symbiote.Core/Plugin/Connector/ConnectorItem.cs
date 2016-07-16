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
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █  
      █  ConnectorItem is an extension of the Item class.  This class represents Items that are provided by Connector Plugins. 
      █  
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ 
                                                                                                   ██ 
                                                                                               ▀█▄ ██ ▄█▀ 
                                                                                                 ▀████▀   
                                                                                                   ▀▀                            */
using Newtonsoft.Json;
using Symbiote.Core.Model;
using System.Threading.Tasks;

namespace Symbiote.Core.Plugin.Connector
{
    /// <summary>
    ///     ConnectorItem is an extension of the <see cref="Item"/> class.  This class represents Items that are provided by <see cref="Connector"/> 
    ///     <see cref="Plugin"/>s.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The primary differences between this class and the base Item are:
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
        /// Sets this <see cref="Item"/>'s parent Item to the specified Item.
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


        public Result<ConnectorItem> AddChild(ConnectorItem pluginItem)
        {
            Result<ConnectorItem> retVal = new Result<ConnectorItem>();
            Result<Item> addResult = base.AddChild((Item)pluginItem);

            retVal.ReturnValue = (ConnectorItem)addResult.ReturnValue;
            retVal.Incorporate(addResult);
            return retVal;
        }

        public Result<ConnectorItem> RemoveChild(ConnectorItem pluginItem)
        {
            Result<ConnectorItem> retVal = new Result<ConnectorItem>();
            Result<Item> removeResult = base.RemoveChild(pluginItem);

            retVal.ReturnValue = (ConnectorItem)removeResult.ReturnValue;
            retVal.Incorporate(removeResult);
            return retVal;
        }

        #region Overridden Methods

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
                return ((IReadable)Connector).Read(this);
            else
                return null;
        }

        public override async Task<object> ReadFromSourceAsync()
        {
            return await Task.Run(() => ReadFromSource());
        }

        /// <summary>
        /// Called by the parent Connector plugin to update the value of the ConnectorItem.
        /// Updates the internal value of the ConnectorItem and fires the Change event to notify any subscribed Items of the update.
        /// </summary>
        /// <remarks>Should never be called by anything other than the parent Connector plugin.</remarks>
        /// <param name="value">The value with which to update the ConnectorItem.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public override Result Write(object value)
        {
            lock (valueLock)
            {
                Value = value;
                base.OnChange(value);
            }
            return new Result();
        }

        public override async Task<Result> WriteAsync(object value)
        {
            return await Task.Run(() => Write(value));
        }

        /// <summary>
        /// Called by Items using this ConnectorItem as a source, passes updated values to the Connector plugin for writing to the source of the item.
        /// </summary>
        /// <remarks>Any and all writes to ConnectorItems (other than by the Connector plugin) should be performed with WriteToSource.</remarks>
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

        public override Result SubscribeToSource()
        {
            if (Connector is ISubscribable)
                return ((ISubscribable)Connector).Subscribe(this);
            else
                return new Result().AddError("The source Connector is not subscribable");
        }

        #endregion

        #endregion
    }
}
