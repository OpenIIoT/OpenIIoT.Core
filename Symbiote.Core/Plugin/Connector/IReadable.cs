/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █    ▄█     ▄████████                                                                     
      █   ███    ███    ███                                                                     
      █   ███▌  ▄███▄▄▄▄██▀    ▄█████   ▄█████  ██████▄    ▄█████  ▀██████▄   █          ▄█████ 
      █   ███▌ ▀▀███▀▀▀▀▀     ██   █    ██   ██ ██   ▀██   ██   ██   ██   ██ ██         ██   █  
      █   ███▌ ▀███████████  ▄██▄▄      ██   ██ ██    ██   ██   ██  ▄██▄▄█▀  ██        ▄██▄▄    
      █   ███    ███    ███ ▀▀██▀▀    ▀████████ ██    ██ ▀████████ ▀▀██▀▀█▄  ██       ▀▀██▀▀    
      █   ███    ███    ███   ██   █    ██   ██ ██   ▄██   ██   ██   ██   ██ ██▌    ▄   ██   █  
      █   █▀     ███    ███   ███████   ██   █▀ ██████▀    ██   █▀ ▄██████▀  ████▄▄██   ███████ 
      █   
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █  
      █  Defines the interface for Connector Plugins capable of writing data to the source of the Connector data.
      █  
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ 
                                                                                                   ██ 
                                                                                               ▀█▄ ██ ▄█▀ 
                                                                                                 ▀████▀   
                                                                                                   ▀▀                            */
using Symbiote.Core.Model;
using System.Threading.Tasks;

namespace Symbiote.Core.Plugin.Connector
{
    /// <summary>
    /// Defines the interface for Connector Plugins capable of providing data from the source of the Connector data.
    /// </summary>
    /// <remarks>
    /// <para>
    ///     An <see cref="IConnector"/> instance implementing IReadable is responsible for providing data for 
    ///     <see cref="ConnectorItem"/>s by way of the <see cref="Read(Item)"/> method.  This method accepts a 
    ///     ConnectorItem instance.
    /// </para>
    /// <para>
    ///     The <see cref="Read(Item)"/> method must return a valid <see cref="Result{T}"/> containing the result of the operation,
    ///     and the read data boxed within an object, including any informational, warning or error messages 
    ///     generated during the operation.
    /// </para>
    /// <para>
    ///     The <see cref="ReadAsync(Item)"/> method behaves as <see cref="Read(Item)"/> but executes asynchronously.
    /// </para>
    /// </remarks>
    public interface IReadable
    {
        /// <summary>
        /// Reads and returns the current value of the specified <see cref="Item"/>.
        /// </summary>
        /// <param name="item">The Item to read.</param>
        /// <returns>A Result containing the result of the operation and the current value of the Item.</returns>
        Result<object> Read(Item item);

        /// <summary>
        /// Asyncronously reads and returns the current value of the specified <see cref="Item"/>
        /// </summary>
        /// <param name="item">The Item to read.</param>
        /// <returns>A Result containing the result of the operation and the current value of the Item.</returns>
        Task<Result<object>> ReadAsync(Item item);
    }
}
