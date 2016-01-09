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
        List<string> GetDirectoryList(string root);
        List<string> GetFileList(string directory, string extension);
        string ReadFile(string fileName);
        void WriteFile(string fileName, string text);
    }

    /// <summary>
    /// Defines the interface for Network Adapter Information objects.
    /// </summary>
    public interface INetworkAdapterInformation
    {
        string Name { get; }
        Platform.NetworkAdapterType Type { get; }
        string MACAddress { get; }
        string IPAddress { get; }
        long Bandwidth { get; }
        long BytesSentPerSecond { get; }
        long BytesReceivedPerSecond { get; }
    }
}
