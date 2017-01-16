/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████                                  ███
      █     ███    ███                              ▀█████████▄
      █     ███    █▀      ██     ██████     █████▄    ▀███▀▀██ ▄█   ▄     █████▄    ▄█████
      █     ███        ▀███████▄ ██    ██   ██   ██     ███   ▀ ██   █▄   ██   ██   ██   █
      █   ▀███████████     ██  ▀ ██    ██   ██   ██     ███     ▀▀▀▀▀██   ██   ██  ▄██▄▄
      █            ███     ██    ██    ██ ▀██████▀      ███     ▄█   ██ ▀██████▀  ▀▀██▀▀
      █      ▄█    ███     ██    ██    ██   ██          ███     ██   ██   ██        ██   █
      █    ▄████████▀     ▄██▀    ██████   ▄███▀       ▄████▀    █████   ▄███▀      ███████
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Enumeration of the circumstances under which a Stateful component can stop.
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

namespace OpenIIoT.SDK.Common
{
    /// <summary>
    ///     Enumeration of the circumstances under which a Stateful component can stop.
    /// </summary>
    [Flags]
    public enum StopType
    {
        /// <summary>
        ///     A normal stop.
        /// </summary>
        Stop = 1,

        /// <summary>
        ///     A restart.
        /// </summary>
        Restart = 2,

        /// <summary>
        ///     A stoppage due to system shutdown.
        /// </summary>
        Shutdown = 4,

        /// <summary>
        ///     An abnormal stop.
        /// </summary>
        Exception = 8
    }
}