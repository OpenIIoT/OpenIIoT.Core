using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Platform
{
    public interface IPlatform
    {
        PlatformManager.PlatformType Type { get; }
        string Version { get; }
        ISystemInformation Info { get; }
        List<string> GetDirectoryList(string root);
        List<string> GetFileList(string directory, string extension);
    }

    public interface ISystemInformation
    {
        double CPUTime { get; }
        double MemoryUsage { get; }
        List<IDiskInformation> Disks { get; }
        List<INetworkAdapterInformation> NetworkAdapters { get; }
        void Refresh();
    }

    public interface IDiskInformation
    {
        string Name { get; }
        PlatformManager.DiskType Type { get; }
        string Path { get; }
        long Capacity { get; }
        long UsedSpace { get; }
        long FreeSpace { get; }
        double PercentFree { get; }
        double PercentUsed { get; }
    }

    public interface INetworkAdapterInformation
    {
        string Name { get; }
        PlatformManager.NetworkAdapterType Type { get; }
        string MACAddress { get; }
        string IPAddress { get; }
        long Bandwidth { get; }
        long BytesSentPerSecond { get; }
        long BytesReceivedPerSecond { get; }
    }
}
