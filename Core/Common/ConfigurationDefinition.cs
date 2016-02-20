using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core
{
    public class ConfigurationDefinition
    {
        public string Form { get; private set; }
        public string Schema { get; private set; }

        public ConfigurationDefinition() : this("", "") { }

        public ConfigurationDefinition(string form, string schema)
        {
            Form = form;
            Schema = schema;
        }

        public ConfigurationDefinition SetForm(string form)
        {
            Form = form;
            return this;
        }

        public ConfigurationDefinition SetSchema(string schema)
        {
            Schema = schema;
            return this;
        }
    }
}
