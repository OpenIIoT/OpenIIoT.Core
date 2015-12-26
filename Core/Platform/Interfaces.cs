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
        ISystemInfo Info { get; }
    }

    public interface ISystemInfo
    {
        double CPUTime { get; }
        double MemoryUsage { get; }
        List<IDiskInfo> Disks { get; }
        void Refresh();
    }

    public interface IDiskInfo
    {
        string Name { get; }
        string Path { get; }
        string Type { get; }
        long Capacity { get; }
        long UsedSpace { get; }
        long FreeSpace { get; }
        double PercentFree { get; }
        double PercentUsed { get; }
    }
}
