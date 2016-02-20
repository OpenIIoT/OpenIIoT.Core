using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Microsoft.Owin.Hosting;

namespace Symbiote.Core.Services.Web
{
    public class WebManager
    {
        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static WebManager instance;

        public string URL { get; private set; }

        private WebManager(ProgramManager manager)
        {
            this.manager = manager;
        }

        internal static WebManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new WebManager(manager);

            return instance;
        }

        internal bool Start()
        {
            URL = "http://*:" + manager.ConfigurationManager.Configuration.Web.Port;
            WebApp.Start(URL);
            return true;
        }
    }
}
