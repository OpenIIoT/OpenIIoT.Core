using System;
using System.Collections.Generic;
using Symbiote.Core;
using Symbiote.Core.Plugin;
using Symbiote.Core.Configuration;
using Symbiote.Core.Plugin.Connector;

namespace Symbiote.Plugin.Connector.Example
{
    public class ExampleConnector : IConnector, IConfigurable<ExampleConnectorConfiguration>
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

        /// <summary>
        /// The ConfigurationDefinition property returns the Endpoint's configuration details.
        /// 
        /// A ConfigurationDefinition instance includes two strings; a Form and a Schema, and a Type corresponding
        /// to the model/configuration class.
        /// </summary>
        public ConfigurationDefinition ConfigurationDefinition { get { return GetConfigurationDefinition(); } }

        /// <summary>
        /// The Configuration property is the type of the model/configuration class.
        /// This corresponds to the value of T in IConfigurable(T).
        /// </summary>
        public ExampleConnectorConfiguration Configuration { get; private set; }

        #endregion

        #region Events

        public event EventHandler<ConnectorEventArgs> Changed;

        #endregion

        #region Constructors

        public ExampleConnector(string instanceName)
        {
            InstanceName = instanceName;

            Name = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            FQN = System.Reflection.Assembly.GetEntryAssembly().GetTypes()[0].Namespace;
            Version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            PluginType = PluginType.Connector;

            InitializeItems();
        }

        #endregion

        #region Instance Methods

        #region IConnector Implementation

        public Result Start()
        {
            return new Result();
        }

        public Result Stop()
        {
            return new Result();
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

        public object Read(string fqn)
        {
            switch (fqn.Replace(InstanceName + ".", ""))
            {
                case "Folder.Integer":
                    return 1;
                case "Folder.Double":
                    return 1.5;
                case "Folder.String":
                    return "Hello World!";
                case "Array":
                    return new int[] { 1, 2, 3, 4, 5 };
                default:
                    return null;
            }

        }


        public Result Write(string item, object value)
        {
            return new Result().AddError("The connector is not writeable.");
        }

        #endregion

        #region IConfigurable Implementation

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

        /// <summary>
        /// The Configure method is called by external actors to configure or re-configure the Endpoint instance.
        /// 
        /// If anything inside the Endpoint needs to be refreshed to reflect changes to the configuration, do it in
        /// this method.
        /// </summary>
        /// <param name="configuration">The instance of the model/configuration type to apply.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public Result Configure(ExampleConnectorConfiguration configuration)
        {
            Configuration = configuration;

            return new Result();
        }

        public Result SaveConfiguration()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void InitializeItems()
        {
            // instantiate an item root
            itemRoot = new ConnectorItem(this, InstanceName, true);

            // create some simulation items
            ConnectorItem folderRoot = itemRoot.AddChild(new ConnectorItem(this, "Folder")).ReturnValue;
            folderRoot.AddChild(new ConnectorItem(this, "Integer"));
            folderRoot.AddChild(new ConnectorItem(this, "Double"));
            folderRoot.AddChild(new ConnectorItem(this, "String"));

            ConnectorItem array = itemRoot.AddChild(new ConnectorItem(this, "Array")).ReturnValue;
        }

        private void OnChange(string fqn, object value)
        {
            if (Changed != null)
                Changed(this, new ConnectorEventArgs(fqn, value));
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

            retVal.SetForm("[\"templateURL\",{\"type\":\"submit\",\"style\":\"btn-info\",\"title\":\"Save\"}]");
            retVal.SetSchema("{\"type\":\"object\",\"title\":\"XMLEndpoint\",\"properties\":{\"templateURL\":{\"title\":\"Template URL\",\"type\":\"string\"}},\"required\":[\"templateURL\"]}");

            // this will always be typeof(YourConfiguration/ModelObject)
            retVal.SetModel(typeof(ExampleConnectorConfiguration));
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
        public static ExampleConnectorConfiguration GetDefaultConfiguration()
        {
            ExampleConnectorConfiguration retVal = new ExampleConnectorConfiguration();
            retVal.Configuration = "Hello World!  This is the example configuration.";
            return retVal;
        }

        #endregion
    }
}
