/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄▄▄▄███▄▄▄▄                                         ▄█    █▄                                                                              ▄████████
      █    ▄██▀▀▀███▀▀▀██▄                                      ███    ███                                                                            ███    ███
      █    ███   ███   ███  ██████  ██████▄     ▄█████  █       ███    ███   ▄█████   █        █  ██████▄    ▄█████      ██     █   ██████  ██▄▄▄▄   ▄███▄▄▄▄██▀    ▄█████   ▄█████ ██   █   █           ██
      █    ███   ███   ███ ██    ██ ██   ▀██   ██   █  ██       ███    ███   ██   ██ ██       ██  ██   ▀██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄ ▀▀███▀▀▀▀▀     ██   █    ██  ▀  ██   ██ ██       ▀███████▄
      █    ███   ███   ███ ██    ██ ██    ██  ▄██▄▄    ██       ███    ███   ██   ██ ██       ██▌ ██    ██   ██   ██     ██  ▀ ██▌ ██    ██ ██   ██ ▀███████████  ▄██▄▄      ██     ██   ██ ██           ██  ▀
      █    ███   ███   ███ ██    ██ ██    ██ ▀▀██▀▀    ██       ███    ███ ▀████████ ██       ██  ██    ██ ▀████████     ██    ██  ██    ██ ██   ██   ███    ███ ▀▀██▀▀    ▀███████ ██   ██ ██           ██
      █    ███   ███   ███ ██    ██ ██   ▄██   ██   █  ██▌    ▄  ██▄  ▄██    ██   ██ ██▌    ▄ ██  ██   ▄██   ██   ██     ██    ██  ██    ██ ██   ██   ███    ███   ██   █     ▄  ██ ██   ██ ██▌    ▄     ██
      █     ▀█   ███   █▀   ██████  ██████▀    ███████ ████▄▄██   ▀████▀     ██   █▀ ████▄▄██ █   ██████▀    ██   █▀    ▄██▀   █    ██████   █   █    ███    ███   ███████  ▄████▀  ██████  ████▄▄██    ▄██▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Data Transfer Object containing model validation information for a data model.
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

namespace OpenIIoT.SDK.Service.WebApi.ModelValidation
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    ///     Data Transfer Object containing model validation information for a data model.
    /// </summary>
    [DataContract]
    public class ModelValidationResult
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ModelValidationResult"/> class.
        /// </summary>
        public ModelValidationResult()
        {
            Model = new List<ModelValidationField>();
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets or sets a message describing the overall state of the model with respect to validation.
        /// </summary>
        [DataMember(Order = 1)]
        [JsonProperty(Order = 1)]
        public string Message { get; set; }

        /// <summary>
        ///     Gets or sets the list of model fields and their respective validation results.
        /// </summary>
        [DataMember(Order = 2)]
        [JsonProperty(Order = 2)]
        public List<ModelValidationField> Model { get; set; }

        #endregion Public Properties
    }
}