
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using NLog;
using System.Reflection;
using Symbiote.Core.Platform;
using Symbiote.Core.Plugin;
using System.Timers;
using Microsoft.Owin.Hosting;

namespace Symbiote.Core
{
    /// <summary>
    /// The Core namespace contains all of the code relating to the core functions of the application.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc { }

    /// <summary>
    /// Main application class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main logger for the application.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static Timer printTimer;

        /// <summary>
        /// The ProgramManager for the application.
        /// </summary>
        private static ProgramManager manager;

        /// <summary>
        /// Main entry point for the application.
        /// </summary>
        /// <remarks>
        /// Responsible for instantiating the platform, and determining whether to start
        /// the application as a Windows service or console/interactive application.
        /// </remarks>
        /// <param name="args">Command line arguments.</param>
        static void Main(string[] args)
        {
            logger.Trace("Program started with arguments: " + string.Join(", ", args));
            
            if (args.Length > 0)
            {
                logger.Trace("Reconfiguring logger to log level '" + args[0] + "'...");
                SetLoggingLevel(args[0]);
            }
            
            // TODO: put everything in one try/catch, catch and print individual exceptions
            logger.Info("Initializing...");

            // instantiate the program manager.
            // the program manager acts as a Service Locator for the symbiote core.
            logger.Trace("Instantiating the program manager...");
            try
            {
                manager = ProgramManager.Instance();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "the application failed to initailize.");
                return;
            }
            logger.Trace("The program manager was instantiated successfully.");


            // instantiate the platform.
            logger.Trace("Instantiating the platform...");
            try
            {
                manager.PlatformManager.Start();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Failed to instantiate the platform.");
                return;
            }

            // display platform information.
            logger.Info("Platform: " + manager.PlatformManager.Platform.PlatformType.ToString() + " (" + manager.PlatformManager.Platform.Version + ")");

            // start the application
            // if the platform is windows and it is not being run as an interactive application, Windows 
            // is trying to start it as a service, so instantiate the service.  Otherwise launch it as a normal console application.
            if ((manager.PlatformManager.Platform.PlatformType == PlatformType.Windows) && (!Environment.UserInteractive))
            {
                logger.Info("Starting application in service mode...");
                ServiceBase.Run(new WindowsService());
            }
            else
            {
                logger.Info("Starting application in interactive mode...");
                Start(args);
                Stop();
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

                printTimer = new Timer(5000);
                printTimer.Elapsed += new ElapsedEventHandler(Tick);
                printTimer.Start();

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

        public static void SetLoggingLevel(string level)
        {
            switch(level.ToLower())
            {
                case "fatal":
                    DisableLoggingLevel(LogLevel.Error);
                    goto case "error";
                case "error":
                    DisableLoggingLevel(LogLevel.Warn);
                    goto case "warn";
                case "warn":
                    DisableLoggingLevel(LogLevel.Info);
                    goto case "info";
                case "info":
                    DisableLoggingLevel(LogLevel.Debug);
                    goto case "debug";
                case "debug":
                    DisableLoggingLevel(LogLevel.Trace);
                    goto case "trace";
                case "trace":
                    break;
            }
        }

        public static void DisableLoggingLevel(LogLevel level)
        {
            foreach (var rule in LogManager.Configuration.LoggingRules)
                rule.DisableLoggingForLevel(level);

            LogManager.ReconfigExistingLoggers();
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

        private static void Tick(object source, EventArgs args)
        {
            //logger.Info("Array: " + manager.ModelManager.FindItem("Symbiote.Simulation.Array").ToJson());
            //logger.Info("CPU usage (readfromsource): " + manager.ModelManager.FindItem("Symbiote.System.Platform.CPU.% Processor Time").ReadFromSource());
            //logger.Info("Sine: " + manager.ModelManager.FindItem("Symbiote.Simulation.Math.Sine").ReadFromSource());
            //logger.Info("Cosine: " + manager.ModelManager.FindItem("Symbiote.Simulation.Math.Cosine").ReadFromSource());
            //logger.Info("Tangent: " + manager.ModelManager.FindItem("Symbiote.Simulation.Math.Tangent").ReadFromSource());
            //logger.Info("CPU usage (read): " + manager.ModelManager.FindItem("Symbiote.System.Platform.CPU.% Processor Time").Read());
            //AddressResolver.Resolve("Symbiote.Simulation.DateTime.Time").Write(DateTime.Now);
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
    }
}
