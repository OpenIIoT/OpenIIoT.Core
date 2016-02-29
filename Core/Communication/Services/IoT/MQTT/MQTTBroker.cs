using NLog;
using Symbiote.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Communication.Services.IoT.MQTT
{
    public class MQTTBroker : IService
    {
        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static MQTTBroker instance;
        private static bool running;

        public ObjectConfiguration Configuration { get; private set; }
        public bool IsRunning { get { return running; } }

        private MQTTBroker(ProgramManager manager)
        {
            this.manager = manager;
            running = false;
        }

        public static MQTTBroker Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new MQTTBroker(manager);

            return instance;
        }

        public OperationResult Start()
        {
            logger.Info("Starting MQTT Broker...");
            running = false;
            logger.Info("The MQTT Broker was started successfully.");
            return new OperationResult();
        }

        public OperationResult Stop()
        {
            logger.Info("Stopping MQTT Broker...");

            running = false;
            return new OperationResult();
        }
    }
}
