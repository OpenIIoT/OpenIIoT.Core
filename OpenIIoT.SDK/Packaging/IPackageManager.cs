/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█     ▄███████▄                                                                 ▄▄▄▄███▄▄▄▄
      █   ███    ███    ███                                                               ▄██▀▀▀███▀▀▀██▄
      █   ███▌   ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████  ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████
      █   ███▌   ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █   ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██
      █   ███▌ ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄     ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀
      █   ███    ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀     ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████
      █   ███    ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █   ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██
      █   █▀    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████   ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Handles the installation and file management of the Packages used to extend the functionality of the application.
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

using System.Collections.Generic;
using System.Threading.Tasks;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Common.OperationResult;

namespace OpenIIoT.SDK.Packaging
{
    /// <summary>
    ///     Handles the installation and file management of the Pacakges used to extend the functionality of the application.
    /// </summary>
    public interface IPackageManager : IManager
    {
        #region Public Properties

        /// <summary>
        ///     Gets the list of Packages available for installation.
        /// </summary>
        IReadOnlyList<Package> Packages { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Creates a <see cref="Package"/> file with the specified data.
        /// </summary>
        /// <remarks>
        ///     The resulting Package file is saved to the Packages directory with a filename composed of the Fully Qualified Name
        ///     and Version of the Package.
        /// </remarks>
        /// <param name="data">The data to save.</param>
        /// <returns>A Result containing the result of the operation and the created IPackage instance.</returns>
        IResult<Package> CreatePackage(byte[] data);

        /// <summary>
        ///     Asynchronously creates a <see cref="Package"/> file with the specified data.
        /// </summary>
        /// <remarks>
        ///     The resulting Package file is saved to the Packages directory with a filename composed of the Fully Qualified Name
        ///     and Version of the Package.
        /// </remarks>
        /// <param name="data">The data to save.</param>
        /// <returns>A Result containing the result of the operation and the created IPackage instance.</returns>
        Task<IResult<Package>> CreatePackageAsync(byte[] data);

        /// <summary>
        ///     Deletes the <see cref="Package"/> matching the specified Fully Qualified Name from disk.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the <see cref="Package"/> to delete.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        IResult DeletePackage(string fqn);

        /// <summary>
        ///     Asynchronously deletes the <see cref="Package"/> matching the specified Fully Qualified Name from disk.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the <see cref="Package"/> to delete.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Task<IResult> DeletePackageAsync(string fqn);

        /// <summary>
        ///     Fetches the <see cref="Package"/> file matching the specified Fully Qualified Name and returns the binary data.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the <see cref="Package"/> to fetch.</param>
        /// <returns>A Result containing the result of the operation and the read binary data.</returns>
        IResult<byte[]> FetchPackage(string fqn);

        /// <summary>
        ///     Asynchronously fetches the <see cref="Package"/> file matching the specified Fully Qualified Name and returns the
        ///     binary data.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the <see cref="Package"/> to fetch.</param>
        /// <returns>A Result containing the result of the operation and the read binary data.</returns>
        Task<IResult<byte[]>> FetchPackageAsync(string fqn);

        /// <summary>
        ///     <para>
        ///         Scans the <see cref="Packages"/> list for a Package matching the specified Fully Qualified Name and, if found,
        ///         returns the found Package.
        ///     </para>
        ///     <para>
        ///         If a matching Package is not found, the <see cref="ScanPackages()"/> method is invoked to refresh the
        ///         <see cref="Packages"/> list from disk.
        ///     </para>
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to find.</param>
        /// <returns>The found Package, if applicable.</returns>
        Package FindPackage(string fqn);

        /// <summary>
        ///     <para>
        ///         Asynchronously scans the <see cref="Packages"/> list for a Package matching the specified Fully Qualified Name
        ///         and, if found, returns the found Package.
        ///     </para>
        ///     <para>
        ///         If a matching Package is not found, the <see cref="ScanPackages()"/> method is invoked to refresh the
        ///         <see cref="Packages"/> list from disk.
        ///     </para>
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to find.</param>
        /// <returns>The found Package, if applicable.</returns>
        Task<Package> FindPackageAsync(string fqn);

        /// <summary>
        ///     Installs the specified <see cref="Package"/> (extracts it to disk).
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to install.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        IResult InstallPackage(string fqn);

        /// <summary>
        ///     Installs the specified <see cref="Package"/> (extracts it to disk) using the specified options.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to install.</param>
        /// <param name="options">The installation options for the operation.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        IResult InstallPackage(string fqn, PackageInstallationOptions options);

        /// <summary>
        ///     Installs the specified <see cref="Package"/> (extracts it to disk) using the specified options and PGP public key.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to install.</param>
        /// <param name="options">The installation options for the operation.</param>
        /// <param name="publicKey">The PGP public key with which to install the Package.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        IResult InstallPackage(string fqn, PackageInstallationOptions options, string publicKey);

        /// <summary>
        ///     Asynchronously installs the specified <see cref="Package"/> (extracts it to disk).
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to install.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Task<IResult> InstallPackageAsync(string fqn);

        /// <summary>
        ///     Asynchronously installs the specified <see cref="Package"/> (extracts it to disk) using the specified options.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to install.</param>
        /// <param name="options">The installation options for the operation.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Task<IResult> InstallPackageAsync(string fqn, PackageInstallationOptions options);

        /// <summary>
        ///     Asynchronously installs the specified <see cref="Package"/> (extracts it to disk) using the specified
        ///     <paramref name="options"/> and PGP <paramref name="publicKey"/>.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to install.</param>
        /// <param name="options">The installation options for the operation.</param>
        /// <param name="publicKey">The PGP public key with which to install the Package.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Task<IResult> InstallPackageAsync(string fqn, PackageInstallationOptions options, string publicKey);

        /// <summary>
        ///     Scans for and returns a list of all Package files in the configured Packages directory.
        /// </summary>
        /// <returns>A Result containing the result of the operation and the list of found Packages.</returns>
        IResult<IList<Package>> ScanPackages();

        /// <summary>
        ///     Asynchronously scans for and returns a list of all Package files in the configured Package directory.
        /// </summary>
        /// <returns>A Result containing the result of the operation and the list of found Packages.</returns>
        Task<IResult<IList<Package>>> ScanPackagesAsync();

        /// <summary>
        ///     Verifies the specified <see cref="Package"/>.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to verify.</param>
        /// <returns>A Result containing the result of the operation and a value indicating whether the Package is valid.</returns>
        IResult<bool> VerifyPackage(string fqn);

        /// <summary>
        ///     Verifies the specified <see cref="Package"/> using the optionally specified PGP Public Key.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to verify.</param>
        /// <param name="publicKey">The optional PGP Public Key with which to verify the package.</param>
        /// <returns>A Result containing the result of the operation and a value indicating whether the Package is valid.</returns>
        IResult<bool> VerifyPackage(string fqn, string publicKey);

        /// <summary>
        ///     Asynchronously verifies the specified <see cref="Package"/>.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to verify.</param>
        /// <returns>A Result containing the result of the operation and a value indicating whether the Package is valid.</returns>
        Task<IResult<bool>> VerifyPackageAsync(string fqn);

        /// <summary>
        ///     Asynchronously verifies the specified <see cref="Package"/> using the optionally specified PGP Public Key.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Package to verify.</param>
        /// <param name="publicKey">The optional PGP Public Key with which to verify the package.</param>
        /// <returns>A Result containing the result of the operation and a value indicating whether the Package is valid.</returns>
        Task<IResult<bool>> VerifyPackageAsync(string fqn, string publicKey);

        #endregion Public Methods
    }
}