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
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  An installable Package Archive.
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

namespace OpenIIoT.Core.Packaging
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using OpenIIoT.SDK.Packaging;
    using OpenIIoT.SDK.Packaging.Manifest;

    /// <summary>
    ///     An installable Package Archive.
    /// </summary>
    [DataContract]
    public class PackageArchive : IPackageArchive
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageArchive"/> class.
        /// </summary>
        /// <param name="fileInfo">The <see cref="FileInfo"/> instance of the Archive file.</param>
        /// <param name="manifest">The manifest contained within the Archive.</param>
        public PackageArchive(FileInfo fileInfo, PackageManifest manifest)
        {
            Manifest = manifest;
            FileInfo = fileInfo;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the time at which the archive was created, in Utc.
        /// </summary>
        [JsonProperty(Order = 6)]
        [DataMember(Order = 6)]
        public DateTime CreatedOn => FileInfo.CreationTimeUtc;

        /// <summary>
        ///     Gets the fully qualified filename of the archive file.
        /// </summary>
        [JsonProperty(Order = 2)]
        [DataMember(Order = 2)]
        public string FileName => FileInfo.FullName;

        /// <summary>
        ///     Gets the Fully Qualified Name of the Package.
        /// </summary>
        [JsonProperty(Order = 1)]
        [DataMember(Order = 1)]
        public string FQN => Manifest.Namespace + "." + Manifest.Title;

        /// <summary>
        ///     Gets a value indicating whether the archive signature contains a trust.
        /// </summary>
        [JsonProperty(Order = 4)]
        [DataMember(Order = 4)]
        public bool HasTrust => !string.IsNullOrEmpty(Manifest?.Signature?.Trust);

        /// <summary>
        ///     Gets a value indicating whether the archive is signed.
        /// </summary>
        [JsonProperty(Order = 5)]
        [DataMember(Order = 5)]
        public bool IsSigned => Manifest?.Signature != default(PackageManifestSignature);

        /// <summary>
        ///     Gets the <see cref="IPackageManifest"/> for the Package.
        /// </summary>
        [JsonProperty(Order = 8)]
        [DataMember(Order = 8)]
        public IPackageManifest Manifest { get; }

        /// <summary>
        ///     Gets the time at which the archive was last modified, in Utc.
        /// </summary>
        [JsonProperty(Order = 7)]
        [DataMember(Order = 7)]
        public DateTime ModifiedOn => FileInfo.LastWriteTimeUtc;

        /// <summary>
        ///     Gets the <see cref="PackageVerification"/> state of the Archive.
        /// </summary>
        [JsonProperty(Order = 3)]
        [DataMember(Order = 3)]
        public PackageVerification Verification { get; }

        #endregion Public Properties

        #region Private Properties

        /// <summary>
        ///     Gets or sets the <see cref="FileInfo"/> instance of the Archive file.
        /// </summary>
        private FileInfo FileInfo { get; set; }

        #endregion Private Properties
    }
}