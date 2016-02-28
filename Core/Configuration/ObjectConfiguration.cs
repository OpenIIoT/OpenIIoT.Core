using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Configuration
{
    public class ObjectConfiguration
    {
        public ConfigurationDefinition Definition { get; private set; }
        public string ConfigurationString { get; private set; }
        public object Configuration { get; private set; }
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

        public OperationResult Configure(string configurationString)
        {
            ConfigurationString = configurationString;
            object deserializedConfiguration = JsonConvert.DeserializeObject(configurationString);
            return Configure(deserializedConfiguration);
        }

        public OperationResult Configure(object configuration)
        {
            IsConfigured = true;
            return new OperationResult();
        }
    }
}
