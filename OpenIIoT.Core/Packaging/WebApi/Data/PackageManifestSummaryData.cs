/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                 ▄▄▄▄███▄▄▄▄
      █     ███    ███                                                               ▄██▀▀▀███▀▀▀██▄
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████  ███   ███   ███   ▄█████  ██▄▄▄▄   █     ▄█████    ▄█████   ▄█████     ██
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █   ███   ███   ███   ██   ██ ██▀▀▀█▄ ██    ██   ▀█   ██   █    ██  ▀  ▀███████▄
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄     ███   ███   ███   ██   ██ ██   ██ ██▌  ▄██▄▄     ▄██▄▄      ██         ██  ▀
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀     ███   ███   ███ ▀████████ ██   ██ ██  ▀▀██▀▀    ▀▀██▀▀    ▀███████     ██
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █   ███   ███   ███   ██   ██ ██   ██ ██    ██        ██   █     ▄  ██     ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████   ▀█   ███   █▀    ██   █▀  █   █  █     ██        ███████  ▄████▀     ▄██▀
      █
      █      ▄████████                                                            ████████▄
      █     ███    ███                                                            ███   ▀███
      █     ███    █▀  ██   █     ▄▄██▄▄▄     ▄▄██▄▄▄    ▄█████     █████ ▄█   ▄  ███    ███   ▄█████      ██      ▄█████
      █     ███        ██   ██  ▄█▀▀██▀▀█▄  ▄█▀▀██▀▀█▄   ██   ██   ██  ██ ██   █▄ ███    ███   ██   ██ ▀███████▄   ██   ██
      █   ▀███████████ ██   ██  ██  ██  ██  ██  ██  ██   ██   ██  ▄██▄▄█▀ ▀▀▀▀▀██ ███    ███   ██   ██     ██  ▀   ██   ██
      █            ███ ██   ██  ██  ██  ██  ██  ██  ██ ▀████████ ▀███████ ▄█   ██ ███    ███ ▀████████     ██    ▀████████
      █      ▄█    ███ ██   ██  ██  ██  ██  ██  ██  ██   ██   ██   ██  ██ ██   ██ ███   ▄███   ██   ██     ██      ██   ██
      █    ▄████████▀  ██████    █  ██  █    █  ██  █    ██   █▀   ██  ██  █████  ████████▀    ██   █▀    ▄██▀     ██   █▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Data Transfer Object used when returning Package Manifest objects.
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
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using OpenIIoT.SDK.Common;
    using OpenIIoT.SDK.Packaging.Manifest;

    /// <summary>
    ///     Data Transfer Object used when returning Package Manifest objects.
    /// </summary>
    [DataContract]
    public class PackageManifestSummaryData
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageManifestSummaryData"/> class with the specified <paramref name="packageManifest"/>.
        /// </summary>
        /// <param name="packageManifest">The <see cref="IPackageManifest"/> instance from which to copy values.</param>
        public PackageManifestSummaryData(IPackageManifest packageManifest)
        {
            this.CopyPropertyValuesFrom(packageManifest);

            if (packageManifest.Signature != default(PackageManifestSignature))
            {
                Signature = new PackageManifestSummarySignatureData(packageManifest.Signature);
            }
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets or sets the Package copyright.
        /// </summary>
        [JsonProperty(Order = 6)]
        [DataMember(Order = 6)]
        public string Copyright { get; set; }

        /// <summary>
        ///     Gets or sets the Package description.
        /// </summary>
        [JsonProperty(Order = 4)]
        [DataMember(Order = 4)]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the Package license.
        /// </summary>
        [JsonProperty(Order = 7)]
        [DataMember(Order = 7)]
        public string License { get; set; }

        /// <summary>
        ///     Gets or sets the Package namespace.
        /// </summary>
        [JsonProperty(Order = 3)]
        [DataMember(Order = 3)]
        public string Namespace { get; set; }

        /// <summary>
        ///     Gets or sets the Package publisher.
        /// </summary>
        [JsonProperty(Order = 5)]
        [DataMember(Order = 5)]
        public string Publisher { get; set; }

        /// <summary>
        ///     Gets or sets the Package Signature.
        /// </summary>
        [JsonProperty(Order = 9)]
        [DataMember(Order = 9)]
        public PackageManifestSummarySignatureData Signature { get; set; }

        /// <summary>
        ///     Gets or sets the Package title.
        /// </summary>
        [JsonProperty(Order = 1)]
        [DataMember(Order = 1)]
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the Package url.
        /// </summary>
        [JsonProperty(Order = 8)]
        [DataMember(Order = 8)]
        public string Url { get; set; }

        /// <summary>
        ///     Gets or sets the Package version.
        /// </summary>
        [JsonProperty(Order = 2)]
        [DataMember(Order = 2)]
        public string Version { get; set; }

        #endregion Public Properties
    }
}