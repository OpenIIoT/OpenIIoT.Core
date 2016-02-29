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
using Symbiote.Core.Communication.Services.Web;
using Symbiote.Core.Communication.Services.IoT.MQTT;

namespace Symbiote.Core.Communication.Services
{
    public class ServiceManager : IManager
    {
        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static ServiceManager instance;

        internal List<IService> Services { get; private set; }

        private ServiceManager(ProgramManager manager)
        {
            this.manager = manager;

            Services = new List<IService>();

            Services.Add(WebService.Instance(manager));
            Services.Add(MQTTBroker.Instance(manager));
        }

        public static ServiceManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new ServiceManager(manager);

            return instance;
        }

        public OperationResult Start()
        {
            OperationResult retVal = new OperationResult();

            logger.Info("Starting services...");
            foreach (IService service in Services)
            {
                logger.Debug("Starting service '" + service.GetType().Name + "'...");
                try
                {
                    OperationResult result = service.Start();
                    if (result.ResultCode == OperationResultCode.Failure)
                        retVal.AddWarning("Failed to start service '" + service.GetType().Name + "'.");

                    if (!service.IsRunning)
                        retVal.AddWarning("The '" + service.GetType().Name + "' service started successfully then immediately stopped.");
                }
                catch (Exception ex)
                {
                    retVal.AddError("Error starting service '" + service.GetType().Name + "': " + ex.Message);
                }
                logger.Debug("Successfully started service '" + service.GetType().Name + "'.");
            }

            retVal.LogResult(logger);
            return retVal;
        }
    }
}
