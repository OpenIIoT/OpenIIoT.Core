/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █      ▄███████▄                                                                                  
      █     ███    ███                                                                                  
      █     ███    ███    █████  ██████     ▄████▄     █████   ▄█████     ▄▄██▄▄▄      ▄██████   ▄█████ 
      █     ███    ███   ██  ██ ██    ██   ██    ▀    ██  ██   ██   ██  ▄█▀▀██▀▀█▄    ██    ██   ██  ▀  
      █   ▀█████████▀   ▄██▄▄█▀ ██    ██  ▄██        ▄██▄▄█▀   ██   ██  ██  ██  ██    ██    ▀    ██     
      █     ███        ▀███████ ██    ██ ▀▀██ ███▄  ▀███████ ▀████████  ██  ██  ██    ██    ▄  ▀███████ 
      █     ███          ██  ██ ██    ██   ██    ██   ██  ██   ██   ██  ██  ██  ██    ██    ██    ▄  ██ 
      █    ▄████▀        ██  ██  ██████    ██████▀    ██  ██   ██   █▀   █  ██  █  ██ ██████▀   ▄████▀  
      █   
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █  
      █  The main application class.
      █  
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ 
                                                                                                   ██ 
                                                                                               ▀█▄ ██ ▄█▀ 
                                                                                                 ▀████▀   
                                                                                                   ▀▀                            */
using System;
using System.Linq;
using System.ServiceProcess;
using NLog;
using System.Reflection;
using Symbiote.Core.Platform;
using System.Text.RegularExpressions;
using Symbiote.Core.Plugin.Connector;
using Symbiote.Core.Model;
using System.Threading;
using Symbiote.Core.Plugin;
using Symbiote.Core.Configuration;
using Symbiote.Core.Service;

namespace Symbiote.Core
{
    /// <summary>
    /// The Core namespace contains all of the code relating to the core functions of the application.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc { }

    /// <summary>
    /// The main application class.
    /// </summary>
    public class Program
    {
        #region Variables

        /// <summary>
        /// The main logger for the application.
        /// </summary>
        private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        /// <summary>
        /// The ProgramManager for the application.
        /// </summary>
        private static ProgramManager manager;

        #endregion

        #region Static Methods

        /// <summary>
        /// Main entry point for the application.
        /// </summary>
        /// <remarks>
        ///     Responsible for instantiating the platform and determining whether to start  the application as a 
        ///     Windows service or console/interactive application.
        /// </remarks>
        /// <param name="args">
        ///     Command line arguments; the first value corresponds to the highest active 
        ///     logging level, e.g. "trace", "debug", "info", "warn", "error" and "fatal".
        /// </param>
        internal static void Main(string[] args)
        {
            // print a heading with the application name and version
            logger.Heading(LogLevel.Info, Assembly.GetExecutingAssembly().GetName().Name + " " + Assembly.GetExecutingAssembly().GetName().Version.ToString());

            logger.EnterMethod(xLogger.Params((object)args));

            try
            {
                #region Command Line Arguments

                // prepare a flag to pass to the ProgramManager initializer to indicate whether the application is starting in safe mode.
                // if the command line argument -safemode was used to start this application, this will be set to true.
                bool safeMode = false;

                //-------------  - ------------ - -
                // process the command line arguments used to start the application
                logger.Debug("Program started with " + (args.Length > 0 ? "arguments: " + string.Join(", ", args) : "no arguments."));

                if (args.Length > 0)
                {
                    // check to see if the application is being run in "safe mode"
                    string safemodearg = args.Where(a => Regex.IsMatch(a, "^(?i)(-safemode)$")).FirstOrDefault();
                    if (safemodearg != default(string))
                    {
                        // if the program was started with the -safemode option, disable certain functionality
                        logger.Info("Program started in safe mode.");
                        safeMode = true;
                    }

                    // check to see if logger arguments were supplied
                    string logarg = args.Where(a => Regex.IsMatch(a, "^((?i)-logLevel:)((?i)trace|debug|info|warn|error|fatal)$")).FirstOrDefault();
                    if (logarg != default(string))
                    {
                        // reconfigure the logger based on the command line arguments.
                        // valid values are "fatal" "error" "warn" "info" "debug" and "trace"
                        // supplying any value will disable logging for any level beneath that level, from left to right as positioned above
                        logger.Debug("Reconfiguring logger to log level '" + logarg.Split(':')[1] + "'...");
                        Utility.SetLoggingLevel(logarg.Split(':')[1]);
                        logger.Debug("Successfully reconfigured logger.");
                    }

                    // check to see if service install/uninstall arguments were supplied
                    string servicearg = args.Where(a => Regex.IsMatch(a, "^(?i)(-(un)?install-service)$")).FirstOrDefault();
                    if (servicearg != default(string))
                    {
                        string action = servicearg.Split('-')[1];
                        logger.Info("Attempting to " + action + " Windows Service...");

                        if (Utility.ModifyService(action))
                            logger.Info("Successfully " + action + "ed Windows Service.");
                        else
                            logger.Error("Failed to " + action + " Windows Service.");

                        // if we do anything with the service, do it then quit.  don't start the application if either argument was used.
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        return;
                    }
                }
                //----------------------------------------------- - - ----------------  -- - -  - - - - - - -----         -

                #endregion


                //------------------ - - ----------- - - 
                // instantiate the Program Manager.
                // the Program Manager acts as a Service Locator for the application.
                // all of the various IManager instances are instantiated (but not started) within the constructor of ProgramManager.
                logger.Heading(LogLevel.Debug, "Initialization");
                logger.Debug("Instantiating the Program Manager...");

                // invoke the Instance() method on ProgramManager to instantiate it.
                // provide a Type array containing each of the application Managers in the order in which they are to be instantiated/started.
                manager = ProgramManager.Instantiate(
                    new Type[] {
                        typeof(PlatformManager),
                        typeof(ConfigurationManager),
                        typeof(PluginManager),
                        typeof(ModelManager),
                        typeof(ServiceManager)
                    },
                    safeMode
                );

                logger.Debug("The Program Manager was instantiated successfully.");

                //Result managerResult = manager.Start();

                //if (managerResult.ResultCode == ResultCode.Failure)
                //    throw new Exception("Failed to start the Program Manager: " + managerResult.LastErrorMessage());
                //-------------------------------  ------------------------ - - - --------------- - -


                //----------------------------------------------- - ------------  - - -
                // start the Platform Manager so we can get the platform details
                // the Platform Manager does not implement IConfigurable, allowing it to be started before the Configuration Manager
                //logger.SubHeading(LogLevel.Debug, "Platform Manager");

                //Result<IManager> platformResult = manager.StartManager(manager.GetManager<PlatformManager>());

                //if (platformResult.ResultCode == ResultCode.Failure)
                //    throw new Exception("Failed to start the Platform Manager: " + platformResult.LastErrorMessage());
                //------------------- - -----------                      ------------- 


                //----------------------------------------- - ----------------
                // start the application.
                // if the platform is windows and it is not being run as an interactive application, Windows 
                // is trying to start it as a service, so instantiate the service.  Otherwise launch it as a normal console application.
                ///logger.Heading(LogLevel.Debug, "Startup");

                ///logger.Info("The Program is running " + (Environment.UserInteractive ? "" : "non-") + "interactively.");

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
                //-------------------------------------------------------------------------------------------------------------- ---- - -
            }
            catch (Exception ex)
            {
                logger.Fatal("The application failed to initialize.");
                logger.Exception(LogLevel.Fatal, ex);
            }
            finally
            {
                logger.ExitMethod();
            }
        }

        /// <summary>
        /// Entry point for the application logic.
        /// </summary>
        /// <param name="args">Command line arguments, passed from Main().</param>
        internal static void Start(string[] args)
        {
            logger.EnterMethod(xLogger.Params((object)args));

            logger.Heading(LogLevel.Debug, "Startup");
            // this is the main try/catch for the application logic.  If an unhandled exception is thrown
            // anywhere in the application it will be caught here and treated as a fatal error, stopping the application.
            try
            {
                //- - - - ------- -   --------------------------- - ---------------------  -    -
                // start the program manager.
                logger.SubHeading(LogLevel.Debug, "Program Manager");
                logger.Info("Invoking the Program Manager Start routine...");
                Result managerStartResult = manager.StartManager(manager);

                if (managerStartResult.ResultCode == ResultCode.Failure)
                    throw new Exception("The Program Manager failed to start: " + managerStartResult.LastErrorMessage());

                logger.Info("Program Manager Started.");
                //----------- - -


                ////--------------------------- - -        -------  - -   - - -  - - - -
                //// load the configuration.
                //// reads the saved configuration from the config file located in Symbiote.exe.config and deserializes the json within
                //logger.SubHeading(LogLevel.Debug, "Configuration Manager");
                //logger.Info("Invoking the Configuration Manager Start routine...");
                //manager.StartManager(manager.GetManager<ConfigurationManager>());
                //logger.Info("Loaded Configuration from '" + manager.GetManager<ConfigurationManager>().ConfigurationFileName + "'.");
                ////--------------------------------------- - -  - --------            -------- -


                ////--------------------------------------------- - - --------- ----  - -    -
                //// load plugins.  
                //// populates the PluginAssemblies list in the Plugin Manager with the assemblies of all of the found and authorized plugins
                //logger.SubHeading(LogLevel.Debug, "Plugin Manager");
                //logger.Info("Invoking the Plugin Manager Start routine...");
                //manager.StartManager(manager.GetManager<PluginManager>());
                //logger.Info(manager.GetManager<PluginManager>().PluginAssemblies.Count() + " Plugin(s) loaded.");
                ////----------------------------------------------------------------  --  ---         ------ - 

                //------------------ - --           --          --  - -
                // create the platform connector plugin instance.
                // instantiates the connector plugin and adds it to the PluginManager so that it can be treated as a regular plugin
                //manager.GetManager<PlatformManager>().Platform.InstantiateConnector("Platform");
                //manager.GetManager<PluginManager>().PluginInstances.Add("Platform", manager.GetManager<PlatformManager>().Platform.Connector);
                //------ - -      ---------------------- - -     ----------------------------- - - -

                logger.Multiline(LogLevel.Debug, "MODEL");

                //------------- - ----------------------- - - -------------------  -- - --- - 
                // instantiate the item model.
                // builds and attaches the model stored within the configuration file to the Model Manager.
                //manager.StartManager(manager.GetManager<ModelManager>());
                //logger.Info(manager.GetManager<ModelManager>().Dictionary.Count + " Item(s) resolved.");

                //---------------------------- - --------- - - -  ---        ------- -  --------------  - --

                logger.Multiline(LogLevel.Debug, "PLATFORM ITEMS");

                //----------------------------------- - - --------  - -------- -  -   -  -           -
                // attach the Platform connector items to the model
                // detatch anything in "Symbiote.System.Platform" that was loaded from the config file
                logger.Info("Detatching potentially stale Platform items...");
                manager.GetManager<ModelManager>().RemoveItem(manager.GetManager<ModelManager>().FindItem(manager.InstanceName + ".System.Platform"));

                logger.Info("Attaching new Platform items...");

                // find or create the parent for the Platform items
                Item systemItem = manager.GetManager<ModelManager>().FindItem(manager.InstanceName + ".System");
                if (systemItem == default(Item))
                    systemItem = manager.GetManager<ModelManager>().AddItem(new Item(manager.InstanceName + ".System")).ReturnValue;

                // attach the Platform items to Symbiote.System
                manager.GetManager<ModelManager>().AttachItem(manager.GetManager<PlatformManager>().Platform.Connector.Browse(), systemItem);
                logger.Info("Attached Platform items to '" + systemItem.FQN + "'.");
                //------------------------------------------------------ -  -         -   - ------  - -         -  - - --


                Item symItem = manager.GetManager<ModelManager>().FindItem(manager.InstanceName);
                if (symItem == default(Item))
                    symItem = manager.GetManager<ModelManager>().AddItem(new Item(manager.InstanceName)).ReturnValue;


                //----------------------------- - -       --
                // show 'em what they've won!
                Utility.PrintLogo(logger);
                Utility.PrintModel(logger, manager.GetManager<ModelManager>().Model, 0);
                //-------------------------------- --------- - -      -              -

                manager.StartManager(manager.GetManager<ServiceManager>());

                //manager.PluginManager.StartPlugins();

                logger.Info(manager.ProductName + " is running.");

                //FQNResolver.Resolve(manager.InstanceName + ".Simulation.Process.Ramp").SubscribeToSource();
                //FQNResolver.Resolve(manager.InstanceName + ".Simulation.DateTime.Time").SubscribeToSource();
                //FQNResolver.Resolve(manager.InstanceName + ".Simulation.Motor").SubscribeToSource();

                //manager.RenameInstance("Symbiote2");

                //Utility.PrintModel(logger, manager.ModelManager.Model, 0);

                //Item test = FQNResolver.Resolve("Symbiote.AddTest");

                //Task<Result> writeTask = test.WriteAsync("Hello World!");
                //Result writeResult = writeTask.ReturnValue;

                //writeResult.LogResult(logger);

                manager.GetManager<PluginManager>().Stop(StopType.Abnormal, true);

                Console.ReadLine();
            }
            catch (TargetInvocationException ex)
            {
                logger.Fatal(ex, "Unable to start the web server.  Is " + manager.ProductName + " running under an account with administrative privilege?");
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Fatal, ex);
                if (!Environment.UserInteractive) throw;
            }
            finally
            {
                logger.ExitMethod();
            }
        }

        private static void PluginStateChanged(object sender, StateChangedEventArgs e)
        {
            logger.Info("Plugin " + ((IPluginInstance)sender).InstanceName + "state changed from " + e.PreviousState + " to "  + e.State + " (" + e.Message + ")");
        }

        /// <summary>
        /// Exit point for the application logic.
        /// </summary>
        public static void Stop()
        {
            logger.EnterMethod();
            logger.Info(manager.ProductName + " is stopping.  Saving configuration...");

            try
            {
                manager.Stop();
                logger.Info(manager.ProductName + " stopped.");
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Error, ex);
            }
            finally
            {
                logger.ExitMethod();
            }
        }

        #endregion
    }
}
