/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄
      █     ███    ███
      █     ███    ███  █         ▄█████      ██       ▄█████  ██████     █████    ▄▄██▄▄▄
      █     ███    ███ ██         ██   ██ ▀███████▄   ██   ▀█ ██    ██   ██  ██  ▄█▀▀██▀▀█▄
      █   ▀█████████▀  ██         ██   ██     ██  ▀  ▄██▄▄    ██    ██  ▄██▄▄█▀  ██  ██  ██
      █     ███        ██       ▀████████     ██    ▀▀██▀▀    ██    ██ ▀███████  ██  ██  ██
      █     ███        ██▌    ▄   ██   ██     ██      ██      ██    ██   ██  ██  ██  ██  ██
      █    ▄████▀      ████▄▄██   ██   █▀    ▄██▀     ██       ██████    ██  ██   █  ██  █
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

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using NLog;
using NLog.xLogger;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Common.Discovery;
using OpenIIoT.SDK.Common.Provider.ItemProvider;
using OpenIIoT.SDK.Platform;
using Utility.OperationResult;

namespace OpenIIoT.Core.Platform
{
    /// <summary>
    ///     The abstract base class from which all Platforms inherit.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Derivations of the Platform class are designed to abstract OS-specific file system I/O differences from the rest of
    ///         the application. When first introduced it was unclear how well Mono handled abstractions in UNIX environments, and
    ///         it is now known that file system differences are a non-issue.
    ///     </para>
    ///     <para>
    ///         The need for platform-specific code remains outside of file system I/O, most notably in the startup of the
    ///         application in Windows environments when running as a service, in addition to OS/platform metrics.
    ///     </para>
    ///     <para>
    ///         Each Platform instance contains the <see cref="PlatformType"/> and <see cref="Version"/> properties, which return
    ///         the platform type; <see cref="PlatformType.Windows"/> or <see cref="PlatformType.UNIX"/>, and the OS-specific
    ///         version, respectively. The PlatformType property is reference during application startup to determine the run mode
    ///         while Version is informational.
    ///     </para>
    ///     <para>
    ///         The <see cref="Directories"/> property is set to an instance of the <see cref="Core.Platform.Directories"/> class.
    ///         This class serves as a container for the various directories in which the application stores files. The instance is
    ///         passed via the constructor.
    ///     </para>
    ///     <para>
    ///         The Platform instance also contains the <see cref="ItemProvider"/> property which contains a reference to the Item
    ///         Provider class which accompanies the Platform. This <see cref="IItemProvider"/> provides <see cref="Item"/> objects
    ///         used to report statistics and metrics about the underlying Platform.
    ///     </para>
    ///     <para>
    ///         The methods provided by the Platform class encompass typical file system operations; reading and writing files,
    ///         creating and deleting directories, and listing files and directories. Additionally, several methods used to
    ///         manipulate compressed Zip files are included to facilitate the management and deployment of Plugins.
    ///     </para>
    ///     <para>This class is expected to continually expand as the needs of the application increase.</para>
    /// </remarks>
    [Discoverable]
    public abstract class Platform : IPlatform
    {
        #region Private Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Platform"/> class.
        /// </summary>
        public Platform()
        {
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets a list containing all of the application directories, loaded from the App.config.
        /// </summary>
        public IDirectories Directories1 { get; private set; }

        /// <summary>
        ///     Gets or sets the accompanying <see cref="IItemProvider"/> for the <see cref="Platform"/>.
        /// </summary>
        [Discoverable]
        public IItemProvider ItemProvider { get; protected set; }

        /// <summary>
        ///     Gets or sets the <see cref="PlatformType"/> of the <see cref="Platform"/>.
        /// </summary>
        public PlatformType PlatformType { get; protected set; }

        /// <summary>
        ///     Gets or sets the version of the <see cref="Platform"/> OS.
        /// </summary>
        public string Version { get; protected set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Deletes all files and subdirectories within the specified <paramref name="directory"/>.
        /// </summary>
        /// <param name="directory">The directory to clear.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual IResult ClearDirectory(string directory)
        {
            logger.EnterMethod(xLogger.Params(directory));
            logger.Debug($"Clearing the contents of directory '{directory}'...");

            IResult retVal = new Result();

            try
            {
                DirectoryInfo di = new DirectoryInfo(directory);

                // delete all files
                foreach (FileInfo file in di.GetFiles())
                {
                    DeleteFile(file.FullName);
                }

                // delete all folders recursively
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    DeleteDirectory(dir.FullName, true);
                }
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Debug, ex);
                retVal.AddError(ex.Message);
                retVal.AddError($"Failed to clear directory '{directory}'.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Computes the SHA256 checksum of the specified <paramref name="file"/>.
        /// </summary>
        /// <param name="file">The file for which the checksum is to be computed.</param>
        /// <returns>A Result containing the result of the operation and the computed checksum.</returns>
        public virtual IResult<string> ComputeFileChecksum(string file)
        {
            logger.EnterMethod(xLogger.Params(file));
            IResult<string> retVal = new Result<string>();

            try
            {
                byte[] binFile = File.ReadAllBytes(file);
                byte[] checksum = SHA256.Create().ComputeHash(binFile);

                StringBuilder builtString = new StringBuilder();
                foreach (byte b in checksum)
                {
                    builtString.Append(b.ToString("x2"));
                }

                retVal.ReturnValue = builtString.ToString();
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Debug, ex);
                retVal.AddError(ex.Message);
                retVal.AddError($"Failed to compute checksum for file '{Path.GetFileName(file)}'.");
            }

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Copies the specified <paramref name="sourceFile"/> to the specified <paramref name="destinationFile"/>.
        /// </summary>
        /// <param name="sourceFile">The file to copy.</param>
        /// <param name="destinationFile">The file to which the source file is to be copied.</param>
        /// <returns>A Result containing the result of the operation and the fully qualified path to the created file.</returns>
        public virtual IResult<string> CopyFile(string sourceFile, string destinationFile)
        {
            return CopyFile(sourceFile, destinationFile, false);
        }

        /// <summary>
        ///     Copies the specified <paramref name="sourceFile"/> to the specified <paramref name="destinationFile"/>, overwriting
        ///     if the destination file exists and the <paramref name="overwrite"/> parameter is true.
        /// </summary>
        /// <param name="sourceFile">The file to copy.</param>
        /// <param name="destinationFile">The file to which the source file is to be copied.</param>
        /// <param name="overwrite">A value indicating whether the destination file is to be overwritten if it exists.</param>
        /// <returns>A Result containing the result of the operation and the fully qualified path to the created file.</returns>
        public virtual IResult<string> CopyFile(string sourceFile, string destinationFile, bool overwrite)
        {
            logger.EnterMethod(xLogger.Params(sourceFile, destinationFile));
            logger.Debug($"Copying file '{sourceFile}' to '{destinationFile}'");

            IResult<string> retVal = new Result<string>();

            try
            {
                File.Copy(sourceFile, destinationFile, overwrite);
                retVal.ReturnValue = destinationFile;
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Debug, ex);
                retVal.AddError(ex.Message);
                retVal.AddError($"Failed to copy file '{Path.GetFileName(sourceFile)}' to '{Path.GetFileName(destinationFile)}'.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Creates the specified <paramref name="directory"/>.
        /// </summary>
        /// <param name="directory">The directory to create.</param>
        /// <returns>A Result containing the result of the operation and the fully qualified path to the created directory.</returns>
        public virtual IResult<string> CreateDirectory(string directory)
        {
            logger.EnterMethod(xLogger.Params(directory));
            logger.Debug($"Creating directory '{directory}'...");

            IResult<string> retVal = new Result<string>();

            try
            {
                retVal.ReturnValue = Directory.CreateDirectory(directory).FullName;
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Debug, ex);
                retVal.AddError(ex.Message);
                retVal.AddError($"Failed to create directory '{directory}'.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Creates the specified <paramref name="zipFile"/> from the specified <paramref name="sourceDirectory"/>.
        /// </summary>
        /// <param name="zipFile">The zip file to which the directory is to be compressed.</param>
        /// <param name="sourceDirectory">The directory from which the zip file is to be created.</param>
        /// <returns>
        ///     A Result containing the result of the operation and the fully qualified filename of the created zip file.
        /// </returns>
        public virtual IResult<string> CreateZip(string zipFile, string sourceDirectory)
        {
            logger.EnterMethod(xLogger.Params(zipFile, sourceDirectory));
            logger.Debug($"Creating zip file '{zipFile}' from directory '{sourceDirectory}'...");

            IResult<string> retVal = new Result<string>();

            try
            {
                ZipFile.CreateFromDirectory(sourceDirectory, zipFile);
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Debug, ex);
                retVal.AddError(ex.Message);
                retVal.AddError($"Failed to create zip file '{Path.GetFileName(zipFile)}' from directory '{sourceDirectory}'.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Deletes the specified <paramref name="directory"/>.
        /// </summary>
        /// <param name="directory">The directory to delete.</param>
        /// <param name="recursive">
        ///     A value indicating whether to recursively delete subdirectories and files contained within the directory.
        /// </param>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual IResult DeleteDirectory(string directory, bool recursive = true)
        {
            logger.EnterMethod(xLogger.Params(directory));
            logger.Debug($"Deleting directory '{directory}'...");

            IResult retVal = new Result();

            try
            {
                DirectoryInfo di = new DirectoryInfo(directory);
                di.Delete(recursive);
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Debug, ex);
                retVal.AddError(ex.Message);
                retVal.AddError($"Failed to delete directory '{directory}'.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Deletes the specified <paramref name="file"/>.
        /// </summary>
        /// <param name="file">The file to delete.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual IResult DeleteFile(string file)
        {
            logger.EnterMethod(xLogger.Params(file));
            logger.Debug($"Deleting file '{file}'...");

            IResult retVal = new Result();

            try
            {
                File.Delete(file);
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Debug, ex);
                retVal.AddError(ex.Message);
                retVal.AddError($"Failed to delete file '{Path.GetFileName(file)}'.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Returns true if the specified <paramref name="directory"/> exists, false otherwise.
        /// </summary>
        /// <param name="directory">The directory to check.</param>
        /// <returns>A value indicating whether the specified directory exists.</returns>
        public virtual bool DirectoryExists(string directory)
        {
            return Directory.Exists(directory);
        }

        /// <summary>
        ///     Extracts the contents of the specified <paramref name="zipFile"/> to the specified <paramref name="destination"/>,
        ///     clearing the destination first if <paramref name="clearDestination"/> is true.
        /// </summary>
        /// <param name="zipFile">The zip file to extract.</param>
        /// <param name="destination">The destination directory.</param>
        /// <param name="clearDestination">
        ///     True if the destination directory should be cleared prior to extraction, false otherwise.
        /// </param>
        /// <returns>A Result containing the result of the operation and the fully qualified path to the extracted files.</returns>
        public virtual IResult<string> ExtractZip(string zipFile, string destination, bool clearDestination = true)
        {
            logger.EnterMethod(xLogger.Params(zipFile, destination, clearDestination));
            logger.Debug($"Extracting zip file '{zipFile}' to destination '{destination}'...");

            IResult<string> retVal = new Result<string>();

            try
            {
                if (!DirectoryExists(destination))
                {
                    CreateDirectory(destination);
                }

                if (clearDestination)
                {
                    logger.Trace($"Attempting to clear destination directory '{destination}'...");

                    IResult clearResult = ClearDirectory(destination);

                    if (clearResult.ResultCode != ResultCode.Success)
                    {
                        throw new Exception($"Error clearing destination directory:  {clearResult.GetLastError()}");
                    }
                }

                logger.Trace("Extracting file...");

                ZipFile.ExtractToDirectory(zipFile, destination);
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Debug, ex);
                retVal.AddError(ex.Message);
                retVal.AddError($"Failed to extract zip file '{Path.GetFileName(zipFile)}' to destination '{destination}'.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Extracts the specified <paramref name="file"/> from the specified <paramref name="zipFile"/> to the specified
        ///     <paramref name="destination"/>, overwriting the file if <paramref name="overwrite"/> is true.
        /// </summary>
        /// <param name="zipFile">The zip file from which to extract the file.</param>
        /// <param name="file">The file to extract from the zip file.</param>
        /// <param name="destination">The destination directory.</param>
        /// <param name="overwrite">True if an existing file should be overwritten, false otherwise.</param>
        /// <returns>
        ///     A Result containing the result of the operation and the fully qualified filename of the extracted file.
        /// </returns>
        public virtual IResult<string> ExtractZipFile(string zipFile, string file, string destination, bool overwrite = true)
        {
            logger.EnterMethod(xLogger.Params(zipFile, file, destination, overwrite));
            logger.Debug($"Extracting file '{file}' from zip file '{zipFile}' into directory '{destination}'...");

            IResult<string> retVal = new Result<string>();

            try
            {
                logger.Trace($"Opening zip file '{zipFile}'...");

                using (ZipArchive archive = ZipFile.Open(zipFile, ZipArchiveMode.Read))
                {
                    ZipArchiveEntry entry = archive.GetEntry(file);

                    string extractedFile = Path.Combine(destination, entry.Name);

                    logger.Trace($"Extracting file '{file}'...");

                    entry.ExtractToFile(extractedFile, overwrite);
                    retVal.ReturnValue = extractedFile;
                }
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Debug, ex);
                retVal.AddError(ex.Message);
                retVal.AddError($"Failed to extract file '{Path.GetFileName(file)}' from zip file '{Path.GetFileName(zipFile)}'.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Returns true if the specified <paramref name="file"/> exists, false otherwise.
        /// </summary>
        /// <param name="file">The file to check.</param>
        /// <returns>A value indicating whether the specified file exists.</returns>
        public virtual bool FileExists(string file)
        {
            return File.Exists(file);
        }

        /// <summary>
        ///     Returns a list of subdirectories within the specified <paramref name="directory"/>.
        /// </summary>
        /// <param name="directory">The parent directory to search.</param>
        /// <returns>
        ///     A Result containing the result of the operation and list containing the fully qualified path of each directory found.
        /// </returns>
        public virtual IResult<IList<string>> ListDirectories(string directory)
        {
            return ListDirectories(directory, "*");
        }

        /// <summary>
        ///     Returns a list of subdirectories within the specified <paramref name="directory"/> matching the specified <paramref name="searchPattern"/>.
        /// </summary>
        /// <param name="directory">The parent directory to search.</param>
        /// <param name="searchPattern">The search pattern to which directory names are compared.</param>
        /// <returns>
        ///     A Result containing the result of the operation and list containing the fully qualified path of each directory found.
        /// </returns>
        public virtual IResult<IList<string>> ListDirectories(string directory, string searchPattern = "*")
        {
            logger.EnterMethod(xLogger.Params(directory, searchPattern));

            IResult<IList<string>> retVal = new Result<IList<string>>();
            retVal.ReturnValue = new List<string>();

            try
            {
                retVal.ReturnValue = Directory.EnumerateDirectories(directory, searchPattern, SearchOption.AllDirectories).ToList<string>();
            }
            catch (IOException ex)
            {
                logger.Exception(LogLevel.Debug, ex);
                retVal.AddError(ex.Message);
                retVal.AddError($"Failed to list subdirectories for root path '{directory}' using search pattern '{searchPattern}'.");
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Returns a list of files within the specified <paramref name="directory"/>.
        /// </summary>
        /// <param name="directory">The directory to search.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a list containing the fully qualified filename of each file found.
        /// </returns>
        public virtual IResult<IList<string>> ListFiles(string directory)
        {
            return ListFiles(directory, "*");
        }

        /// <summary>
        ///     Returns a list of files within the specified <paramref name="directory"/> matching the specified <paramref name="searchPattern"/>.
        /// </summary>
        /// <param name="directory">The directory to search.</param>
        /// <param name="searchPattern">The search pattern to which file names are compared.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a list containing the fully qualified filename of each file found.
        /// </returns>
        public virtual IResult<IList<string>> ListFiles(string directory, string searchPattern = "*")
        {
            logger.EnterMethod(xLogger.Params(directory, searchPattern));

            IResult<IList<string>> retVal = new Result<IList<string>>();
            retVal.ReturnValue = new List<string>();

            try
            {
                retVal.ReturnValue = Directory.EnumerateFiles(directory, searchPattern, SearchOption.AllDirectories).ToList<string>();
            }
            catch (IOException ex)
            {
                logger.Exception(LogLevel.Debug, ex);
                retVal.AddError(ex.Message);
                retVal.AddError($"Failed to list files for directory '{directory}' using search pattern '{searchPattern}'.");
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Returns a list of files contained within the specified <paramref name="zipFile"/> matching the specified <paramref name="searchPattern"/>.
        /// </summary>
        /// <param name="zipFile">The zip file to search.</param>
        /// <param name="searchPattern">The search pattern to match files against.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a list containing the fully qualified filename of each file found.
        /// </returns>
        public virtual IResult<IList<string>> ListZipFiles(string zipFile, string searchPattern = "*")
        {
            logger.EnterMethod(xLogger.Params(zipFile, searchPattern));

            IResult<IList<string>> retVal = new Result<IList<string>>();
            retVal.ReturnValue = new List<string>();

            logger.Trace($"Converting pattern '{searchPattern}' to RegEx..");
            Regex regex = new Regex(SDK.Common.Utility.WildcardToRegex(searchPattern), RegexOptions.IgnoreCase);
            logger.Trace($"Converted pattern to RegEx '{regex}'");

            try
            {
                logger.Trace("Opening zip file...");
                using (ZipArchive archive = ZipFile.OpenRead(zipFile))
                {
                    logger.Trace("Iterating over the contents of the file...");
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (regex.IsMatch(entry.Name))
                        {
                            retVal.ReturnValue.Add(entry.FullName);
                        }
                    }

                    logger.Trace($"{retVal.ReturnValue.Count} matches for '{regex}' found.");
                }
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Debug, ex);
                retVal.AddError(ex.Message);
                retVal.AddError($"Failed to list files in zip file '{Path.GetFileName(zipFile)}'.");
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Reads the contents of the specified <paramref name="file"/> into a byte array.
        /// </summary>
        /// <param name="file">The file to read.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a byte array containing the entire contents of the file.
        /// </returns>
        public IResult<byte[]> ReadFileBytes(string file)
        {
            logger.EnterMethod(xLogger.Params(file));
            logger.Debug($"Reading bytes from file '{file}'...");

            IResult<byte[]> retVal = new Result<byte[]>();

            try
            {
                retVal.ReturnValue = File.ReadAllBytes(file);
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Debug, ex);
                retVal.AddError(ex.Message);
                retVal.AddError($"Failed to read bytes from file '{Path.GetFileName(file)}'.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Reads the contents of the specified <paramref name="file"/> into a string array.
        /// </summary>
        /// <param name="file">The file to read.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a string array containing all of the lines from the file.
        /// </returns>
        public virtual IResult<string[]> ReadFileLines(string file)
        {
            logger.EnterMethod(xLogger.Params(file));
            logger.Debug($"Reading lines from file '{file}'...");

            IResult<string[]> retVal = new Result<string[]>();

            try
            {
                retVal.ReturnValue = File.ReadAllLines(file);
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Debug, ex);
                retVal.AddError(ex.Message);
                retVal.AddError($"Failed to read lines from file '{Path.GetFileName(file)}'.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Reads the contents of the specified <paramref name="file"/> into a single string.
        /// </summary>
        /// <param name="file">The file to read.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a string containing the entire contents of the file.
        /// </returns>
        public virtual IResult<string> ReadFileText(string file)
        {
            logger.EnterMethod(xLogger.Params(file));
            logger.Debug($"Reading text contents of file '{file}'...");

            IResult<string> retVal = new Result<string>();

            try
            {
                retVal.ReturnValue = File.ReadAllText(file);
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Debug, ex);
                retVal.AddError(ex.Message);
                retVal.AddError($"Failed to read text from file '{Path.GetFileName(file)}'.");
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Writes the <paramref name="contents"/> of the specified byte array into the specified <paramref name="file"/>. If
        ///     the destination file already exists it is overwritten.
        /// </summary>
        /// <param name="file">The file to write.</param>
        /// <param name="contents">The binary data to write to the file.</param>
        /// <returns>A Result containing the result of the operation and the fully qualified name of the written file.</returns>
        public virtual IResult<string> WriteFileBytes(string file, byte[] contents)
        {
            logger.EnterMethod(xLogger.Params(file, contents));
            logger.Debug($"Writing bytes to file '{file}'...");

            IResult<string> retVal = new Result<string>();

            try
            {
                File.WriteAllBytes(file, contents);
                retVal.ReturnValue = file;
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Debug, ex);
                retVal.AddError(ex.Message);
                retVal.AddError($"Error writing bytes to file '{file}'.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Writes the <paramref name="contents"/> of the specified string array into the specified <paramref name="file"/>. If
        ///     the destination file already exists it is overwritten.
        /// </summary>
        /// <param name="file">The file to which the specified contents are written.</param>
        /// <param name="contents">The string array containing the content to write.</param>
        /// <returns>A Result containing the result of the operation and the fully qualified name of the written file.</returns>
        public virtual IResult<string> WriteFileLines(string file, string[] contents)
        {
            logger.EnterMethod(xLogger.Params(file, contents));
            logger.Debug($"Writing lines to file '{file}'...");

            IResult<string> retVal = new Result<string>();

            try
            {
                File.WriteAllLines(file, contents);
                retVal.ReturnValue = file;
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Debug, ex);
                retVal.AddError(ex.Message);
                retVal.AddError($"Error writing lines to file '{file}'.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Writes the <paramref name="contents"/> of the specified string into the specified <paramref name="file"/>. If the
        ///     destination file already exists it is overwritten.
        /// </summary>
        /// <param name="file">The file to write.</param>
        /// <param name="contents">The text to write to the file.</param>
        /// <returns>A Result containing the result of the operation and the fully qualified name of the written file.</returns>
        public virtual IResult<string> WriteFileText(string file, string contents)
        {
            logger.EnterMethod(xLogger.Params(file, contents));
            logger.Debug($"Writing text to file '{file}'...");

            IResult<string> retVal = new Result<string>();

            try
            {
                File.WriteAllText(file, contents);
                retVal.ReturnValue = file;
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Debug, ex);
                retVal.AddError(ex.Message);
                retVal.AddError($"Error writing text to file '{file}'.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        #endregion Public Methods
    }
}