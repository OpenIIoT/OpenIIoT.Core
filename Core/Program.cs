﻿using System;
using System.Linq;
using System.ServiceProcess;
using NLog;
using System.Reflection;
using Symbiote.Core.Platform;
using System.Text.RegularExpressions;

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
        /// Responsible for instantiating the platform, and determining whether to start
        /// the application as a Windows service or console/interactive application.
        /// </remarks>
        /// <param name="args">
        /// Command line arguments; the first value corresponds to the highest active 
        /// logging level, e.g. "trace", "debug", "info", "warn", "error" and "fatal".
        /// </param>
        internal static void Main(string[] args)
        {
            logger.Marquee(logger.Info, Assembly.GetExecutingAssembly().GetName().Name + " " + Assembly.GetExecutingAssembly().GetName().Version.ToString());

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
                logger.Debug("Instantiating the Program Manager...");
                manager = ProgramManager.Instance(safeMode);
                logger.Debug("The Program Manager was instantiated successfully.");
                //-------------------------------  ------------------------ - - - --------------- - -


                //----------------------------------------------- - ------------  - - -
                // start the Platform Manager so we can get the platform details
                // the Platform Manager does not implement IConfigurable, allowing it to be started before the Configuration Manager
                logger.Separator(logger.Debug);
                logger.Debug("Starting the Platform Manager...");
                manager.StartManager(manager.PlatformManager);
                logger.Info("Platform: " + manager.PlatformManager.Platform.PlatformType.ToString() + " (" + manager.PlatformManager.Platform.Version + ")");
                //------------------- - -----------                      ------------- 


                //----------------------------------------- - ----------------
                // start the application
                logger.Separator(logger.Debug);
                logger.Checkpoint("Application start");

                // if the platform is windows and it is not being run as an interactive application, Windows 
                // is trying to start it as a service, so instantiate the service.  Otherwise launch it as a normal console application.
                if ((manager.PlatformManager.Platform.PlatformType == PlatformType.Windows) && (!Environment.UserInteractive))
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
                logger.Fatal(ex, "The application failed to initialize.");
                logger.Exception(ex);
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

            // this is the main try/catch for the application logic.  If an unhandled exception is thrown
            // anywhere in the application it will be caught here and treated as a fatal error, stopping the application.
            try
            {


                //- - - - ------- -   --------------------------- - ---------------------  -    -
                // start the program manager.
                logger.Marquee(logger.Debug, "Startup");
                manager.StartManager(manager);
                // set the Starting property to true so that other components can suppress logging messages during startup
                manager.Starting = true;
                //----------- - -


                //--------------------------- - -        -------  - -   - - -  - - - -
                // load the configuration.
                // reads the saved configuration from the config file located in Symbiote.exe.config and deserializes the json within
                logger.Marquee(logger.Debug, "Configuration");
                manager.StartManager(manager.ConfigurationManager);
                logger.Info("Loaded Configuration from '" + manager.ConfigurationFileName + "'.");
                //--------------------------------------- - -  - --------            -------- -


                //--------------------------------------------- - - --------- ----  - -    -
                // load plugins.  
                // populates the PluginAssemblies list in the Plugin Manager with the assemblies of all of the found and authorized plugins
                logger.Marquee(logger.Debug, "Plugins");
                manager.StartManager(manager.PluginManager);
                logger.Info("Loading plugins...");
                manager.PluginManager.LoadPlugins();
                logger.Info(manager.PluginManager.PluginAssemblies.Count() + " Plugin(s) loaded.");
                //----------------------------------------------------------------  --  ---         ------ - 

                return;
                //--------------------- - --------------------- -  -
                // create plugin instances.
                // instantiates each plugin instance defined within the configuration and configures it
                logger.Info("Creating plugin instances...");
                manager.PluginManager.InstantiatePlugins();
                logger.Info(manager.PluginManager.PluginInstances.Count() + " Plugin instance(s) created.");
                //--------------------------------------------- - -   -     -------  -     - - -  ---


                //------------------ - --           --          --  - -
                // create the platform connector plugin instance.
                // instantiates the connector plugin and adds it to the PluginManager so that it can be treated as a regular plugin
                manager.PlatformManager.Platform.InstantiateConnector("Platform");
                manager.PluginManager.PluginInstances.Add("Platform", manager.PlatformManager.Platform.Connector);
                //------ - -      ---------------------- - -     ----------------------------- - - -

                logger.Multiline(logger.Debug, "MODEL");

                //------------- - ----------------------- - - -------------------  -- - --- - 
                // instantiate the item model.
                // builds and attaches the model stored within the configuration file to the Model Manager.
                manager.StartManager(manager.ModelManager);
                logger.Info(manager.ModelManager.Dictionary.Count + " Item(s) resolved.");

                //---------------------------- - --------- - - -  ---        ------- -  --------------  - --

                logger.Multiline(logger.Debug, "PLATFORM ITEMS");

                //----------------------------------- - - --------  - -------- -  -   -  -           -
                // attach the Platform connector items to the model
                // detatch anything in "Symbiote.System.Platform" that was loaded from the config file
                logger.Info("Detatching potentially stale Platform items...");
                manager.ModelManager.RemoveItem(manager.ModelManager.FindItem(manager.InstanceName + ".System.Platform"));

                logger.Info("Attaching new Platform items...");

                // find or create the parent for the Platform items
                Item systemItem = manager.ModelManager.FindItem(manager.InstanceName + ".System");
                if (systemItem == default(Item))
                    systemItem = manager.ModelManager.AddItem(new Item(manager.InstanceName + ".System")).Result;

                // attach the Platform items to Symbiote.System
                manager.ModelManager.AttachItem(manager.PlatformManager.Platform.Connector.Browse(), systemItem);
                logger.Info("Attached Platform items to '" + systemItem.FQN + "'.");
                //------------------------------------------------------ -  -         -   - ------  - -         -  - - --

                logger.Multiline(logger.Debug, "AUTOBUILDS");

                //---- - ----------------------------------------- - - ------------- --   
                // perform the auto-build of any plugin instances with auto-build enabled
                logger.Info("Executing auto build of plugins...");
                OperationResult autoBuildResult = manager.PluginManager.PerformAutoBuild();
                autoBuildResult.LogResult(logger);
                //----------------------------------------------------- --       -   -


                //----------------------------- - -       --
                // show 'em what they've won!
                Utility.PrintLogo(logger);
                Utility.PrintModel(logger, manager.ModelManager.Model, 0);
                //-------------------------------- --------- - -      -              -

                manager.StartManager(manager.ServiceManager);

                manager.PluginManager.StartPlugins();

                logger.Info(manager.ProductName + " is running.");
                manager.Starting = false;

                //FQNResolver.Resolve(manager.InstanceName + ".Simulation.Process.Ramp").SubscribeToSource();
                //FQNResolver.Resolve(manager.InstanceName + ".Simulation.DateTime.Time").SubscribeToSource();
                //FQNResolver.Resolve(manager.InstanceName + ".Simulation.Motor").SubscribeToSource();

                //manager.RenameInstance("Symbiote2");

                Utility.PrintModel(logger, manager.ModelManager.Model, 0);

                //Item test = FQNResolver.Resolve("Symbiote.AddTest");

                //Task<OperationResult> writeTask = test.WriteAsync("Hello World!");
                //OperationResult writeResult = writeTask.Result;

                //writeResult.LogResult(logger);

                Console.ReadLine();
            }
            catch (TargetInvocationException ex)
            {
                logger.Fatal(ex, "Unable to start the web server.  Is " + manager.ProductName + " running under an account with administrative privilege?");
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "Fatal error.");
                logger.Exception(ex);
                if (!Environment.UserInteractive) throw;
            }
            finally
            {
                logger.ExitMethod();
            }
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
                if (manager.ModelManager.SaveModel().ResultCode != OperationResultCode.Failure)
                    manager.ConfigurationManager.SaveConfiguration();

                logger.Info("Configuration saved.");
                logger.Info(manager.ProductName + " stopped.");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error saving configuration.");
            }
            finally
            {
                logger.ExitMethod();
            }
        }

        public static void Test(string arg)
        {
            //Logger logger = new Logger();

            //Guid guid = MethodLogger.Enter(MethodLogger.Params(arg), true);

            //logger.Trace("some messages");

            //MethodLogger.Checkpoint();
            //MethodLogger.Checkpoint(logger);

            //MethodLogger.Checkpoint(guid);
            //MethodLogger.Checkpoint(logger, guid);

            //MethodLogger.Checkpoint(MethodLogger.Vars(arg, arg));
            //MethodLogger.Checkpoint(logger, MethodLogger.Vars(arg, arg));
            //MethodLogger.Checkpoint(logger, MethodLogger.Vars(arg, arg), guid);

            //MethodLogger.Checkpoint(MethodLogger.Vars(arg, arg), MethodLogger.Names("one", "two"));
            //MethodLogger.Checkpoint(logger, MethodLogger.Params(arg, arg), MethodLogger.Names("one", "two"));
            //MethodLogger.Checkpoint(logger, MethodLogger.Params(arg, arg), MethodLogger.Names("one", "two"), guid);

            //MethodLogger.Checkpoint(MethodLogger.Params(arg, arg), MethodLogger.Names("one", "two"), guid);



            //logger.Trace("-------------------------------------------------------------------");

            //MethodLogger.Exception(logger, new Exception(), guid);

            Guid guid = logger.EnterMethod(true);
            logger.Checkpoint(xLogger.Vars(arg, arg), xLogger.Names("one", "two"), guid);

            //try
            //{
            //    throw new Exception("Some exception");
            //}
            //catch(Exception ex)
            //{
            //    logger.Exception(ex, xLogger.Vars(guid), xLogger.Names("guid"), guid);
            //}
            logger.StackTrace();


            logger.ExitMethod(guid);
        }
        #endregion
    }
}