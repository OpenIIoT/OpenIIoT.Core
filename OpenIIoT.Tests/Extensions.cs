/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████
      █     ███    ███
      █     ███    █▀  ▀███  ▐██▀     ██       ▄█████ ██▄▄▄▄    ▄█████  █   ██████  ██▄▄▄▄    ▄█████
      █    ▄███▄▄▄       ██  ██   ▀███████▄   ██   █  ██▀▀▀█▄   ██  ▀  ██  ██    ██ ██▀▀▀█▄   ██  ▀
      █   ▀▀███▀▀▀        ████▀       ██  ▀  ▄██▄▄    ██   ██   ██     ██▌ ██    ██ ██   ██   ██
      █     ███    █▄     ████        ██    ▀▀██▀▀    ██   ██ ▀███████ ██  ██    ██ ██   ██ ▀███████
      █     ███    ███  ▄██ ▀██       ██      ██   █  ██   ██    ▄  ██ ██  ██    ██ ██   ██    ▄  ██
      █     ██████████ ███    ██▄    ▄██▀     ███████  █   █   ▄████▀  █    ██████   █   █   ▄████▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Extension methods to assist with testing and assertions.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016-2017 JP Dillingham (jp@dillingham.ws)
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
using System.Net.Http;

namespace OpenIIoT.Core.Tests
{
    /// <summary>
    ///     Extension methods to assist with testing and assertions.
    /// </summary>
    public static class Extensions
    {
        #region Public Methods

        /// <summary>
        ///     Returns the typed Content of the specified <see paramref="response"/>.
        /// </summary>
        /// <typeparam name="T">The desired Type of the Content.</typeparam>
        /// <param name="response">The response from which the Content is to be retrieved.</param>
        /// <returns>The typed Content, or default(T) if the Content can not be retrieved or cast.</returns>
        public static T GetContent<T>(this HttpResponseMessage response)
        {
            try
            {
                return (T)((ObjectContent<T>)response.Content).Value;
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        #endregion Public Methods
    }
}