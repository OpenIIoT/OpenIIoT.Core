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
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Web.Http;
    using OpenIIoT.Core.Packaging.WebApi.Data;
    using OpenIIoT.Core.Service.WebApi;
    using OpenIIoT.Core.Service.WebApi.ModelValidation;
    using OpenIIoT.SDK;
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
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackagingController"/> class.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public PackagingController()
            : base(ApplicationManager.GetInstance())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackagingController"/> class with the specified
        ///     <see cref="IApplicationManager"/> instance.
        /// </summary>
        /// <param name="manager">The IApplicationManager instance used to resolve dependencies.</param>
        public PackagingController(IApplicationManager manager)
            : base(manager)
        {
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets the PackageManager for the application.
        /// </summary>
        private IPackageManager PackageManager => Manager.GetManager<IPackageManager>();

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Creates a new Package Archive.
        /// </summary>
        /// <param name="data">The base 64 encoded binary data of the Package Archive.</param>
        /// <returns>A Result containing the result of the operation and the created Package Archive.</returns>
        [Authorize]
        [Route("archives")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, "The Package Archive was created or overwritten.", typeof(PackageArchive))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "The specified data is of zero length or is not base 64 encoded.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "An unexpected error was encountered during the operation.", typeof(HttpErrorResult))]
        public async Task<HttpResponseMessage> PackageArchivesAdd([FromBody]string data)
        {
            HttpResponseMessage retVal;

            byte[] decodedData = GetBytesFromBase64String(data);

            if (data.Length == 0)
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, "The data is of zero length.", JsonFormatter());
            }
            else if (decodedData == default(byte[]))
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, "The data is not a valid base 64 encoded string.", JsonFormatter());
            }
            else
            {
                IResult<IPackageArchive> addResult = await PackageManager.AddPackageArchiveAsync(decodedData);

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
        [SwaggerResponse(HttpStatusCode.BadRequest, "One or more parameters are invalid.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.NotFound, "A Package Archive with the specified Fully Qualified Name could not be found.")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Authorization denied.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "An unexpected error was encountered during the operation.", typeof(HttpErrorResult))]
        public async Task<HttpResponseMessage> PackageArchivesDelete(string fqn)
        {
            HttpResponseMessage retVal;

            if (string.IsNullOrEmpty(fqn))
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, "The specified Fully Qualified Name is null or empty.");
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
        ///     Gets the specified Package Archive file.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package Archive to retrieve.</param>
        /// <returns>An HTTP response message.</returns>
        [HttpGet]
        [Route("archives/{fqn}/file")]
        [Authorize]
        [SwaggerResponse(HttpStatusCode.OK, "The Package Archive file was retrieved successfully.", typeof(byte[]))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Authorization denied.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "One or more parameters are invalid.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.NotFound, "A Package archive with the specified Fully Qualified Name could not be found.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "An unexpected error was encountered during the operation.", typeof(HttpErrorResult))]
        public async Task<HttpResponseMessage> PackageArchivesGetFqnFile(string fqn)
        {
            HttpResponseMessage retVal;

            if (string.IsNullOrEmpty(fqn))
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, "The specified Fully Qualified Name is null or empty.");
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
                        HttpErrorResult result = new HttpErrorResult($"Failed to retrieve contents of Package Archive '{fqn}'.", readResult);
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
        ///     Verifies the specified Package Archive.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package Archive to verify.</param>
        /// <param name="publicKey">The PGP public key to be used for verification.</param>
        /// <returns>An HTTP response message.</returns>
        [HttpGet]
        [Route("archives/{fqn}/verification")]
        [Authorize]
        [SwaggerResponse(HttpStatusCode.OK, "The Package Archive verification completed successfully.", typeof(PackageArchiveVerificationData))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Authorization denied.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "One or more parameters are invalid.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.NotFound, "A Package archive with the specified Fully Qualified Name could not be found.")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "An unexpected error was encountered during the operation.", typeof(HttpErrorResult))]
        public async Task<HttpResponseMessage> PackageArchivesGetFqnVerification(string fqn, string publicKey = default(string))
        {
            HttpResponseMessage retVal;

            if (string.IsNullOrEmpty(fqn))
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, "The specified Fully Qualified Name is null or empty.");
            }
            else if (publicKey != default(string) && !new Regex(PackagingConstants.KeyRegEx).IsMatch(publicKey))
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, "The specified PGP public key is not a valid key.");
            }
            else
            {
                IPackageArchive findResult = await PackageManager.FindPackageArchiveAsync(fqn);

                if (findResult != default(IPackageArchive))
                {
                    IResult<bool> verifyResult = await PackageManager.VerifyPackageArchiveAsync(findResult);

                    if (verifyResult.ResultCode != ResultCode.Failure)
                    {
                        retVal = Request.CreateResponse(HttpStatusCode.OK, new PackageArchiveVerificationData(verifyResult), JsonFormatter());
                    }
                    else
                    {
                        HttpErrorResult result = new HttpErrorResult($"Failed to verify Package Archive '{fqn}'.", verifyResult);
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
        ///     Gets the list of available Package Archives.
        /// </summary>
        /// <param name="scan">Refresh the list from disk.</param>
        /// <returns>An HTTP response message.</returns>
        [Route("archives")]
        [HttpGet]
        [Authorize]
        [SwaggerResponse(HttpStatusCode.OK, "The list was retrieved successfully.", typeof(IReadOnlyList<PackageArchiveSummaryData>))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Authorization denied.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "An unexpected error was encountered during the operation.", typeof(HttpErrorResult))]
        public async Task<HttpResponseMessage> PackagesArchivesGet(bool? scan = false)
        {
            if ((bool)scan)
            {
                IResult scanResult = await PackageManager.ScanPackageArchivesAsync();

                if (scanResult.ResultCode == ResultCode.Failure)
                {
                    HttpErrorResult err = new HttpErrorResult("Failed to refresh Package Archive list from disk", scanResult);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, err, JsonFormatter());
                }
            }

            IReadOnlyList<PackageArchiveSummaryData> packageArchives = PackageManager.PackageArchives.Select(p => new PackageArchiveSummaryData(p)).ToList().AsReadOnly();
            return Request.CreateResponse(HttpStatusCode.OK, packageArchives, JsonFormatter());
        }

        /// <summary>
        ///     Gets the list of installed Packages.
        /// </summary>
        /// <param name="scan">Refresh the list from disk.</param>
        /// <returns>An HTTP response message.</returns>
        [Route("packages")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, "The list was retrieved successfully.", typeof(IList<PackageSummaryData>))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Authorization denied.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "An unexpected error was encountered during the operation.", typeof(HttpErrorResult))]
        public async Task<HttpResponseMessage> PackagesGet(bool? scan = false)
        {
            if ((bool)scan)
            {
                IResult scanResult = await PackageManager.ScanPackagesAsync();

                if (scanResult.ResultCode == ResultCode.Failure)
                {
                    HttpErrorResult err = new HttpErrorResult("Failed to refresh Package list from disk", scanResult);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, err, JsonFormatter());
                }
            }

            IReadOnlyList<PackageSummaryData> packages = PackageManager.Packages.Select(p => new PackageSummaryData(p)).ToList().AsReadOnly();
            return Request.CreateResponse(HttpStatusCode.OK, packages, JsonFormatter());
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
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, "The specified Fully Qualified Name is null or empty.");
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

        /// <summary>
        ///     Installs the Package within the specified Package Archive.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package Archive to install.</param>
        /// <param name="options">The installation options for the Package.</param>
        /// <returns>An HTTP response message.</returns>
        [Authorize]
        [Route("packages/{fqn}")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, "The Package was successfully installed.", typeof(Package))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "One or more parameters are invalid.", typeof(ModelValidationResult))]
        [SwaggerResponse(HttpStatusCode.NotFound, "A Package Archive with the specified Fully Qualified Name could not be found.")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Authorization denied.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "An unexpected error was encountered during the operation.", typeof(HttpErrorResult))]
        public async Task<HttpResponseMessage> PackagesInstall(string fqn, [FromBody]PackageInstallationOptions options)
        {
            HttpResponseMessage retVal;
            ModelValidator validator = new ModelValidator(ModelState);

            if (string.IsNullOrEmpty(fqn))
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, new ModelValidationResult() { Message = "The specified Fully Qualified Name is null or empty." }, JsonFormatter());
            }
            else if (!validator.IsValid)
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, validator.Result);
            }
            else
            {
                IPackageArchive findResult = await PackageManager.FindPackageArchiveAsync(fqn);

                if (findResult != default(IPackageArchive))
                {
                    PackageInstallationOptions installOptions = new PackageInstallationOptions()
                    {
                        Overwrite = options.Overwrite,
                        SkipVerification = options.SkipVerification,
                        PublicKey = options.PublicKey,
                    };

                    IResult<IPackage> installResult = await PackageManager.InstallPackageAsync(findResult, installOptions);

                    if (installResult.ResultCode != ResultCode.Failure)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, installResult.ReturnValue, JsonFormatter());
                    }
                    else
                    {
                        HttpErrorResult result = new HttpErrorResult($"Failed to install Package '{fqn}'.", installResult);
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
        ///     Uninstalls the specified Package.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package Archive to uninstall.</param>
        /// <returns>An HTTP response message.</returns>
        [Authorize]
        [Route("packages/{fqn}")]
        [HttpDelete]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.NoContent, "The Package was successfully uninstalled.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "One or more parameters are invalid.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.NotFound, "A Package with the specified Fully Qualified Name could not be found.")]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Authorization denied.", typeof(string))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "An unexpected error was encountered during the operation.", typeof(HttpErrorResult))]
        public async Task<HttpResponseMessage> PackagesUninstall(string fqn)
        {
            HttpResponseMessage retVal;

            if (string.IsNullOrEmpty(fqn))
            {
                retVal = Request.CreateResponse(HttpStatusCode.BadRequest, "The specified Fully Qualified Name is null or empty.");
            }
            else
            {
                IPackage findResult = await PackageManager.FindPackageAsync(fqn);

                if (findResult != default(IPackage))
                {
                    IResult uninstallResult = await PackageManager.UninstallPackageAsync(findResult);

                    if (uninstallResult.ResultCode != ResultCode.Failure)
                    {
                        return Request.CreateResponse(HttpStatusCode.NoContent);
                    }
                    else
                    {
                        HttpErrorResult result = new HttpErrorResult($"Failed to uninstall Package '{fqn}'.", uninstallResult);
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

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Attempts to retrieve a byte array from the specified <paramref name="data"/> and returns a <see cref="Tuple"/>
        ///     containing the result of the attempt and, if successful, the retrieved array.
        /// </summary>
        /// <param name="data">The string from which to attempt to retrieve the byte array.</param>
        /// <returns>
        ///     The retrieved binary data, if the specified <paramref name="data"/> string is a base 64 encoded string.
        /// </returns>
        private byte[] GetBytesFromBase64String(string data)
        {
            byte[] retVal = default(byte[]);

            try
            {
                retVal = Convert.FromBase64String(data);
            }
            catch (Exception)
            {
            }

            return retVal;
        }

        #endregion Private Methods
    }
}