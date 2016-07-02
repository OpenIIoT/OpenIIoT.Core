using System;
using System.Collections.Generic;
using Symbiote.Core.Plugin;
using Symbiote.Core.Plugin.Connector;
using System.Diagnostics;
using Symbiote.Core.Configuration;
namespace Symbiote.Core.Platform.Windows
{
    public class WindowsPlatformConnector : IConnector
    {
        private ConnectorItem itemRoot;
        private PerformanceCounter cpuUsed;
        private PerformanceCounter cpuIdle;

        private double lastCPUUsed;
        private double lastCPUIdle;

        public string Name { get; private set; }
        public string FQN { get; private set; }
        public string Version { get; private set; }
        public PluginType PluginType { get; private set; }
        public ConfigurationDefinition ConfigurationDefinition { get; private set; }
        public string InstanceName { get; private set; }
        public string Configuration { get; private set; }
        public bool IsConfigured { get { return true; } }
        public bool Browseable { get { return true; } }
        public bool Writeable { get { return false; } }

        //public event EventHandler<ConnectorEventArgs> ItemChanged;

        public WindowsPlatformConnector(string instanceName)
        {
            InstanceName = instanceName;
            Name = "WindowsConnector";
            FQN = "Symbiote.Core.Platform.Windows.PlatformConnector";
            Version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
            PluginType = PluginType.Connector;

            ConfigurationDefinition = new ConfigurationDefinition();

            cpuUsed = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuIdle = new PerformanceCounter("Processor", "% Idle Time", "_Total");

            InitializeItems();
        }

        public void Configure(string configuration)
        {

        }

        public Result Start()
        {
            return new Result();
        }

        public Result Restart()
        {
            return new Result();
        }

        public Result Stop()
        {
            return new Result();
        }

        public Item Find(string fqn)
        {
            return Find(itemRoot, fqn);
        }

        private Item Find(Item root, string fqn)
        {
            if (root.FQN == fqn) return root;

            Item found = default(Item);
            foreach (Item child in root.Children)
            {
                found = Find(child, fqn);
                if (found != default(Item)) break;
            }
            return found;
        }

        public Item Browse()
        {
            return itemRoot;
        }

        public List<Item> Browse(Item root)
        {
            return root.Children;
        }

        public Result<object> Read(Item item)
        {
            Result<object> retVal = new Result<object>();

            string[] itemName = item.FQN.Split('.');

            if (itemName.Length < 3) return null;

            switch (itemName[itemName.Length - 2] + "." + itemName[itemName.Length - 1])
            {
                case "CPU.% Processor Time":
                    lastCPUUsed = cpuUsed.NextValue();
                    lastCPUIdle = cpuIdle.NextValue();
                    retVal.ReturnValue = lastCPUUsed;
                    return retVal;
                case "CPU.% Idle Time":
                    lastCPUUsed = cpuUsed.NextValue();
                    lastCPUIdle = cpuIdle.NextValue();
                    retVal.ReturnValue = lastCPUIdle;
                    return retVal;
                case "Memory.Total":
                    retVal.ReturnValue = 0;
                    return retVal;
                case "Memory.Available":
                    retVal.ReturnValue = new PerformanceCounter("Memory", "Available Bytes").NextValue();
                    return retVal;
                case "Memory.Cached":
                    retVal.ReturnValue = new PerformanceCounter("Memory", "Cache Bytes").NextValue();
                    return retVal;
                case "Memory.% Used":
                    retVal.ReturnValue = new PerformanceCounter("Memory", "% Committed Bytes In Use").NextValue();
                    return retVal;
                default:
                    return retVal.AddError("Unable to find Item '" + item + "'.");
            }
        }

        public Result Write(string fqn, object value)
        {
            return new Result().AddError("The connector is not writeable.");
        }

        private void InitializeItems()
        {
            // instantiate an item root
            itemRoot = new ConnectorItem(this, InstanceName);

            // create CPU items
            Item cpuRoot = itemRoot.AddChild(new ConnectorItem(this, "CPU")).ReturnValue;
            cpuRoot.AddChild(new ConnectorItem(this, "CPU.% Processor Time"));
            cpuRoot.AddChild(new ConnectorItem(this, "CPU.% Idle Time"));

            // prepare variables to use for processor time.  you need two successive values to 
            // report accurately so rather than sleeping the thread we will just keep track from 
            // call to call.  the first values will always be zero and that's ok.
            lastCPUUsed = 0;
            lastCPUIdle = 0;

            // create memory items
            Item memRoot = itemRoot.AddChild(new ConnectorItem(this, "Memory")).ReturnValue;
            memRoot.AddChild(new ConnectorItem(this, "Memory.Total"));
            memRoot.AddChild(new ConnectorItem(this, "Memory.Available"));
            memRoot.AddChild(new ConnectorItem(this, "Memory.Cached"));
            memRoot.AddChild(new ConnectorItem(this, "Memory.% Used"));

            // create drive items
            ConnectorItem dRoot = itemRoot.AddChild(new ConnectorItem(this, "Drives")).ReturnValue;

            // system drive
            ConnectorItem sdRoot = dRoot.AddChild(new ConnectorItem(this, "Drives.System")).ReturnValue;
            sdRoot.AddChild(new ConnectorItem(this, "Drives.System.Name"));
            sdRoot.AddChild(new ConnectorItem(this, "Path"));
            sdRoot.AddChild(new ConnectorItem(this, "Type"));
            sdRoot.AddChild(new ConnectorItem(this, "Capacity"));
            sdRoot.AddChild(new ConnectorItem(this, "UsedSpace"));
            sdRoot.AddChild(new ConnectorItem(this, "FreeSpace"));
            sdRoot.AddChild(new ConnectorItem(this, "PercentUsed"));
            sdRoot.AddChild(new ConnectorItem(this, "PercentFree"));

            // data drive
            ConnectorItem ddRoot = dRoot.AddChild(new ConnectorItem(this, "Data")).ReturnValue;
            ddRoot.AddChild(new ConnectorItem(this, "Name"));
            ddRoot.AddChild(new ConnectorItem(this, "Path"));
            ddRoot.AddChild(new ConnectorItem(this, "Type"));
            ddRoot.AddChild(new ConnectorItem(this, "Capacity"));
            ddRoot.AddChild(new ConnectorItem(this, "UsedSpace"));
            ddRoot.AddChild(new ConnectorItem(this, "FreeSpace"));
            ddRoot.AddChild(new ConnectorItem(this, "PercentUsed"));
            ddRoot.AddChild(new ConnectorItem(this, "PercentFree"));
        }

        //private void OnItemChange(string fqn, object value)
        //{
        //    if (ItemChanged != null)
        //        ItemChanged(this, new ConnectorEventArgs(fqn, value));
        //}
    }
}
