using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbiote.Core.Plugin;
using System.Diagnostics;

namespace Symbiote.Core.Platform.UNIX
{
    internal class PlatformConnector : IConnector
    {
        private Item itemRoot;
        private PerformanceCounter cpuUsed;
        private PerformanceCounter cpuIdle;

        private double lastCPUUsed;
        private double lastCPUIdle;

        public string Name { get; private set; }
        public string FullName { get; private set; }
        public Version Version { get; private set; }
        public PluginType PluginType { get; private set; }
        public IPluginConfigurationDefinition ConfigurationDefinition { get; private set; }
        public string InstanceName { get; private set; }
        public string Configuration { get; private set; }
        public bool Configured { get { return true; } }
        public bool Browseable { get { return true; } }
        public bool Writeable { get { return false; } }

        public PlatformConnector(string instanceName)
        {
            InstanceName = instanceName;
            Name = "WindowsConnector";
            FullName = "Symbiote.Core.Platform.Windows.PlatformConnector";
            Version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            PluginType = PluginType.Connector;

            cpuUsed = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuIdle = new PerformanceCounter("Processor", "% Idle Time", "_Total");

            InitializeItems();
        }

        public void Configure(string configuration)
        {

        }

        public Item Browse()
        {
            return itemRoot;
        }


        public List<Item> Browse(Item root)
        {
            return root.Children;
        }

        public object Read(string item)
        {
            string[] itemName = item.Split('.');

            switch (itemName[itemName.Length - 2] + "." + itemName[itemName.Length - 1])
            {
                case "CPU.% Processor Time":
                    lastCPUUsed = cpuUsed.NextValue();
                    return lastCPUUsed;
                case "CPU.% Idle Time":
                    lastCPUIdle = cpuIdle.NextValue();
                    return lastCPUIdle;
                case "Memory.Total":
                    return 0;
                case "Memory.Available":
                    return new PerformanceCounter("Memory", "Available Bytes").NextValue();
                case "Memory.Cached":
                    return new PerformanceCounter("Memory", "Cache Bytes").NextValue();
                case "Memory.% Used":
                    return new PerformanceCounter("Memory", "% Committed Bytes In Use").NextValue();
                default:
                    return 0;
            }
        }

        public void Write(string item, object value)
        {
            throw new NotImplementedException();
        }

        private void InitializeItems()
        {
            // instantiate an item root
            itemRoot = new Item(InstanceName, true);

            // create CPU items
            Item cpuRoot = itemRoot.AddChild(new Item("CPU"));
            cpuRoot.AddChild(new Item("% Processor Time", typeof(double), ""));
            cpuRoot.AddChild(new Item("% Idle Time", typeof(double), ""));

            // prepare variables to use for processor time.  you need two successive values to 
            // report accurately so rather than sleeping the thread we will just keep track from 
            // call to call.  the first values will always be zero and that's ok.
            lastCPUUsed = 0;
            lastCPUIdle = 0;

            // create memory items
            Item memRoot = itemRoot.AddChild(new Item("Memory"));
            memRoot.AddChild(new Item("Total", typeof(double), ""));
            memRoot.AddChild(new Item("Available", typeof(double), ""));
            memRoot.AddChild(new Item("Cached", typeof(double), ""));
            memRoot.AddChild(new Item("% Used", typeof(double), ""));

            // create drive items
            Item dRoot = itemRoot.AddChild(new Item("Drives"));

            // system drive
            Item sdRoot = dRoot.AddChild(new Item("System"));
            sdRoot.AddChild(new Item("Name", typeof(string), ""));
            sdRoot.AddChild(new Item("Path", typeof(string), ""));
            sdRoot.AddChild(new Item("Type", typeof(Platform.DriveType), ""));
            sdRoot.AddChild(new Item("Capacity", typeof(long), ""));
            sdRoot.AddChild(new Item("UsedSpace", typeof(long), ""));
            sdRoot.AddChild(new Item("FreeSpace", typeof(long), ""));
            sdRoot.AddChild(new Item("PercentUsed", typeof(double), ""));
            sdRoot.AddChild(new Item("PercentFree", typeof(double), ""));

            // data drive
            Item ddRoot = dRoot.AddChild(new Item("Data"));
            ddRoot.AddChild(new Item("Name", typeof(string), ""));
            ddRoot.AddChild(new Item("Path", typeof(string), ""));
            ddRoot.AddChild(new Item("Type", typeof(Platform.DriveType), ""));
            ddRoot.AddChild(new Item("Capacity", typeof(long), ""));
            ddRoot.AddChild(new Item("UsedSpace", typeof(long), ""));
            ddRoot.AddChild(new Item("FreeSpace", typeof(long), ""));
            ddRoot.AddChild(new Item("PercentUsed", typeof(double), ""));
            ddRoot.AddChild(new Item("PercentFree", typeof(double), ""));
        }
    }
}
