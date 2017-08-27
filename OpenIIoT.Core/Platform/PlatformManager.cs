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
      █
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NLog;
using NLog.xLogger;
using OpenIIoT.Core.Common;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Common.Discovery;
using OpenIIoT.SDK.Common.Exceptions;
using OpenIIoT.SDK.Platform;
using Utility.OperationResult;

namespace OpenIIoT.Core.Platform
{
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
        private static new xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

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

            // register dependencies
            RegisterDependency<IApplicationManager>(manager);

            // determine the platform and instantiate it
            switch (GetPlatformType())
            {
                case PlatformType.Windows:
                    Platform = new Windows.WindowsPlatform(LoadDirectories());
                    break;

                case PlatformType.UNIX:
                    Platform = new UNIX.UNIXPlatform(LoadDirectories());
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
        ///     Gets the current platform.
        /// </summary>
        [Discoverable]
        public IPlatform Platform { get; private set; }

        /// <summary>
        ///     Gets the settings for the Application.
        /// </summary>
        private IApplicationSettings Settings => Dependency<IApplicationManager>().Settings;

        #endregion Public Properties

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

            // Check to ensure all directories exist. If not, create them.
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

            IDictionary<string, string> directories = Platform.Directories.ToDictionary();

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

        /// <summary>
        ///     Retrieves a Dictionary of the settings within <see cref="IApplicationSettings"/> and their values.
        /// </summary>
        /// <returns>A Dictionary of the settings within <see cref="IApplicationSettings"/> and their values</returns>
        private IDictionary<string, string> GetDirectoryDictionary()
        {
            IDictionary<string, string> retVal = new Dictionary<string, string>();

            foreach (PropertyInfo p in Settings.GetType().GetProperties().Where(p => p.Name.StartsWith("Directory")))
            {
                string name = p.Name.Replace("Directory", string.Empty);
                string value = (string)p.GetValue(Settings);
                retVal.Add(p.Name.Replace("Directory", string.Empty), (string)p.GetValue(Settings));
            }

            return retVal;
        }

        /// <summary>
        ///     De-serializes the provided string to a dictionary containing the program directory names and paths, then creates an
        ///     instance of ProgramDirectories with it.
        /// </summary>
        /// <returns>
        ///     A Result containing the result of the operation along with a ProgramDirectories instance containing the directories.
        /// </returns>
        private Directories LoadDirectories()
        {
            logger.EnterMethod();
            Directories retVal = default(Directories);

            try
            {
                // try to set all of the directories from the deserialized config json. if anything goes wrong an exception will be
                // thrown and we'll handle it.
                retVal = new Directories(GetDirectoryDictionary());
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Debug, ex);
                throw new DirectoryConfigurationException("Exception encountered while parsing the directory configuration.  See inner exception for details.", ex);
            }
            finally
            {
                logger.ExitMethod(retVal);
            }

            return retVal;
        }

        #endregion Private Methods
    }
}