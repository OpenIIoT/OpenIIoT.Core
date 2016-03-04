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
    public class WebService : IService, IConfigurable<WebServiceConfiguration>
    {
        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static WebService instance;
        private static IDisposable server;

        public ConfigurationDefinition ConfigurationDefinition { get { return GetConfigurationDefinition(); } }
        public WebServiceConfiguration Configuration { get; private set; }
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

        public OperationResult Configure()
        {
            return Configure(manager.ConfigurationManager.GetConfiguration<WebServiceConfiguration>(this.GetType()).Result);
        }

        public OperationResult Configure(WebServiceConfiguration configuration)
        {
            Configuration = configuration;
            return new OperationResult();
        }

        public static ConfigurationDefinition GetConfigurationDefinition()
        {
            ConfigurationDefinition retVal = new ConfigurationDefinition();
            retVal.SetForm("[\"name\",\"email\",{\"key\":\"comment\",\"type\":\"textarea\",\"placeholder\":\"Make a comment\"},{\"type\":\"submit\",\"style\":\"btn-info\",\"title\":\"OK\"}]");
            retVal.SetSchema("{\"type\":\"object\",\"title\":\"Comment\",\"properties\":{\"name\":{\"title\":\"Name\",\"type\":\"string\"},\"email\":{\"title\":\"Email\",\"type\":\"string\",\"pattern\":\"^\\\\S+@\\\\S+$\",\"description\":\"Email will be used for evil.\"},\"comment\":{\"title\":\"Comment\",\"type\":\"string\",\"maxLength\":20,\"validationMessage\":\"Don\'t be greedy!\"}},\"required\":[\"name\",\"email\",\"comment\"]}");
            retVal.SetModel(typeof(WebServiceConfiguration));
            return retVal;
        }

        public static WebServiceConfiguration GetDefaultConfiguration()
        {
            WebServiceConfiguration retVal = new WebServiceConfiguration();
            retVal.Port = 80;
            retVal.Root = "";
            return retVal;
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

    public class WebServiceConfiguration
    {
        public int Port { get; set; }
        public string Root { get; set; }
    }
}
