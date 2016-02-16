using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using Newtonsoft.Json;
using Symbiote.Core.Configuration.App;
using Symbiote.Core.Platform;

namespace Symbiote.Core.App
{
    /// <summary>
    /// The App namespace abstracts the platform on which the app runs.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc { }

    /// <summary>
    /// The AppManager class manages the Apps for the application.
    /// </summary>
    public class AppManager
    {
        #region Variables

        /// <summary>
        /// The ProgramManager for the application.
        /// </summary>
        private ProgramManager manager;

        /// <summary>
        /// The Logger for this class.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The Singleton instance of AppManager.
        /// </summary>
        private static AppManager instance;

        #endregion

        #region Properties

        /// <summary>
        /// A list of the available App Archives.
        /// </summary>
        public List<AppArchive> AppArchives { get; private set; }

        /// <summary>
        /// A list of the installed Apps.
        /// </summary>
        public List<App> Apps { get; private set; }

        /// <summary>
        /// True if an App installation is currently in progress, false otherwise.
        /// </summary>
        public bool InstallInProgress { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Private constructor, only called by Instance()
        /// </summary>
        /// <param name="manager">The ProgramManager instance for the application.</param>
        private AppManager(ProgramManager manager)
        {
            this.manager = manager;
            AppArchives = new List<AppArchive>();
            Apps = new List<App>();
            InstallInProgress = false;
        }

        /// <summary>
        /// Instantiates and/or returns the AppManager instance.
        /// </summary>
        /// <param name="manager">The ProgramManager instance for the application.</param>
        /// <returns>The Singleton instance of AppManager.</returns>
        internal static AppManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new AppManager(manager);

            return instance;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Loads the App configuration from the ConfigurationManager and sets the App property equal to the resulting list of Apps.
        /// </summary>
        /// <returns>An OperationResult containing the loaded list of Apps in the Apps property.</returns>
        public OperationResult<List<App>> LoadConfiguration(bool throwExceptionOnFailure = false)
        {
            logger.Info("Loading App configuration...");

            // load the App configuration section from the Configuration Manager.
            OperationResult<List<App>> retVal = LoadConfiguration(manager.ConfigurationManager.Configuration.Apps);

            if (retVal.ResultCode != OperationResultCode.Failure)
            {
                // the load succeeded, with or without warnings.
                if (retVal.ResultCode == OperationResultCode.Success)
                    logger.Info("App configuration load was successful.");
                
                // if any warnings were generated during the load, send them to the logger.
                else if (retVal.ResultCode == OperationResultCode.Warning)
                    retVal.LogAllMessagesAsWarn(logger, "The following warnings were generated during the load:");

                logger.Info(retVal.Result.Count() + " App(s) loaded.");
                Apps = retVal.Result;
            }
            else
            {
                // the load failed.  send the message to the logger and print the list of messages.
                string msg = "Failed to load the App configuration.";
                logger.Error(msg);
                retVal.LogAllMessagesAsError(logger, "The following messages were generated during the load:");

                // if the throwExceptionOnFailure parameter is true, throw an exception
                if (throwExceptionOnFailure) throw new AppLoadException(msg);
            }

            return retVal;
        }

        /// <summary>
        /// Loads the App configuration in the specified ConfigurationAppSection object and returns an OperationResult containing a list of the loaded Apps.
        /// </summary>
        /// <param name="configuration">The ConfigurationAppSection from which to load the App configuration.</param>
        /// <returns>An OperationResult containing the list of loaded Apps.</returns>
        private OperationResult<List<App>> LoadConfiguration(ConfigurationAppSection configuration)
        {
            OperationResult<List<App>> retVal = new OperationResult<List<App>>();
            retVal.Result = new List<App>();

            logger.Trace("Loading configuration... supplied list contains " + configuration.Apps.Count() + " entries.");

            // iterate over the ConfigurationApps stored in the configuration
            foreach(ConfigurationApp configApp in configuration.Apps)
            {
                logger.Trace("Validaing app entry " + configApp.FQN + "...");

                // validate the app fetched from the configuration
                if (configApp.FQN == "") retVal.AddWarning("The FQN field is blank.");
                if (configApp.FQN != System.IO.Path.GetFileNameWithoutExtension(configApp.FileName)) retVal.AddWarning("The FQN field doesn't match the archive name.");

                string[] sfqn = configApp.FQN.Split('.');
                if (sfqn[0] != manager.InternalSettings.ProductName) retVal.AddWarning("The FQN field doesn't start with '" + manager.InternalSettings.ProductName + "'.");
                if (sfqn[1] != "App") retVal.AddWarning("The second tuple of the FQN field isn't 'App'");

                if (configApp.FileName == "") retVal.AddWarning("The FileName field is blank.");

                // if we encountered any errors or warning when validating the configuration, skip it and move to the next.
                if (retVal.ResultCode != OperationResultCode.Success)
                {
                    logger.Trace("Result code was not succes; skipping entry.");
                    continue;
                }

                logger.Trace("App entry '" + configApp.FQN + "' validated successfully.  Creating App instance...");

                // create a new App instance, configure it, then to add to the result list
                App newApp = new App(configApp.FQN.Split('.')[configApp.FQN.Split('.').Length - 1], configApp.FQN, configApp.Version, configApp.AppType, configApp.ConfigurationDefinition, configApp.FileName);

                logger.Trace("Configuring app...");
                newApp.Configure(configApp.Configuration);
                logger.Trace("Configured app.");

                logger.Trace("Adding App '" + newApp.FQN + "' to result list.");
                retVal.Result.Add(newApp);
            }

            logger.Trace("Returning LoadConfiguration result with status '" + retVal.ResultCode + "'.  Result list contains " + retVal.Result.Count() + " entries.");
            return retVal;
        }

        /// <summary>
        /// Saves the current App list to the ConfigurationManager.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult SaveConfiguration()
        {
            OperationResult<List<ConfigurationApp>> retVal = SaveConfiguration(Apps);
            manager.ConfigurationManager.Configuration.Apps.Apps = retVal.Result;
            return retVal;
        }

        private OperationResult<List<ConfigurationApp>> SaveConfiguration(List<App> apps)
        {
            OperationResult<List<ConfigurationApp>> retVal = new OperationResult<List<ConfigurationApp>>();
            retVal.Result = new List<ConfigurationApp>();

            foreach (App app in apps)
            {
                ConfigurationApp newApp = new ConfigurationApp() {
                    FQN = app.FQN,
                    Version = app.Version,
                    AppType = app.AppType,
                    FileName = app.FileName,
                    Configuration = app.Configuration,
                    ConfigurationDefinition = app.ConfigurationDefinition
                };

                retVal.Result.Add(newApp);
            }

            return retVal;
        }

        public AppArchive FindAppArchive(string fqn)
        {
            return AppArchives.Where(a => a.FQN == fqn).FirstOrDefault();
        }

        public App FindApp(string fqn)
        {

            return Apps.Where(i => i.FQN == fqn).FirstOrDefault();
        }

        public async Task<OperationResult<App>> InstallAppAsync(string fqn)
        {
            OperationResult<App> retVal;
            AppArchive foundArchive = FindAppArchive(fqn);

            logger.Info("Attempting to install App '" + foundArchive.FQN + "' from App Archive '" + foundArchive.FileName + "'...");
            if (foundArchive != default(AppArchive))
                retVal = await InstallAppAsync(foundArchive, manager.PlatformManager.Platform);
            else
                retVal = new OperationResult<App>().AddError("Unable to find App Archive with Fully Qualified Name '" + fqn + "'.");

            if (retVal.ResultCode != OperationResultCode.Failure)
            {
                logger.Info("Successfully installed App '" + retVal.Result.FQN + "'.");

                if (retVal.ResultCode == OperationResultCode.Warning)
                    retVal.LogAllMessagesAsWarn(logger, "Warnings were generated during the installation:");
            }
            else
            {
                logger.Warn("Failed to install App '" + foundArchive.FQN + "' from App Archive '" + foundArchive.FileName + "'.");
                retVal.LogAllMessagesAsWarn(logger, "The following messages were generated during the installation:");
            }

            return retVal;
        }

        private async Task<OperationResult<App>> InstallAppAsync(AppArchive appArchive, IPlatform platform)
        {
            OperationResult<App> retVal = new OperationResult<App>();

            if (FindApp(appArchive.FQN) != null)
                retVal.AddError("The App Archive '" + appArchive.FQN + "' has already been installed.  Use the reinstall function to reinstall install it.");
            else
            {
                try
                {
                    InstallInProgress = true;

                    logger.Info("Installing App '" + appArchive.Name + "' from archive '" + appArchive.FQN + "...");
                    string destination = System.IO.Path.Combine(manager.InternalSettings.WebDirectory, appArchive.Name);
                    logger.Trace("Destination: " + destination);

                    if (!platform.DirectoryExists(destination))
                    {
                        logger.Trace("Destination directory doesn't exist.  Creating...");
                        platform.CreateDirectory(destination);
                        logger.Trace("Destination directory created.");
                    }
                    
                    platform.ExtractZip(appArchive.FileName, destination, true);
                    logger.Trace("Successfully extracted the archive '" + System.IO.Path.GetFileName(appArchive.FileName) + "' to '" + destination + "'.");

                    string relativeDestination = destination.Replace(manager.InternalSettings.RootDirectory, "");
                    logger.Trace("Successfully installed App '" + appArchive.Name + "' to '" + relativeDestination + "'.");

                    retVal.Result = new App(appArchive);
                    retVal.Result.SetFileName(appArchive.FileName);

                    // add the new app to the list of installed apps
                    Apps.Add(retVal.Result);

                    SaveConfiguration();
                }
                catch (Exception ex)
                {
                    logger.Warn(ex, "Encountered an error installing App from '" + appArchive.FileName + "'.");
                    retVal.AddError("Encountered an error while installing the App: " + ex.ToString());
                }
                finally
                {
                    InstallInProgress = false;
                }
            }

            return retVal;
        }

        public async Task<OperationResult> UninstallAppAsync(string fqn)
        {
            OperationResult retVal;
            App foundApp = FindApp(fqn);

            logger.Info("Attempting to uninstall App '" + foundApp.FQN + "'...");
            if (foundApp != default(App))
                retVal = await UninstallAppAsync(foundApp, manager.PlatformManager.Platform);
            else
                retVal = new OperationResult().AddError("The specified App isn't installed.");

            if (retVal.ResultCode != OperationResultCode.Failure)
            {
                logger.Info("Successfully uninstalled App '" + foundApp.FQN + "'.");

                if (retVal.ResultCode == OperationResultCode.Warning)
                    retVal.LogAllMessagesAsWarn(logger, "Warnings were generated during the uninstallation:");
            }
            else
            {
                logger.Warn("Failed to uninstall App '" + foundApp.FQN + "'.");
                retVal.LogAllMessagesAsWarn(logger, "The following messages were generated during the uninstallation:");
            }

            return retVal;
        }

        private async Task<OperationResult> UninstallAppAsync(App app, IPlatform platform)
        {
            OperationResult retVal = new OperationResult();
            string appDirectory = System.IO.Path.Combine(manager.InternalSettings.WebDirectory, app.Name);

            logger.Trace("Attempting to uninstall app from '" + appDirectory + "'...");

            try
            {
                platform.DeleteDirectory(appDirectory);
                Apps.Remove(app);
            }
            catch (Exception ex)
            {
                string msg = "Encountered error uninstalling App '" + app.FQN + "' from directory '" + appDirectory + "': ";
                logger.Trace(msg + ex.ToString());
                retVal.AddError(msg + ex.Message);
            }
            return retVal;
        }

        public async Task<OperationResult<App>> ReinstallAppAsync(string fqn)
        {
            return new OperationResult<App>();
        }

        public OperationResult<List<AppArchive>> ReloadAppArchives()
        {
            return LoadAppArchives();
        }

        public OperationResult<List<AppArchive>> LoadAppArchives()
        {
            OperationResult<List<AppArchive>> retVal = LoadAppArchives(manager.InternalSettings.AppDirectory, manager.InternalSettings.AppExtension);
            AppArchives = retVal.Result;
            return retVal;
        }

        private OperationResult<List<AppArchive>> LoadAppArchives(string folder, string searchPattern)
        {
            OperationResult<List<AppArchive>> retVal = new OperationResult<List<AppArchive>>();
            retVal.Result = new List<AppArchive>();

            logger.Trace("Searching for Apps in '" + folder + "' with searchPattern = '" + searchPattern);
            List<string> files = manager.PlatformManager.Platform.GetFileList(folder, searchPattern);
            logger.Trace("Found " + files.Count + " matching file(s). Parsing...");

            foreach (string file in files)
            {
                OperationResult<AppArchive> parseResult = ParseAppArchive(file);

                if (parseResult.ResultCode == OperationResultCode.Success)
                {
                    if (retVal.Result.Find(a => a.FQN == parseResult.Result.FQN) == null)
                        retVal.Result.Add(parseResult.Result);
                    else
                        logger.Warn("The App archive '" + System.IO.Path.GetFileName(parseResult.Result.FileName) + "' contains an App with the same Fully Qualified Name as a previously parsed App.  The duplicate App will not be available to install.");
                }
            }
            return retVal;
        }

        private OperationResult<AppArchive> ParseAppArchive(string fileName)
        {
            return ParseAppArchive(fileName, manager.InternalSettings.AppConfigurationFileName);
        }

        private OperationResult<AppArchive> ParseAppArchive(string fileName, string configFileName)
        {
            OperationResult<AppArchive> retVal = new OperationResult<AppArchive>();
            logger.Info("Found App archive '" + System.IO.Path.GetFileName(fileName) + "'.  Parsing...");
            try
            {
                logger.Trace("Parsing App archive '" + fileName + "'...");
                logger.Trace("Fetching a list of files matching '" + configFileName + "' from the archive...");
                string configFile = manager.PlatformManager.Platform.GetZipFileList(fileName, configFileName).FirstOrDefault();
                if (configFile != "")
                {
                    logger.Trace("Found configuration file.  Extracting to '" + manager.InternalSettings.TempDirectory + "'...");
                    string extractedConfigFile = manager.PlatformManager.Platform.ExtractFileFromZip(fileName, configFile, manager.InternalSettings.TempDirectory, true);
                    logger.Trace("Extracted config file to '" + extractedConfigFile + "'.  Reading contents...");
                    string config = manager.PlatformManager.Platform.ReadFile(extractedConfigFile);
                    logger.Trace("Fetched contents.  Deserializing contents...");
                    retVal.Result = JsonConvert.DeserializeObject<AppArchive>(config);
                    logger.Trace("Successfully deserialized the contents of '" + extractedConfigFile + "' to an App object.");

                    retVal.Result.FileName = fileName;

                    logger.Trace("Validating deserialized App object...");
                    AppArchive a = retVal.Result;

                    if (a.Name == "") retVal.AddError("The Name field is blank.");
                    if (a.FQN == "") retVal.AddError("The FQN field is blank.");

                    if (a.FQN != System.IO.Path.GetFileNameWithoutExtension(a.FileName)) retVal.AddError("The FQN field doesn't match the archive name.");

                    string[] sfqn = a.FQN.Split('.');
                    if (sfqn[0] != manager.InternalSettings.ProductName) retVal.AddError("The FQN field doesn't start with '" + manager.InternalSettings.ProductName + "'.");
                    if (sfqn[1] != "App") retVal.AddError("The second tuple of the FQN field isn't 'App'");
                    if (sfqn[2] != a.Name) retVal.AddError("The FQN field doesn't end with Name.");

                    if ((retVal.ResultCode == OperationResultCode.Success) || (retVal.ResultCode == OperationResultCode.Warning))
                    {
                        logger.Info("Successfully parsed App '" + retVal.Result.FQN + "' from archive '" + System.IO.Path.GetFileName(retVal.Result.FileName) + "'.");
                    }
                    else
                    {
                        logger.Info("Failed to parse a valid App from archive '" + System.IO.Path.GetFileName(fileName) + "'.  The App will not be available to install.");
                    }

                    if (retVal.Messages.Count > 0)
                    {
                        logger.Info("The following messages were generated by the parser:");
                        foreach (OperationResultMessage message in retVal.Messages)
                        {
                            logger.Info("\t" + message);
                        }
                    }

                    return retVal;
                }
                else
                {
                    logger.Trace("Unable to find config file '" + manager.InternalSettings.AppConfigurationFileName + "' in the archive.  Failing validation.");
                    retVal.AddError("Unable to find configuration file '" + manager.InternalSettings.AppConfigurationFileName + "' in the archive.  The App can't be loaded.");
                }
            }
            catch(Exception ex)
            {
                string msg = "Caught exception parsing App archive '" + System.IO.Path.GetFileName(fileName) + "', parse failed.";
                logger.Warn(ex, msg);
                retVal.AddError(msg);
            }

            return retVal;
        }

        #endregion
    }
}
