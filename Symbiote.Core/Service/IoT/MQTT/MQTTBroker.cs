using NLog;
using Symbiote.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Service.IoT.MQTT
{
    public class MQTTBroker : IService, IConfigurable<MQTTBrokerConfiguration>
    {
        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static MQTTBroker instance;
        private static bool running;

        public ConfigurationDefinition ConfigurationDefinition { get { return GetConfigurationDefinition(); } }
        public MQTTBrokerConfiguration Configuration { get; private set; }
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

        public Result Configure()
        {
            Result retVal = new Result();

            Result<MQTTBrokerConfiguration> fetchResult = manager.ConfigurationManager.GetInstanceConfiguration<MQTTBrokerConfiguration>(this.GetType());

            // if the fetch succeeded, configure this instance with the result.  
            if (fetchResult.ResultCode != ResultCode.Failure)
                Configure(fetchResult.ReturnValue);
            // if the fetch failed, add a new default instance to the configuration and try again.
            else
            {
                Result<MQTTBrokerConfiguration> createResult = manager.ConfigurationManager.AddInstanceConfiguration<MQTTBrokerConfiguration>(this.GetType(), GetDefaultConfiguration());
                if (createResult.ResultCode != ResultCode.Failure)
                    Configure(createResult.ReturnValue);
            }

            return Configure(manager.ConfigurationManager.GetInstanceConfiguration<MQTTBrokerConfiguration>(this.GetType()).ReturnValue);
        }

        public Result Configure(MQTTBrokerConfiguration configuration)
        {
            Configuration = configuration;
            return new Result();
        }

        public Result SaveConfiguration()
        {
            return manager.ConfigurationManager.UpdateInstanceConfiguration(this.GetType(), Configuration);
        }

        public static ConfigurationDefinition GetConfigurationDefinition()
        {
            ConfigurationDefinition retVal = new ConfigurationDefinition();
            retVal.Form = "[\"name\",\"email\",{\"key\":\"comment\",\"type\":\"textarea\",\"placeholder\":\"Make a comment\"},{\"type\":\"submit\",\"style\":\"btn-info\",\"title\":\"OK\"}]";
            retVal.Schema = "{\"type\":\"object\",\"title\":\"Comment\",\"properties\":{\"name\":{\"title\":\"Name\",\"type\":\"string\"},\"email\":{\"title\":\"Email\",\"type\":\"string\",\"pattern\":\"^\\\\S+@\\\\S+$\",\"description\":\"Email will be used for evil.\"},\"comment\":{\"title\":\"Comment\",\"type\":\"string\",\"maxLength\":20,\"validationMessage\":\"Don\'t be greedy!\"}},\"required\":[\"name\",\"email\",\"comment\"]}";
            retVal.Model = typeof(MQTTBrokerConfiguration);
            return retVal;
        }

        public static MQTTBrokerConfiguration GetDefaultConfiguration()
        {
            MQTTBrokerConfiguration retVal = new MQTTBrokerConfiguration();
            retVal.Name = "";
            return retVal;
        }

        public Result Start()
        {
            logger.Info("Starting MQTT Broker...");
            Configure();

            running = false;
            logger.Info("The MQTT Broker was started successfully.");
            return new Result();
        }

        public Result Stop()
        {
            logger.Info("Stopping MQTT Broker...");
            Configure();

            running = false;
            return new Result();
        }
    }

    public class MQTTBrokerConfiguration
    {
        public string Name { get; set; }
    }
}
