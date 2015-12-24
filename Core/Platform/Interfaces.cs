using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core
{
    interface IPlatform
    {
        Platform.PlatformType Type();
        string Version();
        ISystemInfo Info();
    }

    interface ISystemInfo
    {
        double CPUTime();
        double MemoryUsage();
        List<IDiskInfo> Disks();
        void Refresh();
    }

    interface IDiskInfo
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
