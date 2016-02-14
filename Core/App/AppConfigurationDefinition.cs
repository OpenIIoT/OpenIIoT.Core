using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.App
{
    public class AppConfigurationDefinition : IAppConfigurationDefinition
    {
        public string Form { get; private set; }
        public string Schema { get; private set; }

        public AppConfigurationDefinition(string form, string schema)
        {
            Form = form;
            Schema = schema;
        }
    }
}
