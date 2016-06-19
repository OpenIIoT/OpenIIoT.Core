using System;
using System.Collections.Generic;
using Symbiote.Core.Plugin;
using Symbiote.Core;
using Symbiote.Core.Configuration;
using Symbiote.Core.Plugin.Connector;
using System.Linq;

namespace Symbiote.Plugin.Connector.Simulation
{
    /// <summary>
    /// Provides simulation data.
    /// </summary>
    public class SimulationConnector : IConnector, IAddable, ISubscribable, IConfigurable<SimulationConnectorConfiguration>
    {
        #region Variables

        /// <summary>
        /// The root node for the item tree.
        /// </summary>
        private ConnectorItem itemRoot;

        #endregion

        #region Properties

        #region IConnector Implementation

        /// <summary>
        /// The connector name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The connector FQN.
        /// </summary>
        public string FQN { get; private set; }

        /// <summary>
        /// The connector Version.
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        /// The connector type.
        /// </summary>
        public PluginType PluginType { get; private set; }

        /// <summary>
        /// The name of the connector instance.
        /// </summary>
        public string InstanceName { get; private set; }

        #endregion

        #region ISubscribable Implementation

        /// <summary>
        /// The <see cref="Dictionary{TKey, TValue}"/> containing the current list of subscribed items and the number of subscribers.
        /// </summary>
        public Dictionary<ConnectorItem, int> Subscriptions { get; private set; }

        #endregion

        #region IConfigurable Implemenation

        public ConfigurationDefinition ConfigurationDefinition { get; private set; }
        public SimulationConnectorConfiguration Configuration { get; private set; }

        #endregion



        private System.Timers.Timer timer;
        private int counter;

        #endregion

        #region Constructors

        public SimulationConnector(string instanceName)
        {
            InstanceName = instanceName;

            Name = "Simulation";
            FQN = "Symbiote.Plugin.Connector.Simulation";
            Version = "1.0.0.0";
            PluginType = PluginType.Connector;

            InitializeItems();

            Subscriptions = new Dictionary<ConnectorItem, int>();

            counter = 0;
            timer = new System.Timers.Timer(50);
            timer.Elapsed += Timer_Elapsed;
        }

        #endregion

        #region Instance Methods

        #region IAddable Implementation

        public OperationResult<Item> Add(string fqn, string sourceFQN)
        {
            OperationResult<Item> retVal = new OperationResult<Item>();

            try
            {
                // split the specified FQN by '.' to get each tuple of the path
                string[] path = fqn.Split('.');

                // iterate over each tuple and make sure it exists in the connector's item model
                // if it doesn't, create it.
                Item currentNode = itemRoot;
                foreach (string tuple in path)
                {
                    if (!currentNode.Children.Exists(n => n.Name == tuple))
                    {
                        currentNode = currentNode.AddChild(new ConnectorItem(this, tuple)).Result;
                        retVal.AddInfo("Added node " + currentNode.FQN);
                    }
                    else
                        currentNode = currentNode.Children.Where(n => n.Name == tuple).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                retVal.AddError("Error adding Item '" + fqn + "': " + ex.Message);
            }

            return retVal;
        }

        #endregion

        #region ISubscribable Implementation

        public OperationResult Subscribe(ConnectorItem item)
        {
            OperationResult retVal = new OperationResult();

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

        public OperationResult UnSubscribe(ConnectorItem item)
        {
            OperationResult retVal = new OperationResult();

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
        public OperationResult Configure()
        {
            throw new NotImplementedException();
        }

        public OperationResult Start()
        {
            timer.Start();
            return new OperationResult();
        }

        public OperationResult Restart()
        {
            Stop();
            Start();
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
            return (root == null ? itemRoot.Children : root.Children);
        }

        public OperationResult<object> Read(Item item)
        {
            OperationResult<object> retVal = new OperationResult<object>();

            double val = DateTime.Now.Second;
            switch (item.FQN.Split('.')[item.FQN.Split('.').Length - 1])
            {
                case "Sine":
                    retVal.Result = Math.Sin(val);
                    return retVal;
                case "Cosine":
                    retVal.Result = Math.Cos(val);
                    return retVal;
                case "Tangent":
                    retVal.Result = Math.Tan(val);
                    return retVal;
                case "Ramp":
                    retVal.Result = val;
                    return retVal;
                case "Step":
                    retVal.Result = val % 5;
                    return retVal;
                case "Toggle":
                    retVal.Result = val % 2;
                    return retVal;
                case "Time":
                    retVal.Result = DateTime.Now.ToString("HH:mm:ss");
                    return retVal;
                case "Date":
                    retVal.Result = DateTime.Now.ToString("MM/dd/yyyy");
                    return retVal;
                case "TimeZone":
                    retVal.Result = DateTime.Now.ToString("zzz");
                    return retVal;
                case "Array":
                    retVal.Result = new int[5] { 1, 2, 3, 4, 5 };
                    return retVal;
                default:
                    return retVal;
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

        //private void OnItemChange(string fqn, object value)
        //{
        //    if (ItemChanged != null)
        //        ItemChanged(this, new ConnectorEventArgs(fqn, value));
        //}
    }

    public class SimulationConnectorConfiguration
    {
        public int Interval { set; get; }
    }
}
