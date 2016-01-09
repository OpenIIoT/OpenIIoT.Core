using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbiote.Core.Plugin;
using System.Diagnostics;

namespace Symbiote.Core.Platform
{
    internal class WindowsConnector : IConnector
    {
        private IConnectorItem itemRoot;
        private PerformanceCounter cpuUsed;
        private PerformanceCounter cpuIdle;

        private double lastCPUUsed;
        private double lastCPUIdle;

        public string Name { get; private set; }
        public string Namespace { get; private set; }
        public Version Version { get; private set; }
        public PluginType PluginType { get; private set; }
        public IPluginConfigurationDefinition ConfigurationDefinition { get; private set; }
        public string InstanceName { get; private set; }
        public string Configuration { get; private set; }
        public bool Configured { get { return true; } }
        public bool Browseable { get { return true; } }
        public bool Writeable { get { return false; } }

        public WindowsConnector(string instanceName)
        {
            InstanceName = instanceName;
            Name = "WindowsConnector";
            Namespace = "Symbiote.Core.Platform.WindowsConnector";
            Version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;

            cpuUsed = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuIdle = new PerformanceCounter("Processor", "% Idle Time", "_Total");

            InitializeItems();
        }

        public void Configure(string configuration)
        {

        }

        public List<IConnectorItem> Browse(IConnectorItem root)
        {
            return (root == null ? itemRoot.Children : root.Children);
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
            itemRoot = new WindowsConnectorItem("Items");
            itemRoot.SetItemAsRoot(InstanceName);

            // create CPU items
            IConnectorItem cpuRoot = itemRoot.AddChild(new WindowsConnectorItem("CPU"));
            cpuRoot.AddChild(new WindowsConnectorItem("% Processor Time", typeof(double), ""));
            cpuRoot.AddChild(new WindowsConnectorItem("% Idle Time", typeof(double), ""));

            // prepare variables to use for processor time.  you need two successive values to 
            // report accurately so rather than sleeping the thread we will just keep track from 
            // call to call.  the first values will always be zero and that's ok.
            lastCPUUsed = 0;
            lastCPUIdle = 0;

            // create memory items
            IConnectorItem memRoot = itemRoot.AddChild(new WindowsConnectorItem("Memory"));
            memRoot.AddChild(new WindowsConnectorItem("Total", typeof(double), ""));
            memRoot.AddChild(new WindowsConnectorItem("Available", typeof(double), ""));
            memRoot.AddChild(new WindowsConnectorItem("Cached", typeof(double), ""));
            memRoot.AddChild(new WindowsConnectorItem("% Used", typeof(double), ""));

            // create drive items
            IConnectorItem dRoot = itemRoot.AddChild(new WindowsConnectorItem("Drives"));

            // system drive
            IConnectorItem sdRoot = dRoot.AddChild(new WindowsConnectorItem("System"));
            sdRoot.AddChild(new WindowsConnectorItem("Name", typeof(string), ""));
            sdRoot.AddChild(new WindowsConnectorItem("Path", typeof(string), ""));
            sdRoot.AddChild(new WindowsConnectorItem("Type", typeof(Platform.DriveType), ""));
            sdRoot.AddChild(new WindowsConnectorItem("Capacity", typeof(long), ""));
            sdRoot.AddChild(new WindowsConnectorItem("UsedSpace", typeof(long), ""));
            sdRoot.AddChild(new WindowsConnectorItem("FreeSpace", typeof(long), ""));
            sdRoot.AddChild(new WindowsConnectorItem("PercentUsed", typeof(double), ""));
            sdRoot.AddChild(new WindowsConnectorItem("PercentFree", typeof(double), ""));

            // data drive
            IConnectorItem ddRoot = dRoot.AddChild(new WindowsConnectorItem("Data"));
            ddRoot.AddChild(new WindowsConnectorItem("Name", typeof(string), ""));
            ddRoot.AddChild(new WindowsConnectorItem("Path", typeof(string), ""));
            ddRoot.AddChild(new WindowsConnectorItem("Type", typeof(Platform.DriveType), ""));
            ddRoot.AddChild(new WindowsConnectorItem("Capacity", typeof(long), ""));
            ddRoot.AddChild(new WindowsConnectorItem("UsedSpace", typeof(long), ""));
            ddRoot.AddChild(new WindowsConnectorItem("FreeSpace", typeof(long), ""));
            ddRoot.AddChild(new WindowsConnectorItem("PercentUsed", typeof(double), ""));
            ddRoot.AddChild(new WindowsConnectorItem("PercentFree", typeof(double), ""));
        }
    }
    public class WindowsConnectorItem : IConnectorItem
    {
        public IConnectorItem Parent { get; private set; }
        public string Name { get; private set; }
        public string Path { get; private set; }
        public string FQN { get; private set; }
        public Type Type { get; private set; }
        public string SourceAddress { get; private set; }
        public List<IConnectorItem> Children { get; private set; }
        public string InstanceName { get; private set; }

        public WindowsConnectorItem(string name) : this(name, typeof(void), "") { }
        public WindowsConnectorItem(string name, Type type, string sourceAddress)
        {
            Name = name;
            Path = "";
            FQN = "";
            Type = type;
            SourceAddress = sourceAddress;
            Children = new List<IConnectorItem>();
        }

        public bool HasChildren()
        {
            return (Children.Count > 0);
        }

        public IConnectorItem AddChild(IConnectorItem child)
        {
            Children.Add(child.SetParent(this));
            return child;
        }

        public IConnectorItem SetParent(IConnectorItem parent)
        {
            Path = parent.FQN;
            FQN = Path + "." + Name;
            return this;
        }

        public IConnectorItem SetItemAsRoot(string instanceName)
        {
            InstanceName = instanceName;
            this.FQN = InstanceName;
            this.SetParent(this);
            return this;
        }
    }

    public class WindowsConnectorConfigurationDefinition : IPluginConfigurationDefinition
    {
        public string Form { get; private set; }
        public string Schema { get; private set; }
    }
}
