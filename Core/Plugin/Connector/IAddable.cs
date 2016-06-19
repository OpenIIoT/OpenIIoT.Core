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
      █  Defines the interface for Connector Plugins capable of allowing new ConnectorItems to be added at runtime.
      █ 
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ 
                                                                                                   ██   
                                                                                               ▀█▄ ██ ▄█▀                       
                                                                                                 ▀████▀   
                                                                                                   ▀▀                            */
namespace Symbiote.Core.Plugin.Connector
{
    /// <summary>
    /// Defines the interface for Connector Plugins capable of allowing new ConnectorItems to be added at runtime.
    /// </summary>
    /// <remarks>
    /// <para>
    ///     An <see cref="IConnector"/> instance implementing IAddable is responsible for adding additional <see cref="ConnectorItem"/>s
    ///     to the Connector Plugin's Item data structure at runtime.  This functionality is intended primarily for data sources without
    ///     the capability of fully describing the Items that are available for reading.
    /// </para>
    /// <para>
    ///     New ConnectorItems are added via the <see cref="Add(string, string)"/> method.  This method accepts a string containing the
    ///     Fully Qualified Name for the new item, and a string containing the Fully Qualified Source Name for the item.  The Source Name
    ///     should be validated by the Plugin to ensure it is well formed.  The Add() method must return an <see cref="OperationResult{T}"/>
    ///     containing the result of the operation and Item that was added, as well as any informational, warning or error messages that 
    ///     were generated during the operation.
    /// </para>
    /// <para>
    ///     Fully Qualified Names may be any well formed name.  If the path of the FQN contains items that don't yet exist, the Plugin
    ///     is responsible for creating them.  For example, if the specified FQN is "Devices.Switches.Momentary.Paddle" and only the 
    ///     "Devices" Item exists, the Add() method is required to create "Switches", "Momentary" and "Paddle", with the SourceFQN property
    ///     of "Paddle" set to the specified Fully Qualified Source Name.
    /// </para>
    /// </remarks>
    public interface IAddable
    {
        /// <summary>
        /// Adds a new <see cref="ConnectorItem"/> with the specified Fully Qualified Name and Fully Qualified Source Name
        /// to the Connector Plugin's data structure.
        /// </summary>
        /// <remarks>
        /// Items contained within the Fully Qualified Path for the Item must be created if they don't yet exist.
        /// </remarks>
        /// <param name="fqn">The Fully Qualifed Name of the <see cref="Item"/> to add.</param>
        /// <param name="sourceFQN">The Fully Qualified Source Name of the backing data point or structure.</param>
        /// <returns>An <see cref="OperationResult{T}"/> containing an <see cref="Item"/> and the result of the operation.</returns>
        OperationResult<Item> Add(string fqn, string sourceFQN);
    }
}
