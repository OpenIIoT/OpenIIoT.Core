/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                         ▄▄▄▄███▄▄▄▄
      █     ███    ███                                                                       ▄██▀▀▀███▀▀▀██▄
      █     ███    ███  █         ▄█████      ██       ▄█████  ██████     █████    ▄▄██▄▄▄   ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████
      █     ███    ███ ██         ██   ██ ▀███████▄   ██   ▀█ ██    ██   ██  ██  ▄█▀▀██▀▀█▄  ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██
      █   ▀█████████▀  ██         ██   ██     ██  ▀  ▄██▄▄    ██    ██  ▄██▄▄█▀  ██  ██  ██  ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀
      █     ███        ██       ▀████████     ██    ▀▀██▀▀    ██    ██ ▀███████  ██  ██  ██  ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████
      █     ███        ██▌    ▄   ██   ██     ██      ██      ██    ██   ██  ██  ██  ██  ██  ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██
      █    ▄████▀      ████▄▄██   ██   █▀    ▄██▀     ██       ██████    ██  ██   █  ██  █    ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Manages the application platform, specifically, the platform-dependent elements of the system.
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

namespace OpenIIoT.Core.Platform
{
    using System;
    using System.Collections.Generic;
    using NLog.xLogger;
    using OpenIIoT.Core.Common;
    using OpenIIoT.SDK;
    using OpenIIoT.SDK.Common;
    using OpenIIoT.SDK.Common.Discovery;
    using OpenIIoT.SDK.Common.Exceptions;
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Platform;

    /// <summary>
    ///     Manages the application platform, specifically, the platform-dependent elements of the system.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The primary purposes of the are to assist the application in determining the current platform (e.g.
    ///         <see cref="Windows"/> or <see cref="UNIX"/>) and to allow for platform dependent code such as file IO to be
    ///         substituted at run time if necessary. This allows for a single project that can be compiled and run on both Windows
    ///         and UNIX systems with no programmatic changes.
    ///     </para>
    ///     <para>
    ///         The <see cref="Platform"/> property is set to an instance of the proper <see cref="IPlatform"/> implementation;
    ///         either <see cref="Windows.WindowsPlatform"/> or <see cref="UNIX.UNIXPlatform"/> . This implementation contains all
    ///         of the (potentially) platform specific methods, such as those used for file I/O.
    ///     </para>
    /// </remarks>
    [Discoverable]
    public class PlatformManager : Manager, IPlatformManager
    {
        #region Private Fields

        /// <summary>
        ///     The Singleton instance of PlatformManager.
        /// </summary>
        private static IPlatformManager instance;

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static new xLogger logger = xLogManager.GetCurrentClassxLogger();

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PlatformManager"/> class.
        /// </summary>
        /// <param name="manager">The ApplicationManager instance for the application.</param>
        private PlatformManager(IApplicationManager manager)
        {
            base.logger = logger;
            Guid guid = logger.EnterMethod();

            ManagerName = "Platform Manager";
            EventProviderName = GetType().Name;

            RegisterDependency<IApplicationManager>(manager);

            Settings = new PlatformSettings();
            Directories = new Directories(Settings);

            switch (GetPlatformType())
            {
                case PlatformType.Windows:
                    Platform = new Windows.WindowsPlatform();
                    break;

                case PlatformType.UNIX:
                    Platform = new UNIX.UNIXPlatform();
                    break;

                default:
                    throw new Exception("Unable to determine platform.  Environment.OSVersion.Platform: " + Environment.OSVersion.Platform.ToString());
            }

            ChangeState(State.Initialized);

            logger.ExitMethod();
        }

        #endregion Private Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the list of configured <see cref="IDirectories"/>.
        /// </summary>
        public IDirectories Directories { get; private set; }

        /// <summary>
        ///     Gets the current <see cref="IPlatform"/> .
        /// </summary>
        [Discoverable]
        public IPlatform Platform { get; private set; }

        #endregion Public Properties

        #region Private Properties

        /// <summary>
        ///     Gets or sets the settings for the Manager.
        /// </summary>
        private PlatformSettings Settings { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Evaluates Environment.OSVersion.Platform to determine the current platform.
        /// </summary>
        /// <returns>A PlatformType enumeration corresponding to the current platform.</returns>
        public static PlatformType GetPlatformType()
        {
            int p = (int)Environment.OSVersion.Platform;
            return (p == 4) || (p == 6) || (p == 128) ? PlatformType.UNIX : PlatformType.Windows;
        }

        /// <summary>
        ///     Instantiates and/or returns the PlatformManager instance.
        /// </summary>
        /// <remarks>
        ///     Invoked via reflection from ApplicationManager. The parameters are used to build an array of IManager parameters
        ///     which are then passed to this method. To specify additional dependencies simply insert them into the parameter list
        ///     for the method and they will be injected when the method is invoked.
        /// </remarks>
        /// <param name="manager">The ApplicationManager instance for the application.</param>
        /// <returns>The Singleton instance of PlatformManager.</returns>
        public static IPlatformManager Instantiate(IApplicationManager manager)
        {
            if (instance == null)
            {
                instance = new PlatformManager(manager);
            }

            return instance;
        }

        /// <summary>
        ///     Terminates Singleton instance of PlatformManager.
        /// </summary>
        public static void Terminate()
        {
            instance = null;
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     Implements the post-instantiation procedure for the <see cref="PlatformManager"/> class.
        /// </summary>
        /// <remarks>This method is invoked by the ApplicationManager following the instantiation of all program Managers.</remarks>
        /// <exception cref="ManagerSetupException">Thrown when an error is encountered during setup.</exception>
        protected override void Setup()
        {
        }

        /// <summary>
        ///     Implements the shutdown procedure for the <see cref="PlatformManager"/> class.
        /// </summary>
        /// <param name="stopType">The <see cref="StopType"/> enumeration corresponding to the nature of the stoppage.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override IResult Shutdown(StopType stopType = StopType.Stop)
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Shutdown for '" + GetType().Name + "'...");

            IResult retVal = new Result();

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        ///     Implements the startup procedure for the <see cref="PlatformManager"/> class.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        /// <exception cref="DirectoryException">Thrown when one or more application directories can not be verified.</exception>
        protected override IResult Startup()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Startup for '" + GetType().Name + "'...");
            IResult retVal = new Result();

            logger.Debug("Checking directories...");

            IResult checkResult = CheckDirectories();
            if (checkResult.ResultCode == ResultCode.Failure)
            {
                throw new DirectoryException("Failed to verify and/or create one or more required program directories: " + checkResult.GetLastError());
            }

            checkResult.LogResult(logger.Debug, "CheckDirectories");

            retVal.Incorporate(checkResult);

            logger.Checkpoint("Directories validated", guid);

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        ///     Check each of the directories in the internal directory list and ensures that they exist.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        private IResult CheckDirectories()
        {
            logger.EnterMethod();
            IResult retVal = new Result();

            IDictionary<string, string> directories = Directories.ToDictionary();

            foreach (string directory in directories.Keys)
            {
                if (!Platform.DirectoryExists(directories[directory]))
                {
                    retVal.Incorporate(Platform.CreateDirectory(directories[directory]));
                    retVal.AddWarning("The directory '" + directories[directory] + "' was missing and was recreated.");
                }
            }

            logger.ExitMethod(retVal);
            return retVal;
        }

        #endregion Private Methods
    }
}