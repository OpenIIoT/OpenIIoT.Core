namespace OpenIIoT.Core.Plugin.WebApi
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using NLog;
    using OpenIIoT.Core.Service.WebApi;
    using OpenIIoT.SDK;
    using OpenIIoT.SDK.Common;
    using OpenIIoT.SDK.Plugin;

    /// <summary>
    ///     Handles the API methods for AppPackages.
    /// </summary>
    public class PluginController : ApiBaseController
    {
        #region Variables

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     The default serialization properties for an AppPackage.
        /// </summary>
        private static List<string> pluginPackageSerializationProperties = new List<string>(new string[] { "Files" });

        /// <summary>
        ///     The ApplicationManager for the application.
        /// </summary>
        private IApplicationManager manager = ApplicationManager.GetInstance();

        #endregion Variables

        #region Instance Methods

        /// <summary>
        ///     Installs the supplied Package.
        /// </summary>
        /// <param name="fileName">The filename of the Plugin Package to install.</param>
        /// <returns>The App instance resulting from the installation.</returns>
        [Route("api/plugin/archive/{fileName}/install")]
        [HttpGet]
        public async Task<HttpResponseMessage> InstallPlugin(string fileName)
        {
            return Request.CreateResponse(JsonFormatter(ContractResolverType.OptOut));
        }

        [Route("api/plugin")]
        [HttpGet]
        public HttpResponseMessage ListPlugins()
        {
            IList<IPlugin> pluginList = manager.GetManager<PluginManager>().Configuration.InstalledPlugins.ToList<IPlugin>();

            return Request.CreateResponse(HttpStatusCode.OK, pluginList, JsonFormatter(ContractResolverType.OptOut, pluginPackageSerializationProperties));
        }

        #endregion Instance Methods
    }
}