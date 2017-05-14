/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄▄▄▄███▄▄▄▄                                                                   ▄██████▄
      █    ▄██▀▀▀███▀▀▀██▄                                                                ███    ███
      █    ███   ███   ███   ▄█████  ██▄▄▄▄   █     ▄█████    ▄█████   ▄█████     ██      ███    █▀     ▄█████ ██▄▄▄▄     ▄█████    █████   ▄█████      ██     ██████     █████
      █    ███   ███   ███   ██   ██ ██▀▀▀█▄ ██    ██   ▀█   ██   █    ██  ▀  ▀███████▄  ▄███          ██   █  ██▀▀▀█▄   ██   █    ██  ██   ██   ██ ▀███████▄ ██    ██   ██  ██
      █    ███   ███   ███   ██   ██ ██   ██ ██▌  ▄██▄▄     ▄██▄▄      ██         ██  ▀ ▀▀███ ████▄   ▄██▄▄    ██   ██  ▄██▄▄     ▄██▄▄█▀   ██   ██     ██  ▀ ██    ██  ▄██▄▄█▀
      █    ███   ███   ███ ▀████████ ██   ██ ██  ▀▀██▀▀    ▀▀██▀▀    ▀███████     ██      ███    ███ ▀▀██▀▀    ██   ██ ▀▀██▀▀    ▀███████ ▀████████     ██    ██    ██ ▀███████
      █    ███   ███   ███   ██   ██ ██   ██ ██    ██        ██   █     ▄  ██     ██      ███    ███   ██   █  ██   ██   ██   █    ██  ██   ██   ██     ██    ██    ██   ██  ██
      █     ▀█   ███   █▀    ██   █▀  █   █  █     ██        ███████  ▄████▀     ▄██▀     ████████▀    ███████  █   █    ███████   ██  ██   ██   █▀    ▄██▀    ██████    ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Generates and populates PackageManifest objects.
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
using System.IO;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Package.Manifest;

namespace OpenIIoT.SDK.Package.Packaging.Operations
{
    /// <summary>
    ///     Generates and populates <see cref="PackageManifest"/> objects.
    /// </summary>
    public static class ManifestGenerator
    {
        #region Public Events

        /// <summary>
        ///     Raised when a new status message is generated.
        /// </summary>
        public static event EventHandler<PackagingUpdateEventArgs> Updated;

        #endregion Public Events

        #region Public Methods

        /// <summary>
        ///     Generates and populates <see cref="PackageManifest"/> objects from the specified directory, including resource
        ///     files and hashing file entries if those options are specified.
        /// </summary>
        /// <param name="inputDirectory">The directory from which to generate a list of files.</param>
        /// <param name="includeResources">A value indicating whether resource files are to be added to the manifest.</param>
        /// <param name="hashFiles">A value indicating whether files added to the manifest are to include a SHA512 hash.</param>
        /// <param name="manifestFile">The filename of the file to which the manifest is to be saved.</param>
        /// <returns>The generated manifest.</returns>
        public static PackageManifest GenerateManifest(string inputDirectory, bool includeResources = false, bool hashFiles = false, string manifestFile = "")
        {
            ArgumentValidator.ValidateInputDirectoryArgument(inputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*", SearchOption.AllDirectories);

            PackageManifestBuilder builder = new PackageManifestBuilder();

            OnUpdated($"Generating manifest for directory '{inputDirectory}'...");
            builder.BuildDefault();
            OnUpdated($"Adding files from '{inputDirectory}'...");

            foreach (string file in files)
            {
                AddFile(builder, file, inputDirectory, includeResources, hashFiles);
            }

            PackageManifest manifest = builder.Manifest;
            OnUpdated(" √ Manifest generated.");

            if (manifestFile != default(string))
            {
                try
                {
                    OnUpdated($"Saving output to file '{manifestFile}'...");
                    File.WriteAllText(manifestFile, manifest.ToJson());
                    OnUpdated(" √ File saved successfully.");
                }
                catch (Exception ex)
                {
                    OnUpdated($"Unable to write to output file '{manifestFile}': {ex.Message}");
                }
            }

            return manifest;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Adds the specified file from the specified directory to the specified builder, using the includeResources and
        ///     hashFiles parameters to determine whether the file should be added and hashed.
        /// </summary>
        /// <param name="builder">The manifest builder with which to add the file.</param>
        /// <param name="file">The file to add.</param>
        /// <param name="directory">The directory containing the file.</param>
        /// <param name="includeResources">A value indicating whether resource files are to be added to the manifest.</param>
        /// <param name="hashFiles">A value indicating whether files added to the manifest are to include a SHA512 hash.</param>
        private static void AddFile(PackageManifestBuilder builder, string file, string directory, bool includeResources, bool hashFiles)
        {
            PackageManifestFileType type = GetFileType(file);

            if (type == PackageManifestFileType.Binary || type == PackageManifestFileType.WebIndex || (type == PackageManifestFileType.Resource && includeResources))
            {
                OnUpdated($"Adding file '{file}'...");
                PackageManifestFile newFile = new PackageManifestFile();

                newFile.Source = Common.Utility.GetRelativePath(directory, file);

                if (type == PackageManifestFileType.Binary || hashFiles)
                {
                    newFile.Checksum = string.Empty;
                }

                builder.AddFile(type, newFile);
            }
            else
            {
                OnUpdated($"Skipping file '{file}...");
            }
        }

        /// <summary>
        ///     Determines and returns the <see cref="PackageManifestFileType"/> matching the specified file.
        /// </summary>
        /// <param name="file">The file for which the <see cref="PackageManifestFileType"/> is to be determined.</param>
        /// <returns>The type of the specified file.</returns>
        private static PackageManifestFileType GetFileType(string file)
        {
            if (Path.GetExtension(file) == "dll")
            {
                return PackageManifestFileType.Binary;
            }
            else if (Path.GetFileName(file).Equals("index.html", StringComparison.OrdinalIgnoreCase) || Path.GetFileName(file).Equals("index.htm", StringComparison.OrdinalIgnoreCase))
            {
                return PackageManifestFileType.WebIndex;
            }
            else
            {
                return PackageManifestFileType.Resource;
            }
        }

        /// <summary>
        ///     Raises the <see cref="Updated"/> event with the specified message.
        /// </summary>
        /// <param name="message">The message to send.</param>
        private static void OnUpdated(string message)
        {
            if (Updated != null)
            {
                Updated(null, new PackagingUpdateEventArgs(PackagingOperation.Manifest, message));
            }
        }

        #endregion Private Methods
    }
}