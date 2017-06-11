/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄
      █     ███    ███
      █     ███    ███    █████  ██████     ▄████▄     █████   ▄█████     ▄▄██▄▄▄
      █     ███    ███   ██  ██ ██    ██   ██    ▀    ██  ██   ██   ██  ▄█▀▀██▀▀█▄
      █   ▀█████████▀   ▄██▄▄█▀ ██    ██  ▄██        ▄██▄▄█▀   ██   ██  ██  ██  ██
      █     ███        ▀███████ ██    ██ ▀▀██ ███▄  ▀███████ ▀████████  ██  ██  ██
      █     ███          ██  ██ ██    ██   ██    ██   ██  ██   ██   ██  ██  ██  ██
      █    ▄████▀        ██  ██  ██████    ██████▀    ██  ██   ██   █▀   █  ██  █
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  The main Application class.
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
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.ServiceProcess;
using System.Text.RegularExpressions;
using NLog;
using NLog.xLogger;
using OpenIIoT.Core.Configuration;
using OpenIIoT.Core.Event;
using OpenIIoT.Core.Model;
using OpenIIoT.Core.Package;
using OpenIIoT.Core.Platform;
using OpenIIoT.Core.Plugin;
using OpenIIoT.Core.Service;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Common.Exceptions;
using OpenIIoT.SDK.Model;
using OpenIIoT.SDK.Platform;
using OpenIIoT.SDK.Plugin;
using OpenIIoT.SDK.Plugin.Connector;
using Utility.CommandLine;
using Utility.OperationResult;

namespace OpenIIoT.Core
{
    /// <summary>
    ///     The main Application class.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         <see cref="Main(string[])"/> first processes command line arguments, reconfiguring the logger to the specified
    ///         level and, if the -uninstall-service or -install-service arguments are specified, either installs or uninstalls the
    ///         Windows Service for the application. If the Windows Service is modified, the application exits following the modification.
    ///     </para>
    ///     <para>
    ///         Next, the <see cref="ApplicationManager"/> is instantiated. Lastly, the application is started in either
    ///         interactive or service mode, depending on how the application was started.
    ///     </para>
    ///     <para>
    ///         The application logic begins in <see cref="Start(string[])"/>, where the Application Manager is started, then the
    ///         <see cref="Startup"/> method is invoked to execute miscellaneous post-startup tasks that weren't appropriate at a
    ///         component level. Following the execution of <see cref="Startup"/>, <see cref="Console.ReadLine"/> is invoked to run
    ///         the application in perpetuity.
    ///     </para>
    ///     <para>
    ///         When the application is stopped, either by the enter key being pressed or by the service being stopped, the
    ///         <see cref="Stop()"/> method is invoked which invokes <see cref="Shutdown()"/> to execute miscellaneous pre-stop
    ///         tasks, then the <see cref="ApplicationManager"/> is stopped, which stops all managers and the application.
    ///     </para>
    ///     <para>
    ///         The field <see cref="managers"/> contains a list of the Manager Types for the application in the order in which
    ///         they are to be instantiated and started.
    ///     </para>
    /// </remarks>
    [ExcludeFromCodeCoverage]
    public class Program
    {
        #region Private Fields

        /// <summary>
        ///     The ApplicationManager for the application.
        /// </summary>
        private static IApplicationManager applicationManager;

        /// <summary>
        ///     The main logger for the application.
        /// </summary>
        private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        /// <summary>
        ///     The list of Managers for the application.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Each Manager must be listed in the order in which they are to be instantiated and started. The order will be
        ///         reversed when the application stops.
        ///     </para>
        ///     <para>Inter-Manager dependencies must be taken into consideration when determining the order.</para>
        /// </remarks>
        private static Type[] managers = new Type[]
        {
            typeof(PlatformManager),
            typeof(ConfigurationManager),
            typeof(EventManager),
            typeof(PluginManager),
            typeof(ModelManager),
            typeof(ServiceManager),
            typeof(PackageManager),
        };

        #endregion Private Fields

        /// <summary>
        ///     Gets or sets the logging level for the application.
        /// </summary>
        [Argument('l', "loglevel")]
        private static string LoggingLevel { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the Windows Service should be installed.
        /// </summary>
        [Argument('i', "install-service")]
        private static bool InstallService { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the Windows Service should be uninstalled.
        /// </summary>
        [Argument('u', "uninstall-service")]
        private static bool UninstallService { get; set; }

        #region Internal Methods

        /// <summary>
        ///     Main entry point for the application.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Responsible for instantiating the platform and determining whether to start the application as a Windows
        ///         service or console/interactive application.
        ///     </para>
        ///     <para>
        ///         The "-logLevel:*" argument is used to determine the logging level of the application. Acceptable values are:
        ///         <list type="bullet">
        ///             <item>
        ///                 <term>trace</term>
        ///                 <description>
        ///                     The lowest logging level. The output for this level is extremely verbose and only outputs to the
        ///                     log file.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>debug</term>
        ///                 <description>
        ///                     Basic debugging information. These messages will appear in the console if this level is enabled.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>info</term>
        ///                 <description>The default logging level; contains basic status information.</description>
        ///             </item>
        ///             <item>
        ///                 <term>warn</term>
        ///                 <description>Contains warning messages.</description>
        ///             </item>
        ///             <item>
        ///                 <term>error</term>
        ///                 <description>
        ///                     Contains error messages. Typically errors produced on this level will not stop the application.
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <term>fatal</term>
        ///                 <description>Fatal error messages; these errors stop the application.</description>
        ///             </item>
        ///         </list>
        ///         Note that the levels are additive; each level contains the messages associated with that level specifically as
        ///         well as all "higher" (more severe) levels.
        ///     </para>
        ///     <para>
        ///         The "-(un)install-service" argument is used to install or uninstall the Windows service. If either of these
        ///         arguments is used, the application performs the requested command and stops. Re-run the application omitting
        ///         the argument to start normally.
        ///     </para>
        ///     <para>
        ///         Any additional arguments will be discarded; the application does not check for, nor does it react to, arguments
        ///         other than those listed above.
        ///     </para>
        /// </remarks>
        /// <param name="args">Command line arguments.</param>
        /// <exception cref="ApplicationArgumentException">
        ///     Thrown when an error is encountered while parsing and applying command line arguments.
        /// </exception>
        /// <exception cref="ApplicationInitializationException">
        ///     Thrown when an error is encountered while initializing the program.
        /// </exception>
        internal static void Main(string[] args)
        {
            logger.EnterMethod(xLogger.Params((object)args));
            logger.Heading(LogLevel.Info, Assembly.GetExecutingAssembly().GetName().Name + " " + Assembly.GetExecutingAssembly().GetName().Version.ToString(), true);
            logger.Info("Initializing application...");

            try
            {
                // process the command line arguments used to start the application
                logger.Debug($"Program started with {(args.Length > 0 ? "arguments: " + string.Join(", ", args) : "no arguments.")}");

                // process the argument array. if the method returns true, the application should exit. this should only happen
                // when an argument is used to cause the application to perform a maintenance task, such as installing or
                // uninstalling the Windows service.
                if (ProcessArguments(args))
                {
                    // if we do anything with the service, do it then quit. don't start the application if either argument was used.
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    return;
                }

                // instantiate the Application Manager.
                logger.Heading(LogLevel.Debug, "Initialization");
                logger.Debug("Instantiating the Application Manager...");

                try
                {
                    applicationManager = ApplicationManager.Instantiate(managers);
                }
                catch (Exception ex)
                {
                    logger.Exception(ex);
                    throw new ApplicationInitializationException("Error instantiating the Program Manager.  See the inner exception for details.", ex);
                }

                logger.Debug("The Program Manager was instantiated successfully.");

                // determine whether the application is being run as a Windows service or as a console application and start
                // accordingly. it is possible to run Windows services on UNIX using mono-service, however this functionality is
                // currently TBD.
                if ((PlatformManager.GetPlatformType() == PlatformType.Windows) && (!Environment.UserInteractive))
                {
                    logger.Info("Starting the application in service mode...");
                    ServiceBase.Run(new WindowsService());
                }
                else
                {
                    logger.Info("Starting the application in interactive mode...");
                    Start(args);
                    Stop();
                }
            }
            catch (Exception ex)
            {
                logger.Fatal("The application encountered a fatal error.");
                logger.Exception(LogLevel.Fatal, ex);
            }
            finally
            {
                logger.ExitMethod();
            }
        }

        /// <summary>
        ///     Entry point for the application logic.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        /// <exception cref="ApplicationStartException">
        ///     Thrown when an exception is encountered while starting the application.
        /// </exception>
        internal static void Start(string[] args)
        {
            logger.EnterMethod(xLogger.Params((object)args), true);
            logger.Heading(LogLevel.Debug, "Startup");

            // this is the main try/catch for the application logic. If an unhandled exception is thrown anywhere in the
            // application it will be caught here and treated as a fatal error, stopping the application.
            try
            {
                // start the program manager.
                logger.SubHeading(LogLevel.Debug, applicationManager.ManagerName);
                logger.Info($"Starting the {applicationManager.ManagerName}...");

                IResult managerStartResult = applicationManager.Start();

                if (managerStartResult.ResultCode == ResultCode.Failure)
                {
                    throw new ApplicationStartException($"The {applicationManager.ManagerName} failed to start: {managerStartResult.GetLastError()}");
                }

                logger.Info($"{applicationManager.ManagerName} started.");
                logger.Info("Performing startup tasks...");

                Startup();

                logger.Info($"{applicationManager.ProductName} is running.");

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                logger.Exception(ex);
                throw new ApplicationStartException("Error starting the application.  See the inner exception for details.", ex);
            }
            finally
            {
                logger.ExitMethod(true);
            }
        }

        /// <summary>
        ///     Exit point for the application logic.
        /// </summary>
        /// <exception cref="ApplicationStopException">
        ///     Thrown when an exception is encountered while stopping the application.
        /// </exception>
        internal static void Stop()
        {
            Guid guid = logger.EnterMethod(true);

            try
            {
                // stop the program manager.
                logger.Heading(LogLevel.Debug, "Shutdown");
                logger.Info($"{applicationManager.ProductName} is stopping...");
                logger.Info("Performing shutdown tasks...");

                Shutdown();

                IResult managerStopResult = applicationManager.Stop(StopType.Shutdown);

                if (managerStopResult.ResultCode == ResultCode.Failure)
                {
                    throw new ApplicationStopException($"The Program Manager failed to stop: {managerStopResult.GetLastError()}");
                }

                logger.Info($"{applicationManager.ManagerName} stopped.");
                logger.Info($"{applicationManager.ProductName} stopped.");
            }
            catch (Exception ex)
            {
                logger.Exception(ex);
                throw new ApplicationStopException("Error stopping the application.  See the inner exception for details.", ex);
            }
            finally
            {
                logger.ExitMethod(true);
            }
        }

        #endregion Internal Methods

        #region Private Methods

        /// <summary>
        ///     Processes the command-line arguments passed to the application and performs the desired action(s).
        /// </summary>
        /// <param name="args">The arguments passed to the application on startup.</param>
        /// <returns>A value indicating whether the application should halt after processing.</returns>
        private static bool ProcessArguments(string[] args)
        {
            logger.EnterMethod(xLogger.Params(args));
            logger.Debug("Processing program arguments...");

            Arguments.Populate();

            bool retVal = false;

            if (InstallService ^ UninstallService)
            {
                logger.Info($"Attempting to {(InstallService ? "install" : "uninstall")} Windows Service...");

                if (InstallService)
                {
                    Utility.ModifyService("install");
                }
                else
                {
                    Utility.ModifyService("uninstall");
                }

                logger.Info($"Successfully {(InstallService ? "installed" : "uninstalled")} Windows Service.");
                retVal = true;
            }
            else if (InstallService && UninstallService)
            {
                throw new ArgumentException("The InstallService and UninstallService arguments can not be used at the same time.");
            }
            else
            {
                if (!string.IsNullOrEmpty(LoggingLevel))
                {
                    if (Regex.IsMatch(LoggingLevel, "^((?i)trace|debug|info|warn|error|fatal)$"))
                    {
                        // reconfigure the logger based on the command line arguments. valid values are "fatal" "error" "warn"
                        // "info" "debug" and "trace" supplying any value will disable logging for any level beneath that level,
                        // from left to right as positioned above
                        logger.Info($"Reconfiguring logger to log level '{LoggingLevel}'...");
                        Utility.SetLoggingLevel(LoggingLevel);
                        logger.Info("Successfully reconfigured logger.");
                    }
                    else
                    {
                        throw new ArgumentException("The value specified for the LogLevel argument is invalid.  Valid values are 'fatal', 'error', 'warn', 'info', 'debug', and 'trace'.");
                    }
                }
            }

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Performs miscellaneous shutdown tasks.
        /// </summary>
        /// <exception cref="ApplicationShutdownRoutineException">
        ///     Thrown when an exception is encountered while performing the program shutdown routine.
        /// </exception>
        private static void Shutdown()
        {
            Guid guid = logger.EnterMethod(true);

            try
            {
                // maybe later!?
            }
            catch (Exception ex)
            {
                logger.Exception(ex);
                throw new ApplicationShutdownRoutineException("Error encountered during the shutdown routine.  See the inner exception for details.", ex);
            }
            finally
            {
                logger.ExitMethod(guid);
            }
        }

        /// <summary>
        ///     Performs miscellaneous startup tasks.
        /// </summary>
        /// <exception cref="ApplicationStartupRoutineException">
        ///     Thrown when an exception is encountered while performing the program startup routine.
        /// </exception>
        private static void Startup()
        {
            Guid guid = logger.EnterMethod(true);

            try
            {
                // find the root item, or create it if it doesn't exist for some reason
                Item symItem = applicationManager.GetManager<IModelManager>().FindItem(applicationManager.InstanceName);
                if (symItem == default(Item))
                {
                    symItem = applicationManager.GetManager<IModelManager>().AddItem(new Item(applicationManager.InstanceName)).ReturnValue;
                }

                // attach all of the simulation items to the model
                applicationManager.GetManager<IModelManager>().AttachItem(((IConnector)applicationManager.GetManager<IPluginManager>().FindPluginInstance("Simulation")).Browse(), symItem);

                // show 'em what they've won!
                Utility.PrintLogo(logger);
                Utility.PrintModel(logger, applicationManager.GetManager<IModelManager>().Model, 0, null, true);
                Utility.PrintLogoFooter(logger);

                // subscribe to the datetime item
                Result subscribe = applicationManager.GetManager<IModelManager>().FindItem("OpenIIoT.Simulation.DateTime.Time").SubscribeToSource();
                subscribe = applicationManager.GetManager<IModelManager>().FindItem("OpenIIoT.Simulation.Binary.DynamicImage").SubscribeToSource();
                subscribe.LogResult(logger.Info);

                applicationManager.GetManager<IPluginManager>().FindPluginInstance("Simulation").Start();
            }
            catch (Exception ex)
            {
                logger.Exception(ex);
                throw new ApplicationStartupRoutineException("Error encountered during the startup routine.  See the inner exception for details.", ex);
            }
            finally
            {
                logger.ExitMethod(guid);
            }
        }

        #endregion Private Methods
    }
}