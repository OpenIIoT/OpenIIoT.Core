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
        List<string> GetFileList(string directory, string extension);
        string ReadFile(string fileName);
        void WriteFile(string fileName, string text);
        string ComputeFileChecksum(string fileName);
    }
}
