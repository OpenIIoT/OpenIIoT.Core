/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █    ▄█     ▄████████                                                                                                   
      █   ███    ███    ███                                                                                                   
      █   ███▌   ███    █▀  ██   █  ▀██████▄    ▄█████  ▄██████    █████  █  ▀██████▄    ▄█████  ▀██████▄   █          ▄█████ 
      █   ███▌   ███        ██   ██   ██   ██   ██  ▀  ██    ██   ██  ██ ██    ██   ██   ██   ██   ██   ██ ██         ██   █  
      █   ███▌ ▀███████████ ██   ██  ▄██▄▄█▀    ██     ██    ▀   ▄██▄▄█▀ ██▌  ▄██▄▄█▀    ██   ██  ▄██▄▄█▀  ██        ▄██▄▄    
      █   ███           ███ ██   ██ ▀▀██▀▀█▄  ▀███████ ██    ▄  ▀███████ ██  ▀▀██▀▀█▄  ▀████████ ▀▀██▀▀█▄  ██       ▀▀██▀▀    
      █   ███     ▄█    ███ ██   ██   ██   ██    ▄  ██ ██    ██   ██  ██ ██    ██   ██   ██   ██   ██   ██ ██▌    ▄   ██   █  
      █   █▀    ▄████████▀  ██████  ▄██████▀   ▄████▀  ██████▀    ██  ██ █   ▄██████▀    ██   █▀ ▄██████▀  ████▄▄██   ███████ 
      █   
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █  
      █  Defines the interface for Connector Plugins which are capable of producing unsolicited value updates to configured Items.
      █  
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ 
                                                                                                   ██ 
                                                                                               ▀█▄ ██ ▄█▀ 
                                                                                                 ▀████▀   
                                                                                                   ▀▀                            */
using System.Collections.Generic;
using Utility.OperationResult;

namespace Symbiote.Core.SDK.Plugin.Connector
{
    /// <summary>
    /// Defines the interface for Connector Plugins which are capable of producing unsolicited value updates to configured Items.
    /// </summary>
    /// <remarks>
    /// <para>
    ///     Each <see cref="IConnector"/> implementing ISubscribable must implement a <see cref="Dictionary{TKey, TValue}"/> property
    ///     named <see cref="Subscriptions"/> keyed on <see cref="ConnectorItem"/> and with value <see cref="int"/>.  Each entry in the 
    ///     Dictionary represents an Item with at least one active subscriber.  
    /// </para>
    /// <para>
    ///     Subscriptions are added via the <see cref="Subscribe(ConnectorItem)"/> method.  If the specified ConnectorItem does not exist
    ///     in the Dictionary at the time of the method call, the method must add an entry to the Dictionary with value 1.  If the specified
    ///     ConnectorItem exists in the Dictionary, the value must be incremented by 1.  The Subscribe() method must return an 
    ///     <see cref="Result"/> containing the result of the operation as well as any informational, warning or error messages 
    ///     that were generated.
    /// </para>
    /// <para>
    ///     Subscription are removed via the <see cref="UnSubscribe(ConnectorItem)"/> method.  Assuming the specified ConnectorItem exists
    ///     in the Dictionary at the time of the method call, the value for the entry must be decremented by 1.  If, after the decrement,
    ///     the value is zero or less, the item must be removed from the Dictionary completely.  The UnSubscribe() method must return an
    ///     Result containing the result of the operation as well as any informational, warning or error messages that were generated.
    /// </para>
    /// </remarks>
    public interface ISubscribable
    {
        /// <summary>
        /// The <see cref="Dictionary{TKey, TValue}"/> containing the current list of subscribed items and the number of subscribers for each.
        /// </summary>
        Dictionary<ConnectorItem, int> Subscriptions { get; }

        /// <summary>
        /// Creates a subscription to the specified ConnectorItem.
        /// </summary>
        /// <remarks>
        ///     Upon the addition of the initial subscriber, an entry is added to the <see cref="Subscriptions"/>
        ///     Dictionary keyed with the specified Item and with a quantity of one.  Successive subscriptions
        ///     increment the quantity by one.
        /// </remarks>
        /// <param name="item">The <see cref="Item"/> to which the subscription should be added.</param>
        /// <returns>An <see cref="Result"/> containing the result of the operation.</returns>
        Result Subscribe(ConnectorItem item);

        /// <summary>
        /// Removes a subscription from the specified ConnectorItem.
        /// </summary>
        /// <remarks>
        ///     Decrements the number of subscribers within the <see cref="Subscriptions"/> Dictionary.
        ///     Upon removal of the final subscriber, the subscription is completely removed.
        /// </remarks>
        /// <param name="item">The <see cref="Item"/> for which the subscription should be removed.</param>
        /// <returns>An <see cref="Result"/> containing the result of the operation.</returns>
        Result UnSubscribe(ConnectorItem item);
    }
}
