/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █    ▄█     ▄████████                                                                                  
      █   ███    ███    ███                                                                                  
      █   ███▌   ███    █▀  ▀███  ▐██▀     ██       ▄█████ ██▄▄▄▄    ▄█████  █  ▀██████▄   █          ▄█████ 
      █   ███▌  ▄███▄▄▄       ██  ██   ▀███████▄   ██   █  ██▀▀▀█▄   ██  ▀  ██    ██   ██ ██         ██   █  
      █   ███▌ ▀▀███▀▀▀        ████▀       ██  ▀  ▄██▄▄    ██   ██   ██     ██▌  ▄██▄▄█▀  ██        ▄██▄▄    
      █   ███    ███    █▄     ████        ██    ▀▀██▀▀    ██   ██ ▀███████ ██  ▀▀██▀▀█▄  ██       ▀▀██▀▀    
      █   ███    ███    ███  ▄██ ▀██       ██      ██   █  ██   ██    ▄  ██ ██    ██   ██ ██▌    ▄   ██   █  
      █   █▀     ██████████ ███    ██▄    ▄██▀     ███████  █   █   ▄████▀  █   ▄██████▀  ████▄▄██   ███████ 
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
using Symbiote.Core.Model;
using System.Collections.Generic;

namespace Symbiote.Core.Plugin.Connector
{
    /// <summary>
    /// Defines the interface for Connector Plugins capable of allowing new ConnectorItems to be added at runtime.
    /// </summary>
    /// <remarks>
    /// <para>
    ///     An <see cref="IConnector"/> instance implementing IExtensible is responsible for adding additional <see cref="ConnectorItem"/>s
    ///     to the Connector Plugin's Item data structure at runtime.  This functionality is intended primarily for data sources without
    ///     the capability of fully describing the Items that are available for reading.
    /// </para>
    /// <para>
    ///     New ConnectorItems are added via the <see cref="AddItem(string, string)"/> method.  This method accepts a string containing the
    ///     Fully Qualified Name for the new item, and a string containing the Fully Qualified Source Name for the item.  The Source Name
    ///     should be validated by the Plugin to ensure it is well formed.  The Add() method must return an <see cref="Result{T}"/>
    ///     containing the result of the operation and Item that was added, as well as any informational, warning or error messages that 
    ///     were generated during the operation.
    /// </para>
    /// <para>
    ///     Fully Qualified Names may be any well formed name.  If the path of the FQN contains items that don't yet exist, the Plugin
    ///     is responsible for creating them.  For example, if the specified FQN is "Devices.Switches.Momentary.Paddle" and only the 
    ///     "Devices" Item exists, the Add() method is required to create "Switches", "Momentary" and "Paddle", with the SourceFQN property
    ///     of "Paddle" set to the specified Fully Qualified Source Name.
    /// </para>
    /// <para>
    ///     A list (rather, dictionary) of <see cref="Item"/>s added using the <see cref="AddItem(string, string)"/> method shall be
    ///     made available in the <see cref="AddedItems"/> property.  This property is a <see cref="Dictionary{TKey, TValue}"/>, 
    ///     keyed on the Fully Qualified Name of the Item and with a value of the Source Fully Qualified Name.
    /// </para>
    /// <para>
    ///     The <see cref="AddedItems"/> list must be persisted and each added Item must be created and added to the appropriate
    ///     location in the Connector's Item data structure when the Connector is initialized.  Should the automatically populated
    ///     Item structure within the Connector change such that a user defined Item's parent(s) no longer exist, the Item must 
    ///     still be added to the structure in accordance with the <see cref="AddItem(string, string)"/> method (that is, the structure
    ///     must be created if it does not exist).
    /// </para>
    /// </remarks>
    public interface IExtensible
    {
        /// <summary>
        ///     Returns a dictionary of the user defined <see cref="Item"/>s that have been added to the Connector, keyed on the 
        ///     Fully Qualified Name of the item and containing the Source Fully Qualified Name as the value.
        /// </summary>
        /// <remarks>
        /// <para>
        ///     The list of added items is presented as a dictionary due to the fact that added Items may reside anywhere in the 
        ///     Connector's Item hierarchy, and to present a list containing only the user defined Items the application
        ///     would need to use a flat list, as Items necessary for the proper traversal of the Item tree may be missing.
        /// </para>
        /// <para>
        ///     Presenting Items in a list in this manner would cause a great deal of trouble when trying to serialize the list
        ///     for consumption in an API.  In order to do this the API would need to traverse the list and gather only pertinent
        ///     properties from the Item list, then serialize those properties and present them.  This theoretical list would be
        ///     of type Dictionary{string, string}, ergo, the data type of this property.
        /// </para>
        /// </remarks>
        Dictionary<string, string> AddedItems { get; }

        /// <summary>
        /// Adds a new <see cref="Item"/> with the specified Fully Qualified Name and Fully Qualified Source Name
        /// to the Connector Plugin's data structure.
        /// </summary>
        /// <remarks>
        /// Items contained within the Fully Qualified Path for the Item must be created if they don't yet exist.
        /// </remarks>
        /// <param name="fqn">The Fully Qualifed Name of the <see cref="Item"/> to add.</param>
        /// <param name="sourceFQN">The Fully Qualified Source Name of the backing data point or structure.</param>
        /// <returns>A Result containing the result of the operation and the newly created Item.</returns>
        Result<Item> AddItem(string fqn, string sourceFQN);

        /// <summary>
        /// Removes a user defined <see cref="Item"/> from the Connector Plugin's data structure.
        /// </summary>
        /// <remarks>
        /// <para>If an Item being removed has child Items, all children are also removed.</para>
        /// <para>
        ///     This method accepts only a string, rather than an Item.  The rationale for this is that the FQN
        ///     is unique and sufficient enough to identify the proper Item, and that an API would most likely
        ///     select the Item to remove after selecting it from a list based on the <see cref="AddedItems"/>
        ///     property, which only contains the FQN as an identifer.
        /// </para>
        /// </remarks>
        /// <param name="fqn">The Item to remove.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result RemoveItem(string fqn);
    }
}
