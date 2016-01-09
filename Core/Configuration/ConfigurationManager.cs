using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Configuration
{
    public class ConfigurationManager
    {
        private ProgramManager manager;
        private static ConfigurationManager instance;

        public Configuration Configuration { get; private set; }

        private ConfigurationManager(ProgramManager manager)
        {
            this.manager = manager;
            Configuration = new Configuration();
        }

        internal static ConfigurationManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new ConfigurationManager(manager);

            return instance;
        }
    }
}
