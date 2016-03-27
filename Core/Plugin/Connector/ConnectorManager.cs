using System;
using System.Collections.Generic;
using NLog;
using Symbiote.Core.Configuration;
using Symbiote.Core.Plugin;

namespace Symbiote.Core.Plugin.Connector
{
    public class ConnectorManager : IManager, IConfigurable<ConnectorManagerConfiguration>
    {
        #region Variables

        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static ConnectorManager instance;

        #endregion

        #region Properties

        public bool Running { get; private set; }

        public ConfigurationDefinition ConfigurationDefinition { get { return GetConfigurationDefinition(); } }

        public ConnectorManagerConfiguration Configuration { get; private set; }

        internal Dictionary<string, Type> Endpoints { get; private set; }

        internal Dictionary<string, IConnector> EndpointInstances { get; private set; }

        #endregion

        #region Constructors

        private ConnectorManager(ProgramManager manager)
        {
            this.manager = manager;
        }

        public static ConnectorManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new ConnectorManager(manager);

            return instance;
        }

        #endregion

        #region Instance Methods

        #region IManager Implementation

        public OperationResult Start()
        {
            OperationResult retVal = new OperationResult();
            Configure();

            // register endpoints
            OperationResult<Dictionary<string, Type>> registerResult = RegisterEndpoints();

            if (registerResult.ResultCode != OperationResultCode.Failure)
            {
                Endpoints = registerResult.Result;
                registerResult.LogResult(logger, "RegisterEndpoints");
                logger.Info(Endpoints.Count + " Endpoints(s) registered.");

                if (registerResult.ResultCode == OperationResultCode.Warning)
                    registerResult.LogAllMessages(logger, "Warn", "The following warnings were generated during the registration:");
            }
            else
                throw new Exception("Failed to register Endpoints: " + registerResult.GetLastError());

            foreach (ConnectorInstance i in Configuration.Instances)
            {
                logger.Info("Instance: " + i.Name);
            }

            Running = (retVal.ResultCode != OperationResultCode.Failure);
            return retVal;
        }

        public OperationResult Restart()
        {
            return new OperationResult();
        }

        public OperationResult Stop()
        {
            Running = false;
            return new OperationResult();
        }

        #endregion

        public OperationResult Configure()
        {
            OperationResult retVal = new OperationResult();

            OperationResult<ConnectorManagerConfiguration> fetchResult = manager.ConfigurationManager.GetInstanceConfiguration<ConnectorManagerConfiguration>(this.GetType());

            // if the fetch succeeded, configure this instance with the result.  
            if (fetchResult.ResultCode != OperationResultCode.Failure)
                Configure(fetchResult.Result);
            // if the fetch failed, add a new default instance to the configuration and try again.
            else
            {
                OperationResult<ConnectorManagerConfiguration> createResult = manager.ConfigurationManager.AddInstanceConfiguration<ConnectorManagerConfiguration>(this.GetType(), GetDefaultConfiguration());
                if (createResult.ResultCode != OperationResultCode.Failure)
                    Configure(createResult.Result);
            }

            return Configure(manager.ConfigurationManager.GetInstanceConfiguration<ConnectorManagerConfiguration>(this.GetType()).Result);
        }

        public OperationResult Configure(ConnectorManagerConfiguration configuration)
        {
            Configuration = configuration;
            return new OperationResult();
        }

        public OperationResult SaveConfiguration()
        {
            return manager.ConfigurationManager.UpdateInstanceConfiguration(this.GetType(), Configuration);
        }

        public static ConfigurationDefinition GetConfigurationDefinition()
        {
            ConfigurationDefinition retVal = new ConfigurationDefinition();
            retVal.SetForm("[\"name\",\"email\",{\"key\":\"comment\",\"type\":\"textarea\",\"placeholder\":\"Make a comment\"},{\"type\":\"submit\",\"style\":\"btn-info\",\"title\":\"OK\"}]");
            retVal.SetSchema("{\"type\":\"object\",\"title\":\"Comment\",\"properties\":{\"name\":{\"title\":\"Name\",\"type\":\"string\"},\"email\":{\"title\":\"Email\",\"type\":\"string\",\"pattern\":\"^\\\\S+@\\\\S+$\",\"description\":\"Email will be used for evil.\"},\"comment\":{\"title\":\"Comment\",\"type\":\"string\",\"maxLength\":20,\"validationMessage\":\"Don\'t be greedy!\"}},\"required\":[\"name\",\"email\",\"comment\"]}");
            retVal.SetModel(typeof(ConnectorManagerConfiguration));
            return retVal;
        }

        public static ConnectorManagerConfiguration GetDefaultConfiguration()
        {
            ConnectorManagerConfiguration retVal = new ConnectorManagerConfiguration();
            retVal.Instances = new List<ConnectorInstance>();
            retVal.Instances.Add(new ConnectorInstance());
            return retVal;
        }

        private OperationResult<Dictionary<string, Type>> RegisterEndpoints()
        {
            logger.Info("Registering Endpoint types...");
            OperationResult<Dictionary<string, Type>> retVal = new OperationResult<Dictionary<string, Type>>();
            retVal.Result = new Dictionary<string, Type>();

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
