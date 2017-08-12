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
      █  The system Platform upon which the Application runs.
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

using System.Collections.Generic;
using OpenIIoT.SDK.Common.Provider.ItemProvider;
using Utility.OperationResult;

namespace OpenIIoT.SDK.Platform
{
    /// <summary>
    ///     The system Platform upon which the Application runs.
    /// </summary>
    public interface IPlatform
    {
        #region Public Properties

        /// <summary>
        ///     Gets a Dictionary containing all of the application directories, loaded from the App.config.
        /// </summary>
        IDirectories Directories { get; }

        /// <summary>
        ///     Gets the Item Provider for the Platform.
        /// </summary>
        IItemProvider ItemProvider { get; }

        /// <summary>
        ///     Gets the Platform Type.
        /// </summary>
        PlatformType PlatformType { get; }

        /// <summary>
        ///     Gets the Version of the Platform OS.
        /// </summary>
        string Version { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Deletes all files and subdirectories within the supplied directory.
        /// </summary>
        /// <param name="directory">The directory to clear.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        IResult ClearDirectory(string directory);

        /// <summary>
        ///     Computes the checksum of the specified file using the SHA256 hashing algorithm.
        /// </summary>
        /// <remarks>
        ///     To ensure cross-platform, cross-installation compatibility, only an unsalted SHA256 algorithm is to be used.
        /// </remarks>
        /// <param name="file">The file for which the checksum is to be computed.</param>
        /// <returns>A Result containing the result of the operation and the computed checksum.</returns>
        IResult<string> ComputeFileChecksum(string file);

        /// <summary>
        ///     Copies the specified source file to the specified destination file.
        /// </summary>
        /// <param name="sourceFile">The file to copy.</param>
        /// <param name="destinationFile">The file to which the source file is to be copied.</param>
        /// <returns>A Result containing the result of the operation and the fully qualified path to the created file.</returns>
        IResult<string> CopyFile(string sourceFile, string destinationFile);

        /// <summary>
        ///     Copies the specified source file to the specified destination file, overwriting if the destination file exists and
        ///     the overwrite parameter is true.
        /// </summary>
        /// <param name="sourceFile">The file to copy.</param>
        /// <param name="destinationFile">The file to which the source file is to be copied.</param>
        /// <param name="overwrite">A value indicating whether the destination file is to be overwritten if it exists.</param>
        /// <returns>A Result containing the result of the operation and the fully qualified path to the created file.</returns>
        IResult<string> CopyFile(string sourceFile, string destinationFile, bool overwrite);

        /// <summary>
        ///     Creates the supplied directory.
        /// </summary>
        /// <param name="directory">The directory to create.</param>
        /// <returns>A Result containing the result of the operation and the fully qualified path to the directory.</returns>
        IResult<string> CreateDirectory(string directory);

        /// <summary>
        ///     Creates the specified zip file from the specified directory.
        /// </summary>
        /// <param name="zipFile">The zip file to which the directory is to be compressed.</param>
        /// <param name="source">The directory from which the zip file is to be created.</param>
        /// <returns>
        ///     A Result containing the result of the operation and the fully qualified filename of the created zip file.
        /// </returns>
        IResult<string> CreateZip(string zipFile, string source);

        /// <summary>
        ///     Deletes the specified directory.
        /// </summary>
        /// <param name="directory">The directory to delete.</param>
        /// <param name="recursive">
        ///     A value indicating whether to recursively delete subdirectories and files contained within the directory.
        /// </param>
        /// <returns>A Result containing the result of the operation.</returns>
        IResult DeleteDirectory(string directory, bool recursive = true);

        /// <summary>
        ///     Deletes the specified file.
        /// </summary>
        /// <param name="file">The file to delete.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        IResult DeleteFile(string file);

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
        IResult<string> ExtractZip(string zipFile, string destination, bool clearDestination = true);

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
        IResult<string> ExtractZipFile(string zipFile, string file, string destination, bool overwrite = true);

        /// <summary>
        ///     Returns true if the specified file exists, false otherwise.
        /// </summary>
        /// <param name="file">The file to check.</param>
        /// <returns>True if the specified file exists, false otherwise.</returns>
        bool FileExists(string file);

        /// <summary>
        ///     Returns a list of subdirectories within the specified directory.
        /// </summary>
        /// <param name="parentDirectory">The parent directory to search.</param>
        /// <param name="searchPattern">The search pattern to which directory names are compared.</param>
        /// <returns>
        ///     A Result containing the result of the operation and list containing the fully qualified path of each directory found.
        /// </returns>
        IResult<IList<string>> ListDirectories(string parentDirectory, string searchPattern = "*");

        /// <summary>
        ///     Returns a list of subdirectories within the specified directory.
        /// </summary>
        /// <param name="parentDirectory">The parent directory to search.</param>
        /// <returns>
        ///     A Result containing the result of the operation and list containing the fully qualified path of each directory found.
        /// </returns>
        IResult<IList<string>> ListDirectories(string parentDirectory);

        /// <summary>
        ///     Returns a list of files within the specified directory matching the supplied searchPattern.
        /// </summary>
        /// <param name="parentDirectory">The directory to search.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a list containing the fully qualified filename of each file found.
        /// </returns>
        IResult<IList<string>> ListFiles(string parentDirectory);

        /// <summary>
        ///     Returns a list of files within the specified directory matching the supplied searchPattern.
        /// </summary>
        /// <param name="parentDirectory">The directory to search.</param>
        /// <param name="searchPattern">The search pattern to which file names are compared.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a list containing the fully qualified filename of each file found.
        /// </returns>
        IResult<IList<string>> ListFiles(string parentDirectory, string searchPattern = "*");

        /// <summary>
        ///     Returns a list of files contained within the specified zip file matching the supplied searchPattern.
        /// </summary>
        /// <param name="zipFile">The zip file to search.</param>
        /// <param name="searchPattern">The search pattern to match files against.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a list containing the fully qualified filename of each file found.
        /// </returns>
        IResult<IList<string>> ListZipFiles(string zipFile, string searchPattern = "*");

        /// <summary>
        ///     Reads the contents of the specified file into a byte array.
        /// </summary>
        /// <param name="file">The file to read.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a byte array containing the entire contents of the file.
        /// </returns>
        IResult<byte[]> ReadFileBytes(string file);

        /// <summary>
        ///     Reads the contents of the specified file into a string array.
        /// </summary>
        /// <param name="file">The file to read.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a string array containing all of the lines from the file.
        /// </returns>
        IResult<string[]> ReadFileLines(string file);

        /// <summary>
        ///     Reads the contents of the specified file into a single string.
        /// </summary>
        /// <param name="file">The file to read.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a string containing the entire contents of the file.
        /// </returns>
        IResult<string> ReadFileText(string file);

        /// <summary>
        ///     Writes the contents of the supplied byte array into the specified file. If the destination file already exists it
        ///     is overwritten.
        /// </summary>
        /// <param name="file">The file to write.</param>
        /// <param name="contents">The binary data to write to the file.</param>
        /// <returns>A Result containing the result of the operation and the fully qualified name of the written file.</returns>
        IResult<string> WriteFileBytes(string file, byte[] contents);

        /// <summary>
        ///     Writes the contents of the specified string array into the specified file. If the destination file already exists
        ///     it is overwritten.
        /// </summary>
        /// <param name="file">The file to which the specified contents are written.</param>
        /// <param name="contents">The string array containing the content to write.</param>
        /// <returns>A Result containing the result of the operation and the fully qualified name of the written file.</returns>
        IResult<string> WriteFileLines(string file, string[] contents);

        /// <summary>
        ///     Writes the contents of the supplied string into the specified file. If the destination file already exists it is overwritten.
        /// </summary>
        /// <param name="file">The file to write.</param>
        /// <param name="contents">The text to write to the file.</param>
        /// <returns>A Result containing the result of the operation and the fully qualified name of the written file.</returns>
        IResult<string> WriteFileText(string file, string contents);

        #endregion Public Methods
    }
}