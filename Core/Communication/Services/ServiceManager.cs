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
using Symbiote.Core.Communication.Services;

namespace Symbiote.Core.Communication.Services
{
    public class ServiceManager : IManager, IConfigurable
    {
        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static ServiceManager instance;

        public ObjectConfiguration Configuration { get; private set; }

        internal Dictionary<string, IService> Services { get; private set; }

        private ServiceManager(ProgramManager manager)
        {
            this.manager = manager;

            Services = new Dictionary<string, IService>();
        }

        public static ServiceManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new ServiceManager(manager);

            return instance;
        }

        private OperationResult<Dictionary<string, IService>> RegisterServices()
        {
            logger.Info("Registering services...");
            OperationResult<Dictionary<string, IService>> retVal = new OperationResult<Dictionary<string, IService>>();
            retVal.Result = new Dictionary<string, IService>();

            try
            {
                retVal.Result.Add("Web", Web.WebService.Instance(manager));
                retVal.Result.Add("MQTT Broker", IoT.MQTT.MQTTBroker.Instance(manager));
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while registering Endpoint types: " + ex);
            }

            return retVal;
        }

        private OperationResult StartServices(Dictionary<string, IService> services)
        {
            OperationResult retVal = new OperationResult();

            // iterate over the list of registered services and try to start each one
            foreach (string serviceName in services.Keys)
            {
                logger.Debug("Starting service '" + serviceName + "'...");

                try
                {
                    IService service = services[serviceName];
                    OperationResult startResult = service.Start();

                    if (startResult.ResultCode == OperationResultCode.Failure)
                        retVal.AddWarning("Failed to start service '" + serviceName + "'.");
                    else
                    {
                        logger.Info("Started service '" + serviceName + "'.");

                        if (startResult.ResultCode == OperationResultCode.Warning)
                            startResult.LogAllMessages(logger, "Warn", "The following warnings were generated when starting '" + serviceName + "':");
                    }
                    if (!service.IsRunning)
                        retVal.AddWarning("The '" + serviceName + "' service started successfully and then immediately stopped.");
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception thrown while starting services: " + ex);
                }
            }
            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Starts the Service Manager and all services.
        /// </summary>
        /// <remarks>Any failure to start the manager should throw an Exception.</remarks>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Start()
        {
            // register services
            OperationResult<Dictionary<string, IService>> registerResult = RegisterServices();

            if (registerResult.ResultCode != OperationResultCode.Failure)
            {
                Services = registerResult.Result;
                registerResult.LogResult(logger, "Info", "Warn", "Error", "RegisterServices");
                logger.Info(Services.Count + " Service(s) registered.");

                if (registerResult.ResultCode == OperationResultCode.Warning)
                    registerResult.LogAllMessages(logger, "Warn", "The following warnings were generated during the registration:");
            }
            else
                throw new Exception("Failed to register Services: " + registerResult.GetLastError());

            // start registered services
            logger.Info("Starting services...");
            return StartServices(Services);
        }
    }
}
