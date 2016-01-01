using System.Collections.Generic;

namespace Symbiote.Core.Platform
{
    /// <summary>
    /// Defines the interface for Platform objects.
    /// </summary>
    public interface IPlatform
    {
        Platform.PlatformType PlatformType { get; }
        string Version { get; }
        ISystemInformation Info { get; }
        List<string> GetDirectoryList(string root);
        List<string> GetFileList(string directory, string extension);
    }

    /// <summary>
    /// Defines the interface for System Information objects.
    /// </summary>
    public interface ISystemInformation
    {
        double CPUTime { get; }
        double MemoryUsage { get; }
        List<IDriveInformation> Drives { get; }
        List<INetworkAdapterInformation> NetworkAdapters { get; }
        void Refresh();
    }

    /// <summary>
    /// Defines the interface for Drive Information objects.
    /// </summary>
    public interface IDriveInformation
    {
        string Name { get; }
        Platform.DriveType Type { get; }
        string Path { get; }
        long Capacity { get; }
        long UsedSpace { get; }
        long FreeSpace { get; }
        double PercentFree { get; }
        double PercentUsed { get; }
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
