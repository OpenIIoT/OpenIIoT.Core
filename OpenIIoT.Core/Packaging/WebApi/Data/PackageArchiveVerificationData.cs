/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                ▄████████
      █     ███    ███                                                                ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████   ███    ███    █████  ▄██████   ██   █     █   █    █     ▄█████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █    ███    ███   ██  ██ ██    ██   ██   ██   ██  ██    ██   ██   █
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ▀███████████  ▄██▄▄█▀ ██    ▀   ▄██▄▄▄██▄▄ ██▌ ██    ██  ▄██▄▄
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀      ███    ███ ▀███████ ██    ▄  ▀▀██▀▀▀██▀  ██  ██    ██ ▀▀██▀▀
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █    ███    ███   ██  ██ ██    ██   ██   ██   ██   █▄  ▄█    ██   █
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████   ███    █▀    ██  ██ ██████▀    ██   ██   █     ▀██▀     ███████
      █
      █    ▄█    █▄                                                                                         ████████▄
      █   ███    ███                                                                                        ███   ▀███
      █   ███    ███    ▄█████    █████  █     ▄█████  █   ▄██████   ▄█████      ██     █   ██████  ██▄▄▄▄  ███    ███   ▄█████      ██      ▄█████
      █   ███    ███   ██   █    ██  ██ ██    ██   ▀█ ██  ██    ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄ ███    ███   ██   ██ ▀███████▄   ██   ██
      █   ███    ███  ▄██▄▄     ▄██▄▄█▀ ██▌  ▄██▄▄    ██▌ ██    ▀    ██   ██     ██  ▀ ██▌ ██    ██ ██   ██ ███    ███   ██   ██     ██  ▀   ██   ██
      █   ███    ███ ▀▀██▀▀    ▀███████ ██  ▀▀██▀▀    ██  ██    ▄  ▀████████     ██    ██  ██    ██ ██   ██ ███    ███ ▀████████     ██    ▀████████
      █    ██▄  ▄██    ██   █    ██  ██ ██    ██      ██  ██    ██   ██   ██     ██    ██  ██    ██ ██   ██ ███   ▄███   ██   ██     ██      ██   ██
      █     ▀████▀     ███████   ██  ██ █     ██      █   ██████▀    ██   █▀    ▄██▀   █    ██████   █   █  ████████▀    ██   █▀    ▄██▀     ██   █▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Data Transfer Object used when returning the results of a Package Archive verification operation.
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

namespace OpenIIoT.Core.Packaging.WebApi.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Packaging;

    /// <summary>
    ///     Data Transfer Object used when returning the results of a Package Archive verification operation.
    /// </summary>
    [DataContract]
    public class PackageArchiveVerificationData
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageArchiveVerificationData"/> class with the specified <paramref name="result"/>.
        /// </summary>
        /// <param name="result">
        ///     the <see cref="IResult{T}"></see> generated by the
        ///     <see cref="PackageManager.VerifyPackageArchive(IPackageArchive)"/> method.
        /// </param>
        public PackageArchiveVerificationData(IResult<bool> result)
        {
            Verification = PackageVerification.Refuted;

            if (result.ReturnValue)
            {
                Verification = PackageVerification.Verified;
            }

            Messages = result.Messages.Select(m => m.Text).ToList();
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets or sets the list of messages generated by the operation.
        /// </summary>
        [DataMember(Order = 2)]
        [JsonProperty(Order = 2)]
        public IList<string> Messages { get; set; }

        /// <summary>
        ///     Gets or sets the result of the operation.
        /// </summary>
        [DataMember(Order = 1)]
        [JsonProperty(Order = 1)]
        public PackageVerification Verification { get; set; }

        #endregion Public Properties
    }
}