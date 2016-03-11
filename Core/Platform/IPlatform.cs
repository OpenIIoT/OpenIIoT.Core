using System.Collections.Generic;
using Symbiote.Core.Plugin.Connector;

namespace Symbiote.Core.Platform
{
    /// <summary>
    /// Defines the interface for Platform objects.
    /// </summary>
    public interface IPlatform
    {
        /// <summary>
        /// The Platform Type.
        /// </summary>
        PlatformType PlatformType { get; }

        /// <summary>
        /// The Version of the Platform OS.
        /// </summary>
        string Version { get; }

        /// <summary>
        /// The accompanying Connector Plugin for the Platform.
        /// </summary>
        IConnector Connector { get; }

        /// <summary>
        /// Instantiates the accompanying Connector Plugin with the supplied root path.
        /// </summary>
        /// <param name="instanceName"></param>
        /// <returns>The instantiated Connector Plugin.</returns>
        IConnector InstantiateConnector(string instanceName);

        /// <summary>
        /// Returns a list of subdirectories within the supplied path.
        /// </summary>
        /// <param name="root">The parent directory to search.</param>
        /// <returns>A list containing the fully qualified path of each directory found.</returns>
        OperationResult<List<string>> GetDirectoryList(string root);

        /// <summary>
        /// Returns a list of files within the supplied directory matching the supplied searchPattern.
        /// </summary>
        /// <param name="directory">The directory to search.</param>
        /// <param name="searchPattern">The search pattern to match files against.</param>
        /// <returns>A list containing the fully qualified filename of each file found.</returns>
        OperationResult<List<string>> GetFileList(string directory, string searchPattern);

        /// <summary>
        /// Returns a list of files contained within the specified zip file matching the supplied searchPattern.
        /// </summary>
        /// <param name="zipFile">The zip file to search.</param>
        /// <param name="searchPattern">The search pattern to match files against.</param>
        /// <returns>A list containing the fully qualified filename of each file found.</returns>
        List<string> GetZipFileList(string zipFile, string searchPattern);

        /// <summary>
        /// Extracts the contents of the supplied zip file to the specified destination, 
        /// clearing the destination first if clearDestination is true.
        /// </summary>
        /// <param name="zipFile">The zip file to extract.</param>
        /// <param name="destination">The destination directory.</param>
        /// <param name="clearDestination">True if the destination directory should be cleared prior to extraction, false otherwise.</param>
        /// <returns></returns>
        bool ExtractZip(string zipFile, string destination, bool clearDestination);

        /// <summary>
        /// Extracts the supplied file from the supplied zip file to the supplied destination, overwriting the file if overwrite is true.
        /// </summary>
        /// <param name="zipFile">The zip file from which to extract the file.</param>
        /// <param name="file">The file to extract from the zip file.</param>
        /// <param name="destination">The destination directory.</param>
        /// <param name="overwrite">True if an existing file should be overwritten, false otherwise.</param>
        /// <returns>The fully qualified filename of the extracted file.</returns>
        string ExtractFileFromZip(string zipFile, string file, string destination, bool overwrite);
        bool DeleteDirectory(string directory);
        bool ClearDirectory(string directory);
        string CreateDirectory(string directory);
        bool DirectoryExists(string directory);
        string ReadFile(string fileName);
        string[] ReadAllLinesFromFile(string fileName);
        void WriteFile(string fileName, string text);
        string GetApplicationDirectory();
        string GetLogFile(string logDirectory);
        string ComputeFileChecksum(string fileName);
    }
}
