using System.Collections.Generic;
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
using Utility.OperationResult;
using OpenIIoT.SDK.Package;
using OpenIIoT.Core.Service.WebAPI;
using System.IO;
using System;
using System.Web.Http.Description;
using Swashbuckle.Swagger.Annotations;

namespace OpenIIoT.Core.Package.WebAPI
{
    /// <summary>
    ///     Handles the API methods for AppPackages.
    /// </summary>
    [RoutePrefix("api")]
    public class PackageController : ApiBaseController
    {
        #region Variables

        /// <summary>
        ///     The default serialization properties for an AppPackage.
        /// </summary>
        private static List<string> pluginPackageSerializationProperties = new List<string>(new string[] { "Files" });

        /// <summary>
        ///     The ApplicationManager for the application.
        /// </summary>
        private IApplicationManager manager = ApplicationManager.GetInstance();

        /// <summary>
        ///     Gets the PackageManager for the application.
        /// </summary>
        private IPackageManager PackageManager => manager.GetManager<IPackageManager>();

        #endregion Variables

        #region Instance Methods

        /// <summary>
        ///     Deletes the specified Package.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to delete.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        [HttpDelete]
        [Route("v1/package/{fqn}")]
        [ResponseType(typeof(Result))]
        [SwaggerResponse(HttpStatusCode.OK, "The Package was deleted.", typeof(Result))]
        [SwaggerResponse(HttpStatusCode.NotFound, "A Package with the specified FQN could not be found.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "An unexpected error was encountered during the operation.", typeof(Result))]
        public async Task<HttpResponseMessage> DeletePackage(string fqn)
        {
            HttpResponseMessage retVal;
            Result result = new Result();

            IPackage findResult = await PackageManager.FindPackageAsync(fqn);
            var type = Request.Content.Headers.ContentType;

            if (findResult == default(IPackage))
            {
                result.AddError("A Package with the specified FQN could not be found.");
                retVal = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                IResult deleteResult = await manager.GetManager<IPackageManager>().DeletePackageAsync(fqn);

                if (deleteResult.ResultCode != ResultCode.Failure)
                {
                    retVal = Request.CreateResponse(HttpStatusCode.OK, deleteResult, JsonFormatter());
                }
                else
                {
                    retVal = Request.CreateResponse(HttpStatusCode.InternalServerError, deleteResult, JsonFormatter());
                }
            }

            var c = retVal.Content;
            return retVal;
        }

        [Route("v1/{fqn}/download")]
        [HttpGet]
        public async Task<HttpResponseMessage> DownloadPackage(string fqn)
        {
            HttpResponseMessage retVal;

            IPackage findResult = await manager.GetManager<IPackageManager>().FindPackageAsync(fqn);

            if (findResult != default(IPackage))
            {
                IResult<byte[]> readResult = await manager.GetManager<IPackageManager>().ReadPackageAsync(fqn);

                if (readResult.ResultCode != ResultCode.Failure)
                {
                    retVal = Request.CreateResponse(HttpStatusCode.OK);
                    retVal.Content = new ByteArrayContent(readResult.ReturnValue);
                    retVal.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    retVal.Content.Headers.ContentDisposition.FileName = Path.GetFileName(findResult.FileName);
                }
                else
                {
                    retVal = Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                retVal = Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return retVal;
        }

        /// <summary>
        ///     Returns the Package from the list of available Packages that matches the supplied Fully Qualified Name.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to return.</param>
        /// <returns>The matching Package.</returns>
        [Route("v1/{fqn}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetPackage(string fqn)
        {
            HttpResponseMessage retVal;
            IPackage findResult = await manager.GetManager<IPackageManager>().FindPackageAsync(fqn);

            retVal = Request.CreateResponse(HttpStatusCode.OK, findResult, JsonFormatter(ContractResolverType.OptOut, "Files"));

            return retVal;
        }

        [Route("api/package")]
        [HttpGet]
        public HttpResponseMessage GetPackages()
        {
            IList<IPackage> packages = manager.GetManager<IPackageManager>().Packages;

            return Request.CreateResponse(HttpStatusCode.OK, packages, JsonFormatter(ContractResolverType.OptOut, "Files"));
        }

        [Route("api/package/{fqn}")]
        [HttpPut]
        public async Task<HttpResponseMessage> InstallPackage(string fqn, [FromBody]PackageInstallationOptions options)
        {
            IResult installResult = await manager.GetManager<IPackageManager>().InstallPackageAsync(fqn, options);

            return Request.CreateResponse(HttpStatusCode.OK, installResult, JsonFormatter());
        }

        /// <summary>
        ///     Reloads the list of Packages from disk and returns the list.
        /// </summary>
        /// <returns>The reloaded list of available Packages.</returns>
        [Route("api/package/scan")]
        [HttpGet]
        public async Task<HttpResponseMessage> ScanPackages()
        {
            IResult<IList<IPackage>> packages = await manager.GetManager<IPackageManager>().ScanPackagesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, packages, JsonFormatter(ContractResolverType.OptOut, "Files"));
        }

        /// <summary>
        ///     Creates a new Package with the specified filename from the specified base 64 encoded binary data.
        /// </summary>
        /// <param name="base64Data">The base 64 encoded binary package data.</param>
        /// <returns></returns>
        [Route("v1/package/upload")]
        [HttpPost]
        public async Task<HttpResponseMessage> UploadPackage([FromBody]string base64Data)
        {
            IResult retVal = new Result();
            byte[] data = default(byte[]);

            try
            {
                data = Convert.FromBase64String(base64Data.ToString());
            }
            catch (Exception ex)
            {
                retVal.AddError(ex.Message);
                retVal.AddError("The provided file data is invalid.");
            }

            if (retVal.ResultCode != ResultCode.Failure)
            {
                retVal = await manager.GetManager<IPackageManager>().CreatePackageAsync(data);
            }

            return Request.CreateResponse(HttpStatusCode.OK, retVal, JsonFormatter());
        }

        [Route("api/package/{fqn}/verify")]
        [HttpGet]
        public async Task<HttpResponseMessage> VerifyPackage(string fqn, string publicKey = "")
        {
            IResult<bool> verifyResult = await manager.GetManager<IPackageManager>().VerifyPackageAsync(fqn, publicKey);

            return Request.CreateResponse(HttpStatusCode.OK, verifyResult, JsonFormatter());
        }

        #endregion Instance Methods
    }
}