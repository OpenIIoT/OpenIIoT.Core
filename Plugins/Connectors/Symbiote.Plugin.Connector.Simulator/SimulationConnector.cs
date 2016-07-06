using Symbiote.Core;
using Symbiote.Core.Configuration;
using Symbiote.Core.Plugin;
using Symbiote.Core.Plugin.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Symbiote.Core.Model;
using System.Threading.Tasks;

namespace Symbiote.Plugin.Connector.Simulation
{
    /// <summary>
    /// Provides simulation data.
    /// </summary>
    public class SimulationConnector : IConnector, IReadable, ISubscribable, IConfigurable<SimulationConnectorConfiguration>
    {
        #region Variables

        /// <summary>
        /// the logger for the Connector.
        /// </summary>
        private xLogger logger;

        /// <summary>
        /// The root node for the item tree.
        /// </summary>
        private ConnectorItem itemRoot;

        /// <summary>
        /// The main timer.
        /// </summary>
        private Timer timer;

        /// <summary>
        /// The main counter.
        /// </summary>
        private int counter;

        #endregion

        #region Properties

        #region IConnector Implementation

        /// <summary>
        /// The Connector name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The Connector FQN.
        /// </summary>
        public string FQN { get; private set; }

        /// <summary>
        /// The Connector Version.
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        /// The Connector type.
        /// </summary>
        public PluginType PluginType { get; private set; }

        /// <summary>
        /// The name of the Connector instance.
        /// </summary>
        public string InstanceName { get; private set; }

        /// <summary>
        /// The State of the Connector.
        /// </summary>
        public State State { get; private set; }

        #endregion

        #region ISubscribable Implementation

        /// <summary>
        /// The dictionary containing the current list of subscribed Items and the number of subscribers for each Item..
        /// </summary>
        public Dictionary<ConnectorItem, int> Subscriptions { get; private set; }

        #endregion

        #region IConfigurable Implemenation

        public ConfigurationDefinition ConfigurationDefinition { get; private set; }
        public SimulationConnectorConfiguration Configuration { get; private set; }

        #endregion

        #endregion

        #region Events

        #region IManager Events

        public event EventHandler<StateChangedEventArgs> StateChanged;

        #endregion

        #endregion

        #region Constructors

        public SimulationConnector(ProgramManager manager, string instanceName, xLogger logger)
        {
            InstanceName = instanceName;
            this.logger = logger;

            Name = "Simulation";
            FQN = "Symbiote.Plugin.Connector.Simulation";
            Version = "1.0.0.0";
            PluginType = PluginType.Connector;

            logger.Info("Initializing " + PluginType + " " + FQN + "." + instanceName);

            InitializeItems();

            Subscriptions = new Dictionary<ConnectorItem, int>();

            counter = 0;
            timer = new System.Timers.Timer(50);
            timer.Elapsed += Timer_Elapsed;
        }

        #endregion

        #region Instance Methods

        #region ISubscribable Implementation

        public Result Subscribe(ConnectorItem item)
        {
            Result retVal = new Result();

            try
            {
                if (Subscriptions.ContainsKey(item))
                    Subscriptions[item]++;
                else
                    Subscriptions.Add(item, 1);

                retVal.AddInfo("The Item '" + item.FQN + "' now has " + Subscriptions[item] + " subscriber(s).");
            }
            catch (Exception ex)
            {
                retVal.AddError("Error subscribing to Item '" + item.FQN + "': " + ex.Message);
            }

            return retVal;
        }

        public Result UnSubscribe(ConnectorItem item)
        {
            Result retVal = new Result();

            try
            {
                if (!Subscriptions.ContainsKey(item))
                    retVal.AddError("The Item '" + item.FQN + "' is not currently subscribed.");
                else
                {
                    Subscriptions[item]--;

                    if (Subscriptions[item] <= 0)
                    {
                        Subscriptions.Remove(item);
                        retVal.AddInfo("The Item '" + item.FQN + "' has been fully unsubscribed.");
                    }
                    else
                        retVal.AddInfo("The Item '" + item.FQN + "' now has " + Subscriptions[item] + " subscriber(s).");
                }
            }
            catch (Exception ex)
            {
                retVal.AddError("Error unsubscribing from Item '" + item.FQN + "': " + ex.Message);
            }

            return retVal;
        }

        #endregion

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            counter++;

            // iterate over the subscribed tags and update them using Write()
            // this will update the value of the ConnectorItem and will fire the Changed event
            // which will cascade the value through the model
            foreach (Item key in Subscriptions.Keys)
            {
                if (key.FQN == InstanceName + ".DateTime.Time") key.Write(DateTime.Now);
                if (key.FQN == InstanceName + ".Process.Ramp") key.Write(counter);
            }
        }

        /// <summary>
        /// The parameterless Configure() method calls the overloaded Configure() and passes in the instance of 
        /// the model/type returned by the GetConfiguration() method in the Configuration Manager.
        /// 
        /// This is akin to saying "configure yourself using whatever is in the config file"
        /// </summary>
        /// <returns></returns>
        public Result Configure()
        {
            throw new NotImplementedException();
        }

        public Result Start()
        {
            timer.Start();
            return new Result();
        }

        public Result Restart()
        {
            Stop();
            Start();
            return new Result();
        }

        public Result Stop()
        {
            timer.Stop();
            return new Result();
        }

        /// <summary>
        /// The Configure method is called by external actors to configure or re-configure the Endpoint instance.
        /// 
        /// If anything inside the Endpoint needs to be refreshed to reflect changes to the configuration, do it in
        /// this method.
        /// </summary>
        /// <param name="configuration">The instance of the model/configuration type to apply.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Configure(SimulationConnectorConfiguration configuration)
        {
            Configuration = configuration;

            return new Result();
        }

        public Result SaveConfiguration()
        {
            throw new NotImplementedException();
        }

        public Item Find(string fqn)
        {
            return Find(itemRoot, fqn);
        }

        public async Task<Item> FindAsync(string fqn)
        {
            return await Task.Run(() => Find(fqn));
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

        public async Task<Item> BrowseAsync()
        {
            return await Task.Run(() => Browse());
        }

        public List<Item> Browse(Item root)
        {
            return (root == null ? itemRoot.Children : root.Children);
        }

        public async Task<List<Item>> BrowseAsync(Item root)
        {
            return await Task.Run(() => Browse(root));
        }

        public Result<object> Read(Item item)
        {
            Result<object> retVal = new Result<object>();

            double val = DateTime.Now.Second;
            switch (item.FQN.Split('.')[item.FQN.Split('.').Length - 1])
            {
                case "Sine":
                    retVal.ReturnValue = Math.Sin(val);
                    return retVal;
                case "Cosine":
                    retVal.ReturnValue = Math.Cos(val);
                    return retVal;
                case "Tangent":
                    retVal.ReturnValue = Math.Tan(val);
                    return retVal;
                case "Ramp":
                    retVal.ReturnValue = val;
                    return retVal;
                case "Step":
                    retVal.ReturnValue = val % 5;
                    return retVal;
                case "Toggle":
                    retVal.ReturnValue = val % 2;
                    return retVal;
                case "Time":
                    retVal.ReturnValue = DateTime.Now.ToString("HH:mm:ss");
                    return retVal;
                case "Date":
                    retVal.ReturnValue = DateTime.Now.ToString("MM/dd/yyyy");
                    return retVal;
                case "TimeZone":
                    retVal.ReturnValue = DateTime.Now.ToString("zzz");
                    return retVal;
                case "Array":
                    retVal.ReturnValue = new int[5] { 1, 2, 3, 4, 5 };
                    return retVal;
                default:
                    return retVal;
            }
                
        }

        public async Task<Result<object>> ReadAsync(Item item)
        {
            return await Task.Run(() => Read(item));
        }

        public Result Write(string item, object value)
        {
            return new Result().AddError("The connector is not writeable.");
        }

        private void InitializeItems()
        {
            // instantiate an item root
            itemRoot = new ConnectorItem(this, InstanceName, true);

            // create some simulation items
            ConnectorItem mathRoot = itemRoot.AddChild(new ConnectorItem(this, "Math")).ReturnValue;
            mathRoot.AddChild(new ConnectorItem(this, "Sine"));
            mathRoot.AddChild(new ConnectorItem(this, "Cosine"));
            mathRoot.AddChild(new ConnectorItem(this, "Tangent"));

            ConnectorItem processRoot = itemRoot.AddChild(new ConnectorItem(this, "Process")).ReturnValue;
            processRoot.AddChild(new ConnectorItem(this, "Ramp"));
            processRoot.AddChild(new ConnectorItem(this, "Step"));
            processRoot.AddChild(new ConnectorItem(this, "Toggle"));

            ConnectorItem timeRoot = itemRoot.AddChild(new ConnectorItem(this, "DateTime")).ReturnValue;
            timeRoot.AddChild(new ConnectorItem(this, "Time"));
            timeRoot.AddChild(new ConnectorItem(this, "Date"));
            timeRoot.AddChild(new ConnectorItem(this, "TimeZone"));

            ConnectorItem arrayRoot = itemRoot.AddChild(new ConnectorItem(this, "Array")).ReturnValue;

            ConnectorItem motorRoot = itemRoot.AddChild(new ConnectorItem(this, "Motor")).ReturnValue;

            ConnectorItem motorArrayRoot = itemRoot.AddChild(new ConnectorItem(this, "MotorArray")).ReturnValue;

        }

        #endregion

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
    }

    public class SimulationConnectorConfiguration
    {
        public int Interval { set; get; }
    }
}
