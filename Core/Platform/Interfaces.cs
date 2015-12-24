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
        string Path();
        long Capacity();
        long UsedSpace();
        long FreeSpace();
    }
}
