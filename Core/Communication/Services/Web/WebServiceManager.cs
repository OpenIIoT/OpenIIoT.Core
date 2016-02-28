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

namespace Symbiote.Core.Communication.Services.Web
{
    public class WebServiceManager
    {
        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static WebServiceManager instance;

        public string URL { get; private set; }

        public Dictionary<string, Hub> Hubs { get; private set; }
        public Dictionary<string, ApiController> ApiControllers { get; private set; }

        private WebServiceManager(ProgramManager manager)
        {
            this.manager = manager;
            Hubs = new Dictionary<string, Hub>();
            ApiControllers = new Dictionary<string, ApiController>();
        }

        internal static WebServiceManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new WebServiceManager(manager);

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
