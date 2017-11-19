/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄
      █     ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████
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
      █  Data Transfer Object used when returning Package objects.
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
    using OpenIIoT.SDK.Packaging.Manifest;

    /// <summary>
    ///     Data Transfer Object used when returning Package objects.
    /// </summary>
    [DataContract]
    public class PackageSummaryData
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageSummaryData"/> class with the specified <paramref name="package"/>.
        /// </summary>
        /// <param name="package">The <see cref="IPackage"/> instance from which to copy values.</param>
        public PackageSummaryData(IPackage package)
        {
            this.CopyPropertyValuesFrom(package);

            if (package.Manifest != default(IPackageManifest))
            {
                Manifest = new PackageManifestSummaryData(package.Manifest);
            }
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets or sets the fully qualified name of the directory in which the Package resides.
        /// </summary>
        [JsonProperty(Order = 2)]
        [DataMember(Order = 2)]
        public string DirectoryName { get; set; }

        /// <summary>
        ///     Gets or sets the Fully Qualified Name of the Package.
        /// </summary>
        [JsonProperty(Order = 1)]
        [DataMember(Order = 1)]
        public string FQN { get; set; }

        /// <summary>
        ///     Gets or sets the time at which the archive was last modified, according to the host filesystem.
        /// </summary>
        [JsonProperty(Order = 3)]
        [DataMember(Order = 3)]
        public DateTime InstalledOn { get; set; }

        /// <summary>
        ///     Gets or sets the Manifest for the Package.
        /// </summary>
        [JsonProperty(Order = 4)]
        [DataMember(Order = 4)]
        public PackageManifestSummaryData Manifest { get; set; }

        #endregion Public Properties
    }
}