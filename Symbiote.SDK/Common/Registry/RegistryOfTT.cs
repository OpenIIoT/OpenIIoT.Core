/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████                                                                    ███            ███
      █     ███    ███                                                                ▀█████████▄    ▀█████████▄
      █    ▄███▄▄▄▄██▀    ▄█████    ▄████▄    ▄█████     ██       █████ ▄█   ▄      ▄    ▀███▀▀██       ▀███▀▀██ ▄
      █   ▀▀███▀▀▀▀▀     ██   █    ██    ▀    ██  ▀  ▀███████▄   ██  ██ ██   █▄   ▄▀      ███   ▀        ███   ▀  ▀▄
      █   ▀███████████  ▄██▄▄     ▄██         ██         ██  ▀  ▄██▄▄█▀ ▀▀▀▀▀██ ▄▀        ███            ███        ▀▄
      █     ███    ███ ▀▀██▀▀    ▀▀██ ███▄  ▀███████     ██    ▀███████ ▄█   ██ ▀▄        ███            ███        ▄▀
      █     ███    ███   ██   █    ██    ██    ▄  ██     ██      ██  ██ ██   ██   ▀▄      ███     ▄▄     ███      ▄▀
      █     ███    ███   ███████   ██████▀   ▄████▀     ▄██▀     ██  ██  █████      ▀    ▄████▀   ▄█    ▄████▀   ▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  A two dimensional object Registry.
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
    ///     A single dimensional object Registry.
    /// </summary>
    /// <typeparam name="TKey">The Type of the Registry key.</typeparam>
    /// <typeparam name="TValue">The Type of the Registry value.</typeparam>
    public class Registry<TKey, TValue> : IRegistry<TKey, TValue>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Registry{TKey}"/> class.
        /// </summary>
        public Registry()
        {
            Registrants = new Dictionary<TKey, TValue>();
        }

        /// <summary>
        ///     Gets the Registry <see cref="List{T}"/>.
        /// </summary>
        public Dictionary<TKey, TValue> Registrants { get; private set; }

        /// <summary>
        ///     Adds the specified key to the <see cref="Registrants"/><see cref="List{T}"/>.
        /// </summary>
        /// <param name="key">The key to add.</param>
        /// <param name="value">The value associated with the specified key.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Register(TKey key, TValue value)
        {
            Result retVal = new Result();

            if (Registrants.ContainsKey(key))
            {
                retVal.AddError("The specified key '" + key.ToString() + "' has already been registered.");
            }
            else
            {
                Registrants.Add(key, value);
            }

            return retVal;
        }

        /// <summary>
        ///     Removes the specified Key from the <see cref="Registrants"/><see cref="List{T}"/>.
        /// </summary>
        /// <param name="key">The key to remove.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result DeRegister(TKey key)
        {
            Result retVal = new Result();

            if (!Registrants.ContainsKey(key))
            {
                retVal.AddWarning("The specified key '" + key.ToString() + "' has not been registered and therefore can not be deregistered.");
            }
            else
            {
                Registrants.Remove(key);
            }

            return retVal;
        }
    }
}