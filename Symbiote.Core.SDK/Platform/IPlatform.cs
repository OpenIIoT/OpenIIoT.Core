/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█     ▄███████▄
      █   ███    ███    ███
      █   ███▌   ███    ███  █         ▄█████      ██       ▄█████  ██████     █████    ▄▄██▄▄▄
      █   ███▌   ███    ███ ██         ██   ██ ▀███████▄   ██   ▀█ ██    ██   ██  ██  ▄█▀▀██▀▀█▄
      █   ███▌ ▀█████████▀  ██         ██   ██     ██  ▀  ▄██▄▄    ██    ██  ▄██▄▄█▀  ██  ██  ██
      █   ███    ███        ██       ▀████████     ██    ▀▀██▀▀    ██    ██ ▀███████  ██  ██  ██
      █   ███    ███        ██▌    ▄   ██   ██     ██      ██      ██    ██   ██  ██  ██  ██  ██
      █   █▀    ▄████▀      ████▄▄██   ██   █▀    ▄██▀     ██       ██████    ██  ██   █  ██  █
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Defines the interface for Platform objects.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016 JP Dillingham (jp@dillingham.ws)
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

using System.Collections.Generic;
using Utility.OperationResult;
using Symbiote.Core.SDK.Plugin.Connector;

namespace Symbiote.Core.SDK.Platform
{
    /// <summary>
    ///     Defines the interface for Platform objects.
    /// </summary>
    public interface IPlatform
    {
        #region Public Properties

        /// <summary>
        ///     The accompanying Connector Plugin for the Platform.
        /// </summary>
        IConnector Connector { get; }

        /// <summary>
        ///     The Platform Type.
        /// </summary>
        PlatformType PlatformType { get; }

        /// <summary>
        ///     The Version of the Platform OS.
        /// </summary>
        string Version { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Deletes all files and subdirectories within the supplied directory.
        /// </summary>
        /// <param name="directory">The directory to clear.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result ClearDirectory(string directory);

        /// <summary>
        ///     Computes the checksum of the specified file using the SHA256 hashing algorithm.
        /// </summary>
        /// <remarks>
        ///     To ensure cross-platform, cross-installation compatibility, only an unsalted SHA256 algorithm is to be used.
        /// </remarks>
        /// <param name="file">The file for which the checksum is to be computed.</param>
        /// <returns>A Result containing the result of the operation and the computed checksum.</returns>
        Result<string> ComputeFileChecksum(string file);

        /// <summary>
        ///     Creates the supplied directory.
        /// </summary>
        /// <param name="directory">The directory to create.</param>
        /// <returns>A Result containing the result of the operation and the fully qualified path to the directory.</returns>
        Result<string> CreateDirectory(string directory);

        /// <summary>
        ///     Deletes the supplied directory.
        /// </summary>
        /// <param name="directory">The directory to delete.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result DeleteDirectory(string directory);

        /// <summary>
        ///     Deletes the specified file.
        /// </summary>
        /// <param name="file">The file to delete.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result DeleteFile(string file);

        /// <summary>
        ///     Returns true if the specified directory exists, false otherwise.
        /// </summary>
        /// <param name="directory">The directory to check.</param>
        /// <returns>True if the specified directory exists, false otherwise.</returns>
        bool DirectoryExists(string directory);

        /// <summary>
        ///     Extracts the contents of the supplied zip file to the specified destination, clearing the destination first if
        ///     clearDestination is true.
        /// </summary>
        /// <param name="zipFile">The zip file to extract.</param>
        /// <param name="destination">The destination directory.</param>
        /// <param name="clearDestination">
        ///     True if the destination directory should be cleared prior to extraction, false otherwise.
        /// </param>
        /// <returns>A Result containing the result of the operation and the fully qualified path to the extracted files.</returns>
        Result<string> ExtractZip(string zipFile, string destination, bool clearDestination = true);

        /// <summary>
        ///     Extracts the supplied file from the supplied zip file to the supplied destination, overwriting the file if
        ///     overwrite is true.
        /// </summary>
        /// <param name="zipFile">The zip file from which to extract the file.</param>
        /// <param name="file">The file to extract from the zip file.</param>
        /// <param name="destination">The destination directory.</param>
        /// <param name="overwrite">True if an existing file should be overwritten, false otherwise.</param>
        /// <returns>
        ///     A Result containing the result of the operation and the fully qualified filename of the extracted file.
        /// </returns>
        Result<string> ExtractZipFile(string zipFile, string file, string destination, bool overwrite = true);

        /// <summary>
        ///     Returns true if the specified file exists, false otherwise.
        /// </summary>
        /// <param name="file">The file to check.</param>
        /// <returns>True if the specified file exists, false otherwise.</returns>
        bool FileExists(string file);

        /// <summary>
        ///     Instantiates the accompanying Connector Plugin with the supplied root path.
        /// </summary>
        /// <param name="instanceName"></param>
        /// <returns>The instantiated Connector Plugin.</returns>
        IConnector InstantiateConnector(string instanceName);

        /// <summary>
        ///     Returns a list of subdirectories within the supplied path.
        /// </summary>
        /// <param name="parentDirectory">The parent directory to search.</param>
        /// <returns>
        ///     A Result containing the result of the operation and list containing the fully qualified path of each directory found.
        /// </returns>
        Result<List<string>> ListDirectories(string parentDirectory);

        /// <summary>
        ///     Returns a list of files within the supplied directory matching the supplied searchPattern.
        /// </summary>
        /// <param name="parentDirectory">The directory to search.</param>
        /// <param name="searchPattern">The search pattern to match files against.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a list containing the fully qualified filename of each file found.
        /// </returns>
        Result<List<string>> ListFiles(string parentDirectory, string searchPattern);

        /// <summary>
        ///     Returns a list of files contained within the specified zip file matching the supplied searchPattern.
        /// </summary>
        /// <param name="zipFile">The zip file to search.</param>
        /// <param name="searchPattern">The search pattern to match files against.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a list containing the fully qualified filename of each file found.
        /// </returns>
        Result<List<string>> ListZipFiles(string zipFile, string searchPattern);

        /// <summary>
        ///     Reads the contents of the specified file into a single string.
        /// </summary>
        /// <param name="file">The file to read.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a string containing the entire contents of the file.
        /// </returns>
        Result<string> ReadFile(string file);

        /// <summary>
        ///     Reads the contents of the specified file into a string array.
        /// </summary>
        /// <param name="file">The file to read.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a string array containing all of the lines from the file.
        /// </returns>
        Result<string[]> ReadFileLines(string file);

        /// <summary>
        ///     Writes the contents of the supplied string into the specified file. If the destination file already exists it is overwritten.
        /// </summary>
        /// <param name="file">The file to write.</param>
        /// <param name="contents">The text to write to the file.</param>
        /// <returns>The fully qualified name of the written file.</returns>
        Result<string> WriteFile(string file, string contents);

        #endregion Public Methods
    }
}