using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using NLog;
using OpenIIoT.SDK.Configuration;
using Utility.OperationResult;

[module: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleType", Justification = "Reviewed.")]

namespace OpenIIoT.Core.Service.WebApi
{
    public class WebApiService : IService, IConfigurable<WebAPIServiceConfiguration>
    {
        #region Internal Fields

        /// <summary>
        ///     The configuration for this Service.
        /// </summary>
        /// <remarks>Decorated as [ThreadStatic] so that it is accessible to the Owin startup class.</remarks>
        [ThreadStatic]
        private static WebAPIServiceConfiguration configuration;

        #endregion Internal Fields

        #region Private Fields

        private static WebApiService instance;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static IDisposable server;

        private ApplicationManager manager;

        #endregion Private Fields

        #region Private Constructors

        private WebApiService(ApplicationManager manager)
        {
            this.manager = manager;
            Hubs = new Dictionary<string, Hub>();
            ApiControllers = new Dictionary<string, ApiController>();
        }

        #endregion Private Constructors

        #region Public Properties

        public Dictionary<string, ApiController> ApiControllers { get; private set; }

        public WebAPIServiceConfiguration Configuration { get; private set; }

        public IConfigurationDefinition ConfigurationDefinition => GetConfigurationDefinition();

        public Dictionary<string, Hub> Hubs { get; private set; }

        public bool IsRunning => server != null;

        public string URL { get; private set; }

        #endregion Public Properties

        #region Internal Properties

        /// <summary>
        ///     Provies configuration accessibility to the Owin startup class.
        /// </summary>
        internal static WebAPIServiceConfiguration GetConfiguration
        {
            get
            {
                return configuration;
            }

            set
            {
                configuration = value;
            }
        }

        #endregion Internal Properties

        #region Public Methods

        public static IConfigurationDefinition GetConfigurationDefinition()
        {
            ConfigurationDefinition retVal = new ConfigurationDefinition();
            retVal.Form = "[\"name\",\"email\",{\"key\":\"comment\",\"type\":\"textarea\",\"placeholder\":\"Make a comment\"},{\"type\":\"submit\",\"style\":\"btn-info\",\"title\":\"OK\"}]";
            retVal.Schema = "{\"type\":\"object\",\"title\":\"Comment\",\"properties\":{\"name\":{\"title\":\"Name\",\"type\":\"string\"},\"email\":{\"title\":\"Email\",\"type\":\"string\",\"pattern\":\"^\\\\S+@\\\\S+$\",\"description\":\"Email will be used for evil.\"},\"comment\":{\"title\":\"Comment\",\"type\":\"string\",\"maxLength\":20,\"validationMessage\":\"Don\'t be greedy!\"}},\"required\":[\"name\",\"email\",\"comment\"]}";
            retVal.Model = typeof(WebAPIServiceConfiguration);

            WebAPIServiceConfiguration config = new WebAPIServiceConfiguration();
            config.Port = 80;
            config.Root = string.Empty;

            retVal.DefaultConfiguration = config;

            return retVal;
        }

        public static WebApiService Instance(ApplicationManager manager)
        {
            if (instance == null)
            {
                instance = new WebApiService(manager);
            }

            return instance;
        }

        public IResult Configure()
        {
            Result retVal = new Result();

            IResult<WebAPIServiceConfiguration> fetchResult = manager.GetManager<IConfigurationManager>().Configuration.GetInstance<WebAPIServiceConfiguration>(GetType());

            // if the fetch succeeded, configure this instance with the result.
            if (fetchResult.ResultCode != ResultCode.Failure)
            {
                Configure(fetchResult.ReturnValue);
            }
            else
            {
                // if the fetch failed, add a new default instance to the configuration and try again.
                IResult<WebAPIServiceConfiguration> createResult = manager.GetManager<IConfigurationManager>().Configuration.AddInstance<WebAPIServiceConfiguration>(this.GetType(), GetConfigurationDefinition().DefaultConfiguration);
                if (createResult.ResultCode != ResultCode.Failure)
                {
                    Configure(createResult.ReturnValue);
                }
            }

            return Configure(manager.GetManager<IConfigurationManager>().Configuration.GetInstance<WebAPIServiceConfiguration>(this.GetType()).ReturnValue);
        }

        public IResult Configure(WebAPIServiceConfiguration configuration)
        {
            Configuration = configuration;
            GetConfiguration = configuration;
            return new Result();
        }

        public IResult SaveConfiguration()
        {
            return manager.GetManager<IConfigurationManager>().Configuration.UpdateInstance(this.GetType(), Configuration);
        }

        public Result Start()
        {
            logger.Info("Starting Web server...");
            Configure();
            Result retVal = new Result();

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

        public Result Stop()
        {
            logger.Info("Stopping Web server...");
            Result retVal = new Result();

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

        #endregion Public Methods
    }

    public class WebAPIServiceConfiguration
    {
        #region Public Properties

        public int Port { get; set; }

        public string Root { get; set; }

        #endregion Public Properties
    }
}