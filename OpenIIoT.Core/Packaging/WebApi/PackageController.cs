/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                              ▄████████
      █     ███    ███                                                              ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████ ███    █▀   ██████  ██▄▄▄▄      ██       █████  ██████   █        █          ▄█████    █████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █  ███        ██    ██ ██▀▀▀█▄ ▀███████▄   ██  ██ ██    ██ ██       ██         ██   █    ██  ██
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ███        ██    ██ ██   ██     ██  ▀  ▄██▄▄█▀ ██    ██ ██       ██        ▄██▄▄     ▄██▄▄█▀
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ███    █▄  ██    ██ ██   ██     ██    ▀███████ ██    ██ ██       ██       ▀▀██▀▀    ▀███████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █  ███    ███ ██    ██ ██   ██     ██      ██  ██ ██    ██ ██▌    ▄ ██▌    ▄   ██   █    ██  ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████ ████████▀   ██████   █   █     ▄██▀     ██  ██  ██████  ████▄▄██ ████▄▄██   ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016-2017 JP Dillingham (jp@dillingham.ws)
      █
      █  This program is free software: you can redistribute it and/or modify
      █  it under the terms of the GNU Affero General Public License as published by
      █  the Free Software Foundation, either version 3 of the License, or
      █  (at your option) any later version.
      █
      █  This program is distributed in the hope that it will be useful,
      █  but WITHOUT ANY WARRANTY; without even the implied warranty of
      █  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      █  GNU Affero General Public License for more details.
      █
      █  You should have received a copy of the GNU Affero General Public License
      █  along with this program.  If not, see <http://www.gnu.org/licenses/>.
      █
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

namespace OpenIIoT.Core.Packaging.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Web.Http;
    using OpenIIoT.Core.Service.WebApi;
    using OpenIIoT.SDK;
    using OpenIIoT.SDK.Common;
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Packaging;
    using Swashbuckle.Swagger.Annotations;

    /// <summary>
    ///     Handles the API methods for AppPackages.
    /// </summary>
    [Authorize]
    [Service.WebApi.ControllerRoutePrefixAttribute("v1/package")]
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
        [Route("{fqn}")]
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
            Package findResult = await PackageManager.FindPackageAsync(fqn);
            var type = Request.Content.Headers.ContentType;

            if (findResult == default(Package))
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

        [Route("{fqn}/download")]
        [HttpGet]
        public async Task<HttpResponseMessage> DownloadPackage(string fqn)
        {
            HttpResponseMessage retVal;

            Package findResult = await manager.GetManager<IPackageManager>().FindPackageAsync(fqn);

            if (findResult != default(Package))
            {
                IResult<byte[]> readResult = await manager.GetManager<IPackageManager>().FetchPackageAsync(fqn);

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
        [Route("{fqn}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetPackage(string fqn)
        {
            HttpResponseMessage retVal;
            Package findResult = await manager.GetManager<IPackageManager>().FindPackageAsync(fqn);

            retVal = Request.CreateResponse(HttpStatusCode.OK, findResult, JsonFormatter(ContractResolverType.OptOut, "Files"));

            return retVal;
        }

        /// <summary>
        ///     Returns a list of Packages available for installation.
        /// </summary>
        /// <returns>A Result containing the result of the operation and a list of Packages.</returns>
        [Route("")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, "The list operation completed successfully.", typeof(List<Package>))]
        public HttpResponseMessage GetPackages()
        {
            IReadOnlyList<Package> packages = manager.GetManager<IPackageManager>().Packages;

            return Request.CreateResponse(HttpStatusCode.OK, packages, JsonFormatter(ContractResolverType.OptOut, "Files"));
        }

        [Route("{fqn}")]
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
        [Authorize(Roles = "Administrator")]
        [Route("scan")]
        [HttpGet]
        public async Task<HttpResponseMessage> ScanPackages()
        {
            IResult<IList<Package>> packages = await manager.GetManager<IPackageManager>().ScanPackagesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, packages, JsonFormatter(ContractResolverType.OptOut, "Files"));
        }

        /// <summary>
        ///     Creates a new Package with the specified filename from the specified base 64 encoded binary data.
        /// </summary>
        /// <param name="data">The base 64 encoded binary package data.</param>
        /// <returns>A Result containing the result of the operation and the created Package.</returns>
        [Authorize]
        [Route("")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, "The Package was created or overwritten.", typeof(Package))]
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
            IResult<Package> result = await manager.GetManager<IPackageManager>().CreatePackageAsync(binaryData);

            if (result.ResultCode != ResultCode.Failure)
            {
                return Request.CreateResponse(HttpStatusCode.Created, result.ReturnValue, JsonFormatter());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result, JsonFormatter());
            }
        }

        [Route("{fqn}/verify")]
        [HttpGet]
        public async Task<HttpResponseMessage> VerifyPackage(string fqn, string publicKey = "")
        {
            IResult<bool> verifyResult = await manager.GetManager<IPackageManager>().VerifyPackageAsync(fqn, publicKey);

            return Request.CreateResponse(HttpStatusCode.OK, verifyResult, JsonFormatter());
        }

        #endregion Instance Methods
    }
}