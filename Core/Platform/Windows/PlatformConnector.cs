using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbiote.Core.Plugin;
using System.Diagnostics;

namespace Symbiote.Core.Platform.Windows
{
    internal class PlatformConnector : IConnector
    {
        private IComposite itemRoot;
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

            ConfigurationDefinition = new PluginConfigurationDefinition();

            cpuUsed = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuIdle = new PerformanceCounter("Processor", "% Idle Time", "_Total");

            InitializeItems();
        }

        public void Configure(string configuration)
        {

        }

        public List<IComposite> Browse(IComposite root)
        {
            return (root == null ? itemRoot.Children : root.Children);
        }

        public object Read(string fqn)
        {
            string[] itemName = fqn.Split('.');

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

        public void Write(string fqn, object value)
        {
            throw new NotImplementedException();
        }

        private void InitializeItems()
        {
            // instantiate an item root
            itemRoot = new PlatformConnectorItem(InstanceName, true);

            // create CPU items
            IComposite cpuRoot = itemRoot.AddChild(new PlatformConnectorItem("CPU"));
            cpuRoot.AddChild(new PlatformConnectorItem("% Processor Time", typeof(double), ""));
            cpuRoot.AddChild(new PlatformConnectorItem("% Idle Time", typeof(double), ""));

            // prepare variables to use for processor time.  you need two successive values to 
            // report accurately so rather than sleeping the thread we will just keep track from 
            // call to call.  the first values will always be zero and that's ok.
            lastCPUUsed = 0;
            lastCPUIdle = 0;

            // create memory items
            IComposite memRoot = itemRoot.AddChild(new PlatformConnectorItem("Memory"));
            memRoot.AddChild(new PlatformConnectorItem("Total", typeof(double), ""));
            memRoot.AddChild(new PlatformConnectorItem("Available", typeof(double), ""));
            memRoot.AddChild(new PlatformConnectorItem("Cached", typeof(double), ""));
            memRoot.AddChild(new PlatformConnectorItem("% Used", typeof(double), ""));

            // create drive items
            IComposite dRoot = itemRoot.AddChild(new PlatformConnectorItem("Drives"));

            // system drive
            IComposite sdRoot = dRoot.AddChild(new PlatformConnectorItem("System"));
            sdRoot.AddChild(new PlatformConnectorItem("Name", typeof(string), ""));
            sdRoot.AddChild(new PlatformConnectorItem("Path", typeof(string), ""));
            sdRoot.AddChild(new PlatformConnectorItem("Type", typeof(Platform.DriveType), ""));
            sdRoot.AddChild(new PlatformConnectorItem("Capacity", typeof(long), ""));
            sdRoot.AddChild(new PlatformConnectorItem("UsedSpace", typeof(long), ""));
            sdRoot.AddChild(new PlatformConnectorItem("FreeSpace", typeof(long), ""));
            sdRoot.AddChild(new PlatformConnectorItem("PercentUsed", typeof(double), ""));
            sdRoot.AddChild(new PlatformConnectorItem("PercentFree", typeof(double), ""));

            // data drive
            IComposite ddRoot = dRoot.AddChild(new PlatformConnectorItem("Data"));
            ddRoot.AddChild(new PlatformConnectorItem("Name", typeof(string), ""));
            ddRoot.AddChild(new PlatformConnectorItem("Path", typeof(string), ""));
            ddRoot.AddChild(new PlatformConnectorItem("Type", typeof(Platform.DriveType), ""));
            ddRoot.AddChild(new PlatformConnectorItem("Capacity", typeof(long), ""));
            ddRoot.AddChild(new PlatformConnectorItem("UsedSpace", typeof(long), ""));
            ddRoot.AddChild(new PlatformConnectorItem("FreeSpace", typeof(long), ""));
            ddRoot.AddChild(new PlatformConnectorItem("PercentUsed", typeof(double), ""));
            ddRoot.AddChild(new PlatformConnectorItem("PercentFree", typeof(double), ""));
        }
    }
}
