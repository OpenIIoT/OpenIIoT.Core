using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbiote.Core.Plugin;
using Symbiote.Core;

namespace Symbiote.Plugin.Connector.Simulation
{
    public class SimulationConnector : IConnector
    {
        private Item itemRoot;
        
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

        public SimulationConnector(string instanceName)
        {
            InstanceName = instanceName;

            Name = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            FullName = System.Reflection.Assembly.GetEntryAssembly().GetTypes()[0].Namespace;
            Version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            PluginType = PluginType.Connector;
            ConfigurationDefinition = new PluginConfigurationDefinition();

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
            return (root == null ? itemRoot.Children : root.Children);
        }

        public object Read(string value)
        {
            double val = DateTime.Now.Second;
            switch(value.Split('.')[value.Split('.').Length - 1])
            {
                case "Sine":
                    return Math.Sin(val);
                case "Cosine":
                    return Math.Cos(val);
                case "Tangent":
                    return Math.Tan(val);
                case "Ramp":
                    return val;
                case "Step":
                    return val % 5;
                case "Toggle":
                    return val % 2;
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

            // create some simulation items
            Item mathRoot = itemRoot.AddChild(new Item("Math"));
            mathRoot.AddChild(new Item("Sine", typeof(double)));
            mathRoot.AddChild(new Item("Cosine", typeof(double)));
            mathRoot.AddChild(new Item("Tangent", typeof(double)));

            Item processRoot = itemRoot.AddChild(new Item("Process"));
            processRoot.AddChild(new Item("Ramp", typeof(double)));
            processRoot.AddChild(new Item("Step", typeof(double)));
            processRoot.AddChild(new Item("Toggle", typeof(double)));
        }
    }

    public class PluginConfigurationDefinition : IPluginConfigurationDefinition
    {
        public string Form { get; private set; }
        public string Schema { get; private set; }

        public PluginConfigurationDefinition()
        {
            Form = "";
            Schema = "";
        }
    }
}
