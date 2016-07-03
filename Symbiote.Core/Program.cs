using System;
using System.Linq;
using System.ServiceProcess;
using NLog;
using System.Reflection;
using Symbiote.Core.Platform;
using System.Text.RegularExpressions;
using Symbiote.Core.Plugin.Connector;
using Symbiote.Core.Model;

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
                manager = ProgramManager.Instance(safeMode);
                logger.Debug("The Program Manager was instantiated successfully.");
                //-------------------------------  ------------------------ - - - --------------- - -


                //----------------------------------------------- - ------------  - - -
                // start the Platform Manager so we can get the platform details
                // the Platform Manager does not implement IConfigurable, allowing it to be started before the Configuration Manager
                logger.SubHeading(LogLevel.Debug, "Platform Manager");
                logger.Info("Starting the Platform Manager...");
                manager.StartManager(manager.PlatformManager);
                logger.Info("Platform: " + manager.PlatformManager.Platform.PlatformType.ToString() + " (" + manager.PlatformManager.Platform.Version + ")");
                logger.Info("Program is running " + (Environment.UserInteractive ? "" : "non-") + "interactively.");
                //------------------- - -----------                      ------------- 


                //----------------------------------------- - ----------------
                // start the application.
                // if the platform is windows and it is not being run as an interactive application, Windows 
                // is trying to start it as a service, so instantiate the service.  Otherwise launch it as a normal console application.
                logger.Heading(LogLevel.Debug, "Startup");

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

            // this is the main try/catch for the application logic.  If an unhandled exception is thrown
            // anywhere in the application it will be caught here and treated as a fatal error, stopping the application.
            try
            {
                //- - - - ------- -   --------------------------- - ---------------------  -    -
                // start the program manager.
                logger.SubHeading(LogLevel.Debug, "Program Manager");
                logger.Info("Invoking the Program Manager Start routine...");
                manager.StartManager(manager);
                logger.Info("Program Manager Started.");
                //----------- - -


                //--------------------------- - -        -------  - -   - - -  - - - -
                // load the configuration.
                // reads the saved configuration from the config file located in Symbiote.exe.config and deserializes the json within
                logger.SubHeading(LogLevel.Debug, "Configuration Manager");
                logger.Info("Invoking the Configuration Manager Start routine...");
                manager.StartManager(manager.ConfigurationManager);
                logger.Info("Loaded Configuration from '" + manager.ConfigurationFileName + "'.");
                //--------------------------------------- - -  - --------            -------- -


                //--------------------------------------------- - - --------- ----  - -    -
                // load plugins.  
                // populates the PluginAssemblies list in the Plugin Manager with the assemblies of all of the found and authorized plugins
                logger.SubHeading(LogLevel.Debug, "Plugin Manager");
                logger.Info("Invoking the Plugin Manager Start routine...");
                manager.StartManager(manager.PluginManager);
                logger.Info(manager.PluginManager.PluginAssemblies.Count() + " Plugin(s) loaded.");
                //----------------------------------------------------------------  --  ---         ------ - 


                //--------------------- - --------------------- -  -
                // create plugin instances.
                // instantiates each plugin instance defined within the configuration and configures it
                //logger.Info("Creating plugin instances...");
                //manager.PluginManager.InstantiatePlugins();
                //logger.Info(manager.PluginManager.PluginInstances.Count() + " Plugin instance(s) created.");
                //--------------------------------------------- - -   -     -------  -     - - -  ---


                //------------------ - --           --          --  - -
                // create the platform connector plugin instance.
                // instantiates the connector plugin and adds it to the PluginManager so that it can be treated as a regular plugin
                manager.PlatformManager.Platform.InstantiateConnector("Platform");
                manager.PluginManager.PluginInstances.Add("Platform", manager.PlatformManager.Platform.Connector);
                //------ - -      ---------------------- - -     ----------------------------- - - -

                logger.Multiline(LogLevel.Debug, "MODEL");

                //------------- - ----------------------- - - -------------------  -- - --- - 
                // instantiate the item model.
                // builds and attaches the model stored within the configuration file to the Model Manager.
                manager.StartManager(manager.ModelManager);
                logger.Info(manager.ModelManager.Dictionary.Count + " Item(s) resolved.");

                //---------------------------- - --------- - - -  ---        ------- -  --------------  - --

                logger.Multiline(LogLevel.Debug, "PLATFORM ITEMS");

                //----------------------------------- - - --------  - -------- -  -   -  -           -
                // attach the Platform connector items to the model
                // detatch anything in "Symbiote.System.Platform" that was loaded from the config file
                logger.Info("Detatching potentially stale Platform items...");
                manager.ModelManager.RemoveItem(manager.ModelManager.FindItem(manager.InstanceName + ".System.Platform"));

                logger.Info("Attaching new Platform items...");

                // find or create the parent for the Platform items
                Item systemItem = manager.ModelManager.FindItem(manager.InstanceName + ".System");
                if (systemItem == default(Item))
                    systemItem = manager.ModelManager.AddItem(new Item(manager.InstanceName + ".System")).ReturnValue;

                // attach the Platform items to Symbiote.System
                manager.ModelManager.AttachItem(manager.PlatformManager.Platform.Connector.Browse(), systemItem);
                logger.Info("Attached Platform items to '" + systemItem.FQN + "'.");
                //------------------------------------------------------ -  -         -   - ------  - -         -  - - --

                //((IAddable)manager.PluginManager.FindPluginInstance("Simulation")).Add("One.Two.Three.Four.Five", "fart");
                //((IAddable)manager.PluginManager.FindPluginInstance("Simulation")).Add("One.Two.Three.ThreeThree.ThreeThreeThree", "fart");




                //Item symItem = manager.ModelManager.FindItem(manager.InstanceName);
                //if (symItem == default(Item))
                //    symItem = manager.ModelManager.AddItem(new Item(manager.InstanceName)).ReturnValue;

                //manager.ModelManager.AttachItem(((IConnector)manager.PluginManager.FindPluginInstance("Simulation")).Browse(), symItem);


                //Result subscribe = manager.ModelManager.FindItem("Symbiote.Simulation.DateTime.Time").SubscribeToSource();

                //subscribe.LogResult(logger.Info);

                //Result subscribe2 = manager.ModelManager.FindItem("Symbiote.Simulation.Process.Ramp").SubscribeToSource();

                //subscribe2.LogResult(logger.Info);

                //logger.Info("Starting Simulation Connector...");
                //manager.PluginManager.FindPluginInstance("Simulation").Start();

                ////-------------------------------------------------------------------------------------------------

                //IConnector example = (IConnector)manager.PluginManager.FindPluginInstance("Example");


                // ((IAddable)example).Add("New.Item", "None");

                //manager.ModelManager.AttachItem(example.Browse(), symItem);

     

                //Result subscribe3 = manager.ModelManager.FindItem("Symbiote.Example.CurrentTime").SubscribeToSource();

                //subscribe3.LogResult(logger.Info);

                //example.Start().LogResult(logger.Info) ;

                //----------------------------- - -       --
                // show 'em what they've won!
                Utility.PrintLogo(logger);
                Utility.PrintModel(logger, manager.ModelManager.Model, 0);
                //-------------------------------- --------- - -      -              -

                manager.StartManager(manager.ServiceManager);

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

        /// <summary>
        /// Exit point for the application logic.
        /// </summary>
        public static void Stop()
        {
            logger.EnterMethod();
            logger.Info(manager.ProductName + " is stopping.  Saving configuration...");

            try
            {
                if (manager.ModelManager.SaveModel().ResultCode != ResultCode.Failure)
                    manager.ConfigurationManager.SaveConfiguration();

                logger.Info("Configuration saved.");
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
