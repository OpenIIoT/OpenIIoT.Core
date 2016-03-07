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
using System.Web.Http.Services;

namespace Symbiote.Core.Service.Web
{
    public class WebService : IService, IConfigurable<WebServiceConfiguration>
    {
        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static WebService instance;
        private static IDisposable server;

        [ThreadStatic]
        internal static WebServiceConfiguration configuration;

        public ConfigurationDefinition ConfigurationDefinition { get { return GetConfigurationDefinition(); } }
        public WebServiceConfiguration Configuration { get; private set; }
        public bool IsRunning { get { return (server != null); } }

        public string URL { get; private set; }

        internal static WebServiceConfiguration GetConfiguration { get { return configuration; } set { configuration = value; } }

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
            GetConfiguration = configuration;
            return new OperationResult();
        }

        public OperationResult SaveConfiguration()
        {
            return manager.ConfigurationManager.SaveConfiguration(this.GetType(), Configuration);
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
            Configure();
            OperationResult retVal = new OperationResult();

            URL = "http://*:" + Configuration.Port;

            try
            {
                server = WebApp.Start<OwinStartup>(URL);
                logger.Info("Web server listening at '" + URL + "/" + Configuration.Root + "'.");
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
