/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                 ▄▄▄▄███▄▄▄▄                                                                ▀█████████▄
      █     ███    ███                                                               ▄██▀▀▀███▀▀▀██▄                                                                ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████  ███   ███   ███   ▄█████  ██▄▄▄▄   █     ▄█████    ▄█████   ▄█████     ██      ███    ███ ██   █   █   █       ██████▄     ▄█████    █████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █   ███   ███   ███   ██   ██ ██▀▀▀█▄ ██    ██   ▀█   ██   █    ██  ▀  ▀███████▄  ▄███▄▄▄██▀  ██   ██ ██  ██       ██   ▀██   ██   █    ██  ██
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄     ███   ███   ███   ██   ██ ██   ██ ██▌  ▄██▄▄     ▄██▄▄      ██         ██  ▀ ▀▀███▀▀▀██▄  ██   ██ ██▌ ██       ██    ██  ▄██▄▄     ▄██▄▄█▀
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀     ███   ███   ███ ▀████████ ██   ██ ██  ▀▀██▀▀    ▀▀██▀▀    ▀███████     ██      ███    ██▄ ██   ██ ██  ██       ██    ██ ▀▀██▀▀    ▀███████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █   ███   ███   ███   ██   ██ ██   ██ ██    ██        ██   █     ▄  ██     ██      ███    ███ ██   ██ ██  ██▌    ▄ ██   ▄██   ██   █    ██  ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████   ▀█   ███   █▀    ██   █▀  █   █  █     ██        ███████  ▄████▀     ▄██▀   ▄█████████▀  ██████  █   ████▄▄██ ██████▀    ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Provides a fluent API with which to build PackageManifest instances.
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

using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenIIoT.SDK.Packaging.Manifest
{
    /// <summary>
    ///     Provides a fluent API with which to build <see cref="PackageManifest"/> instances.
    /// </summary>
    public class PackageManifestBuilder
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageManifestBuilder"/> class.
        /// </summary>
        /// <param name="manifest">The PackageManifest instance with which to initialize the builder.</param>
        public PackageManifestBuilder(PackageManifest manifest = default(PackageManifest))
        {
            Manifest = manifest;

            if (manifest == default(PackageManifest))
            {
                Manifest = new PackageManifest();
            }
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the PackageManifest instance that has been built.
        /// </summary>
        public PackageManifest Manifest { get; private set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Adds a <see cref="PackageManifestFile"/> to the <see cref="PackageManifest"/> under construction.
        /// </summary>
        /// <param name="file">The PackageManifestFile instance to add.</param>
        /// <returns>The modified <see cref="PackageManifest"/> instance.</returns>
        public PackageManifestBuilder AddFile(PackageManifestFile file)
        {
            if (Manifest.Files == default(IList<PackageManifestFile>))
            {
                Manifest.Files = new List<PackageManifestFile>();
            }

            Manifest.Files.Add(file);

            return this;
        }

        /// <summary>
        ///     Builds the default, generic instance of a <see cref="PackageManifestBuilder"/>.
        /// </summary>
        /// <returns>The built <see cref="PackageManifest"/> instance.</returns>
        public PackageManifestBuilder BuildDefault()
        {
            this.Title("DefaultPlugin")
                .Version("1.0.0")
                .Namespace("OpenIIoT.Plugin")
                .Description("Default plugin.")
                .Publisher("OpenIIoT Team")
                .Copyright("Copyright (c) " + DateTime.Now.Year + " OpenIIoT")
                .License("AGPLv3")
                .Url("http://github.com/openiiot");

            return this;
        }

        /// <summary>
        ///     Removes all <see cref="PackageManifestFile"/> instances from the <see cref="PackageManifest"/> under construction.
        /// </summary>
        /// <returns>The modified <see cref="PackageManifest"/> instance.</returns>
        public PackageManifestBuilder ClearFiles()
        {
            if (Manifest.Files != default(IList<PackageManifestFile>))
            {
                Manifest.Files.Clear();
            }

            return this;
        }

        /// <summary>
        ///     Sets the <see cref="PackageManifest.Copyright"/> field of the <see cref="PackageManifest"/> under construction to
        ///     the specified value.
        /// </summary>
        /// <param name="copyright">The value to which the Copyright field is to be set.</param>
        /// <returns>The modified <see cref="PackageManifest"/> instance.</returns>
        public PackageManifestBuilder Copyright(string copyright)
        {
            Manifest.Copyright = copyright;
            return this;
        }

        /// <summary>
        ///     Sets the <see cref="PackageManifest.Description"/> field of the <see cref="PackageManifest"/> under construction to
        ///     the specified value.
        /// </summary>
        /// <param name="description">The value to which the Description field is to be set.</param>
        /// <returns>The modified <see cref="PackageManifest"/> instance.</returns>
        public PackageManifestBuilder Description(string description)
        {
            Manifest.Description = description;
            return this;
        }

        /// <summary>
        ///     Sets the <see cref="PackageManifest.Files"/> field of the <see cref="PackageManifest"/> under construction to the
        ///     specified value.
        /// </summary>
        /// <param name="files">The value to which the Files field is to be set.</param>
        /// <returns>The modified <see cref="PackageManifest"/> instance.</returns>
        public PackageManifestBuilder Files(IList<PackageManifestFile> files)
        {
            Manifest.Files = files;
            return this;
        }

        /// <summary>
        ///     Sets the <see cref="PackageManifest.License"/> field of the <see cref="PackageManifest"/> under construction to the
        ///     specified value.
        /// </summary>
        /// <param name="license">The value to which the License field is to be set.</param>
        /// <returns>The modified <see cref="PackageManifest"/> instance.</returns>
        public PackageManifestBuilder License(string license)
        {
            Manifest.License = license;
            return this;
        }

        /// <summary>
        ///     Sets the <see cref="PackageManifest.Namespace"/> field to the <see cref="PackageManifest"/> under construction to
        ///     the specified value.
        /// </summary>
        /// <param name="ns">The value to which the Namespace field is to be set.</param>
        /// <returns>The modified <see cref="PackageManifest"/> instance.</returns>
        public PackageManifestBuilder Namespace(string ns)
        {
            Manifest.Namespace = ns;
            return this;
        }

        /// <summary>
        ///     Sets the <see cref="PackageManifest.Publisher"/> field to the <see cref="PackageManifest"/> under construction to
        ///     the specified value.
        /// </summary>
        /// <param name="publisher">The value to which the Publisher field is to be set.</param>
        /// <returns>The modified <see cref="PackageManifest"/> instance.</returns>
        public PackageManifestBuilder Publisher(string publisher)
        {
            Manifest.Publisher = publisher;
            return this;
        }

        /// <summary>
        ///     Removes the specified <see cref="PackageManifestFile"/> from the <see cref="PackageManifest"/> under construction.
        /// </summary>
        /// <param name="file">The PackageManifestFile instance to remove.</param>
        /// <returns>The modified <see cref="PackageManifest"/> instance.</returns>
        public PackageManifestBuilder RemoveFile(PackageManifestFile file)
        {
            if (Manifest.Files != default(IList<PackageManifestFile>))
            {
                PackageManifestFile foundFile = Manifest.Files.Where(f => f.Source == file.Source).FirstOrDefault();

                if (foundFile != default(PackageManifestFile))
                {
                    Manifest.Files.Remove(foundFile);
                }
            }

            return this;
        }

        /// <summary>
        ///     Sets the <see cref="PackageManifest.Signature"/> field to the <see cref="PackageManifest"/> under construction to
        ///     the specified value.
        /// </summary>
        /// <param name="signature">The value to which the Signature field is to be set.</param>
        /// <returns>The modified <see cref="PackageManifest"/> instance.</returns>
        public PackageManifestBuilder Signature(PackageManifestSignature signature)
        {
            Manifest.Signature = signature;
            return this;
        }

        /// <summary>
        ///     Sets the <see cref="PackageManifest.Title"/> field to the <see cref="PackageManifest"/> under construction to the
        ///     specified value.
        /// </summary>
        /// <param name="title">The value to which the Title field is to be set.</param>
        /// <returns>The modified <see cref="PackageManifest"/> instance.</returns>
        public PackageManifestBuilder Title(string title)
        {
            Manifest.Title = title;
            return this;
        }

        /// <summary>
        ///     Sets the <see cref="PackageManifest.Url"/> field to the <see cref="PackageManifest"/> under construction to the
        ///     specified value.
        /// </summary>
        /// <param name="url">The value to which the Url field is to be set.</param>
        /// <returns>The modified <see cref="PackageManifest"/> instance.</returns>
        public PackageManifestBuilder Url(string url)
        {
            Manifest.Url = url;
            return this;
        }

        /// <summary>
        ///     Sets the <see cref="PackageManifest.Version"/> field to the <see cref="PackageManifest"/> under construction to the
        ///     specified value.
        /// </summary>
        /// <param name="version">The value to which the Version field is to be set.</param>
        /// <returns>The modified <see cref="PackageManifest"/> instance.</returns>
        public PackageManifestBuilder Version(string version)
        {
            Manifest.Version = version;
            return this;
        }

        #endregion Public Methods
    }
}