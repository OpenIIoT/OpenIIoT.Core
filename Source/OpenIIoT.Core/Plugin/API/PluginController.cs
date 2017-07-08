﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using NLog;
using OpenIIoT.Core.Platform;
using OpenIIoT.Core.Plugin;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Plugin;
using Utility.OperationResult;
using OpenIIoT.Core.Service.Web;

namespace OpenIIoT.Core.Plugin.API
{
    /// <summary>
    ///     Handles the API methods for AppPackages.
    /// </summary>
    public class PluginController : ApiController
    {
        #region Variables

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     The default serialization properties for an AppPackage.
        /// </summary>
        private static List<string> pluginPackageSerializationProperties = new List<string>(new string[] { });

        /// <summary>
        ///     The ApplicationManager for the application.
        /// </summary>
        private IApplicationManager manager = ApplicationManager.GetInstance();

        #endregion Variables

        #region Instance Methods

        [Route("api/plugin/archive/{fileName}/download")]
        [HttpGet]
        public HttpResponseMessage DownloadPackage(string fileName)
        {
            ApiResult<bool> retVal = new ApiResult<bool>(Request);
            retVal.LogRequest(logger.Info);

            string pluginPackage = System.IO.Path.Combine(manager.GetManager<PlatformManager>().Platform.Directories.Packages, manager.GetManager<PluginManager>().Packages.Where(p => p.FileName == fileName).FirstOrDefault().FileName);

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);

            result.Content = new StreamContent(new System.IO.FileStream(pluginPackage, System.IO.FileMode.Open));
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = System.IO.Path.GetFileName(pluginPackage) };

            retVal.LogResult(logger);
            return result;
        }

        /// <summary>
        ///     Returns the Package from the list of available Packages that matches the supplied filename.
        /// </summary>
        /// <param name="fileName">The Fully Qualified Name of the Package to return.</param>
        /// <returns>The matching Package.</returns>
        [Route("api/plugin/archive/{fileName}")]
        [HttpGet]
        public HttpResponseMessage GetPackage(string fileName)
        {
            ApiResult<IPackage> retVal = new ApiResult<IPackage>(Request);
            retVal.LogRequest(logger.Info);

            retVal.ReturnValue = manager.GetManager<PluginManager>().Packages.Where(p => p.FileName == fileName).FirstOrDefault();

            if (retVal.ReturnValue == default(Package))
            {
                retVal.StatusCode = HttpStatusCode.NotFound;
            }

            retVal.LogResult(logger);
            return retVal.CreateResponse(JsonFormatter(new List<string>(new string[] { }), ContractResolverType.OptOut));
        }

        /// <summary>
        ///     Installs the supplied Package.
        /// </summary>
        /// <param name="fileName">The filename of the Plugin Package to install.</param>
        /// <returns>The App instance resulting from the installation.</returns>
        [Route("api/plugin/archive/{fileName}/install")]
        [HttpGet]
        public async Task<HttpResponseMessage> InstallPlugin(string fileName)
        {
            return new ApiResult<bool>(Request).CreateResponse(JsonFormatter(new List<string>(new string[] { }), ContractResolverType.OptOut));
        }

        /// <summary>
        ///     Returns the JsonMediaTypeFormatter to use with this controller.
        /// </summary>
        /// <param name="serializationProperties">
        ///     A list of properties to exclude or include, depending on the ContractResolverType, in the serialized result.
        /// </param>
        /// <param name="contractResolverType">
        ///     A ContractResolverType representing the desired behavior of serializationProperties, OptIn or OptOut.
        /// </param>
        /// <returns>A configured instance of JsonMediaTypeFormatter</returns>
        public JsonMediaTypeFormatter JsonFormatter(List<string> serializationProperties, ContractResolverType contractResolverType)
        {
            JsonMediaTypeFormatter retVal = new JsonMediaTypeFormatter();

            retVal.SerializerSettings = new JsonSerializerSettings();

            retVal.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            retVal.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            retVal.SerializerSettings.Formatting = Formatting.Indented;
            retVal.SerializerSettings.ContractResolver = new ContractResolver(serializationProperties, contractResolverType);
            retVal.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());

            return retVal;
        }

        /// <summary>
        ///     Returns the list of available AppPackages.
        /// </summary>
        /// <returns>The list of available AppPackages.</returns>
        [Route("api/plugin/archive")]
        [HttpGet]
        public HttpResponseMessage ListPackages()
        {
            ApiResult<IList<IPackage>> retVal = new ApiResult<IList<IPackage>>(Request);
            retVal.LogRequest(logger.Info);

            retVal.ReturnValue = manager.GetManager<PluginManager>().Packages;

            retVal.LogResult(logger);
            return retVal.CreateResponse(JsonFormatter(pluginPackageSerializationProperties, ContractResolverType.OptOut));
        }

        [Route("api/plugin")]
        [HttpGet]
        public HttpResponseMessage ListPlugins()
        {
            ApiResult<List<IPlugin>> retVal = new ApiResult<List<IPlugin>>(Request);
            retVal.LogRequest(logger.Info);

            retVal.ReturnValue = manager.GetManager<PluginManager>().Configuration.InstalledPlugins.ToList<IPlugin>();

            retVal.LogResult(logger);
            return retVal.CreateResponse(JsonFormatter(pluginPackageSerializationProperties, ContractResolverType.OptOut));
        }

        /// <summary>
        ///     Reloads the list of Packages from disk and returns the list.
        /// </summary>
        /// <returns>The reloaded list of available Packages.</returns>
        [Route("api/plugin/archive/reload")]
        [HttpGet]
        public HttpResponseMessage ReloadPackages()
        {
            return new ApiResult<bool>(Request).CreateResponse(JsonFormatter(pluginPackageSerializationProperties, ContractResolverType.OptOut));
        }

        #endregion Instance Methods
    }
}