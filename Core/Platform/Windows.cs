using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Symbiote.Core.Platform
{
    public class WindowsPlatform : IPlatform
    {
        private static Logger logger;

        public PlatformManager.PlatformType Type { get; private set; }
        public string Version { get; private set; }
        public ISystemInfo Info { get; private set; }

        public WindowsPlatform()
        {
            logger = LogManager.GetCurrentClassLogger();

            Type = PlatformManager.PlatformType.Windows;
            Version = Environment.OSVersion.VersionString;
            Info = new WindowsSystemInfo();
        }
    }

    public class WindowsSystemInfo: ISystemInfo
    {
        public double CPUTime { get; private set; }
        public double MemoryUsage { get; private set; }
        public List<IDiskInfo> Disks { get; private set; }

        public WindowsSystemInfo()
        {
            Disks = new List<IDiskInfo>();
            Refresh();
        }

        public void Refresh()
        {
            CPUTime = getCPUCounter();
            MemoryUsage = getAvailableRAM();
            Disks.Clear();
            
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
               if (drive.IsReady)
                    Disks.Add(new WindowsDiskInfo(drive));
            }

        }

        public double getCPUCounter()
        {
            PerformanceCounter cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            cpuCounter.NextValue();
            System.Threading.Thread.Sleep(250);
            return cpuCounter.NextValue();
        }

        public double getAvailableRAM()
        {
            return new PerformanceCounter("Memory", "Available MBytes").NextValue();
        }
    }

    public class WindowsDiskInfo : IDiskInfo
    {
        private static Logger logger;

        public string Name { get; private set; }
        public string Path { get; private set; }
        public string Type { get; private set; }
        public long Capacity { get; private set; }
        public long UsedSpace { get; private set; }
        public long FreeSpace { get; private set; }
        public double PercentFree { get; private set; }
        public double PercentUsed { get; private set; }

        public WindowsDiskInfo(DriveInfo drive)
        {
            logger = LogManager.GetCurrentClassLogger();
            try
            {
                if (!drive.IsReady)
                    throw new System.IO.IOException("Drive " + drive.Name + " is not ready; unable to retrieve information");
                else
                {
                    this.Name = drive.Name;
                    this.Path = drive.RootDirectory.ToString();
                    this.Type = drive.DriveType.ToString();
                    this.Capacity = drive.TotalSize;
                    this.FreeSpace = drive.TotalFreeSpace;
                    this.UsedSpace = Capacity - FreeSpace;
                    this.PercentFree = FreeSpace / (double)Capacity;
                    this.PercentUsed = UsedSpace / (double)Capacity;
                }
            }
            catch (System.IO.IOException ex)
            {
                logger.Error("Error listing drive info", ex);
            }
        }
    }
}
