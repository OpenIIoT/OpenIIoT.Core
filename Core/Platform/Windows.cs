using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core
{
    class WindowsPlatform : IPlatform
    {
        public WindowsPlatform() { }
        public Platform.PlatformType Type() { return Platform.PlatformType.Windows; }
        public string Version() { return Environment.OSVersion.VersionString; }
        public ISystemInfo Info()
        {
            return new WindowsSystemInfo();
        }
    }

    class WindowsSystemInfo: ISystemInfo
    {
        private double cpuTime;
        private double memoryUsage;
        private List<IDiskInfo> disks;

        public WindowsSystemInfo()
        {
            cpuTime = 0;
            memoryUsage = 0;
            disks = new List<IDiskInfo>();
            Refresh();
        }

        public double CPUTime()
        {
            return cpuTime;
        }

        public double MemoryUsage()
        {
            return memoryUsage;
        }

        public List<IDiskInfo> Disks()
        {
            return disks;
        }

        public void Refresh()
        {
            cpuTime = getCPUCounter();
            memoryUsage = getAvailableRAM();
            disks.Clear();
            disks.Add(new WindowsDiskInfo("c:"));
        }

        public double getCPUCounter()
        {

            PerformanceCounter cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            // will always start at 0
            double firstValue = cpuCounter.NextValue();
            System.Threading.Thread.Sleep(250);
            // now matches task manager reading
            double secondValue = cpuCounter.NextValue();

            return secondValue;

        }

        public double getAvailableRAM()
        {
            return new PerformanceCounter("Memory", "Available MBytes").NextValue();
        }

    }

    class WindowsDiskInfo: IDiskInfo
    {
        private string path;
        private long capacity;
        private long usedSpace;
        private long freeSpace;

        public WindowsDiskInfo(string path)
        {
            this.path = path;
            this.capacity = 10000;
            this.usedSpace = 5000;
            this.freeSpace = capacity - usedSpace;
        }

        public string Path()
        {
            return path;
        }
        public long Capacity() { return capacity; }
        public long UsedSpace() { return usedSpace; }
        public long FreeSpace() { return freeSpace; }
    }
}
