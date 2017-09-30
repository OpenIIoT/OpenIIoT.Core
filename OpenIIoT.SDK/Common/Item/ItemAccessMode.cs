/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█                                    ▄████████                                                   ▄▄▄▄███▄▄▄▄
      █   ███                                    ███    ███                                                ▄██▀▀▀███▀▀▀██▄
      █   ███▌     ██       ▄█████    ▄▄██▄▄▄    ███    ███  ▄██████  ▄██████    ▄█████   ▄█████   ▄█████  ███   ███   ███  ██████  ██████▄     ▄█████
      █   ███▌ ▀███████▄   ██   █   ▄█▀▀██▀▀█▄   ███    ███ ██    ██ ██    ██   ██   █    ██  ▀    ██  ▀   ███   ███   ███ ██    ██ ██   ▀██   ██   █
      █   ███▌     ██  ▀  ▄██▄▄     ██  ██  ██ ▀███████████ ██    ▀  ██    ▀   ▄██▄▄      ██       ██      ███   ███   ███ ██    ██ ██    ██  ▄██▄▄
      █   ███      ██    ▀▀██▀▀     ██  ██  ██   ███    ███ ██    ▄  ██    ▄  ▀▀██▀▀    ▀███████ ▀███████  ███   ███   ███ ██    ██ ██    ██ ▀▀██▀▀
      █   ███      ██      ██   █   ██  ██  ██   ███    ███ ██    ██ ██    ██   ██   █     ▄  ██    ▄  ██  ███   ███   ███ ██    ██ ██   ▄██   ██   █
      █   █▀      ▄██▀     ███████   █  ██  █    ███    █▀  ██████▀  ██████▀    ███████  ▄████▀   ▄████▀    ▀█   ███   █▀   ██████  ██████▀    ███████
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Enumeration of the different Item access modes.
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

namespace OpenIIoT.SDK.Common
{
    /// <summary>
    ///     Enumeration of the different <see cref="Item"/> access modes.
    /// </summary>
    public enum ItemAccessMode
    {
        /// <summary>
        ///     The <see cref="Item"/> is capable of being written to as well as read from.
        /// </summary>
        ReadWrite,

        /// <summary>
        ///     The <see cref="Item"/> is capable of being read from but not written to.
        /// </summary>
        ReadOnly
    }
}