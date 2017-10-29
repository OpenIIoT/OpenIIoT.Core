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

namespace OpenIIoT.SDK.Packaging
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using OpenIIoT.SDK.Common;
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Common.Provider.EventProvider;

    /// <summary>
    ///     Handles the installation and file management of the Pacakges used to extend the functionality of the application.
    /// </summary>
    public interface IPackageManager : IManager
    {
        #region Public Events

        /// <summary>
        ///     Occurs when a <see cref="IPackageArchive"/> is added.
        /// </summary>
        [Event(Description = "Occurs when a Package archive is added.")]
        event EventHandler<PackageArchiveEventArgs> PackageArchiveAdded;

        /// <summary>
        ///     Occurs when a <see cref="IPackageArchive"/> is deleted.
        /// </summary>
        [Event(Description = "Occurs when a Package archive is deleted.")]
        event EventHandler<PackageArchiveEventArgs> PackageArchiveDeleted;

        /// <summary>
        ///     Occurs when a <see cref="IPackage"/> is installed.
        /// </summary>
        [Event(Description = "Occurs when a Package is installed.")]
        event EventHandler<PackageInstallEventArgs> PackageInstalled;

        /// <summary>
        ///     Occurs when a <see cref="IPackage"/> is uninstalled.
        /// </summary>
        [Event(Description = "Occurs when a Package is uninstalled.")]
        event EventHandler<PackageInstallEventArgs> PackageUninstalled;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        ///     Gets the list of <see cref="IPackageArchive"/> files available for installation.
        /// </summary>
        IReadOnlyList<IPackageArchive> PackageArchives { get; }

        /// <summary>
        ///     Gets the list of installed <see cref="IPackage"/> s.
        /// </summary>
        IReadOnlyList<IPackage> Packages { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Adds a <see cref="IPackageArchive"/> from the specified binary <paramref name="data"/>.
        /// </summary>
        /// <remarks>
        ///     The resulting Package archive file is saved to the Packages directory with a filename composed of the Fully
        ///     Qualified Name and Version of the Package.
        /// </remarks>
        /// <param name="data">The binary data to save.</param>
        /// <returns>A Result containing the result of the operation and the created <see cref="IPackageArchive"/> instance.</returns>
        IResult<IPackageArchive> AddPackageArchive(byte[] data);

        /// <summary>
        ///     Asynchronously adds a <see cref="IPackageArchive"/> from the specified binary <paramref name="data"/>.
        /// </summary>
        /// <remarks>
        ///     The resulting Package archive file is saved to the Packages directory with a filename composed of the Fully
        ///     Qualified Name and Version of the Package.
        /// </remarks>
        /// <param name="data">The binary data to save.</param>
        /// <returns>A Result containing the result of the operation and the created <see cref="IPackageArchive"/> instance.</returns>
        Task<IResult<IPackageArchive>> AddPackageArchiveAsync(byte[] data);

        /// <summary>
        ///     Deletes the specified <see cref="IPackageArchive"/> from disk.
        /// </summary>
        /// <param name="packageArchive">The <see cref="IPackageArchive"/> to delete.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        IResult DeletePackageArchive(IPackageArchive packageArchive);

        /// <summary>
        ///     Asynchronously deletes the specified <see cref="IPackageArchive"/> from disk.
        /// </summary>
        /// <param name="packageArchive">The <see cref="IPackageArchive"/> to delete.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Task<IResult> DeletePackageArchiveAsync(IPackageArchive packageArchive);

        /// <summary>
        ///     Fetches the specified <paramref name="packageArchive"/> and returns the binary data.
        /// </summary>
        /// <param name="packageArchive">The <see cref="IPackageArchive"/> to fetch.</param>
        /// <returns>
        ///     A Result containing the result of the operation and the <see cref="byte"/> array containing the fetched data.
        /// </returns>
        IResult<byte[]> FetchPackageArchive(IPackageArchive packageArchive);

        /// <summary>
        ///     Asynchronously fetches the specified <paramref name="packageArchive"/> and returns the binary data.
        /// </summary>
        /// <param name="packageArchive">The <see cref="IPackageArchive"/> to fetch.</param>
        /// <returns>
        ///     A Result containing the result of the operation and the <see cref="byte"/> array containing the fetched data.
        /// </returns>
        Task<IResult<byte[]>> FetchPackageArchiveAsync(IPackageArchive packageArchive);

        /// <summary>
        ///     <para>
        ///         Searches the <see cref="Packages"/> list for a <see cref="IPackage"/> matching the specified
        ///         <paramref name="fqn"/> and, if found, returns the found instance.
        ///     </para>
        ///     <para>
        ///         If a matching Package is not found, the <see cref="ScanPackages()"/> method is invoked to refresh the
        ///         <see cref="Packages"/> list from disk.
        ///     </para>
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the <see cref="IPackage"/> to find.</param>
        /// <returns>The found <see cref="IPackage"/>.</returns>
        IPackage FindPackage(string fqn);

        /// <summary>
        ///     <para>
        ///         Searches the <see cref="PackageArchives"/> list for a <see cref="IPackageArchive"/> matching the specified
        ///         <paramref name="fqn"/> and, if found, returns the found instance.
        ///     </para>
        ///     <para>
        ///         If a matching Package archive is not found, the <see cref="ScanPackageArchives()"/> method is invoked to
        ///         refresh the <see cref="PackageArchives"/> list from disk.
        ///     </para>
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the <see cref="IPackageArchive"/> to find.</param>
        /// <returns>The found <see cref="IPackageArchive"/>.</returns>
        IPackageArchive FindPackageArchive(string fqn);

        /// <summary>
        ///     <para>
        ///         Asynchronously searches the <see cref="PackageArchives"/> list for a <see cref="IPackageArchive"/> matching the
        ///         specified <paramref name="fqn"/> and, if found, returns the found instance.
        ///     </para>
        ///     <para>
        ///         If a matching Package archive is not found, the <see cref="ScanPackageArchives()"/> method is invoked to
        ///         refresh the <see cref="PackageArchives"/> list from disk.
        ///     </para>
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the <see cref="IPackageArchive"/> to find.</param>
        /// <returns>The found <see cref="IPackageArchive"/>.</returns>
        Task<IPackageArchive> FindPackageArchiveAsync(string fqn);

        /// <summary>
        ///     <para>
        ///         Asynchronously searches the <see cref="Packages"/> list for a <see cref="IPackage"/> matching the specified
        ///         <paramref name="fqn"/> and, if found, returns the found instance.
        ///     </para>
        ///     <para>
        ///         If a matching Package is not found, the <see cref="ScanPackages()"/> method is invoked to refresh the
        ///         <see cref="Packages"/> list from disk.
        ///     </para>
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the <see cref="IPackage"/> to find.</param>
        /// <returns>The found <see cref="IPackage"/>.</returns>
        Task<IPackage> FindPackageAsync(string fqn);

        /// <summary>
        ///     Installs the specified <paramref name="packageArchive"/>.
        /// </summary>
        /// <param name="packageArchive">The <see cref="IPackageArchive"/> to install.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        IResult InstallPackage(IPackageArchive packageArchive);

        /// <summary>
        ///     Installs the specified <paramref name="packageArchive"/> with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="packageArchive">The <see cref="IPackageArchive"/> to install.</param>
        /// <param name="options">The <see cref="PackageInstallationOptions"/> for the installation.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        IResult InstallPackage(IPackageArchive packageArchive, PackageInstallationOptions options);

        /// <summary>
        ///     Asynchronously installs the specified <paramref name="packageArchive"/>.
        /// </summary>
        /// <param name="packageArchive">The <see cref="IPackageArchive"/> to install.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Task<IResult> InstallPackageAsync(IPackageArchive packageArchive);

        /// <summary>
        ///     Asynchronously installs the specified <paramref name="packageArchive"/> with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="packageArchive">The <see cref="IPackageArchive"/> to install.</param>
        /// <param name="options">The <see cref="PackageInstallationOptions"/> for the installation.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Task<IResult> InstallPackageAsync(IPackageArchive packageArchive, PackageInstallationOptions options);

        /// <summary>
        ///     Scans for and returns a list of available <see cref="IPackageArchive"/> instances in the configured PackageArchive directory.
        /// </summary>
        /// <returns>
        ///     A Result containing the result of the operation and the list of found <see cref="IPackageArchive"/> s
        /// </returns>
        IResult<IList<IPackageArchive>> ScanPackageArchives();

        /// <summary>
        ///     Asynchronously scans for and returns a list of all <see cref="IPackageArchive"/> instances in the configured
        ///     PackageArchives directory.
        /// </summary>
        /// <returns>
        ///     A Result containing the result of the operation and the list of found <see cref="IPackageArchive"/> s.
        /// </returns>
        Task<IResult<IList<IPackageArchive>>> ScanPackageArchivesAsync();

        /// <summary>
        ///     Scans for and returns a list of installed <see cref="IPackage"/> instances in the configured Packages directory.
        /// </summary>
        /// <returns>A Result containing the result of the operation and the list of found <see cref="IPackage"/> s.</returns>
        IResult<IList<IPackage>> ScanPackages();

        /// <summary>
        ///     Asynchronously scans for and returns a list of installed <see cref="IPackage"/> instances in the configured
        ///     Packages directory.
        /// </summary>
        /// <returns>A Result containing the result of the operation and the list of found <see cref="IPackage"/> s.</returns>
        Task<IResult<IList<IPackage>>> ScanPackagesAsync();

        ///// <summary>
        /////     Uninstalls the specified <paramref name="package"/>.
        ///// </summary>
        ///// <param name="package">The <see cref="IPackage"/> to uninstall.</param>
        ///// <returns>A Result containing the result of the operation.</returns>
        //IResult UninstallPackage(IPackage package);

        ///// <summary>
        /////     Asynchronously uninstalls the specified <paramref name="package"/>.
        ///// </summary>
        ///// <param name="package">The <see cref="IPackage"/> to uninstall.</param>
        ///// <returns>A Result containing the result of the operation.</returns>
        //Task<IResult> UninstallPackageAsync(IPackage package);

        ///// <summary>
        /////     Verifies the <see cref="IPackageArchive"/> matching the specified <paramref name="fqn"/> using the specified <paramref name="publicKey"/>.
        ///// </summary>
        ///// <param name="fqn">The Fully Qualified Name of the <see cref="IPackageArchive"/> to verify.</param>
        ///// <param name="publicKey">The PGP Public Key with which to verify the package.</param>
        ///// <returns>
        /////     A Result containing the result of the operation and a value indicating whether the <see cref="IPackageArchive"/> is valid.
        ///// </returns>
        //IResult<bool> VerifyPackageArchive(string fqn, string publicKey);

        ///// <summary>
        /////     Verifies the <see cref="IPackageArchive"/> matching the specified <paramref name="fqn"/>.
        ///// </summary>
        ///// <param name="fqn">The Fully Qualified Name of the <see cref="IPackageArchive"/> to verify.</param>
        ///// <returns>
        /////     A Result containing the result of the operation and a value indicating whether the <see cref="IPackageArchive"/> is valid.
        ///// </returns>
        //IResult<bool> VerifyPackageArchive(string fqn);

        ///// <summary>
        /////     Verifies the specified <paramref name="packageArchive"/>.
        ///// </summary>
        ///// <param name="packageArchive">The <see cref="IPackageArchive"/> to verify.</param>
        ///// <returns>
        /////     A Result containing the result of the operation and a value indicating whether the <see cref="IPackageArchive"/> is valid.
        ///// </returns>
        //IResult<bool> VerifyPackageArchive(IPackageArchive packageArchive);

        ///// <summary>
        /////     Verifies the specified <paramref name="packageArchive"/> using the specified <paramref name="publicKey"/>.
        ///// </summary>
        ///// <param name="packageArchive">The <see cref="IPackageArchive"/> to verify.</param>
        ///// <param name="publicKey">The PGP Public Key with which to verify the package.</param>
        ///// <returns>
        /////     A Result containing the result of the operation and a value indicating whether the <see cref="IPackageArchive"/> is valid.
        ///// </returns>
        //IResult<bool> VerifyPackageArchive(IPackageArchive packageArchive, string publicKey);

        ///// <summary>
        /////     Asynchronously verifies the specified <paramref name="packageArchive"/> using the specified <paramref name="publicKey"/>.
        ///// </summary>
        ///// <param name="packageArchive">The <see cref="IPackageArchive"/> to verify.</param>
        ///// <param name="publicKey">The PGP Public Key with which to verify the package.</param>
        ///// <returns>
        /////     A Result containing the result of the operation and a value indicating whether the <see cref="IPackageArchive"/> is valid.
        ///// </returns>
        //Task<IResult<bool>> VerifyPackageArchiveAsync(IPackageArchive packageArchive, string publicKey);

        ///// <summary>
        /////     Asynchronously verifies the <see cref="IPackageArchive"/> matching the specified <paramref name="fqn"/> using the
        /////     specified <paramref name="publicKey"/>.
        ///// </summary>
        ///// <param name="fqn">The Fully Qualified Name of the <see cref="IPackageArchive"/> to verify.</param>
        ///// <param name="publicKey">The PGP Public Key with which to verify the package.</param>
        ///// <returns>
        /////     A Result containing the result of the operation and a value indicating whether the <see cref="IPackageArchive"/> is valid.
        ///// </returns>
        //Task<IResult<bool>> VerifyPackageArchiveAsync(string fqn, string publicKey);

        ///// <summary>
        /////     Asynchronously verifies the <see cref="IPackageArchive"/> matching the specified <paramref name="fqn"/>.
        ///// </summary>
        ///// <param name="fqn">The Fully Qualified Name of the <see cref="IPackageArchive"/> to verify.</param>
        ///// <returns>
        /////     A Result containing the result of the operation and a value indicating whether the <see cref="IPackageArchive"/> is valid.
        ///// </returns>
        //Task<IResult<bool>> VerifyPackageArchiveAsync(string fqn);

        ///// <summary>
        /////     Asynchronously verifies the specified <paramref name="packageArchive"/>.
        ///// </summary>
        ///// <param name="packageArchive">The <see cref="IPackageArchive"/> to verify.</param>
        ///// <returns>
        /////     A Result containing the result of the operation and a value indicating whether the <see cref="IPackageArchive"/> is valid.
        ///// </returns>
        //Task<IResult<bool>> VerifyPackageArchiveAsync(IPackageArchive packageArchive);

        #endregion Public Methods
    }
}