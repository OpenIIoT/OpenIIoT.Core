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
    public class ServiceManager : IManager, IConfigurable<ServiceManagerConfiguration>
    {
        #region Variables

        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static ServiceManager instance;

        #endregion

        #region Properties

        public ConfigurationDefinition ConfigurationDefinition { get { return GetConfigurationDefinition(); } }

        public ServiceManagerConfiguration Configuration { get; private set; }

        public Dictionary<string, IService> Services { get; private set; }

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

        public OperationResult Configure()
        {
            return Configure(manager.ConfigurationManager.GetConfiguration<ServiceManagerConfiguration>(this.GetType()).Result);
        }

        public OperationResult Configure(ServiceManagerConfiguration configuration)
        {
            Configuration = configuration;
            return new OperationResult();
        }

        public static ConfigurationDefinition GetConfigurationDefinition()
        {
            ConfigurationDefinition retVal = new ConfigurationDefinition();
            retVal.SetForm("[\"name\",\"email\",{\"key\":\"comment\",\"type\":\"textarea\",\"placeholder\":\"Make a comment\"},{\"type\":\"submit\",\"style\":\"btn-info\",\"title\":\"OK\"}]");
            retVal.SetSchema("{\"type\":\"object\",\"title\":\"Comment\",\"properties\":{\"name\":{\"title\":\"Name\",\"type\":\"string\"},\"email\":{\"title\":\"Email\",\"type\":\"string\",\"pattern\":\"^\\\\S+@\\\\S+$\",\"description\":\"Email will be used for evil.\"},\"comment\":{\"title\":\"Comment\",\"type\":\"string\",\"maxLength\":20,\"validationMessage\":\"Don\'t be greedy!\"}},\"required\":[\"name\",\"email\",\"comment\"]}");
            retVal.SetModel(typeof(ServiceManagerConfiguration));
            return retVal;
        }

        public static ServiceManagerConfiguration GetDefaultConfiguration()
        {
            ServiceManagerConfiguration retVal = new ServiceManagerConfiguration();
            retVal.Instances = new List<ServiceInstance>();
            return retVal;
        }

        /// <summary>
        /// Starts the Service Manager and all services.
        /// </summary>
        /// <remarks>Don't forget that you tried to do this with reflection once and it ended badly.  Just copy/paste.</remarks>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Start()
        {
            logger.Info("Starting services...");
            OperationResult retVal = new OperationResult();

            Services.Add("Web Services", Web.WebService.Instance(manager));
            manager.ConfigurationManager.RegisterType(typeof(Web.WebService));
            Services["Web Services"].Start();

            Services.Add("MQTT Broker", IoT.MQTT.MQTTBroker.Instance(manager));
            manager.ConfigurationManager.RegisterType(typeof(IoT.MQTT.MQTTBroker));
            Services["MQTT Broker"].Start();

            return retVal;
        }

        private OperationResult<Dictionary<string, Type>> RegisterServices()
        {
            logger.Info("Registering Service types...");
            OperationResult<Dictionary<string, Type>> retVal = new OperationResult<Dictionary<string, Type>>();
            retVal.Result = new Dictionary<string, Type>();

            try
            {
                retVal.Result.Add("Web Services", typeof(Web.WebService));
                manager.ConfigurationManager.RegisterType(typeof(Web.WebService));

                retVal.Result.Add("MQTT Broker", typeof(IoT.MQTT.MQTTBroker));
                manager.ConfigurationManager.RegisterType(typeof(Web.WebService));
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while registering Service types: " + ex);
            }

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

        private OperationResult StartServices(Dictionary<string, IService> serviceInstances)
        {
            OperationResult retVal = new OperationResult();

            // iterate over the list of registered services and try to start each one
            foreach (string serviceName in serviceInstances.Keys)
            {
                logger.Debug("Starting service '" + serviceName + "'...");

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

        #endregion
    }

    public class ServiceManagerConfiguration
    {
        public List<ServiceInstance> Instances { get; set; }

        public ServiceManagerConfiguration()
        {
            Instances = new List<ServiceInstance>();
        }
    }

    public class ServiceInstance
    {
        public string Name { get; set; }
        public Type ServiceType { get; set; }
    }
}
