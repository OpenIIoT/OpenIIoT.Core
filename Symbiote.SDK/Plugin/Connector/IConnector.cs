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

using Symbiote.SDK;
using Symbiote.SDK.Plugin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Symbiote.SDK.Plugin.Connector
{
    /// <summary>
    ///     Defines the interface for Connector Plugins.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Classes implementing IConnector are responsible for application extensibility, providing read/write access to
    ///         external data stores and interfaces.
    ///     </para>
    ///     <para>
    ///         All data exposed by an IConnector must be represented as an <see cref="Item"/> with instance type
    ///         <see cref="ConnectorItem"/>. ConnectorItem instances must be arranged in a composite (tree) data structure, the
    ///         minimum structure being that of a single root node. This data structure is accessed by the application with the
    ///         <see cref="Browse()"/> and <see cref="Browse(Item)"/> methods. The <see cref="Find(string)"/> method must be
    ///         implemented to search for and return an Item matching the specified Fully Qualified Name within the data structure,
    ///         if it exists.
    ///     </para>
    ///     <para>
    ///         Asynchronous overloads are provided for each of the methods. These are: <see cref="BrowseAsync()"/>,
    ///         <see cref="BrowseAsync(Item)"/>, and <see cref="FindAsync(string)"/>. Other than enclosing the return type in a
    ///         <see cref="Task{TResult}"/> and executing asynchronously, these methods are identical to their synchronous counterparts.
    ///     </para>
    ///     <para>
    ///         The IConnector interface represents the minimun implementation of the class. Other functionality may be implemented
    ///         by implementing one or more of the following interfaces:
    ///         <list>
    ///             <item>
    ///                 <see cref="ISubscribable"/>: Allows the application to subscribe Model Items to ConnectorItems to receive
    ///                 value updates.
    ///             </item>
    ///             <item><see cref="IWriteable"/>: Allows the application to write values to the source of a ConnectorItem.</item>
    ///             <item>
    ///                 <see cref="IExtensible"/>: Allows the application to add additional ConnectorItems to the Connector at runtime.
    ///             </item>
    ///         </list>
    ///     </para>
    /// </remarks>
    public interface IConnector : IPluginInstance, IItemProvider
    {
    }
}