/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █    ▄█   ▄█                                  
      █   ███  ███                                  
      █   ███▌ ███▌     ██       ▄█████    ▄▄██▄▄▄  
      █   ███▌ ███▌ ▀███████▄   ██   █   ▄█▀▀██▀▀█▄ 
      █   ███▌ ███▌     ██  ▀  ▄██▄▄     ██  ██  ██ 
      █   ███  ███      ██    ▀▀██▀▀     ██  ██  ██ 
      █   ███  ███      ██      ██   █   ██  ██  ██ 
      █   █▀   █▀      ▄██▀     ███████   █  ██  █  
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      ▄  
      █  Defines the interface for Model Items.
      █  
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀   
      █  The GNU Affero General Public License (GNU AGPL)
      █  
      █  Copyright (C) 2016 JP Dillingham (jp@dillingham.ws)
      █  
      █  This program is free software: you can redistribute it and/or modify
      █  it under the terms of the GNU Affero General Public License as published by
      █  the Free Software Foundation, either version 3 of the License, or
      █  (at your option) any later version.
      █  
      █  This program is distributed in the hope that it will be useful,
      █  but WITHOUT ANY WARRANTY; without even the implied warranty of
      █  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      █  GNU Affero General Public License for more details.
      █  
      █  You should have received a copy of the GNU Affero General Public License
      █  along with this program.  If not, see <http://www.gnu.org/licenses/>.
      █  
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ 
                                                                                                   ██ 
                                                                                               ▀█▄ ██ ▄█▀ 
                                                                                                 ▀████▀   
                                                                                                   ▀▀                            */
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Utility.OperationResult;

namespace Symbiote.Core
{
    /// <summary>
    /// Defines the interface for Model Items.
    /// </summary>
    public interface IItem : ICloneable
    {
        #region Events

        /// <summary>
        /// Occurs when the value of the item changes.
        /// </summary>
        event EventHandler<ItemChangedEventArgs> Changed;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the Item's parent Item.
        /// </summary>
        Item Parent { get; }

        /// <summary>
        /// Gets the name of the Item; corresponds to the final tuple of the FQN.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the Fully Qualified Name of the item.
        /// </summary>
        string FQN { get; }

        /// <summary>
        /// Gets the path to the Item; corresponds to the FQN less the final tuple (the name).
        /// </summary>
        string Path { get; }

        /// <summary>
        /// Gets the fully qualified name name of the source item.
        /// </summary>
        string SourceFQN { get; }

        /// <summary>
        /// Gets the Item instance resolved from the SourceFQN.
        /// </summary>
        Item SourceItem { get; }

        /// <summary>
        /// Gets a Guid for the Item, generated when it is instantiated.
        /// </summary>
        Guid Guid { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the Item's value is writeable.
        /// </summary>
        bool Writeable { get; set; }

        /// <summary>
        /// Gets the value of the composite item.
        /// </summary>
        object Value { get; }

        /// <summary>
        /// Gets the collection of Items contained within this Item.
        /// </summary>
        List<Item> Children { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the Item's parent Item to the supplied Item.
        /// </summary>
        /// <param name="parent">The Item to set as the Item's parent.</param>
        /// <returns>A Result containing the result of the operation and the current Item.</returns>
        Result<Item> SetParent(Item parent);

        /// <summary>
        /// Adds the supplied item to this Item's Children collection.
        /// </summary>
        /// <param name="item">The Item to add.</param>
        /// <returns>A Result containing the result of the operation and the added Item.</returns>
        Result<Item> AddChild(Item item);

        /// <summary>
        /// Removes the specified child Item from this Item's Children collection.
        /// </summary>
        /// <param name="item">The Item to remove.</param>
        /// <returns>A Result containing the result of the operation and the removed Item.</returns>
        Result<Item> RemoveChild(Item item);

        /// <summary>
        /// Returns true if the Item has children, false otherwise.
        /// </summary>
        /// <returns>True if the Item has children, false otherwise.</returns>
        bool HasChildren();

        /// <summary>
        /// Returns the value of this Item's Value property.
        /// </summary>
        /// <returns>The retrieved value.</returns>
        object Read();

        /// <summary>
        /// Asynchronously returns the value of this Item's Value property.
        /// </summary>
        /// <returns>The retrieved value.</returns>
        Task<object> ReadAsync();

        /// <summary>
        /// Reads this Item's Value from its SourceItem.  If this Item has children,
        /// ReadFromSource() is also executed on each child.
        /// </summary>
        /// <returns>The retrieved value.</returns>
        object ReadFromSource();

        /// <summary>
        /// Asynchronously reads this Item's Value from its SourceItem.  If this item has children,
        /// ReadFromSource() is also executed on each child.
        /// </summary>
        /// <returns>The retrieved value.</returns>
        Task<object> ReadFromSourceAsync();

        /// <summary>
        /// Adds the SourceItemChanged event handler for this Item to the SourceItem's Changed event.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        Result SubscribeToSource();

        /// <summary>
        /// Removes the SourceItemChanged event handler for this Item from the SourceItem's Changed event.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        Result UnsubscribeFromSource();

        /// <summary>
        /// Writes the provided value to this Item's Value property.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result Write(object value);

        /// <summary>
        /// Asynchronously writes the provided value to this Item's Value property.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Task<Result> WriteAsync(object value);

        /// <summary>
        /// Writes the provided value to this Item's SourceItem.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result WriteToSource(object value);

        /// <summary>
        /// Asynchronously writes the provided value to this Item's SourceItem.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Task<Result> WriteToSourceAsync(object value);

        /// <summary>
        /// Returns the serialization of the Item using the default ContractResolver.
        /// </summary>
        /// <returns>The serialization of the Item.</returns>
        string ToJson();

        /// <summary>
        /// Returns the serialization of the Item using the supplied ContractResolver.
        /// </summary>
        /// <param name="contractResolver">The ContractResolver with which the Item is to be serialized.</param>
        /// <returns>The serialization of the Item.</returns>
        string ToJson(DefaultContractResolver contractResolver);

        #endregion
    }
}
