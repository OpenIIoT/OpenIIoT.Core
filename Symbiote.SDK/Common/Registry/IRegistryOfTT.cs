/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█     ▄████████                                                                        ███            ███
      █   ███    ███    ███                                                                    ▀█████████▄    ▀█████████▄
      █   ███▌  ▄███▄▄▄▄██▀    ▄█████    ▄████▄   █    ▄█████     ██       █████ ▄█   ▄      ▄    ▀███▀▀██       ▀███▀▀██ ▄
      █   ███▌ ▀▀███▀▀▀▀▀     ██   █    ██    ▀  ██    ██  ▀  ▀███████▄   ██  ██ ██   █▄   ▄▀      ███   ▀        ███   ▀  ▀▄
      █   ███▌ ▀███████████  ▄██▄▄     ▄██       ██▌   ██         ██  ▀  ▄██▄▄█▀ ▀▀▀▀▀██ ▄▀        ███            ███        ▀▄
      █   ███    ███    ███ ▀▀██▀▀    ▀▀██ ███▄  ██  ▀███████     ██    ▀███████ ▄█   ██ ▀▄        ███            ███        ▄▀
      █   ███    ███    ███   ██   █    ██    ██ ██     ▄  ██     ██      ██  ██ ██   ██   ▀▄      ███     ▄▄     ███      ▄▀
      █   █▀     ███    ███   ███████   ██████▀  █    ▄████▀     ▄██▀     ██  ██  █████      ▀    ▄████▀   ▄█    ▄████▀   ▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Defines the interface for Registrar objects having a two dimensional Registry.
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

using System.Collections.Generic;
using Utility.OperationResult;

namespace Symbiote.SDK
{
    /// <summary>
    ///     Defines the interface for Registrar objects having a two dimensional <see cref="Registry"/>.
    /// </summary>
    /// <typeparam name="TKey">The Type of the Registry key.</typeparam>
    /// <typeparam name="TValue">The Type of the Registry value.</typeparam>
    public interface IRegistry<TKey, TValue>
    {
        /// <summary>
        ///     Gets the Registry <see cref="Dictionary{TKey, TValue}"/>.
        /// </summary>
        Dictionary<TKey, TValue> Registrants { get; }

        /// <summary>
        ///     Adds the specified key to the <see cref="Registants"/><see cref="Dictionary{TKey, TValue}"/> with the specified value.
        /// </summary>
        /// <param name="key">The key to add.</param>
        /// <param name="value">The value associated with the specified key.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result Register(TKey key, TValue value);

        /// <summary>
        ///     Removes the specified key from the <see cref="Registrants"/><see cref="Dictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="key">The key to remove.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result DeRegister(TKey key);
    }
}