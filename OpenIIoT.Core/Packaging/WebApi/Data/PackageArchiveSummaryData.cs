/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                ▄████████                                                          ▄████████                                                            ████████▄
      █     ███    ███                                                                ███    ███                                                        ███    ███                                                            ███   ▀███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████   ███    ███    █████  ▄██████   ██   █     █   █    █     ▄█████   ███    █▀  ██   █     ▄▄██▄▄▄     ▄▄██▄▄▄    ▄█████     █████ ▄█   ▄  ███    ███   ▄█████      ██      ▄█████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █    ███    ███   ██  ██ ██    ██   ██   ██   ██  ██    ██   ██   █    ███        ██   ██  ▄█▀▀██▀▀█▄  ▄█▀▀██▀▀█▄   ██   ██   ██  ██ ██   █▄ ███    ███   ██   ██ ▀███████▄   ██   ██
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ▀███████████  ▄██▄▄█▀ ██    ▀   ▄██▄▄▄██▄▄ ██▌ ██    ██  ▄██▄▄    ▀███████████ ██   ██  ██  ██  ██  ██  ██  ██   ██   ██  ▄██▄▄█▀ ▀▀▀▀▀██ ███    ███   ██   ██     ██  ▀   ██   ██
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀      ███    ███ ▀███████ ██    ▄  ▀▀██▀▀▀██▀  ██  ██    ██ ▀▀██▀▀             ███ ██   ██  ██  ██  ██  ██  ██  ██ ▀████████ ▀███████ ▄█   ██ ███    ███ ▀████████     ██    ▀████████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █    ███    ███   ██  ██ ██    ██   ██   ██   ██   █▄  ▄█    ██   █     ▄█    ███ ██   ██  ██  ██  ██  ██  ██  ██   ██   ██   ██  ██ ██   ██ ███   ▄███   ██   ██     ██      ██   ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████   ███    █▀    ██  ██ ██████▀    ██   ██   █     ▀██▀     ███████  ▄████████▀  ██████    █  ██  █    █  ██  █    ██   █▀   ██  ██  █████  ████████▀    ██   █▀    ▄██▀     ██   █▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Data Transfer Object used when returning Package Archive objects.
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
    using System;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using OpenIIoT.SDK.Common;
    using OpenIIoT.SDK.Packaging;

    /// <summary>
    ///     Data Transfer Object used when returning Package Archive objects.
    /// </summary>
    [DataContract]
    public class PackageArchiveSummaryData
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageArchiveSummaryData"/> class with the specified <paramref name="packageArchive"/>.
        /// </summary>
        /// <param name="packageArchive">The <see cref="IPackageArchive"/> instance from which to copy values.</param>
        public PackageArchiveSummaryData(IPackageArchive packageArchive)
        {
            this.CopyPropertyValuesFrom(packageArchive);

            Manifest = new PackageManifestData(packageArchive.Manifest);
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets or sets the time at which the Archive was created, in Utc.
        /// </summary>
        [JsonProperty(Order = 5)]
        [DataMember(Order = 5)]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        ///     Gets or sets the fully qualified filename of the Archive file.
        /// </summary>
        [JsonProperty(Order = 2)]
        [DataMember(Order = 2)]
        public string FileName { get; set; }

        /// <summary>
        ///     Gets or sets the fully fualified fame of the Package.
        /// </summary>
        [JsonProperty(Order = 1)]
        [DataMember(Order = 1)]
        public string FQN { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the Archive signature contains a trust.
        /// </summary>
        [JsonProperty(Order = 3)]
        [DataMember(Order = 3)]
        public bool HasTrust { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the Archive is signed.
        /// </summary>
        [JsonProperty(Order = 4)]
        [DataMember(Order = 4)]
        public bool IsSigned { get; set; }

        /// <summary>
        ///     Gets or sets the Manifest for the Package.
        /// </summary>
        [JsonProperty(Order = 7)]
        [DataMember(Order = 7)]
        public PackageManifestData Manifest { get; set; }

        /// <summary>
        ///     Gets or sets the time at which the Archive was last modified, in Utc.
        /// </summary>
        [JsonProperty(Order = 6)]
        [DataMember(Order = 6)]
        public DateTime ModifiedOn { get; set; }

        #endregion Public Properties
    }
}