using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

/// <summary>
/// The Windows class implements the platform interfaces necessary to run the application on the Windows platform.
/// </summary>
/// <remarks>
/// Some wierdness in the C# compiler won't allow implicitly defined interface properties if the property is less
/// accessible than public.  For whatever reason the properties can be public but the class can be internal.
/// The effective accessibility for these classes and all of their members is internal.
/// </remarks>
namespace Symbiote.Core.Platform
{
    internal class Windows : IPlatform
    {
        private static Logger logger;

        public Platform.PlatformType PlatformType { get; private set; }
        public string Version { get; private set; }
        public ISystemInformation Info { get; private set; }

        internal Windows()
        {
            logger = LogManager.GetCurrentClassLogger();

            PlatformType = Platform.PlatformType.Windows;
            Version = Environment.OSVersion.VersionString;
            Info = new WindowsSystemInformation();
        }

        public List<string> GetDirectoryList(string root)
        {
            List<string> list = new List<string>();
            try
            {
                list = Directory.EnumerateDirectories(root).ToList<string>();
            }
            catch (IOException ex)
            {
                logger.Error(ex, "Error listing directories for root path '" + root + "'");
            }
            return list;
        }

        public List<string> GetFileList(string root, string searchPattern)
        {
            List<string> list = new List<string>();
            try
            {
                list = Directory.EnumerateFiles(root, searchPattern).ToList<string>();
            }
            catch (IOException ex)
            {
                logger.Error(ex, "Error listing files for directory '" + root + "' using search pattern '" + searchPattern);
            }
            return list;
        }
    }

    internal class WindowsSystemInformation: ISystemInformation
    {
        public double CPUTime { get; private set; }
        public double MemoryUsage { get; private set; }
        public List<IDriveInformation> Drives { get; private set; }
        public List<INetworkAdapterInformation> NetworkAdapters { get; private set; }

        internal WindowsSystemInformation()
        {
            Drives = new List<IDriveInformation>();
            Refresh();
        }

        public void Refresh()
        {
            CPUTime = getCPUCounter();
            MemoryUsage = getAvailableRAM();
            Drives.Clear();
            
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
               if (drive.IsReady)
                    Drives.Add(new WindowsDriveInformation(drive));
            }

        }

        private double getCPUCounter()
        {
            PerformanceCounter cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            cpuCounter.NextValue();
            System.Threading.Thread.Sleep(250);
            return cpuCounter.NextValue();
        }

        private double getAvailableRAM()
        {
            return new PerformanceCounter("Memory", "Available MBytes").NextValue();
        }
    }

    internal class WindowsDriveInformation : IDriveInformation
    {
        private static Logger logger;

        public string Name { get; private set; }
        public string Path { get; private set; }
        public Platform.DriveType Type { get; private set; }
        public long Capacity { get; private set; }
        public long UsedSpace { get; private set; }
        public long FreeSpace { get; private set; }
        public double PercentFree { get; private set; }
        public double PercentUsed { get; private set; }

        internal WindowsDriveInformation(DriveInfo drive)
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
                    this.Type = (Platform.DriveType)Enum.Parse(typeof(Platform.DriveType), drive.DriveType.ToString());
                    this.Capacity = drive.TotalSize;
                    this.FreeSpace = drive.TotalFreeSpace;
                    this.UsedSpace = Capacity - FreeSpace;
                    this.PercentFree = FreeSpace / (double)Capacity;
                    this.PercentUsed = UsedSpace / (double)Capacity;
                }
            }
            catch (System.IO.IOException ex)
            {
                logger.Error(ex, "Error listing drive info");
            }
        }
    }
}
