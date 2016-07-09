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

        public State State { get; private set; }

        public Dictionary<string, IService> Services { get; private set; }
        public Dictionary<string, Type> ServiceTypes { get; private set; }

        #endregion

        #region Events

        #region IManager Events

        public event EventHandler<StateChangedEventArgs> StateChanged;

        #endregion

        #endregion

        #region Constructors

        private ServiceManager(ProgramManager manager)
        {
            this.manager = manager;
            Services = new Dictionary<string, IService>();
        }

        private static ServiceManager Instantiate(ProgramManager manager)
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
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Start()
        {
            logger.Debug("Starting services...");
            Result retVal = new Result();

            State = State.Starting;

            Result<Dictionary<string, Type>> registerResult = RegisterServices();
            if (registerResult.ResultCode != ResultCode.Failure)
            {
                ServiceTypes = registerResult.ReturnValue;
                Result<Dictionary<string, IService>> instantiateResult = InstantiateServices();
                if (instantiateResult.ResultCode != ResultCode.Failure)
                {
                    Services = instantiateResult.ReturnValue;
                    retVal = StartServices();
                }
                else
                    retVal.AddError("Failed to instantiate Services. " + retVal.LastErrorMessage());
            }
            else
                retVal.AddError("Failed to register Service types. " + retVal.LastErrorMessage());

            if (retVal.ResultCode != ResultCode.Failure)
                State = State.Running;
            else
                State = State.Faulted;

            return retVal;
        }

        public Result Restart(StopType stopType = StopType.Normal)
        {
            logger.Info("Restarting services...");
            Result retVal = new Result();

            retVal.Incorporate(Stop(stopType));
            retVal.Incorporate(Start());

            retVal.LogResult(logger);
            return retVal;
        }

        public Result Stop(StopType stopType = StopType.Normal)
        {
            logger.Info("Stopping services...");
            Result retVal = new Result();

            State = State.Stopping;

            if (retVal.ResultCode != ResultCode.Failure)
                State = State.Stopped;
            else
                State = State.Faulted;

            retVal.LogResult(logger);
            return retVal;
        }

        #endregion

        private Result<Dictionary<string, Type>> RegisterServices()
        {
            logger.Debug("Registering Service types...");
            Result<Dictionary<string, Type>> retVal = RegisterServices(manager.GetManager<ConfigurationManager>());
            retVal.LogResult(logger.Debug);
            return retVal;
        }

        private Result<Dictionary<string, Type>> RegisterServices(ConfigurationManager configurationManager)
        {
            logger.Trace("Registering Service types...");
            Result<Dictionary<string, Type>> retVal = new Result<Dictionary<string, Type>>();
            retVal.ReturnValue = new Dictionary<string, Type>();

            try
            {
                logger.Trace("Registering Web Services...");
                retVal.ReturnValue.Add("Web Services", typeof(Web.WebService));
                configurationManager.RegisterType(typeof(Web.WebService));

                logger.Trace("Registering MQTT Broker...");
                retVal.ReturnValue.Add("MQTT Broker", typeof(IoT.MQTT.MQTTBroker));
                configurationManager.RegisterType(typeof(Web.WebService));
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while registering Service types: " + ex);
            }

            return retVal;
        }

        private Result<Dictionary<string, IService>> InstantiateServices()
        {
            logger.Debug("Instantiating Services...");
            Result<Dictionary<string, IService>> retVal = InstantiateServices(ServiceTypes);
            retVal.LogResult(logger.Debug);
            return retVal;
        }

        private Result<Dictionary<string, IService>> InstantiateServices(Dictionary<string, Type> serviceTypes)
        {
            logger.Debug("Instantiating services...");
            Result<Dictionary<string, IService>> retVal = new Result<Dictionary<string, IService>>();
            retVal.ReturnValue = new Dictionary<string, IService>();

            try
            {
                foreach (string serviceType in serviceTypes.Keys)
                {
                    logger.Trace("Instantiating service '" + serviceType + "'...");
                    IService serviceInstance = (IService)serviceTypes[serviceType].GetMethod("Instance").Invoke(null, new object[] { manager });

                    if (serviceInstance != default(IService))
                        retVal.ReturnValue.Add(serviceType, serviceInstance);
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

        private Result StartServices()
        {
            logger.Debug("Starting Services...");
            Result retVal = StartServices(Services);
            retVal.LogResult(logger.Debug);
            return retVal;
        }

        private Result StartServices(Dictionary<string, IService> serviceInstances)
        {
            logger.Trace("Starting services...");
            Result retVal = new Result();

            // iterate over the list of registered services and try to start each one
            foreach (string serviceName in serviceInstances.Keys)
            {
                logger.Info("Starting service '" + serviceName + "'...");

                try
                {
                    IService service = serviceInstances[serviceName];
                    Result startResult = service.Start();

                    if (startResult.ResultCode == ResultCode.Failure)
                        retVal.AddWarning("Failed to start service '" + serviceName + "'.");
                    else
                    {
                        logger.Info("Started service '" + serviceName + "'.");

                        if (startResult.ResultCode == ResultCode.Warning)
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
