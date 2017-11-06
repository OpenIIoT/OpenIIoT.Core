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
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Represents an installable extension archive.
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
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using OpenIIoT.SDK.Packaging;
    using OpenIIoT.SDK.Packaging.Manifest;

    /// <summary>
    ///     Represents an installable extension archive.
    /// </summary>
    [DataContract]
    public class Package : IPackage
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Package"/> class.
        /// </summary>
        /// <param name="directoryInfo">The <see cref="DirectoryInfo"/> instance of the directory in which the Package resides.</param>
        /// <param name="manifest">The manifest contained within the archive.</param>
        public Package(DirectoryInfo directoryInfo, IPackageManifest manifest)
        {
            DirectoryInfo = directoryInfo;
            Manifest = manifest;

            Files = DirectoryInfo.EnumerateFiles("*", SearchOption.AllDirectories).Select(f => f.FullName).ToList();
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the fully qualified name of the directory in which the Package resides.
        /// </summary>
        [JsonProperty(Order = 2)]
        [DataMember(Order = 2)]
        public string DirectoryName => DirectoryInfo.FullName;

        /// <summary>
        ///     Gets the list of files contained within the Package directory.
        /// </summary>
        [JsonProperty(Order = 5)]
        [DataMember(Order = 5)]
        public IList<string> Files { get; private set; }

        /// <summary>
        ///     Gets the Fully Qualified Name of the Package.
        /// </summary>
        [JsonProperty(Order = 1)]
        [DataMember(Order = 1)]
        public string FQN => Manifest.Namespace + "." + Manifest.Name;

        /// <summary>
        ///     Gets the time at which the archive was last modified, according to the host filesystem.
        /// </summary>
        [JsonProperty(Order = 3)]
        [DataMember(Order = 3)]
        public DateTime InstalledOn => DirectoryInfo.CreationTimeUtc;

        /// <summary>
        ///     Gets the <see cref="IPackageManifest"/> for the Package.
        /// </summary>
        [JsonProperty(Order = 4)]
        [DataMember(Order = 4)]
        public IPackageManifest Manifest { get; }

        #endregion Public Properties

        #region Private Properties

        /// <summary>
        ///     Gets or sets the <see cref="DirectoryInfo"/> instance of the directory in which the Package resides.
        /// </summary>
        private DirectoryInfo DirectoryInfo { get; set; }

        #endregion Private Properties
    }
}