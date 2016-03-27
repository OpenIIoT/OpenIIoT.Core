using System;
using System.Collections.Generic;
using Symbiote.Core.Plugin.Connector;
using System.Diagnostics;
using Symbiote.Core.Configuration;
using Symbiote.Core.Plugin;

namespace Symbiote.Core.Platform.UNIX
{
    internal class PlatformConnector : IConnector
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
        public string Fingerprint { get { return "0e2fc599cf9cb475684b4c539cc0c5ee98fa003d65be53c4664926495828fbe0";  } }
        public ConfigurationDefinition ConfigurationDefinition { get; private set; }
        public string InstanceName { get; private set; }
        public string Configuration { get; private set; }
        public bool IsConfigured { get { return true; } }
        public bool Browseable { get { return true; } }
        public bool Writeable { get { return false; } }

        public event EventHandler<ConnectorEventArgs> Changed;

        public PlatformConnector(string instanceName)
        {
            InstanceName = instanceName;
            Name = "UNIXConnector";
            FQN = "Symbiote.Core.Platform.UNIX.PlatformConnector";
            Version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
            PluginType = PluginType.Connector;

            cpuUsed = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuIdle = new PerformanceCounter("Processor", "% Idle Time", "_Total");

            InitializeItems();
        }

        public void Configure(string configuration)
        {

        }

        public OperationResult Start()
        {
            return new OperationResult();
        }

        public OperationResult Stop()
        {
            return new OperationResult();
        }

        public Item FindItem(string fqn)
        {
            return FindItem(itemRoot, fqn);
        }

        private Item FindItem(Item root, string fqn)
        {
            if (root.FQN == fqn) return root;

            Item found = default(Item);
            foreach (Item child in root.Children)
            {
                found = FindItem(child, fqn);
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

        public object Read(string item)
        {
            string[] itemName = item.Split('.');

            if (itemName.Length < 3) return null;

            switch (itemName[itemName.Length - 2] + "." + itemName[itemName.Length - 1])
            {
                case "CPU.% Processor Time":
                    lastCPUUsed = cpuUsed.NextValue();
                    lastCPUIdle = cpuIdle.NextValue();
                    return lastCPUUsed;
                case "CPU.% Idle Time":
                    lastCPUUsed = cpuUsed.NextValue();
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

        public OperationResult Write(string item, object value)
        {
            return new OperationResult().AddError("The connector is not writeable.");
        }

        private void InitializeItems()
        {
            // instantiate an item root
            itemRoot = new ConnectorItem(this, InstanceName);

            // create CPU items
            Item cpuRoot = itemRoot.AddChild(new ConnectorItem(this, "CPU")).Result;
            cpuRoot.AddChild(new ConnectorItem(this, "CPU.% Processor Time"));
            cpuRoot.AddChild(new ConnectorItem(this, "CPU.% Idle Time"));

            // prepare variables to use for processor time.  you need two successive values to 
            // report accurately so rather than sleeping the thread we will just keep track from 
            // call to call.  the first values will always be zero and that's ok.
            lastCPUUsed = 0;
            lastCPUIdle = 0;

            // create memory items
            Item memRoot = itemRoot.AddChild(new ConnectorItem(this, "Memory")).Result;
            memRoot.AddChild(new ConnectorItem(this, "Memory.Total"));
            memRoot.AddChild(new ConnectorItem(this, "Memory.Available"));
            memRoot.AddChild(new ConnectorItem(this, "Memory.Cached"));
            memRoot.AddChild(new ConnectorItem(this, "Memory.% Used"));

            // create drive items
            ConnectorItem dRoot = itemRoot.AddChild(new ConnectorItem(this, "Drives")).Result;

            // system drive
            ConnectorItem sdRoot = dRoot.AddChild(new ConnectorItem(this, "Drives.System")).Result;
            sdRoot.AddChild(new ConnectorItem(this, "Drives.System.Name"));
            sdRoot.AddChild(new ConnectorItem(this, "Path"));
            sdRoot.AddChild(new ConnectorItem(this, "Type"));
            sdRoot.AddChild(new ConnectorItem(this, "Capacity"));
            sdRoot.AddChild(new ConnectorItem(this, "UsedSpace"));
            sdRoot.AddChild(new ConnectorItem(this, "FreeSpace"));
            sdRoot.AddChild(new ConnectorItem(this, "PercentUsed"));
            sdRoot.AddChild(new ConnectorItem(this, "PercentFree"));

            // data drive
            ConnectorItem ddRoot = dRoot.AddChild(new ConnectorItem(this, "Data")).Result;
            ddRoot.AddChild(new ConnectorItem(this, "Name"));
            ddRoot.AddChild(new ConnectorItem(this, "Path"));
            ddRoot.AddChild(new ConnectorItem(this, "Type"));
            ddRoot.AddChild(new ConnectorItem(this, "Capacity"));
            ddRoot.AddChild(new ConnectorItem(this, "UsedSpace"));
            ddRoot.AddChild(new ConnectorItem(this, "FreeSpace"));
            ddRoot.AddChild(new ConnectorItem(this, "PercentUsed"));
            ddRoot.AddChild(new ConnectorItem(this, "PercentFree"));
        }

        private void OnChange(string fqn, object value)
        {
            if (Changed != null)
                Changed(this, new ConnectorEventArgs(fqn, value));
        }
    }
}
