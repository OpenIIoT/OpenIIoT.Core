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
using OpenIIoT.Core.Configuration;
using NLog.xLogger;
using Utility.OperationResult;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Configuration;
using OpenIIoT.SDK.Common;

using OpenIIoT.SDK.Common;

namespace OpenIIoT.Core.Service
{
    public class ServiceManager : Manager, IManager
    {
        #region Variables

        new private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));
        private static ServiceManager instance;

        #endregion Variables

        #region Properties

        public Dictionary<string, IService> Services { get; private set; }
        public Dictionary<string, Type> ServiceTypes { get; private set; }

        #endregion Properties

        #region Constructors

        private ServiceManager(IApplicationManager manager, IConfigurationManager configurationManager)
        {
            base.logger = logger;
            logger.EnterMethod();

            ManagerName = "Service Manager";

            RegisterDependency<IApplicationManager>(manager);
            RegisterDependency<IConfigurationManager>(configurationManager);

            ChangeState(State.Initialized);

            Services = new Dictionary<string, IService>();
            ServiceTypes = new Dictionary<string, Type>();
        }

        public static ServiceManager Instantiate(IApplicationManager manager, IConfigurationManager configurationManager)
        {
            if (instance == null)
                instance = new ServiceManager(manager, configurationManager);

            return instance;
        }

        #endregion Constructors

        #region Instance Methods

        protected override Result Startup()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Startup for '" + GetType().Name + "'...");
            Result retVal = new Result();

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
                    retVal.AddError("Failed to instantiate Services. " + retVal.GetLastError());
            }
            else
                retVal.AddError("Failed to register Service types. " + retVal.GetLastError());

            retVal.Incorporate(registerResult);

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(guid);
            return retVal;
        }

        protected override Result Shutdown(StopType stopType = StopType.Stop)
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Shutdown for '" + GetType().Name + "'...");
            Result retVal = new Result();

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(guid);
            return retVal;
        }

        private Result<Dictionary<string, Type>> RegisterServices()
        {
            logger.Debug("Registering Service types...");
            Result<Dictionary<string, Type>> retVal = RegisterServices(Dependency<IConfigurationManager>());
            retVal.LogResult(logger.Debug);
            return retVal;
        }

        private Result<Dictionary<string, Type>> RegisterServices(IConfigurationManager configurationManager)
        {
            logger.Trace("Registering Service types...");
            Result<Dictionary<string, Type>> retVal = new Result<Dictionary<string, Type>>();
            retVal.ReturnValue = new Dictionary<string, Type>();

            try
            {
                logger.Trace("Registering Web Services...");
                retVal.ReturnValue.Add("Web Services", typeof(Web.WebService));
                configurationManager.ConfigurableTypeRegistry.RegisterType(typeof(Web.WebService));
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
                    IService serviceInstance = (IService)serviceTypes[serviceType].GetMethod("Instance").Invoke(null, new object[] { Dependency<IApplicationManager>() });

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

        #endregion Instance Methods
    }
}