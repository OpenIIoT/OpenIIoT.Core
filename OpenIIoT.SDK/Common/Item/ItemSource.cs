/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█                                     ▄████████
      █   ███                                    ███    ███
      █   ███▌     ██       ▄█████    ▄▄██▄▄▄    ███    █▀   ██████  ██   █     █████  ▄██████    ▄█████
      █   ███▌ ▀███████▄   ██   █   ▄█▀▀██▀▀█▄   ███        ██    ██ ██   ██   ██  ██ ██    ██   ██   █
      █   ███▌     ██  ▀  ▄██▄▄     ██  ██  ██ ▀███████████ ██    ██ ██   ██  ▄██▄▄█▀ ██    ▀   ▄██▄▄
      █   ███      ██    ▀▀██▀▀     ██  ██  ██          ███ ██    ██ ██   ██ ▀███████ ██    ▄  ▀▀██▀▀
      █   ███      ██      ██   █   ██  ██  ██    ▄█    ███ ██    ██ ██   ██   ██  ██ ██    ██   ██   █
      █   █▀      ▄██▀     ███████   █  ██  █   ▄████████▀   ██████  ██████    ██  ██ ██████▀    ███████
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Enumeration of the different Item sources.
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

namespace OpenIIoT.SDK
{
    /// <summary>
    ///     Enumeration of the different <see cref="Item"/> sources.
    /// </summary>
    public enum ItemSource
    {
        /// <summary>
        ///     The <see cref="Item"/> source is unknown (blank).
        /// </summary>
        Unknown,

        /// <summary>
        ///     The <see cref="Item"/> source is unresolved; the <see cref="Item"/> corresponding to the
        ///     <see cref="Item.SourceFQN"/> property could not be located.
        /// </summary>
        Unresolved,

        /// <summary>
        ///     The <see cref="Item"/> source is another instance of the <see cref="Item"/> class.
        /// </summary>
        Item,

        /// <summary>
        ///     The <see cref="Item"/> source is a class implementing the <see cref="IItemProvider"/> interface.
        /// </summary>
        Provider
    }
}