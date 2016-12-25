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
      █  The abstract base class from which all Platforms inherit.
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
using Symbiote.SDK;
using Symbiote.SDK.Platform;
using Symbiote.SDK.Plugin.Connector;
using Utility.OperationResult;

namespace Symbiote.Core.Platform
{
    /// <summary>
    ///     The abstract base class from which all Platforms inherit.
    /// </summary>
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
        ///     Gets or sets the accompanying Connector Plugin for the Platform.
        /// </summary>
        public IConnector Connector { get; protected set; }

        /// <summary>
        ///     Gets or sets the Platform Type.
        /// </summary>
        public PlatformType PlatformType { get; protected set; }

        /// <summary>
        ///     Gets or sets the Version of the Platform OS.
        /// </summary>
        public string Version { get; protected set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Deletes all files and subdirectories within the supplied directory.
        /// </summary>
        /// <param name="directory">The directory to clear.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual Result ClearDirectory(string directory)
        {
            logger.EnterMethod(xLogger.Params(directory));
            logger.Trace("Attempting to clear the contents of directory '" + directory + "'...");

            Result retVal = new Result();

            try
            {
                DirectoryInfo di = new DirectoryInfo(directory);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }

                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while clearing directory '" + directory + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Computes the checksum of the specified file.
        /// </summary>
        /// <param name="file">The file for which the checksum is to be computed.</param>
        /// <returns>A Result containing the result of the operation and the computed checksum.</returns>
        public virtual Result<string> ComputeFileChecksum(string file)
        {
            logger.EnterMethod(xLogger.Params(file));
            logger.Trace("Computing checksum for file '" + file + "'...");

            Result<string> retVal = new Result<string>();

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
                retVal.AddError("Exception thrown calculating checksum: " + ex.Message);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Creates the supplied directory.
        /// </summary>
        /// <param name="directory">The directory to create.</param>
        /// <returns>A Result containing the result of the operation and the fully qualified path to the directory.</returns>
        public virtual Result<string> CreateDirectory(string directory)
        {
            logger.EnterMethod(xLogger.Params(directory));
            logger.Trace("Creating directory '" + directory + "'...");

            Result<string> retVal = new Result<string>();

            try
            {
                retVal.ReturnValue = Directory.CreateDirectory(directory).FullName;
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while creating directory '" + directory + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Deletes the supplied directory.
        /// </summary>
        /// <param name="directory">The directory to delete.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual Result DeleteDirectory(string directory)
        {
            logger.EnterMethod(xLogger.Params(directory));
            logger.Trace("Attempting to delete directory '" + directory + "'...");

            Result retVal = new Result();

            try
            {
                DirectoryInfo di = new DirectoryInfo(directory);
                di.Delete(true);
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while deleting the directory '" + directory + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Deletes the specified file.
        /// </summary>
        /// <param name="file">The file to delete.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public virtual Result DeleteFile(string file)
        {
            logger.EnterMethod(xLogger.Params(file));
            logger.Trace("Deleting file '" + file + "'...");

            Result retVal = new Result();

            try
            {
                File.Delete(file);
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while attempting to delete file '" + file + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Returns true if the specified directory exists, false otherwise.
        /// </summary>
        /// <param name="directory">The directory to check.</param>
        /// <returns>True if the specified directory exists, false otherwise.</returns>
        public virtual bool DirectoryExists(string directory)
        {
            return Directory.Exists(directory);
        }

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
        public virtual Result<string> ExtractZip(string zipFile, string destination, bool clearDestination = true)
        {
            logger.EnterMethod(xLogger.Params(zipFile, destination, clearDestination));
            logger.Trace("Extracting zip file '" + zipFile + "' to destination '" + destination + "'...");

            Result<string> retVal = new Result<string>();

            try
            {
                if (!DirectoryExists(destination))
                {
                    CreateDirectory(destination);
                }

                if (clearDestination)
                {
                    logger.Trace("Attempting to clear destination directory '" + destination + "'...");
                    Result clearResult = ClearDirectory(destination);
                    if (clearResult.ResultCode != ResultCode.Success)
                    {
                        throw new Exception("Error clearing destination directory: " + clearResult.GetLastError());
                    }
                }

                logger.Trace("Extracting file...");
                ZipFile.ExtractToDirectory(zipFile, destination);
            }
            catch (Exception ex)
            {
                retVal.AddError("Error extracting zip file '" + zipFile + "' to destination '" + destination + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

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
        public virtual Result<string> ExtractZipFile(string zipFile, string file, string destination, bool overwrite = true)
        {
            logger.EnterMethod(xLogger.Params(zipFile, file, destination, overwrite));
            logger.Trace("Extracting file '" + file + "' from zip file '" + zipFile + "' into directory '" + destination + "'...");

            Result<string> retVal = new Result<string>();

            try
            {
                logger.Trace("Opening zip file '" + zipFile + "'...");
                using (ZipArchive archive = ZipFile.Open(zipFile, ZipArchiveMode.Update))
                {
                    ZipArchiveEntry entry = archive.GetEntry(file);

                    string extractedFile = Path.Combine(destination, entry.Name);

                    logger.Trace("Extracting file '" + file + "'...");
                    entry.ExtractToFile(extractedFile, overwrite);
                    retVal.ReturnValue = extractedFile;
                }
            }
            catch (Exception ex)
            {
                retVal.AddError("Error extracting file '" + file + "' from zip file '" + zipFile + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Returns true if the specified file exists, false otherwise.
        /// </summary>
        /// <param name="file">The file to check.</param>
        /// <returns>True if the specified file exists, false otherwise.</returns>
        public virtual bool FileExists(string file)
        {
            return File.Exists(file);
        }

        /// <summary>
        ///     Instantiates the accompanying Connector Plugin with the supplied root path.
        /// </summary>
        /// <param name="instanceName">The name of the connector instance.</param>
        /// <returns>The instantiated Connector Plugin.</returns>
        public abstract IConnector InstantiateConnector(string instanceName);

        /// <summary>
        ///     Returns a list of subdirectories within the supplied path.
        /// </summary>
        /// <param name="parentDirectory">The parent directory to search.</param>
        /// <returns>
        ///     A Result containing the result of the operation and list containing the fully qualified path of each directory found.
        /// </returns>
        public virtual Result<List<string>> ListDirectories(string parentDirectory)
        {
            logger.EnterMethod(xLogger.Params(parentDirectory));
            logger.Trace("Listing subdirectories of '" + parentDirectory + "'...");

            Result<List<string>> retVal = new Result<List<string>>();
            retVal.ReturnValue = new List<string>();

            try
            {
                retVal.ReturnValue = Directory.EnumerateDirectories(parentDirectory).ToList<string>();
            }
            catch (IOException ex)
            {
                retVal.AddError("Error listing subdirectories for root path '" + parentDirectory + "': " + ex.Message);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Returns a list of files within the supplied directory matching the supplied searchPattern.
        /// </summary>
        /// <param name="parentDirectory">The directory to search.</param>
        /// <param name="searchPattern">The search pattern to match files against.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a list containing the fully qualified filename of each file found.
        /// </returns>
        public virtual Result<List<string>> ListFiles(string parentDirectory, string searchPattern)
        {
            logger.EnterMethod(xLogger.Params(parentDirectory, searchPattern));
            logger.Trace("Listing files in directory '" + parentDirectory + "' matching searchPattern '" + searchPattern + "'...");

            Result<List<string>> retVal = new Result<List<string>>();
            retVal.ReturnValue = new List<string>();

            try
            {
                retVal.ReturnValue = Directory.EnumerateFiles(parentDirectory, searchPattern, SearchOption.AllDirectories).ToList<string>();
            }
            catch (IOException ex)
            {
                retVal.AddError("Error listing files for directory '" + parentDirectory + "' using search pattern '" + searchPattern + " : " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Returns a list of files contained within the specified zip file matching the supplied searchPattern.
        /// </summary>
        /// <param name="zipFile">The zip file to search.</param>
        /// <param name="searchPattern">The search pattern to match files against.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a list containing the fully qualified filename of each file found.
        /// </returns>
        public virtual Result<List<string>> ListZipFiles(string zipFile, string searchPattern)
        {
            logger.EnterMethod(xLogger.Params(zipFile, searchPattern));
            logger.Trace("Listing files in zip file '" + zipFile + "' matching searchPattern '" + searchPattern + "'...");

            Result<List<string>> retVal = new Result<List<string>>();
            retVal.ReturnValue = new List<string>();

            logger.Trace("Converting pattern '" + searchPattern + "' to RegEx..");
            Regex regex = new Regex(SDK.Utility.WildcardToRegex(searchPattern), RegexOptions.IgnoreCase);
            logger.Trace("Converted pattern to RegEx '" + regex + "'");

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

                    logger.Trace(retVal.ReturnValue.Count + " matches for '" + regex + "' found.");
                }
            }
            catch (Exception ex)
            {
                retVal.AddError("Error listing files in zip file '" + zipFile + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Reads the contents of the specified file into a single string.
        /// </summary>
        /// <param name="file">The file to read.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a string containing the entire contents of the file.
        /// </returns>
        public virtual Result<string> ReadFile(string file)
        {
            logger.EnterMethod(xLogger.Params(file));
            logger.Trace("Reading contents of file '" + file + "'...");

            Result<string> retVal = new Result<string>();

            try
            {
                retVal.ReturnValue = File.ReadAllText(file);
            }
            catch (Exception ex)
            {
                retVal.AddError("Error reading file '" + file + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Reads the contents of the specified file into a string array.
        /// </summary>
        /// <param name="file">The file to read.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a string array containing all of the lines from the file.
        /// </returns>
        public virtual Result<string[]> ReadFileLines(string file)
        {
            logger.EnterMethod(xLogger.Params(file));
            logger.Trace("Reading lines from file '" + file + "'...");

            Result<string[]> retVal = new Result<string[]>();

            try
            {
                retVal.ReturnValue = File.ReadAllLines(file);
            }
            catch (Exception ex)
            {
                retVal.AddError("Error reading lines from file '" + file + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        /// <summary>
        ///     Writes the contents of the supplied string into the specified file. If the destination file already exists it is overwritten.
        /// </summary>
        /// <param name="file">The file to write.</param>
        /// <param name="contents">The text to write to the file.</param>
        /// <returns>The fully qualified name of the written file.</returns>
        public virtual Result<string> WriteFile(string file, string contents)
        {
            logger.EnterMethod(xLogger.Params(file, contents));
            logger.Trace("Writing to file '" + file + "'...");

            Result<string> retVal = new Result<string>();

            try
            {
                File.WriteAllText(file, contents);
                retVal.ReturnValue = file;
            }
            catch (Exception ex)
            {
                retVal.AddError("Error writing to file '" + file + "': " + ex);
                logger.Exception(LogLevel.Debug, ex);
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal.ResultCode);
            return retVal;
        }

        #endregion Public Methods
    }
}