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
        private PluginItem itemRoot;
        
        public string Name { get; private set; }
        public string FQN { get; private set; }
        public Version Version { get; private set; }
        public PluginType PluginType { get; private set; }
        public ConfigurationDefinition ConfigurationDefinition { get; private set; }
        public string InstanceName { get; private set; }
        public string Configuration { get; private set; }
        public bool IsConfigured { get { return true; } }
        public bool Browseable { get { return true; } }
        public bool Writeable { get { return false; } }

        public SimulationConnector(string instanceName)
        {
            InstanceName = instanceName;

            Name = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            FQN = System.Reflection.Assembly.GetEntryAssembly().GetTypes()[0].Namespace;
            Version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            PluginType = PluginType.Connector;
            ConfigurationDefinition = new ConfigurationDefinition();

            InitializeItems();
        }

        public void Configure(string configuration)
        {
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
            return (root == null ? itemRoot.Children : root.Children);
        }

        public object Read(string value)
        {
            double val = DateTime.Now.Second;
            switch (value.Split('.')[value.Split('.').Length - 1])
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
                case "Time":
                    return DateTime.Now.ToString("HH:mm:ss");
                case "Date":
                    return DateTime.Now.ToString("MM/dd/yyyy");
                case "TimeZone":
                    return DateTime.Now.ToString("zzz");
                case "Array":
                    return new int[5] { 1, 2, 3, 4, 5 };
                case "Motor":
                    return new Motor("Test Motor", "ABC123XYZ", 30, false);
                case "MotorArray":
                    return Motor.GetMotorArray();
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
            itemRoot = new PluginItem(this, InstanceName, true);

            // create some simulation items
            PluginItem mathRoot = itemRoot.AddChild(new PluginItem(this, "Math", typeof(Folder)));
            mathRoot.AddChild(new PluginItem(this, "Sine", typeof(double)));
            mathRoot.AddChild(new PluginItem(this, "Cosine", typeof(double)));
            mathRoot.AddChild(new PluginItem(this, "Tangent", typeof(double)));

            PluginItem processRoot = itemRoot.AddChild(new PluginItem(this, "Process", typeof(Folder)));
            processRoot.AddChild(new PluginItem(this, "Ramp", typeof(double)));
            processRoot.AddChild(new PluginItem(this, "Step", typeof(double)));
            processRoot.AddChild(new PluginItem(this, "Toggle", typeof(double)));

            PluginItem timeRoot = itemRoot.AddChild(new PluginItem(this, "DateTime", typeof(Structure)));
            timeRoot.AddChild(new PluginItem(this, "Time", typeof(string)));
            timeRoot.AddChild(new PluginItem(this, "Date", typeof(string)));
            timeRoot.AddChild(new PluginItem(this, "TimeZone", typeof(string)));
            //timeRoot.DesignateAsDataStucture();

            PluginItem arrayRoot = itemRoot.AddChild(new PluginItem(this, "Array", typeof(object[])));

            PluginItem motorRoot = itemRoot.AddChild(new PluginItem(this, "Motor", typeof(object)));

            PluginItem motorArrayRoot = itemRoot.AddChild(new PluginItem(this, "MotorArray", typeof(List<object>)));

        }
    }

    //public class PluginConfigurationDefinition : IPluginConfigurationDefinition
    //{
    //    public string Form { get; private set; }
    //    public string Schema { get; private set; }

    //    public PluginConfigurationDefinition()
    //    {
    //        Form = "";
    //        Schema = "";
    //    }
    //}

    public class Motor
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public bool IsRunning { get; set; }

        public Motor(string name, string model, int horsePower, bool isRunning)
        {
            Name = name;
            Model = model;
            HorsePower = horsePower;
            IsRunning = isRunning;
        }

        public static List<Motor> GetMotorArray()
        {
            List<Motor> retVal = new List<Motor>();
            retVal.Add(new Motor("Motor A", "ABC123XYZ.1", 30, true));
            retVal.Add(new Motor("Motor B", "ABC123XYZ.2", 30, false));
            retVal.Add(new Motor("Motor C", "ABC123XYZ.x", 35, true));
            return retVal;
        }
    }
}
