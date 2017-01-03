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
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █
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

using System.Threading.Tasks;

namespace Symbiote.SDK
{
    /// <summary>
    ///     Defines the interface for Connector Plugins capable of providing data from the source of the Connector data.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         An <see cref="IConnector"/> instance implementing IReadable is responsible for providing data for
    ///         <see cref="ConnectorItem"/> s by way of the <see cref="Read(Item)"/> method. This method accepts a ConnectorItem instance.
    ///     </para>
    ///     <para>
    ///         The <see cref="Read(Item)"/> method must return a valid <see cref="Result{T}"/> containing the result of the
    ///         operation, and the read data boxed within an object, including any informational, warning or error messages
    ///         generated during the operation.
    ///     </para>
    ///     <para>The <see cref="ReadAsync(Item)"/> method behaves as <see cref="Read(Item)"/> but executes asynchronously.</para>
    /// </remarks>
    public interface IReadable
    {
        /// <summary>
        ///     Reads and returns the current value of the specified <see cref="Item"/>.
        /// </summary>
        /// <param name="item">The Item to read.</param>
        /// <returns>The value of the specified Item.</returns>
        object Read(Item item);

        /// <summary>
        ///     Asynchronously reads and returns the current value of the specified <see cref="Item"/>
        /// </summary>
        /// <param name="item">The Item to read.</param>
        /// <returns>The value of the specified Item.</returns>
        Task<object> ReadAsync(Item item);
    }
}