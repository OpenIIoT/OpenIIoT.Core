using System;
using System.Collections.Generic;
using NLog;
using Symbiote.Core.Configuration;
using Symbiote.Core.Plugin;

namespace Symbiote.Core.Plugin.Endpoint
{
    public class EndpointManager : IManager, IConfigurable<EndpointManagerConfiguration>
    {
        #region Variables

        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static EndpointManager instance;

        #endregion

        #region Properties

        public bool Running { get; private set; }

        public ConfigurationDefinition ConfigurationDefinition { get { return GetConfigurationDefinition(); } }

        public EndpointManagerConfiguration Configuration { get; private set; }

        internal Dictionary<string, Type> Endpoints { get; private set; }

        internal Dictionary<string, IEndpoint> EndpointInstances { get; private set; }

        #endregion

        #region Constructors

        private EndpointManager(ProgramManager manager)
        {
            this.manager = manager;
        }

        public static EndpointManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new EndpointManager(manager);

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
                registerResult.LogResult(logger.Info, "RegisterEndpoints");
                logger.Info(Endpoints.Count + " Endpoints(s) registered.");

                if (registerResult.ResultCode == OperationResultCode.Warning)
                    registerResult.LogAllMessages(logger.Warn, "Warn", "The following warnings were generated during the registration:");
            }
            else
                throw new Exception("Failed to register Endpoints: " + registerResult.GetLastError());

            foreach (EndpointInstance i in Configuration.Instances)
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

            OperationResult<EndpointManagerConfiguration> fetchResult = manager.ConfigurationManager.GetInstanceConfiguration<EndpointManagerConfiguration>(this.GetType());

            // if the fetch succeeded, configure this instance with the result.  
            if (fetchResult.ResultCode != OperationResultCode.Failure)
                Configure(fetchResult.Result);
            // if the fetch failed, add a new default instance to the configuration and try again.
            else
            {
                OperationResult<EndpointManagerConfiguration> createResult = manager.ConfigurationManager.AddInstanceConfiguration<EndpointManagerConfiguration>(this.GetType(), GetDefaultConfiguration());
                if (createResult.ResultCode != OperationResultCode.Failure)
                    Configure(createResult.Result);
            }

            return Configure(manager.ConfigurationManager.GetInstanceConfiguration<EndpointManagerConfiguration>(this.GetType()).Result);
        }

        public OperationResult Configure(EndpointManagerConfiguration configuration)
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
            retVal.SetModel(typeof(EndpointManagerConfiguration));
            return retVal;
        }

        public static EndpointManagerConfiguration GetDefaultConfiguration()
        {
            EndpointManagerConfiguration retVal = new EndpointManagerConfiguration();
            retVal.Instances = new List<EndpointInstance>();
            retVal.Instances.Add(new EndpointInstance());
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

    public class EndpointManagerConfiguration
    {
        public List<EndpointInstance> Instances { get; set; }

        public EndpointManagerConfiguration()
        {
            Instances = new List<EndpointInstance>();
        }
    }

    public class EndpointInstance
    {
        public string Name { get; set; }
        public Type EndpointType { get; set; }
    }
}
