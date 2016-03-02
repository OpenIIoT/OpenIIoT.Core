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
    public class EndpointManager : IManager, IConfigurable
    {
        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static EndpointManager instance;

        public ObjectConfiguration Configuration { get; private set; }

        internal Dictionary<string, Type> EndpointTypes { get; private set; }

        internal Dictionary<string, IEndpoint> Endpoints { get; private set; }

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

        private OperationResult<Dictionary<string, Type>> RegisterEndpoints()
        {
            logger.Info("Registering Endpoint types...");
            OperationResult<Dictionary<string, Type>> retVal = new OperationResult<Dictionary<string, Type>>();
            retVal.Result = new Dictionary<string, Type>();

            try
            {
                retVal.Result.Add("Json Web Service", typeof(Web.JsonEndpoint));
                retVal.Result.Add("XML Web Service", typeof(Web.XMLEndpoint));
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
                EndpointTypes = registerResult.Result;
                registerResult.LogResult(logger, "Info", "Warn", "Error", "RegisterEndpoints");
                logger.Info(EndpointTypes.Count + " Endpoints(s) registered.");

                if (registerResult.ResultCode == OperationResultCode.Warning)
                    registerResult.LogAllMessages(logger, "Warn", "The following warnings were generated during the registration:");
            }
            else
                throw new Exception("Failed to register Endpoints: " + registerResult.GetLastError());

            // test -- create new config
            EndpointInstance i1 = new EndpointInstance();
            i1.Name = "Test";
            i1.EndpointType = typeof(Web.JsonEndpoint);
            i1.Configuration = "hello world1";

            EndpointInstance i2 = new EndpointInstance();
            i2.Name = "Test2";
            i2.EndpointType = typeof(Web.XMLEndpoint);
            i2.Configuration = "hello world2";


            var emc = new EndpointManagerConfiguration();
            emc.EndpointInstances.Add(i1);
            emc.EndpointInstances.Add(i2);

            
            
            // fetch configuration
            Configuration = new ObjectConfiguration();
            Configuration.Define(new ConfigurationDefinition());
            Configuration.Configure(emc.EndpointInstances);
            Configuration.LoadConfiguration();
            Configuration.SaveConfiguration();


            // create endpoint instances
            // tbd

            return new OperationResult();
        }
    }
}
