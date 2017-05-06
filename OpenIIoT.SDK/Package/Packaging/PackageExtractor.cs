/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                 ▄████████
      █     ███    ███                                                                ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████   ███    █▀  ▀███  ▐██▀     ██       █████   ▄█████   ▄██████     ██     ██████     █████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █   ▄███▄▄▄       ██  ██   ▀███████▄   ██  ██   ██   ██ ██    ██ ▀███████▄ ██    ██   ██  ██
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ▀▀███▀▀▀        ████▀       ██  ▀  ▄██▄▄█▀   ██   ██ ██    ▀      ██  ▀ ██    ██  ▄██▄▄█▀
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀      ███    █▄     ████        ██    ▀███████ ▀████████ ██    ▄      ██    ██    ██ ▀███████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █    ███    ███  ▄██ ▀██       ██      ██  ██   ██   ██ ██    ██     ██    ██    ██   ██  ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████   ██████████ ███    ██▄    ▄██▀     ██  ██   ██   █▀ ██████▀     ▄██▀    ██████    ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Extracts Package files.
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
using System.IO.Compression;

namespace OpenIIoT.SDK.Package.Packaging
{
    /// <summary>
    ///     Extracts Package files.
    /// </summary>
    public static class PackageExtractor
    {
        #region Public Events

        /// <summary>
        ///     Raised when a new status message is generated.
        /// </summary>
        public static event EventHandler<PackagingUpdateEventArgs> Updated;

        #endregion Public Events

        #region Public Methods

        /// <summary>
        ///     Extracts the specified Package file to the specified output directory after first verifying the package, unless the
        ///     skipVerification parameter is specified.
        /// </summary>
        /// <param name="packageFile">The Package to be extracted.</param>
        /// <param name="outputDirectory">The directory into which the Package payload is to be extracted.</param>
        /// <param name="overwrite">A value indicating whether the output directory should be overwritten if it exists.</param>
        /// <param name="skipVerification">A value indicating whether the verification prior to extraction is to be skipped.</param>
        public static void ExtractPackage(string packageFile, string outputDirectory, bool overwrite = false, bool skipVerification = false)
        {
            ValidatePackageFileArgument(packageFile);
            ValidateOutputDirectoryArgument(outputDirectory, overwrite);

            OnUpdated($"Extracting package '{Path.GetFileName(packageFile)}' to directory '{outputDirectory}'...");

            if (!skipVerification)
            {
                PackageVerifier.VerifyPackage(packageFile);
            }
            else
            {
                OnUpdated("Package verification skipped.");
            }

            string tempDirectory = Path.Combine(Path.GetTempPath(), System.Reflection.Assembly.GetEntryAssembly().GetName().Name, Guid.NewGuid().ToString());

            try
            {
                OnUpdated($"Extracting payload archive to '{tempDirectory}'...");
                ZipFile.ExtractToDirectory(packageFile, tempDirectory);
                OnUpdated(" √ Payload archive extracted successfully.");

                if (Directory.Exists(outputDirectory) && overwrite)
                {
                    OnUpdated($"Deleting existing output directory '{outputDirectory}'...");
                    Directory.Delete(outputDirectory, true);
                    OnUpdated(" √ Output directory deleted successfully.");
                }

                OnUpdated($"Extracting payload archive to destination '{outputDirectory}'...");
                ZipFile.ExtractToDirectory(Path.Combine(tempDirectory, Package.Constants.PayloadArchiveName), outputDirectory);
                OnUpdated(" √ Package extracted successfully.");
            }
            catch (Exception ex)
            {
                OnUpdated($"Error extracting Package: {ex.Message}");
            }
            finally
            {
                OnUpdated("Deleting temporary files...");
                Directory.Delete(tempDirectory, true);
                OnUpdated(" √ Temporary files deleted successfully.");
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Raises the <see cref="Updated"/> event with the specified message.
        /// </summary>
        /// <param name="message">The message to send.</param>
        private static void OnUpdated(string message)
        {
            if (Updated != null)
            {
                Updated(null, new PackagingUpdateEventArgs(PackagingOperation.ManifestExtraction, message));
            }
        }

        /// <summary>
        ///     Validates the outputDirectory and overwrite arguments for <see cref="ExtractPackage(string, string, bool, bool)"/>.
        /// </summary>
        /// <param name="outputDirectory">The value specified for the outputDirectory argument.</param>
        /// <param name="overwrite">The value specified for the overwrite argument.</param>
        /// <exception cref="ArgumentException">Thrown when the package is an empty or null string.</exception>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when the output directory exists and is not empty but the overwrite argument is false.
        /// </exception>
        private static void ValidateOutputDirectoryArgument(string outputDirectory, bool overwrite)
        {
            if (string.IsNullOrEmpty(outputDirectory))
            {
                throw new ArgumentException("The required argument 'directory' was not supplied.");
            }

            if (Directory.Exists(outputDirectory) && !overwrite)
            {
                if (Directory.GetFiles(outputDirectory).Length > 0)
                {
                    throw new InvalidOperationException($"The directory '{outputDirectory}' exists and is not empty.");
                }
            }
        }

        /// <summary>
        ///     Validates the packageFile argument for <see cref="ExtractPackage(string, string, bool, bool)"/>.
        /// </summary>
        /// <param name="packageFile">The value specified for the packageFile argument.</param>
        /// <exception cref="ArgumentException">Thrown when the package is an empty or null string.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the package can not be found on the local file system.</exception>
        /// <exception cref="InvalidDataException">Thrown when the package contains no files.</exception>
        /// <exception cref="IOException">Thrown when the package can not be read.</exception>
        private static void ValidatePackageFileArgument(string packageFile)
        {
            if (string.IsNullOrEmpty(packageFile))
            {
                throw new ArgumentException("The required argument 'package' was not supplied.");
            }

            if (!File.Exists(packageFile))
            {
                throw new FileNotFoundException($"The specified package file '{packageFile}' could not be found.");
            }

            if (new FileInfo(packageFile).Length == 0)
            {
                throw new InvalidDataException($"The specified package file '{packageFile}' is empty.");
            }

            if (!File.OpenRead(packageFile).CanRead)
            {
                throw new IOException($"The specified package file '{packageFile}' could not be opened for reading.  It may be open in another process, or you may have insufficient rights.");
            }
        }

        #endregion Private Methods
    }
}