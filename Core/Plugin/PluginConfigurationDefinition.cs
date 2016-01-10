using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Plugin
{
    class PluginConfigurationDefinition : IPluginConfigurationDefinition
    {
        public string Form { get; private set; }
        public string Schema { get; private set; }

        public PluginConfigurationDefinition() : this("", "") { }

        public PluginConfigurationDefinition(string form, string schema)
        {
            Form = form;
            Schema = schema;
        }

        public PluginConfigurationDefinition SetForm(string form)
        {
            Form = form;
            return this;
        }

        public PluginConfigurationDefinition SetSchema(string schema)
        {
            Schema = schema;
            return this;
        }
    }
}
