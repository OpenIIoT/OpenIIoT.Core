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

namespace Symbiote.Core.Service
{
    public class ServiceManager : IManager
    {
        #region Variables

        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static ServiceManager instance;

        #endregion

        #region Properties

        public ManagerState State { get; private set; }
        public Dictionary<string, IService> Services { get; private set; }
        public Dictionary<string, Type> ServiceTypes { get; private set; }

        #endregion

        #region Constructors

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

        #endregion Constructors

        #region Instance Methods

        #region IManager Implementation

        /// <summary>
        /// Starts the Service Manager and all services.
        /// </summary>
        /// <remarks>Don't forget that you tried to do this with reflection once and it ended badly.  Just copy/paste.</remarks>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Start()
        {
            logger.Debug("Starting services...");
            OperationResult retVal = new OperationResult();

            State = ManagerState.Starting;

            OperationResult<Dictionary<string, Type>> registerResult = RegisterServices();
            if (registerResult.ResultCode != OperationResultCode.Failure)
            {
                ServiceTypes = registerResult.Result;
                OperationResult<Dictionary<string, IService>> instantiateResult = InstantiateServices();
                if (instantiateResult.ResultCode != OperationResultCode.Failure)
                {
                    Services = instantiateResult.Result;
                    retVal = StartServices();
                }
                else
                    retVal.AddError("Failed to instantiate Services. " + retVal.LastErrorMessage());
            }
            else
                retVal.AddError("Failed to register Service types. " + retVal.LastErrorMessage());

            if (retVal.ResultCode != OperationResultCode.Failure)
                State = ManagerState.Running;
            else
                State = ManagerState.Faulted;

            return retVal;
        }

        public OperationResult Restart()
        {
            logger.Info("Restarting services...");
            OperationResult retVal = new OperationResult();

            retVal.Incorporate(Stop());
            retVal.Incorporate(Start());

            retVal.LogResult(logger);
            return retVal;
        }

        public OperationResult Stop()
        {
            logger.Info("Stopping services...");
            OperationResult retVal = new OperationResult();

            State = ManagerState.Stopping;

            if (retVal.ResultCode != OperationResultCode.Failure)
                State = ManagerState.Stopped;
            else
                State = ManagerState.Faulted;

            retVal.LogResult(logger);
            return retVal;
        }

        #endregion

        private OperationResult<Dictionary<string, Type>> RegisterServices()
        {
            logger.Debug("Registering Service types...");
            OperationResult<Dictionary<string, Type>> retVal = RegisterServices(manager.ConfigurationManager);
            retVal.LogResult(logger.Debug);
            return retVal;
        }

        private OperationResult<Dictionary<string, Type>> RegisterServices(ConfigurationManager configurationManager)
        {
            logger.Trace("Registering Service types...");
            OperationResult<Dictionary<string, Type>> retVal = new OperationResult<Dictionary<string, Type>>();
            retVal.Result = new Dictionary<string, Type>();

            try
            {
                logger.Trace("Registering Web Services...");
                retVal.Result.Add("Web Services", typeof(Web.WebService));
                configurationManager.RegisterType(typeof(Web.WebService));

                logger.Trace("Registering MQTT Broker...");
                retVal.Result.Add("MQTT Broker", typeof(IoT.MQTT.MQTTBroker));
                configurationManager.RegisterType(typeof(Web.WebService));
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while registering Service types: " + ex);
            }

            return retVal;
        }

        private OperationResult<Dictionary<string, IService>> InstantiateServices()
        {
            logger.Debug("Instantiating Services...");
            OperationResult<Dictionary<string, IService>> retVal = InstantiateServices(ServiceTypes);
            retVal.LogResult(logger.Debug);
            return retVal;
        }

        private OperationResult<Dictionary<string, IService>> InstantiateServices(Dictionary<string, Type> serviceTypes)
        {
            logger.Debug("Instantiating services...");
            OperationResult<Dictionary<string, IService>> retVal = new OperationResult<Dictionary<string, IService>>();
            retVal.Result = new Dictionary<string, IService>();

            try
            {
                foreach (string serviceType in serviceTypes.Keys)
                {
                    logger.Trace("Instantiating service '" + serviceType + "'...");
                    IService serviceInstance = (IService)serviceTypes[serviceType].GetMethod("Instance").Invoke(null, new object[] { manager });

                    if (serviceInstance != default(IService))
                        retVal.Result.Add(serviceType, serviceInstance);
                    else
                        retVal.AddWarning("Unable to instantiate service '" + serviceType + "'.");

                }
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while instantiating Service types: " + ex);
            }

            return retVal;
        }

        private OperationResult StartServices()
        {
            logger.Debug("Starting Services...");
            OperationResult retVal = StartServices(Services);
            retVal.LogResult(logger.Debug);
            return retVal;
        }

        private OperationResult StartServices(Dictionary<string, IService> serviceInstances)
        {
            logger.Trace("Starting services...");
            OperationResult retVal = new OperationResult();

            // iterate over the list of registered services and try to start each one
            foreach (string serviceName in serviceInstances.Keys)
            {
                logger.Info("Starting service '" + serviceName + "'...");

                try
                {
                    IService service = serviceInstances[serviceName];
                    OperationResult startResult = service.Start();

                    if (startResult.ResultCode == OperationResultCode.Failure)
                        retVal.AddWarning("Failed to start service '" + serviceName + "'.");
                    else
                    {
                        logger.Info("Started service '" + serviceName + "'.");

                        if (startResult.ResultCode == OperationResultCode.Warning)
                            startResult.LogAllMessages(logger.Debug, "The following warnings were generated when starting '" + serviceName + "':");
                    }
                    if (!service.IsRunning)
                        retVal.AddWarning("The '" + serviceName + "' service started successfully and then immediately stopped.");
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception thrown while starting services: " + ex);
                }
            }
            return retVal;
        }

        #endregion
    }
}
