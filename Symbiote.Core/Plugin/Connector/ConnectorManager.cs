using System;
using System.Collections.Generic;
using NLog;
using Symbiote.Core.Configuration;

namespace Symbiote.Core.Plugin.Connector
{
    public class ConnectorManager : IStateful, IConfigurable<ConnectorManagerConfiguration>
    {
        #region Variables

        private IProgramManager manager;
        private IPluginManager pluginManager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static ConnectorManager instance;

        #endregion

        #region Properties

        public State State { get; private set; }

        public ConfigurationDefinition ConfigurationDefinition { get { return GetConfigurationDefinition(); } }

        public ConnectorManagerConfiguration Configuration { get; private set; }

        internal Dictionary<string, Type> Endpoints { get; private set; }

        internal Dictionary<string, IConnector> EndpointInstances { get; private set; }

        #endregion

        #region Events

        #region IManager Events

        public event EventHandler<StateChangedEventArgs> StateChanged;

        #endregion

        #endregion

        #region Constructors

        private ConnectorManager(IPluginManager pluginManager, IProgramManager programManager)
        {
            manager = programManager;
            this.pluginManager = pluginManager;
        }

        public static ConnectorManager Instance(IPluginManager pluginManager, IProgramManager programManager)
        {
            if (instance == null)
                instance = new ConnectorManager(pluginManager, programManager);

            return instance;
        }

        #endregion

        #region Instance Methods

        #region IManager Implementation

        public Result Start()
        {
            Result retVal = new Result();
            Configure();

            State = State.Starting;

            // register endpoints
            Result<Dictionary<string, Type>> registerResult = RegisterEndpoints();

            if (registerResult.ResultCode != ResultCode.Failure)
            {
                Endpoints = registerResult.ReturnValue;
                registerResult.LogResult(logger.Info, "RegisterEndpoints");
                logger.Info(Endpoints.Count + " Endpoints(s) registered.");

                if (registerResult.ResultCode == ResultCode.Warning)
                    registerResult.LogAllMessages(logger.Warn, "Warn", "The following warnings were generated during the registration:");
            }
            else
                throw new Exception("Failed to register Endpoints: " + registerResult.LastErrorMessage());

            foreach (ConnectorInstance i in Configuration.Instances)
            {
                logger.Info("Instance: " + i.Name);
            }

            if (retVal.ResultCode != ResultCode.Failure)
                State = State.Running;
            else
                State = State.Faulted;

            return retVal;
        }

        public Result Restart(StopType stopType = StopType.Normal)
        {
            return Start().Incorporate(Stop(stopType));
        }

        public Result Stop(StopType stopType = StopType.Normal)
        {
            State = State.Stopped;
            return new Result();
        }

        #endregion

        public Result Configure()
        {
            Result retVal = new Result();

            Result<ConnectorManagerConfiguration> fetchResult = manager.GetManager<ConfigurationManager>().GetInstanceConfiguration<ConnectorManagerConfiguration>(this.GetType());

            // if the fetch succeeded, configure this instance with the result.  
            if (fetchResult.ResultCode != ResultCode.Failure)
                Configure(fetchResult.ReturnValue);
            // if the fetch failed, add a new default instance to the configuration and try again.
            else
            {
                Result<ConnectorManagerConfiguration> createResult = manager.GetManager<ConfigurationManager>().AddInstanceConfiguration<ConnectorManagerConfiguration>(this.GetType(), GetDefaultConfiguration());
                if (createResult.ResultCode != ResultCode.Failure)
                    Configure(createResult.ReturnValue);
            }

            return Configure(manager.GetManager<ConfigurationManager>().GetInstanceConfiguration<ConnectorManagerConfiguration>(this.GetType()).ReturnValue);
        }

        public Result Configure(ConnectorManagerConfiguration configuration)
        {
            Configuration = configuration;
            return new Result();
        }

        public Result SaveConfiguration()
        {
            return manager.GetManager<ConfigurationManager>().UpdateInstanceConfiguration(this.GetType(), Configuration);
        }

        public static ConfigurationDefinition GetConfigurationDefinition()
        {
            ConfigurationDefinition retVal = new ConfigurationDefinition();
            retVal.Form = "[\"name\",\"email\",{\"key\":\"comment\",\"type\":\"textarea\",\"placeholder\":\"Make a comment\"},{\"type\":\"submit\",\"style\":\"btn-info\",\"title\":\"OK\"}]";
            retVal.Schema = "{\"type\":\"object\",\"title\":\"Comment\",\"properties\":{\"name\":{\"title\":\"Name\",\"type\":\"string\"},\"email\":{\"title\":\"Email\",\"type\":\"string\",\"pattern\":\"^\\\\S+@\\\\S+$\",\"description\":\"Email will be used for evil.\"},\"comment\":{\"title\":\"Comment\",\"type\":\"string\",\"maxLength\":20,\"validationMessage\":\"Don\'t be greedy!\"}},\"required\":[\"name\",\"email\",\"comment\"]}";
            retVal.Model = typeof(ConnectorManagerConfiguration);
            return retVal;
        }

        public static ConnectorManagerConfiguration GetDefaultConfiguration()
        {
            ConnectorManagerConfiguration retVal = new ConnectorManagerConfiguration();
            retVal.Instances = new List<ConnectorInstance>();
            retVal.Instances.Add(new ConnectorInstance());
            return retVal;
        }

        private Result<Dictionary<string, Type>> RegisterEndpoints()
        {
            logger.Info("Registering Endpoint types...");
            Result<Dictionary<string, Type>> retVal = new Result<Dictionary<string, Type>>();
            retVal.ReturnValue = new Dictionary<string, Type>();

            try
            {

            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while registering Endpoint types: " + ex);
            }

            return retVal;
        }



        #endregion
    }

    public class ConnectorManagerConfiguration
    {
        public List<ConnectorInstance> Instances { get; set; }

        public ConnectorManagerConfiguration()
        {
            Instances = new List<ConnectorInstance>();
        }
    }

    public class ConnectorInstance
    {
        public string Name { get; set; }
        public Type EndpointType { get; set; }
    }
}
