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
    using OpenIIoT.Core.Packaging.WebApi.Data;
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
    [RoutePrefix("v1/packaging")]
    public class PackagingController : ApiBaseController
    {
        #region Private Fields

        /// <summary>
        ///     The default serialization properties for an AppPackage.
        /// </summary>
        private static List<string> pluginPackageSerializationProperties = new List<string>(new string[] { "Files" });

        /// <summary>
        ///     The ApplicationManager for the application.
        /// </summary>
        private IApplicationManager manager = ApplicationManager.GetInstance();

        #endregion Private Fields

        #region Private Properties

        /// <summary>
        ///     Gets the PackageManager for the application.
        /// </summary>
        private IPackageManager PackageManager => manager.GetManager<IPackageManager>();

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Creates a new Package with the specified filename from the specified base 64 encoded binary data.
        /// </summary>
        /// <param name="data">The base 64 encoded binary package data.</param>
        /// <returns>A Result containing the result of the operation and the created Package.</returns>
        [Authorize]
        [Route("archive")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, "The Package was created or overwritten.", typeof(PackageArchive))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "The specified data does not contain a valid Package, is not base 64 encoded, or is of zero length.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "An unexpected error was encountered during the operation.", typeof(Result))]
        public async Task<HttpResponseMessage> PackageArchivesAdd([FromBody]string data)
        {
            HttpResponseMessage retVal;
            Tuple<bool, byte[]> bytes = TryGetBytesFromBase64String(data);
            bool isValidData = bytes.Item1;
            byte[] binaryData = bytes.Item2;

            if (data.Length == 0)
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, "The data is of zero length.", JsonFormatter());
            }
            else if (!isValidData)
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, "The data is not a valid base 64 encoded string.", JsonFormatter());
            }
            else
            {
                IResult<IPackageArchive> addResult = await PackageManager.AddPackageArchiveAsync(binaryData);

                if (addResult.ResultCode != ResultCode.Failure)
                {
                    retVal = Request.CreateResponse(HttpStatusCode.Created, addResult.ReturnValue, JsonFormatter());
                }
                else
                {
                    HttpErrorResult err = new HttpErrorResult("Failed to create a Package Archive from the specified data.", addResult);
                    retVal = Request.CreateResponse(HttpStatusCode.InternalServerError, err, JsonFormatter());
                }
            }

            return retVal;
        }

        /// <summary>
        ///     Deletes the specified Package Archive.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package Archive to delete.</param>
        /// <returns>An HTTP response message.</returns>
        [HttpDelete]
        [Route("archives/{fqn}")]
        [Authorize]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.NoContent, "The Package Archive was successfully deleted.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "The specified Fully Qualified Name is invalid.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.NotFound, "A Package archive with the specified Fully Qualified Name could not be found.")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Authorization denied.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "An unexpected error was encountered during the operation.", typeof(Result))]
        public async Task<HttpResponseMessage> PackageArchivesDelete(string fqn)
        {
            HttpResponseMessage retVal;

            if (string.IsNullOrEmpty(fqn))
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, "The specified Fully Qualified Name is null or empty.");
            }
            else if (!fqn.Contains('.'))
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, "The specified Fully Qualified Name contains only one dot-separated tuple.");
            }
            else
            {
                IPackageArchive findResult = await PackageManager.FindPackageArchiveAsync(fqn);

                if (findResult != default(IPackageArchive))
                {
                    IResult deleteResult = await PackageManager.DeletePackageArchiveAsync(findResult);

                    if (deleteResult.ResultCode != ResultCode.Failure)
                    {
                        return Request.CreateResponse(HttpStatusCode.NoContent);
                    }
                    else
                    {
                        HttpErrorResult result = new HttpErrorResult($"Failed to delete Package Archive '{fqn}'.", deleteResult);
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, result, JsonFormatter());
                    }
                }
                else
                {
                    retVal = Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }

            return retVal;
        }

        /// <summary>
        ///     Gets the specified Package Archive.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package Archive to retrieve.</param>
        /// <returns>An HTTP response message.</returns>
        [Route("archives/{fqn}")]
        [HttpGet]
        [Authorize]
        [SwaggerResponse(HttpStatusCode.OK, "The Package Archive was retrieved successfully.", typeof(PackageArchive))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "One or more parameters are invalid.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.NotFound, "The PackageArchive could not be found.")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Authorization denied.", typeof(string))]
        public async Task<HttpResponseMessage> PackageArchivesGetFqn(string fqn)
        {
            HttpResponseMessage retVal;

            if (string.IsNullOrEmpty(fqn))
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, "The specified Fully Qualified Name is null or empty.", JsonFormatter());
            }
            else if (!fqn.Contains('.'))
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, "The specified Fully Qualified Name contains only one dot-separated tuple.");
            }
            else
            {
                IPackageArchive packageArchive = await PackageManager.FindPackageArchiveAsync(fqn);

                if (packageArchive != default(IPackageArchive))
                {
                    retVal = Request.CreateResponse(HttpStatusCode.OK, packageArchive, JsonFormatter());
                }
                else
                {
                    retVal = Request.CreateResponse(HttpStatusCode.NotFound, JsonFormatter());
                }
            }

            return retVal;
        }

        /// <summary>
        ///     Retrieves the specified Package Archive file.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package Archive to retrieve.</param>
        /// <returns>An HTTP response message.</returns>
        [HttpGet]
        [Route("archives/{fqn}/file")]
        [Authorize]
        [SwaggerResponse(HttpStatusCode.OK, "The Package Archive was retrieved successfully.", typeof(byte[]))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Authorization denied.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "The specified Fully Qualified Name is invalid.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.NotFound, "A Package archive with the specified Fully Qualified Name could not be found.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "An unexpected error was encountered during the operation.", typeof(Result))]
        public async Task<HttpResponseMessage> PackageArchivesGetFqnFile(string fqn)
        {
            HttpResponseMessage retVal;

            if (string.IsNullOrEmpty(fqn))
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, "The specified Fully Qualified Name is null or empty.");
            }
            else if (!fqn.Contains('.'))
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, "The specified Fully Qualified Name contains only one dot-separated tuple.");
            }
            else
            {
                IPackageArchive findResult = await PackageManager.FindPackageArchiveAsync(fqn);

                if (findResult != default(IPackageArchive))
                {
                    IResult<byte[]> readResult = await PackageManager.FetchPackageArchiveAsync(findResult);

                    if (readResult.ResultCode != ResultCode.Failure)
                    {
                        retVal = Request.CreateResponse(HttpStatusCode.OK);
                        retVal.Content = new ByteArrayContent(readResult.ReturnValue);
                        retVal.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                        retVal.Content.Headers.ContentDisposition.FileName = Path.GetFileName(findResult.FileName);
                    }
                    else
                    {
                        HttpErrorResult result = new HttpErrorResult($"Failed to retrieve contents of Package archive '{fqn}'.", readResult);
                        retVal = Request.CreateResponse(HttpStatusCode.InternalServerError, result, JsonFormatter());
                    }
                }
                else
                {
                    retVal = Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }

            return retVal;
        }

        /// <summary>
        ///     Returns a list of Package Archives available for installation.
        /// </summary>
        /// <param name="scan">Refresh from disk.</param>
        /// <returns>An HTTP response message.</returns>
        [Route("archives")]
        [HttpGet]
        [Authorize]
        [SwaggerResponse(HttpStatusCode.OK, "The list operation completed successfully.", typeof(IReadOnlyList<PackageArchiveSummaryData>))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Authorization denied.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "An unexpected error was encountered during the operation.", typeof(HttpErrorResult))]
        public async Task<HttpResponseMessage> PackagesArchivesGet(bool? scan)
        {
            HttpResponseMessage retVal;

            if ((bool)scan)
            {
                IResult scanResult = await PackageManager.ScanPackageArchivesAsync();

                if (scanResult.ResultCode == ResultCode.Failure)
                {
                    HttpErrorResult err = new HttpErrorResult("Failed to refresh Package Archive list from disk", scanResult);
                    retVal = Request.CreateResponse(HttpStatusCode.InternalServerError, err, JsonFormatter());
                }
            }

            IReadOnlyList<PackageArchiveSummaryData> packageArchives = PackageManager.PackageArchives.Select(p => new PackageArchiveSummaryData(p)).ToList().AsReadOnly();
            retVal = Request.CreateResponse(HttpStatusCode.OK, packageArchives, JsonFormatter());

            return retVal;
        }

        /// <summary>
        ///     Returns a list of installed Packages.
        /// </summary>
        /// <param name="scan">Refresh from disk.</param>
        /// <returns>An HTTP response message.</returns>
        [Route("packages")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, "The list operation completed successfully.", typeof(IList<Package>))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Authorization denied.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "An unexpected error was encountered during the operation.", typeof(HttpErrorResult))]
        public async Task<HttpResponseMessage> PackagesGet(bool? scan)
        {
            HttpResponseMessage retVal;

            if ((bool)scan)
            {
                IResult scanResult = await manager.GetManager<IPackageManager>().ScanPackagesAsync();

                if (scanResult.ResultCode == ResultCode.Failure)
                {
                    HttpErrorResult err = new HttpErrorResult("Failed to refresh Package list from disk", scanResult);
                    retVal = Request.CreateResponse(HttpStatusCode.InternalServerError, err, JsonFormatter());
                }
            }

            IReadOnlyList<IPackage> packages = manager.GetManager<IPackageManager>().Packages;
            retVal = Request.CreateResponse(HttpStatusCode.OK, packages, JsonFormatter());

            return retVal;
        }

        /// <summary>
        ///     Gets the specified Package.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to retrieve.</param>
        /// <returns>An HTTP response message.</returns>
        [Route("packages/{fqn}")]
        [HttpGet]
        [Authorize]
        [SwaggerResponse(HttpStatusCode.OK, "The Package was retrieved successfully.", typeof(Package))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "One or more parameters are invalid.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.NotFound, "The PackageArchive could not be found.")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Authorization denied.", typeof(string))]
        public async Task<HttpResponseMessage> PackagesGetFqn(string fqn)
        {
            HttpResponseMessage retVal;

            if (string.IsNullOrEmpty(fqn))
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, "The specified fqn is null or empty.", JsonFormatter());
            }
            else
            {
                IPackage package = await PackageManager.FindPackageAsync(fqn);

                if (package != default(IPackage))
                {
                    retVal = Request.CreateResponse(HttpStatusCode.OK, package, JsonFormatter());
                }
                else
                {
                    retVal = Request.CreateResponse(HttpStatusCode.NotFound, JsonFormatter());
                }
            }

            return retVal;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Attempts to retrieve a byte array from the specified <paramref name="data"/> and returns a <see cref="Tuple"/>
        ///     containing the result of the attempt and, if successful, the retrieved array.
        /// </summary>
        /// <param name="data">The string from which to attempt to retrieve the byte array.</param>
        /// <returns>A <see cref="Tuple"/> containing the result of the attempt and, if successful, the retrieved array.s</returns>
        private Tuple<bool, byte[]> TryGetBytesFromBase64String(string data)
        {
            Tuple<bool, byte[]> retVal;
            byte[] bytes = default(byte[]);

            try
            {
                bytes = Convert.FromBase64String(data);
                retVal = new Tuple<bool, byte[]>(true, bytes);
            }
            catch (Exception)
            {
                retVal = new Tuple<bool, byte[]>(false, null);
            }

            return retVal;
        }

        #endregion Private Methods
    }
}