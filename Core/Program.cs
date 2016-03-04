using System;
using System.Linq;
using System.ServiceProcess;
using NLog;
using System.Reflection;
using Symbiote.Core.Platform;
using System.Timers;

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
        private static Logger logger = LogManager.GetCurrentClassLogger();

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
        /// <param name="args">Command line arguments.</param>
        internal static void Main(string[] args)
        {
            try
            {
                //-------------  - ------------ - -
                // reconfigure the logger based on the command line arguments.
                // valid values are "fatal" "error" "warn" "info" "debug" and "trace"
                // supplying any value will disable logging for any level beneath that level, from left to right as positioned above
                logger.Debug("Program started with " + (args.Length > 0 ? "arguments: " + string.Join(", ", args) : "no arguments."));

                args = new string[] { "debug" };
                if (args.Length > 0)
                {
                    logger.Debug("Reconfiguring logger to log level '" + args[0] + "'...");
                    Utility.SetLoggingLevel(args[0]);
                }
                //----------------------------------------------- - - ----------------  -- - -  - - - - - - -----         -

                logger.Info("Initializing...");

                //------------------ - - ----------- - - 
                // instantiate the Program Manager.
                // the Program Manager acts as a Service Locator for the application.
                logger.Info("Instantiating the Program Manager...");
                manager = ProgramManager.Instance();
                logger.Info("The Program Manager was instantiated successfully.");
                //-------------------------------  ------------------------ - - - --------------- - -

                //----------------------------------------------- - ------------  - - -
                // start the Platform Manager so we can get the platform details
                // the Platform Manager does not implement IConfigurable, allowing it to be started before the Configuration Manager
                logger.Info("Starting the Platform Manager...");
                manager.PlatformManager.Start();
                logger.Info("The Platform Manager was started successfully.");
                logger.Info("Platform: " + manager.PlatformManager.Platform.PlatformType.ToString() + " (" + manager.PlatformManager.Platform.Version + ")");
                //------------------- - -----------                      ------------- 

                //----------------------------------------- - ----------------
                // start the application
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
                //-------------------------------------------------------------------      -------------------------------------------  - -- - - -
            }
            catch (Exception ex)
            {
                logger.Error(ex, "The application failed to initialize.");
            }
        }

        /// <summary>
        /// Entry point for the application logic.
        /// </summary>
        /// <param name="args">Command line arguments, passed from Main().</param>
        internal static void Start(string[] args)
        {
            try
            {
                // start the program manager, which in turn will start each of the managers.
                manager.Start();


                logger.Info("Checking directories...");
                manager.PlatformManager.Platform.CheckApplicationDirectories(manager.Directories);
                
                //--------------------------- - -        -------  - -   - - -  - - - -
                // load the configuration.
                //      reads the saved configuration from the config file located in Symbiote.exe.config and deserializes the json within
                //--------------------------------------- - -  - --------            -------- -
                logger.Info("Loading configuration...");
                manager.ConfigurationManager.LoadConfiguration();
                logger.Info("Configuration loaded.");

                //--------------------------------------------- - - --------- ----  - -    -
                // load plugins.  
                //      populates the PluginAssemblies list in the Plugin Manager with the assemblies of all of the found and authorized plugins
                //----------------------------------------------------------------  --  ---         ------ - 
                logger.Info("Loading plugins...");
                manager.PluginManager.LoadPlugins("Plugins");
                logger.Info(manager.PluginManager.PluginAssemblies.Count() + " Plugin(s) loaded.");

                //--------------------- - --------------------- -  -
                // create plugin instances.
                //      instantiates each plugin instance defined within the configuration and configures it
                //--------------------------------------------- - -   -     -------  -     - - -  ---
                logger.Info("Creating plugin instances...");
                manager.PluginManager.InstantiatePlugins();
                logger.Info(manager.PluginManager.PluginInstances.Count() + " Plugin instance(s) created.");

                //------------------ - --           --          --  - -
                // create the platform connector plugin instance.
                //      instantiates the connector plugin and adds it to the PluginManager so that it can be treated as a regular plugin
                //------ - -      ---------------------- - -     ----------------------------- - - -
                manager.PlatformManager.Platform.InstantiateConnector("Platform");
                manager.PluginManager.PluginInstances.Add(manager.PlatformManager.Platform.Connector);

                //------------- - ----------------------- - - -------------------  -- - --- - 
                // instantiate the item model.
                //      builds and attaches the model stored within the configuration file to the Model Manager.
                //---------------------------- - --------- - - -  ---        ------- -  --------------  - --
                logger.Info("Attaching model...");
                Model.ModelBuildResult modelBuildResult = manager.ModelManager.BuildModel(manager.ConfigurationManager.Configuration.Model.Items);
                manager.ModelManager.AttachModel(modelBuildResult);
                logger.Info("Attached model.");

                //----------------------------------- - - --------  - -------- -  -   -  -           -
                // attach the Platform connector items to the model
                //------------------------------------------------------ -  -         -   - ------  - -         -  - - --
                // detatch anything in "Symbiote.System.Platform" that was loaded from the config file
                logger.Info("Detatching potentially stale Platform items...");
                manager.ModelManager.RemoveItem(manager.ModelManager.FindItem(manager.ProductName + ".System.Platform"));

                logger.Info("Attaching new Platform items...");

                // find or create the parent for the Platform items
                Item systemItem = manager.ModelManager.FindItem(manager.ProductName + ".System");
                if (systemItem == default(Item))
                    systemItem = manager.ModelManager.AddItem(new Item(manager.ProductName + ".System")).Result;

                // attach the Platform items to Symbiote.System
                manager.ModelManager.AttachItem(manager.PlatformManager.Platform.Connector.Browse(), systemItem, true);
                logger.Info("Attached Platform items to '" + systemItem.FQN + "'.");

                //---- - ----------------------------------------- - - ------------- --   
                // perform the auto-build of any plugin instances with auto-build enabled
                //----------------------------------------------------- --       -   -
                logger.Info("Executing auto build of plugins...");
                manager.PluginManager.PerformAutoBuild();
                logger.Info("Auto build complete");

                //----------------------------- - -       --
                // show 'em what they've won!
                //-------------------------------- --------- - -      -              -
                Utility.PrintLogo(logger);
                Utility.PrintItemChildren(logger, manager.ModelManager.Model, 0);

                //------------------- - - -------------- - --------------  -
                // start the app manager
                //-- - - - - ------------- - - - ---------------------- -          -
                logger.Info("Searching for Apps...");
                manager.AppManager.LoadConfiguration();
                manager.AppManager.LoadAppArchives();
                logger.Info("Apps loaded.");



                StartManager(manager.ServiceManager);
                StartManager(manager.EndpointManager);



                logger.Info(manager.ProductName + " is running.");

                Console.ReadLine();
            }
            catch (TargetInvocationException ex)
            {
                logger.Error(ex, "Unable to start the web server.  Is " + manager.ProductName + " running under an account with administrative privilege?");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Fatal error.");
            }
        }

        /// <summary>
        /// Exit point for the application logic.
        /// </summary>
        public static void Stop()
        {
            logger.Info(manager.ProductName + " is stopping.  Saving configuration...");

            try
            {
                if (manager.ModelManager.SaveModel().ResultCode != OperationResultCode.Failure)
                    manager.ConfigurationManager.SaveConfiguration();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error saving configuration.");
            }

            logger.Info("Configuration saved.");

            logger.Info(manager.ProductName + " stopped.");
        }

        private static void StartManager(IManager manager)
        {
            logger.Info("Starting " + manager.GetType().Name + "...");

            OperationResult retVal = manager.Start();

            if (retVal.ResultCode == OperationResultCode.Failure)
                throw new Exception("Failed to start " + manager.GetType().Name + "." + retVal.GetLastError());
            else
            {
                logger.Info(manager.GetType().Name + " started.");

                if (retVal.ResultCode == OperationResultCode.Warning)
                    retVal.LogAllMessages(logger, "Warn", "The following warnings were encountered during the operation:");
            }
        }

        #endregion

    }
}
