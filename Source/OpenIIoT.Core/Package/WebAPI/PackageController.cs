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

namespace OpenIIoT.Core.Package.WebAPI
{
    /// <summary>
    ///     Handles the API methods for AppPackages.
    /// </summary>
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

        #endregion Variables

        #region Instance Methods

        [Route("api/package/{fqn}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeletePackage(string fqn)
        {
            HttpResponseMessage retVal;
            HttpStatusCode statusCode = HttpStatusCode.OK;

            IResult deleteResult = await manager.GetManager<IPackageManager>().DeletePackageAsync(fqn);

            retVal = Request.CreateResponse(HttpStatusCode.OK, deleteResult, JsonFormatter());
            return retVal;
        }

        [Route("api/package/{fqn}/download")]
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
        [Route("api/package/{fqn}")]
        [HttpGet]
        public async Task<HttpResponseMessage> FindPackage(string fqn)
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

        //[Route("api/package/{fqn}/overwrite")]
        //[HttpPut]
        //public async Task<HttpResponseMessage> InstallPackageOverwrite(string fqn, string publicKey = "")
        //{
        //    IResult installResult = await manager.GetManager<IPackageManager>().InstallPackageAsync(fqn, PackageInstallOptions.Overwrite, publicKey);

        //    return Request.CreateResponse(HttpStatusCode.OK, installResult, JsonFormatter());
        //}

        //[Route("api/package/{fqn}/overwrite/skipverification")]
        //[HttpPut]
        //public async Task<HttpResponseMessage> InstallPackageOverwriteSkipVerification(string fqn, string publicKey = "")
        //{
        //    PackageInstallOptions options = PackageInstallOptions.Overwrite | PackageInstallOptions.SkipVerification;
        //    IResult installResult = await manager.GetManager<IPackageManager>().InstallPackageAsync(fqn, options, publicKey);

        //    return Request.CreateResponse(HttpStatusCode.OK, installResult, JsonFormatter());
        //}

        //[Route("api/package/{fqn}/skipverification")]
        //[HttpPut]
        //public async Task<HttpResponseMessage> InstallPackageSkipVerification(string fqn, string publicKey = "")
        //{
        //    IResult installResult = await manager.GetManager<IPackageManager>().InstallPackageAsync(fqn, PackageInstallOptions.SkipVerification, publicKey);

        //    return Request.CreateResponse(HttpStatusCode.OK, installResult, JsonFormatter());
        //}

        [Route("api/package/{fqn}/read")]
        [HttpGet]
        public async Task<HttpResponseMessage> ReadPackage(string fqn)
        {
            HttpResponseMessage retVal;

            IResult<byte[]> readResult = await manager.GetManager<IPackageManager>().ReadPackageAsync(fqn);

            return Request.CreateResponse(HttpStatusCode.OK, readResult, JsonFormatter());
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

        [Route("api/package/upload/{fileName}")]
        [HttpPost]
        public async Task<HttpResponseMessage> UploadPackage([FromBody]string base64Data, string fileName)
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
                retVal = await manager.GetManager<IPackageManager>().CreatePackageAsync(data, fileName);
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