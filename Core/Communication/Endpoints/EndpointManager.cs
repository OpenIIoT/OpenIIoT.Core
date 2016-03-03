using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Microsoft.Owin.Hosting;
using Microsoft.AspNet.SignalR;
using System.Web.Http;
using Newtonsoft.Json;
using Symbiote.Core.Configuration;
using Symbiote.Core.Communication.Endpoints;

namespace Symbiote.Core.Communication.Endpoints
{
    public class EndpointManager : IManager, IConfigurable<EndpointManagerConfiguration>
    {
        #region Variables

        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static EndpointManager instance;

        #endregion

        #region Properties

        public ConfigurationDefinition ConfigurationDefinition { get; private set; }

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

        public OperationResult Configure(EndpointManagerConfiguration configuration)
        {
            Configuration = configuration;
            return new OperationResult();
        }

        public static ConfigurationDefinition GetConfigurationDefinition()
        {
            ConfigurationDefinition retVal = new ConfigurationDefinition();
            retVal.SetForm("[\"name\",\"email\",{\"key\":\"comment\",\"type\":\"textarea\",\"placeholder\":\"Make a comment\"},{\"type\":\"submit\",\"style\":\"btn-info\",\"title\":\"OK\"}]");
            retVal.SetSchema("{\"type\":\"object\",\"title\":\"Comment\",\"properties\":{\"name\":{\"title\":\"Name\",\"type\":\"string\"},\"email\":{\"title\":\"Email\",\"type\":\"string\",\"pattern\":\"^\\\\S+@\\\\S+$\",\"description\":\"Email will be used for evil.\"},\"comment\":{\"title\":\"Comment\",\"type\":\"string\",\"maxLength\":20,\"validationMessage\":\"Don\'t be greedy!\"}},\"required\":[\"name\",\"email\",\"comment\"]}");
            retVal.SetModel(typeof(EndpointManagerConfiguration));
            return retVal;
        }

        private OperationResult<Dictionary<string, Type>> RegisterEndpoints()
        {
            logger.Info("Registering Endpoint types...");
            OperationResult<Dictionary<string, Type>> retVal = new OperationResult<Dictionary<string, Type>>();
            retVal.Result = new Dictionary<string, Type>();

            try
            {
                // register types.  both lines are required for each type. 
                retVal.Result.Add("Example Endpoint", typeof(Web.ExampleEndpoint));
                manager.ConfigurationManager.RegisterType(typeof(Web.ExampleEndpoint), Web.ExampleEndpoint.GetConfigurationDefinition());
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while registering Endpoint types: " + ex);
            }

            return retVal;
        }

        public OperationResult Start()
        {
            // register endpoints
            OperationResult<Dictionary<string, Type>> registerResult = RegisterEndpoints();

            if (registerResult.ResultCode != OperationResultCode.Failure)
            {
                Endpoints = registerResult.Result;
                registerResult.LogResult(logger, "Info", "Warn", "Error", "RegisterEndpoints");
                logger.Info(Endpoints.Count + " Endpoints(s) registered.");

                if (registerResult.ResultCode == OperationResultCode.Warning)
                    registerResult.LogAllMessages(logger, "Warn", "The following warnings were generated during the registration:");
            }
            else
                throw new Exception("Failed to register Endpoints: " + registerResult.GetLastError());

            // test -- create new config
            EndpointInstance i1 = new EndpointInstance();
            i1.Name = "Test";
            i1.EndpointType = typeof(Web.ExampleEndpoint);
            i1.Configuration = "hello world1";

            EndpointInstance i2 = new EndpointInstance();
            i2.Name = "Test2";
            i2.EndpointType = typeof(Web.ExampleEndpoint);
            i2.Configuration = "hello world2";


            var emc = new EndpointManagerConfiguration();
            emc.Instances.Add(i1);
            emc.Instances.Add(i2);

            logger.Info(JsonConvert.SerializeObject(emc));

            Configure(manager.ConfigurationManager.GetConfiguration<EndpointManagerConfiguration>(this.GetType()).Result);

            foreach (EndpointInstance i in Configuration.Instances)
            {
                logger.Info("Instance: " + i.Name);
            }
            
            // fetch configuration


            // create endpoint instances
            // tbd

            return new OperationResult();
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
        public object Configuration { get; set; }
    }
}
