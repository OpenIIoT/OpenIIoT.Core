using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Symbiote.Core.Configuration
{
    public class ObjectConfiguration
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        public ConfigurationDefinition Definition { get; private set; }
        public string ConfigurationJson { get; private set; }
        public object ConfigurationObject { get; private set; }
        public bool IsDefined { get; private set; }
        public bool IsConfigured { get; private set; }

        public ObjectConfiguration(ConfigurationDefinition definition = default(ConfigurationDefinition))
        {
            IsDefined = false;
            IsConfigured = false;

            if (definition != default(ConfigurationDefinition))
                Define(definition);
        }

        public ObjectConfiguration Define(ConfigurationDefinition definition)
        {
            Definition = definition;
            IsDefined = true;
            return this;
        }

        public OperationResult Configure(string configurationJson)
        {
            ConfigurationJson = configurationJson;
            object deserializedConfiguration = JsonConvert.DeserializeObject(configurationJson);
            return Configure(deserializedConfiguration);
        }

        public OperationResult Configure(object configuration)
        {
            ConfigurationObject = configuration;
            IsConfigured = true;
            return new OperationResult();
        }

        public OperationResult<ObjectConfiguration> LoadConfiguration([CallerMemberName]string caller = "")
        {
            OperationResult<ObjectConfiguration> retVal = new OperationResult<ObjectConfiguration>();

            // todo: load config from ConfigurationManager
            logger.Info("This is where we would read the json from the file");
            return retVal;

        }

        public OperationResult SaveConfiguration()
        {
            return SaveConfiguration(ConfigurationObject);
        }

        public OperationResult SaveConfiguration(object configuration)
        {
            logger.Info("config: " + JsonConvert.SerializeObject(configuration, Formatting.Indented));
            return new OperationResult();
        }
    }
}
