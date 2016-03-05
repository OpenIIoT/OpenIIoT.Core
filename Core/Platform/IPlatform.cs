using System.Collections.Generic;
using Symbiote.Core.Plugin;

namespace Symbiote.Core.Platform
{
    /// <summary>
    /// Defines the interface for Platform objects.
    /// </summary>
    public interface IPlatform
    {
        Platform.PlatformType PlatformType { get; }
        string Version { get; }
        IConnector Connector { get; }
        IConnector InstantiateConnector(string rootPath);
        List<string> GetDirectoryList(string root);
        List<string> GetFileList(string directory, string searchPattern);
        List<string> GetZipFileList(string zipFile, string searchPattern);
        bool ExtractZip(string zipFile, string destination, bool clearDestination);
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
