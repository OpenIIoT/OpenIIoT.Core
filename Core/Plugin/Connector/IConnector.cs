/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █   
      █   
      █   
      █   
      █   
      █   
      █   
      █   
      █   
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █ 
      █  Defines the interface for Connector Plugins.
      █ 
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ 
                                                                                                   ██   
                                                                                               ▀█▄ ██ ▄█▀                       
                                                                                                 ▀████▀   
                                                                                                   ▀▀                            */
using System.Collections.Generic;

namespace Symbiote.Core.Plugin.Connector
{
    /// <summary>
    /// Defines the interface for Connector Plugins.
    /// </summary>
    /// <remarks>
    /// <para>
    ///     Classes implementing IConnector are responsible for application extensibility, providing read/write access to external 
    ///     data stores and interfaces.
    /// </para>
    /// <para>
    ///     All data exposed by an IConnector must be represented as an <see cref="Item"/> with instance type <see cref="ConnectorItem"/>.  
    ///     ConnectorItem instances must be arranged in a composite (tree) data structure, the minimum structure being that of a single 
    ///     root node.  This data structure is accessed by the application with the <see cref="Browse()"/> and <see cref="Browse(Item)"/> 
    ///     methods.  The <see cref="Find(string)"/> method must be implemented to search for and return an Item matching the specified
    ///     Fully Qualified Name within the data structure, if it exists.
    /// </para>
    /// <para>
    ///     The <see cref="Read(Item)"/> method must return an <see cref="OperationResult{T}"/> containing an object representing the 
    ///     current value of the specified Item.  The OperationResult must contain the result of the operation, including the status
    ///     and any informational, warning or error messages that were generated.
    /// </para>
    /// <para>
    ///     The IConnector interface represents the minimun implementation of the class.  Other functionality may be implemented by 
    ///     implementing one or more of the following interfaces:
    ///     <list>
    ///         <item><see cref="IAddable"/>: Allows the application to add additional ConnectorItems to the Connector at runtime.</item>
    ///         <item><see cref="IWriteable"/>: Allows the application to write values to the source of a ConnectorItem.</item>
    ///         <item><see cref="ISubscribable"/>: Allows the application to subscribe Model Items to ConnectorItems to receive value updates.</item>
    ///     </list>
    /// </para>
    /// </remarks>
    public interface IConnector : IPluginInstance
    {
        /// <summary>
        /// Returns the root node of the connector's <see cref="Item"/> tree.
        /// </summary>
        /// <returns>The root node of the connector's <see cref="Item"/> tree.</returns>
        Item Browse();

        /// <summary>
        /// Returns a list of the children <see cref="Item"/>s for the specified Item within the connector's Item tree.
        /// </summary>
        /// <param name="root">The <see cref="Item"/> for which the children are to be returned.</param>
        /// <returns>A <see cref="List{T}"/> of type <see cref="Item"/> containing all of the specified Item's children.</returns>
        List<Item> Browse(Item root);

        /// <summary>
        /// Returns the <see cref="Item"/> matching the specified Fully Qualified Name.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the <see cref="Item"/> to return.</param>
        /// <returns>The found <see cref="Item"/>, or the default(Item) if not found.</returns>
        Item Find(string fqn);

        /// <summary>
        /// Returns the current value of the specified <see cref="Item"/>.
        /// </summary>
        /// <param name="item">The <see cref="Item"/> to read.</param>
        /// <returns>The current value of the <see cref="Item"/>.</returns>
        OperationResult<object> Read(Item item);
    }
}
