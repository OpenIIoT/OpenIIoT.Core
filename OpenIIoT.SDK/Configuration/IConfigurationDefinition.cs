/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█  ▄████████                                                                                                      ████████▄
      █   ███  ███    ███                                                                                                     ███   ▀███
      █   ███▌ ███    █▀   ██████  ██▄▄▄▄     ▄█████  █     ▄████▄  ██   █     █████   ▄█████      ██     █   ██████  ██▄▄▄▄  ███    ███    ▄█████    ▄█████  █  ██▄▄▄▄   █      ██     █   ██████  ██▄▄▄▄
      █   ███▌ ███        ██    ██ ██▀▀▀█▄   ██   ▀█ ██    ██    ▀  ██   ██   ██  ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄ ███    ███   ██   █    ██   ▀█ ██  ██▀▀▀█▄ ██  ▀███████▄ ██  ██    ██ ██▀▀▀█▄
      █   ███▌ ███        ██    ██ ██   ██  ▄██▄▄    ██▌  ▄██       ██   ██  ▄██▄▄█▀   ██   ██     ██  ▀ ██▌ ██    ██ ██   ██ ███    ███  ▄██▄▄     ▄██▄▄    ██▌ ██   ██ ██▌     ██  ▀ ██▌ ██    ██ ██   ██
      █   ███  ███    █▄  ██    ██ ██   ██ ▀▀██▀▀    ██  ▀▀██ ███▄  ██   ██ ▀███████ ▀████████     ██    ██  ██    ██ ██   ██ ███    ███ ▀▀██▀▀    ▀▀██▀▀    ██  ██   ██ ██      ██    ██  ██    ██ ██   ██
      █   ███  ███    ███ ██    ██ ██   ██   ██      ██    ██    ██ ██   ██   ██  ██   ██   ██     ██    ██  ██    ██ ██   ██ ███   ▄███   ██   █    ██      ██  ██   ██ ██      ██    ██  ██    ██ ██   ██
      █   █▀   ████████▀   ██████   █   █    ██      █     ██████▀  ██████    ██  ██   ██   █▀    ▄██▀   █    ██████   █   █  ████████▀    ███████   ██      █    █   █  █      ▄██▀   █    ██████   █   █
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Defines the interface for Configuration Definition objects.
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
using Utility.OperationResult;

namespace OpenIIoT.SDK.Configuration
{
    /// <summary>
    ///     Defines the interface for Configuration Definition objects.
    /// </summary>
    public interface IConfigurationDefinition
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the default configuration.
        /// </summary>
        /// <remarks>Must be an instance of the Type specified in the <see cref="Model"/> property.</remarks>
        object DefaultConfiguration { get; }

        /// <summary>
        ///     Gets or sets a string containing a json representation of an HTML configuration form.
        /// </summary>
        string Form { get; }

        /// <summary>
        ///     Gets or sets an object representing the model to be built from the schema.
        /// </summary>
        Type Model { get; }

        /// <summary>
        ///     Gets or sets a string containing a json representation of the schema to populate using the form.
        /// </summary>
        string Schema { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Returns a value indicating whether this instance is valid.
        /// </summary>
        /// <remarks>
        ///     To be considered valid, the <see cref="Form"/> and <see cref="Schema"/> properties must contain valid Json, the
        ///     <see cref="Model"/> property must not be null, and the Type of the value contained in <see cref="Default"/> must be
        ///     of the same Type specified in the Model property.
        /// </remarks>
        /// <returns>A value indicating whether this instance is valid.</returns>
        IResult<bool> IsValid();

        #endregion Public Methods
    }
}