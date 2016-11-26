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
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      █
      █  The PlatformManager class manages the application platform, specifically, the platform-dependent elements of the system.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016 JP Dillingham (jp@dillingham.ws)
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

using NLog;
using NLog.xLogger;
using Symbiote.Core.SDK;
using Symbiote.Core.SDK.Platform;
using System;
using System.Collections.Generic;
using Utility.OperationResult;

namespace Symbiote.Core.Platform
{
    /// <summary>
    ///     The PlatformManager class manages the application platform, specifically, the platform-dependent elements of the system.
    /// </summary>
    public class PlatformManager : Manager, IPlatformManager
    {
        #region Private Fields

        /// <summary>
        ///     The Singleton instance of PlatformManager.
        /// </summary>
        private static PlatformManager instance;

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        new private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        ///     Private constructor, only called by Instance()
        /// </summary>
        /// <param name="manager">The ApplicationManager instance for the application.</param>
        private PlatformManager(IApplicationManager manager)
        {
            base.logger = logger;
            Guid guid = logger.EnterMethod();

            ManagerName = "Platform Manager";

            // register dependencies
            RegisterDependency<IApplicationManager>(manager);

            ChangeState(State.Initialized);

            logger.ExitMethod();
        }

        #endregion Private Constructors

        #region Public Properties

        /// <summary>
        ///     A Dictionary containing all of the application directories, loaded from the App.config.
        /// </summary>
        public IPlatformDirectories Directories { get; private set; }

        /// <summary>
        ///     The current platform.
        /// </summary>
        public IPlatform Platform { get; private set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Evaluates Environment.OSVersion.Platform to determine the current platform.
        /// </summary>
        /// <returns>A PlatformType enumeration corresponding to the current platform.</returns>
        public static PlatformType GetPlatformType()
        {
            int p = (int)Environment.OSVersion.Platform;
            return ((p == 4) || (p == 6) || (p == 128) ? PlatformType.UNIX : PlatformType.Windows);
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
        public static PlatformManager Instantiate(IApplicationManager manager)
        {
            if (instance == null)
                instance = new PlatformManager(manager);

            return instance;
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Result Shutdown(StopType stopType = StopType.Stop)
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Shutdown for '" + GetType().Name + "'...");
            Result retVal = new Result();

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        protected override Result Startup()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Startup for '" + GetType().Name + "'...");
            Result retVal = new Result();

            //-------- --
            // determine the platform and instantiate it
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
            //------------------- - -     -

            //-------- - - - -- - -
            // Populate the ProgramDirectories list
            logger.Debug("Loading application directories...");

            // fetch the directory list from .exe.config
            string directoryList = GetDirectories();

            // replace the pipe character placeholder with the platform specific directory separator
            directoryList = directoryList.Replace('|', System.IO.Path.DirectorySeparatorChar);

            Result<PlatformDirectories> loadDirectoryResult = PlatformDirectories.LoadDirectories(Platform, directoryList);

            if (loadDirectoryResult.ResultCode == ResultCode.Failure)
                throw new Exception("Failed to load application directory list: " + loadDirectoryResult.GetLastError());

            Directories = loadDirectoryResult.ReturnValue;
            loadDirectoryResult.LogResult(logger.Debug, "LoadDirectories");

            retVal.Incorporate(loadDirectoryResult);

            logger.Checkpoint("Directory configuration loaded", guid);
            //------------------------------------ - -

            //-------------------------- - - -               -
            // Check to ensure all directories exist.  If not, create them.
            logger.Debug("Checking directories...");
            Result checkResult = Directories.CheckDirectories();
            if (checkResult.ResultCode == ResultCode.Failure)
                throw new Exception("Failed to verify and/or create one or more required program directory: " + checkResult.GetLastError());

            checkResult.LogResult(logger.Debug, "CheckDirectories");

            retVal.Incorporate(checkResult);

            logger.Checkpoint("Directories validated", guid);
            //------------- - - -

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        ///     Retrieves the "Directories" setting from the app.config file, or the default value if the retrieval fails.
        /// </summary>
        /// <returns>The list of program directories.</returns>
        private static string GetDirectories()
        {
            return Utility.GetSetting(
                "Directories",
                @"{
                      &quot;Data&quot;:&quot;Data&quot;,
                      &quot;Archives&quot;:&quot;Data\|Archives&quot;,
                      &quot;Plugins&quot;:&quot;Plugins&quot;,
                      &quot;Temp&quot;:&quot;Data\|Temp&quot;,
		              &quot;Persistence&quot;:&quot;Data\|Persistence&quot;,
                      &quot;Web&quot;:&quot;Web&quot;,
                      &quot;Logs&quot;:&quot;Logs&quot;
                 }"
            );
        }

        #endregion Private Methods
    }

    /// <summary>
    ///     The Platform namespace abstracts the platform on which the app runs.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The primary purposes are to assist the application in determining the current platform (e.g. Windows or UNIX) and
    ///         to allow for platform dependent code such as file IO to be substituted at run time. This allows for a single
    ///         project that can be compiled and run on both Windows and UNIX systems with no programatic changes.
    ///     </para>
    ///     <para>
    ///         Each Platform type gets a folder (e.g. UNIX, Windows) and within that folder a derivation of Platform named as
    ///         "PlatformPlatform" where the first "Platform" is the name. Each Platform type is required to provide an
    ///         implementation of IConnector for the platform which returns statistical information about the hardware and OS
    ///         hosting the application. Of primary concern is CPU, Memory and Hard Disk usage.
    ///     </para>
    ///     <para>
    ///         Finally, the Platform Manager and PlatformDirectories class work together to ensure that the necessary directories
    ///         are present in the configured locations. If any directories are missing they are recreated at startup. The
    ///         app.exe.config file contains the definition for these directories. If the configuration file is missing any or all
    ///         of the programatically defined directories an exception will be thrown by the constructor of PlatformDirectories,
    ///         causing the initialization of the application to fail.
    ///     </para>
    /// </remarks>
    [System.Runtime.CompilerServices.CompilerGenerated]
    internal class NamespaceDoc
    { }
}