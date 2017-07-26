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
        [SwaggerResponse(HttpStatusCode.OK, "The Package was deleted.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "The specified Fully Qualified Name is invalid.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.NotFound, "A Package with the specified Fully Qualified Name could not be found.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "An unexpected error was encountered during the operation.", typeof(Result))]
        public async Task<HttpResponseMessage> DeletePackage(string fqn)
        {
            Result result = new Result();

            // validate the FQN
            if (string.IsNullOrEmpty(fqn))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "The Fully Qualified Name is null or empty.", JsonFormatter());
            }

            if (!fqn.Contains('.'))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "The Fully Qualified Name contains only one dot-separated tuple.", JsonFormatter());
            }

            // locate the Package
            IPackage findResult = await PackageManager.FindPackageAsync(fqn);
            var type = Request.Content.Headers.ContentType;

            if (findResult == default(IPackage))
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            // delete the Package
            IResult deleteResult = await manager.GetManager<IPackageManager>().DeletePackageAsync(fqn);

            if (deleteResult.ResultCode != ResultCode.Failure)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, deleteResult.Messages, JsonFormatter());
            }
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
                    retVal.Content.Headers.ContentDisposition.FileName = Path.GetFileName(findResult.Filename);
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
        [Route("v1/package/{fqn}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetPackage(string fqn)
        {
            HttpResponseMessage retVal;
            IPackage findResult = await manager.GetManager<IPackageManager>().FindPackageAsync(fqn);

            retVal = Request.CreateResponse(HttpStatusCode.OK, findResult, JsonFormatter(ContractResolverType.OptOut, "Files"));

            return retVal;
        }

        /// <summary>
        ///     Returns a list of Packages available for installation.
        /// </summary>
        /// <returns>A Result containing the result of the operation and a list of Packages.</returns>
        [Route("v1/package")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, "The list operation completed successfully.", typeof(List<IPackage>))]
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
        /// <param name="data">The base 64 encoded binary package data.</param>
        /// <returns>A Result containing the result of the operation and the created Package.</returns>
        [Route("v1/package")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, "The Package was created or overwritten.", typeof(IPackage))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "The specified data does not contain a valid Package, is not base 64 encoded, or is of zero length.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "An unexpected error was encountered during the operation.", typeof(Result))]
        public async Task<HttpResponseMessage> UploadPackage([FromBody]string data)
        {
            // validate the data length
            if (data.Length == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "The data is of zero length.", JsonFormatter());
            }

            // try to decode the base64 input
            byte[] binaryData = default(byte[]);

            try
            {
                binaryData = Convert.FromBase64String(data.ToString());
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "The data is not base 64 encoded.", JsonFormatter());
            }

            // try to create the Package
            IResult<IPackage> result = await manager.GetManager<IPackageManager>().CreatePackageAsync(binaryData);

            if (result.ResultCode != ResultCode.Failure)
            {
                return Request.CreateResponse(HttpStatusCode.Created, result.ReturnValue, JsonFormatter());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result, JsonFormatter());
            }
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