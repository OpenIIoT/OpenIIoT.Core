/*
     █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
     █   
     █    ▄█  ▄████████  
     █   ███  ███    ███ 
     █   ███▌ ███    █▀   ██████  ██▄▄▄▄  ██▄▄▄▄     ▄█████  ▄██████     ██     ██████     █████ 
     █   ███▌ ███        ██    ██ ██▀▀▀█▄ ██▀▀▀█▄   ██   █  ██    ██ ▀███████▄ ██    ██   ██  ██ 
     █   ███▌ ███        ██    ██ ██   ██ ██   ██  ▄██▄▄    ██    ▀      ██  ▀ ██    ██  ▄██▄▄█▀ 
     █   ███  ███    █▄  ██    ██ ██   ██ ██   ██ ▀▀██▀▀    ██    ▄      ██    ██    ██ ▀███████ 
     █   ███  ███    ███ ██    ██ ██   ██ ██   ██   ██   █  ██    ██     ██    ██    ██   ██  ██ 
     █   █▀   ████████▀   ██████   █   █   █   █    ███████ ██████▀     ▄██▀    ██████    ██  ██   
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
using Symbiote.Core.SDK;
using Symbiote.Core.SDK.Plugin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Symbiote.Core.SDK.Plugin.Connector
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
    ///     Asynchronous overloads are provided for each of the methods.  These are: <see cref="BrowseAsync()"/>, <see cref="BrowseAsync(Item)"/>,
    ///     and <see cref="FindAsync(string)"/>.  Other than enclosing the return type in a <see cref="Task{TResult}"/> and executing 
    ///     asynchronously, these methods are identical to their synchronous counterparts.
    /// </para>
    /// <para>
    ///     The IConnector interface represents the minimun implementation of the class.  Other functionality may be implemented by 
    ///     implementing one or more of the following interfaces:
    ///     <list>
    ///         <item><see cref="IReadable"/>: Allows the application to read the value of ConnectorItems from the Connector's data source.</item>
    ///         <item><see cref="ISubscribable"/>: Allows the application to subscribe Model Items to ConnectorItems to receive value updates.</item>
    ///         <item><see cref="IWriteable"/>: Allows the application to write values to the source of a ConnectorItem.</item>
    ///         <item><see cref="IExtensible"/>: Allows the application to add additional ConnectorItems to the Connector at runtime.</item>
    ///     </list>
    /// </para>
    /// </remarks>
    public interface IConnector : IPluginInstance
    {
        /// <summary>
        /// Returns the root node of the connector's <see cref="Item"/> tree.
        /// </summary>
        /// <returns>The root node of the connector's Item tree.</returns>
        IItem Browse();

        /// <summary>
        /// Asynchronously returns the root node of the connector's <see cref="Item"/> tree.
        /// </summary>
        /// <returns>The root node of the connector's Item tree.</returns>
        Task<IItem> BrowseAsync();

        /// <summary>
        /// Returns a list of the children <see cref="Item"/>s for the specified Item within the connector's Item tree.
        /// </summary>
        /// <param name="root">The Item for which the children are to be returned.</param>
        /// <returns>A List of type Item containing all of the specified Item's children.</returns>
        List<IItem> Browse(IItem root);

        /// <summary>
        /// Asynchronously returns a list of the children <see cref="Item"/>s for the specified Item within the connector's Item tree.
        /// </summary>
        /// <param name="root">The Item for which the children are to be returned.</param>
        /// <returns>A List of type Item containing all of the specified Item's children.</returns>
        Task<List<IItem>> BrowseAsync(IItem root);

        /// <summary>
        /// Finds and eturns the <see cref="Item"/> matching the specified Fully Qualified Name.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to return.</param>
        /// <returns>The found Item, or the default(Item) if not found.</returns>
        IItem Find(string fqn);

        /// <summary>
        /// Asynchronously finds and returns the <see cref="Item"/> matching the specified Fully Qualified Name.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to return.</param>
        /// <returns>The found Item, or the default(Item) if not found.</returns>
        Task<IItem> FindAsync(string fqn);
    }
}
