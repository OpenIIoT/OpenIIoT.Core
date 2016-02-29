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
using Symbiote.Core.Configuration;

namespace Symbiote.Core.Communication.Services.Web
{
    public class WebService : IService
    {
        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static WebService instance;
        private static IDisposable server;

        public ObjectConfiguration Configuration { get; private set; }
        public bool IsRunning { get { return (server != null); } }

        public string URL { get; private set; }

        public Dictionary<string, Hub> Hubs { get; private set; }
        public Dictionary<string, ApiController> ApiControllers { get; private set; }

        private WebService(ProgramManager manager)
        {
            this.manager = manager;
            Hubs = new Dictionary<string, Hub>();
            ApiControllers = new Dictionary<string, ApiController>();
        }

        public static WebService Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new WebService(manager);

            return instance;
        }

        public OperationResult Start()
        {
            logger.Info("Starting Web server...");
            OperationResult retVal = new OperationResult();

            URL = "http://*:" + manager.ConfigurationManager.Configuration.Web.Port;

            try
            {
                server = WebApp.Start(URL);
                logger.Info("Web server listening at '" + URL + "'.");
                logger.Info("The Web server was started successfully.");
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while starting the web server: " + ex);
            }

            return retVal;
        }

        public OperationResult Stop()
        {
            logger.Info("Stopping Web server...");
            OperationResult retVal = new OperationResult();

            try
            {
                server.Dispose();
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while disposing of the web server: " + ex);
            }

            return retVal;
        }
    }
}
