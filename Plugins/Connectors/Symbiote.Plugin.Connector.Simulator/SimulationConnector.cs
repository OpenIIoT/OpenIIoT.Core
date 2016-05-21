using System;
using System.Collections.Generic;
using Symbiote.Core.Plugin;
using Symbiote.Core;
using Symbiote.Core.Configuration;
using Symbiote.Core.Plugin.Connector;

namespace Symbiote.Plugin.Connector.Simulation
{
    public class SimulationConnector : IConnector, IConfigurable<SimulationConnectorConfiguration>
    {
        private ConnectorItem itemRoot;
       
        public string Name { get; private set; }
        public string FQN { get; private set; }
        public string Version { get; private set; }
        public PluginType PluginType { get; private set; }
        //public string Fingerprint { get { return "3118151346273047544222b3818c868f3fa3209378ef72ae7c432ce9c8206f0b"; } }

        public ConfigurationDefinition ConfigurationDefinition { get; private set; }
        public SimulationConnectorConfiguration Configuration { get; private set; }

        public string InstanceName { get; private set; }
        public bool Browseable { get { return true; } }
        public bool Writeable { get { return false; } }

        public event EventHandler<ConnectorEventArgs> Changed;

        private System.Timers.Timer timer;
        private int counter;

        public SimulationConnector(string instanceName)
        {
            InstanceName = instanceName;

            Name = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            FQN = System.Reflection.Assembly.GetEntryAssembly().GetTypes()[0].Namespace;
            Version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
            PluginType = PluginType.Connector;

            InitializeItems();

            counter = 0;
            timer = new System.Timers.Timer(50);
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            counter++;
            ((ConnectorItem)FindItem(InstanceName + ".Process.Ramp")).Write(counter);
            ((ConnectorItem)FindItem(InstanceName + ".DateTime.Time")).Write(DateTime.Now);
            ((ConnectorItem)FindItem(InstanceName + ".Motor")).Write(new Motor("Test Motor", "ABCXYZ", counter, true));
        }

        /// <summary>
        /// The parameterless Configure() method calls the overloaded Configure() and passes in the instance of 
        /// the model/type returned by the GetConfiguration() method in the Configuration Manager.
        /// 
        /// This is akin to saying "configure yourself using whatever is in the config file"
        /// </summary>
        /// <returns></returns>
        public OperationResult Configure()
        {
            throw new NotImplementedException();
        }

        public OperationResult Start()
        {
            timer.Start();
            return new OperationResult();
        }

        public OperationResult Stop()
        {
            timer.Stop();
            return new OperationResult();
        }

        /// <summary>
        /// The Configure method is called by external actors to configure or re-configure the Endpoint instance.
        /// 
        /// If anything inside the Endpoint needs to be refreshed to reflect changes to the configuration, do it in
        /// this method.
        /// </summary>
        /// <param name="configuration">The instance of the model/configuration type to apply.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Configure(SimulationConnectorConfiguration configuration)
        {
            Configuration = configuration;

            return new OperationResult();
        }

        public OperationResult SaveConfiguration()
        {
            throw new NotImplementedException();
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
            itemRoot = new ConnectorItem(this, InstanceName, true);

            // create some simulation items
            ConnectorItem mathRoot = itemRoot.AddChild(new ConnectorItem(this, "Math")).Result;
            mathRoot.AddChild(new ConnectorItem(this, "Sine"));
            mathRoot.AddChild(new ConnectorItem(this, "Cosine"));
            mathRoot.AddChild(new ConnectorItem(this, "Tangent"));

            ConnectorItem processRoot = itemRoot.AddChild(new ConnectorItem(this, "Process")).Result;
            processRoot.AddChild(new ConnectorItem(this, "Ramp"));
            processRoot.AddChild(new ConnectorItem(this, "Step"));
            processRoot.AddChild(new ConnectorItem(this, "Toggle"));

            ConnectorItem timeRoot = itemRoot.AddChild(new ConnectorItem(this, "DateTime")).Result;
            timeRoot.AddChild(new ConnectorItem(this, "Time"));
            timeRoot.AddChild(new ConnectorItem(this, "Date"));
            timeRoot.AddChild(new ConnectorItem(this, "TimeZone"));

            ConnectorItem arrayRoot = itemRoot.AddChild(new ConnectorItem(this, "Array")).Result;

            ConnectorItem motorRoot = itemRoot.AddChild(new ConnectorItem(this, "Motor")).Result;

            ConnectorItem motorArrayRoot = itemRoot.AddChild(new ConnectorItem(this, "MotorArray")).Result;

        }

        #region Static Methods

        /// <summary>
        /// The GetConfigurationDefinition method is static and returns the ConfigurationDefinition for the Endpoint.
        /// 
        /// This method is necessary so that the configuration defintion can be registered with the ConfigurationManager
        /// prior to any instances being created.  This method MUST be implemented, however it is not possible to specify
        /// static methods in an interface, so implementing IConfigurable will not enforce this.
        /// </summary>
        /// <returns>The ConfigurationDefinition for the Endpoint.</returns>
        public static ConfigurationDefinition GetConfigurationDefinition()
        {
            ConfigurationDefinition retVal = new ConfigurationDefinition();

            // to create the form and schema strings, visit http://schemaform.io/examples/bootstrap-example.html
            // use the example to create the desired form and schema, and ensure that the resulting model matches the model
            // for the endpoint.  When you are happy with the json from the above url, visit http://www.freeformatter.com/json-formatter.html#ad-output
            // and paste in the generated json and format it using the "JavaScript escaped" option.  Paste the result into the methods below.

            retVal.Form = "[\"templateURL\",{\"type\":\"submit\",\"style\":\"btn-info\",\"title\":\"Save\"}]";
            retVal.Schema = "{\"type\":\"object\",\"title\":\"XMLEndpoint\",\"properties\":{\"templateURL\":{\"title\":\"Template URL\",\"type\":\"string\"}},\"required\":[\"templateURL\"]}";

            // this will always be typeof(YourConfiguration/ModelObject)
            retVal.Model = typeof(SimulationConnectorConfiguration);
            return retVal;
        }

        /// <summary>
        /// The GetDefaultConfiguration method is static and returns a default or blank instance of
        /// the confguration model/type.
        /// 
        /// If the ConfigurationManager fails to retrieve the configuration for an instance it will invoke this 
        /// method and return this value in lieu of a loaded configuration.  This is a failsafe in case
        /// the configuration file becomes corrupted.
        /// </summary>
        /// <returns></returns>
        public static SimulationConnectorConfiguration GetDefaultConfiguration()
        {
            SimulationConnectorConfiguration retVal = new SimulationConnectorConfiguration();
            retVal.Interval = 1000;
            return retVal;
        }

        #endregion

        private void OnChange(string fqn, object value)
        {
            if (Changed != null)
                Changed(this, new ConnectorEventArgs(fqn, value));
        }
    }

    public class SimulationConnectorConfiguration
    {
        public int Interval { set; get; }
    }

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
