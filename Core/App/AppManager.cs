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
    #region Namespace Documentation

    /// <summary>
    /// The App namespace abstracts the platform on which the app runs.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc { }

    #endregion

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
                logger.Info("App configuration load was successful.");
                
                // if any warnings were generated during the load, send them to the logger.
                if (retVal.ResultCode == OperationResultCode.Warning)
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
        public OperationResult<List<ConfigurationApp>> SaveConfiguration()
        {
            logger.Info("Saving the App configuration...");

            OperationResult<List<ConfigurationApp>> retVal = SaveConfiguration(Apps);

            // save succeeded
            if (retVal.ResultCode != OperationResultCode.Failure)
            {
                logger.Info("Successfully saved the App configuration.");

                // if warnings were generated, print them to the logger
                if (retVal.ResultCode == OperationResultCode.Warning)
                    retVal.LogAllMessagesAsWarn(logger, "The following warnings were generated during the save:");

                manager.ConfigurationManager.Configuration.Apps.Apps = retVal.Result;
            }
            else
            {
                logger.Error("Failed to save the App configuration.");
                retVal.LogAllMessagesAsError(logger, "The following messages were generated during the save:");
            }
                
            return retVal;
        }

        /// <summary>
        /// Creates a list of ConfigurationApp objects based on the provided list of Apps and returns the list.
        /// </summary>
        /// <param name="apps">The list of Apps to copy to the list of ConfigurationApps.</param>
        /// <returns>An OperationResult containing The list of ConfigurationApps created from the supplied App list.</returns>
        private OperationResult<List<ConfigurationApp>> SaveConfiguration(List<App> apps)
        {
            logger.Trace("Saving configuration...");

            OperationResult<List<ConfigurationApp>> retVal = new OperationResult<List<ConfigurationApp>>();
            retVal.Result = new List<ConfigurationApp>();

            // iterate over the list of Apps
            foreach (App app in apps)
            {
                logger.Trace("Saving App " + app.FQN + " to a new instance of ConfigurationApp...");

                // create a new ConfigurationApp and copy the properties from the current App
                ConfigurationApp newApp = new ConfigurationApp() {
                    FQN = app.FQN,
                    Version = app.Version,
                    AppType = app.AppType,
                    FileName = app.FileName,
                    Configuration = app.Configuration,
                    ConfigurationDefinition = app.ConfigurationDefinition
                };

                logger.Trace("Adding new ConfigurationApp " + app.FQN + " to saved app list...");

                // add the new ConfigurationApp to the list of ConfigurationApps
                retVal.Result.Add(newApp);
            }

            logger.Trace("Configuration saved.");

            return retVal;
        }

        /// <summary>
        /// Installs the App contained within the AppArchive matching the supplied FQN.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the App Archive from which to install the App.</param>
        /// <returns>An OperationResult containing an App corresponding to the installed App.</returns>
        public async Task<OperationResult<App>> InstallAppAsync(string fqn)
        {
            logger.Trace("Installing App '" + fqn + "'...");

            OperationResult<App> retVal;
            AppArchive foundArchive = FindAppArchive(fqn);

            logger.Info("Attempting to install App '" + foundArchive.FQN + "' from App Archive '" + foundArchive.FileName + "'...");

            // make sure an archive matching the supplied FQN exists
            if (foundArchive != default(AppArchive))
                retVal = await InstallAppAsync(foundArchive, manager.PlatformManager.Platform);
            else
            {
                retVal = new OperationResult<App>().AddError("Unable to find App Archive with Fully Qualified Name '" + fqn + "'.");
                return retVal;
            }

            // the installation suceeed, with or without warnings
            if (retVal.ResultCode != OperationResultCode.Failure)
            {
                logger.Info("Successfully installed App '" + retVal.Result.FQN + "'.");

                // if any warnings were generated, print them to the logger
                if (retVal.ResultCode == OperationResultCode.Warning)
                    retVal.LogAllMessagesAsWarn(logger, "Warnings were generated during the installation:");

                // add the new app to the list of installed apps
                Apps.Add(retVal.Result);

                // save the updated App list to the configuration manager
                SaveConfiguration();
            }
            else
            {
                logger.Warn("Failed to install App '" + foundArchive.FQN + "' from App Archive '" + foundArchive.FileName + "'.");
                retVal.LogAllMessagesAsWarn(logger, "The following messages were generated during the installation:");
            }

            return retVal;
        }

        /// <summary>
        /// Installs the App contained within the supplied AppArchive using methods supplied by the supplied IPlatform.
        /// </summary>
        /// <param name="appArchive">The AppArchive from which to install the App.</param>
        /// <param name="platform">The IPlatform instance to use carry out the installation.</param>
        /// <returns></returns>
        private async Task<OperationResult<App>> InstallAppAsync(AppArchive appArchive, IPlatform platform)
        {

            OperationResult<App> retVal = new OperationResult<App>();

            // if the app we are installing is a Console, check to make sure an existing Console hasn't already been installed.
            if (appArchive.AppType == AppType.Console)
            {
                App existingConsole = Apps.Where(a => a.AppType == AppType.Console).FirstOrDefault();
                if (existingConsole != default(App))
                {
                    retVal.AddError("A Console App ('" + existingConsole.Name + "') has already been installed.");
                    return retVal;
                }
            }
            // make sure the app hasn't been installed already.
            if (FindApp(appArchive.FQN) != null)
                retVal.AddError("The App Archive '" + appArchive.FQN + "' has already been installed.  Use the reinstall function to reinstall install it.");
            else
            {
                try
                {
                    // set the InstallInProgress flag to prevent repeated calls from colliding
                    InstallInProgress = true;

                    logger.Trace("Installing App '" + appArchive.Name + "' from archive '" + appArchive.FileName + "'...");
                    string destination = System.IO.Path.Combine(manager.InternalSettings.WebDirectory, (appArchive.AppType == AppType.Console ? "Console" : appArchive.Name));
                    logger.Trace("Destination: " + destination);

                    // if the destination directory doesn't exist, create it.
                    if (!platform.DirectoryExists(destination))
                    {
                        logger.Trace("Destination directory doesn't exist.  Creating...");
                        platform.CreateDirectory(destination);
                        logger.Trace("Destination directory created.");
                    }

                    //---------------------------------------------------- - ------ - -           ----- - 
                    // asynchronous code
                    //----- - - ---------- -
                    // extract the archive to the destination
                    // note: the ExtractZip function in the base library needs an absolute path for the input file to work properly.
                    await Task.Run(() => platform.ExtractZip(System.IO.Path.Combine(manager.InternalSettings.AppDirectory,appArchive.FileName), destination, true));

                    logger.Trace("Successfully extracted the archive '" + System.IO.Path.GetFileName(appArchive.FileName) + "' to '" + destination + "'.");

                    // clean up the name and print it to the logger
                    string relativeDestination = destination.Replace(manager.InternalSettings.RootDirectory, "");
                    logger.Trace("Successfully installed App '" + appArchive.Name + "' to '" + relativeDestination + "'.");

                    // create a new App
                    retVal.Result = new App(appArchive);
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

        /// <summary>
        /// Uninstalls the App matching the supplied FQN.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the App to uninstall.</param>
        /// <returns>A basic OperationResult.</returns>
        public async Task<OperationResult> UninstallAppAsync(string fqn)
        {
            OperationResult retVal;
            App foundApp = FindApp(fqn);

            logger.Info("Attempting to uninstall App '" + foundApp.FQN + "'...");

            // make sure the app is installed
            if (foundApp != default(App))
                retVal = await UninstallAppAsync(foundApp, manager.PlatformManager.Platform);
            else
                retVal = new OperationResult().AddError("The specified App isn't installed.");

            // if the operation succeeded
            if (retVal.ResultCode != OperationResultCode.Failure)
            {
                logger.Info("Successfully uninstalled App '" + foundApp.FQN + "'.");

                // if any warnings were generated, print them to the logger
                if (retVal.ResultCode == OperationResultCode.Warning)
                    retVal.LogAllMessagesAsWarn(logger, "Warnings were generated during the uninstallation:");

                // save the updated App list to the configuration manager
                SaveConfiguration();
            }
            else
            {
                logger.Warn("Failed to uninstall App '" + foundApp.FQN + "'.");
                retVal.LogAllMessagesAsWarn(logger, "The following messages were generated during the uninstallation:");
            }

            return retVal;
        }

        /// <summary>
        /// Uninstalls the supplied App using methods supplied by the supplied IPlatform.
        /// </summary>
        /// <param name="app">The App to uninstall.</param>
        /// <param name="platform">The IPlatform instance to use to carry out the uninstallation.</param>
        /// <returns></returns>
        private async Task<OperationResult> UninstallAppAsync(App app, IPlatform platform)
        {
            OperationResult retVal = new OperationResult();
            string appDirectory = System.IO.Path.Combine(manager.InternalSettings.WebDirectory, (app.AppType == AppType.Console ? "Console" : app.Name));

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

        /// <summary>
        /// Reinstalls the App matching the supplied FQN.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the App to reinstall.</param>
        /// <returns>An OperationResult containing the reinstalled App.</returns>
        public async Task<OperationResult<App>> ReinstallAppAsync(string fqn)
        {
            OperationResult<App> retVal;
            App foundApp = FindApp(fqn);

            logger.Info("Attempting to reinstall App '" + foundApp.FQN + "' from App Archive '" + foundApp.FileName + "'...");

            // make sure the specified app is installed
            if (foundApp != default(App))
                retVal = await ReinstallAppAsync(foundApp, manager.PlatformManager.Platform);
            else
                retVal = new OperationResult<App>().AddError("The specified App isn't installed.");

            // if the operation succeeded
            if (retVal.ResultCode != OperationResultCode.Failure)
            {
                logger.Info("Successfully reinstalled App '" + foundApp.FQN + "'.");

                // if any warnings were generated, print them to the logger
                if (retVal.ResultCode == OperationResultCode.Warning)
                    retVal.LogAllMessagesAsWarn(logger, "Warnings were generated during the reinstallation:");
            }
            else
            {
                logger.Warn("Failed to uninstall App '" + foundApp.FQN + "'.");
                retVal.LogAllMessagesAsWarn(logger, "The following messages were generated during the reinstallation:");
            }

            return retVal;
        }

        /// <summary>
        /// Reinstalls the supplied App using methods supplied by the supplied IPlatform.
        /// </summary>
        /// <param name="app">The App to reinstall.</param>
        /// <param name="platform">The IPlatform instance to use to carry out the reinstallation.</param>
        /// <returns></returns>
        private async Task<OperationResult<App>> ReinstallAppAsync(App app, IPlatform platform)
        {
            OperationResult<App> retVal = new OperationResult<App>();
            AppArchive foundAppArchive = FindAppArchive(app.FQN);

            // make sure the app archive exists
            if (foundAppArchive == default(AppArchive))
            {
                retVal.AddError("Unable to find the App Archive for App '" + app.FQN + "'.  Reinstallation can't continue.");
                return retVal;
            }

            // save the configuration for the app so we can reconfigure it after it has been reinstalled
            string configuration = app.Configuration;

            logger.Trace("Attempting to reinstall '" + app.FQN + "' from archive '" + foundAppArchive.FileName + "'...");

            // uninstall the app
            OperationResult uninstallResult = await UninstallAppAsync(app, platform);

            // if the uninstallation failed, copy the messages from the operationresult and exit the method
            if (uninstallResult.ResultCode == OperationResultCode.Failure)
            {
                retVal.AddError("Failed to uninstall App '" + app.FQN + "'.");
                retVal.Messages = uninstallResult.Messages;
                return retVal;
            }
            // if the uninstall didn't fail, copy any messages from the result to the result of this operation.
            else
            {
                foreach (OperationResultMessage message in uninstallResult.Messages)
                {
                    if (message.Type == OperationResultMessageType.Warning)
                        retVal.AddWarning(message.Message);
                    else
                        retVal.AddInfo(message.Message);
                }
            }

            // install the app from the archive
            OperationResult installResult = await InstallAppAsync(foundAppArchive, platform);

            // if the install failed, fail this operation
            if (installResult.ResultCode == OperationResultCode.Failure)
            {
                retVal.AddError("Failed to install App.");
                retVal.Messages = installResult.Messages;
                return retVal;
            }
            // if it didn't, copy the messages to the result of this operation
            else
            {
                foreach (OperationResultMessage message in installResult.Messages)
                {
                    if (message.Type == OperationResultMessageType.Warning)
                        retVal.AddWarning(message.Message);
                    else
                        retVal.AddInfo(message.Message);
                }
            }
            return retVal;
        }

        /// <summary>
        /// Loads all of the AppArchives found in the configured folder into a list and returns it.
        /// </summary>
        /// <returns>An OperationResult containing the list of loaded AppArchives.</returns>
        public OperationResult<List<AppArchive>> LoadAppArchives(bool throwExceptionOnFailure = false)
        {
            logger.Info("Loading App Archives...");
            OperationResult<List<AppArchive>> retVal = LoadAppArchives(manager.InternalSettings.AppDirectory, manager.InternalSettings.AppExtension, manager.PlatformManager.Platform);

            // load succeeded
            if (retVal.ResultCode != OperationResultCode.Failure)
            {
                logger.Info("App Archives loaded.");

                // if warnings were generated, print them to the logger
                if (retVal.ResultCode == OperationResultCode.Warning)
                    retVal.LogAllMessagesAsWarn(logger, "The following warnings were generated during the load:");

                logger.Info(retVal.Result.Count() + " App Archives loaded.");

                AppArchives = retVal.Result;
            }
            else
            {
                // the load failed.  send the message to the logger and print the list of messages.
                string msg = "Failed to load App Archives.";
                logger.Error(msg);
                retVal.LogAllMessagesAsError(logger, "The following messages were generated during the load:");

                // if the throwExceptionOnFailure parameter is true, throw an exception
                if (throwExceptionOnFailure) throw new AppLoadException(msg);
            }

            return retVal;
        }

        /// <summary>
        /// Loads all of the AppArchives contained in files matching the supplied searchPattern found in the supplied folder into a list and returns it.
        /// </summary>
        /// <param name="folder">The folder to search for AppArchives.</param>
        /// <param name="searchPattern">The wildcard pattern to use when searching for archives (e.g. *.zip).</param>
        /// <param name="platform">The IPlatform instance to use to carry out the reinstallation.</param>
        /// <returns>An OperationResult containing the list of loaded AppArchives.</returns>
        private OperationResult<List<AppArchive>> LoadAppArchives(string folder, string searchPattern, IPlatform platform)
        {
            OperationResult<List<AppArchive>> retVal = new OperationResult<List<AppArchive>>();
            retVal.Result = new List<AppArchive>();

            // fetch a list of matching files using the supplied IPlatform
            logger.Trace("Searching for Apps in '" + folder + "' with searchPattern = '" + searchPattern);
            List<string> files = platform.GetFileList(folder, searchPattern);
            logger.Trace("Found " + files.Count + " matching file(s). Parsing...");

            // iterate over the found files
            foreach (string file in files)
            {
                logger.Trace("Parsing file: " + file);

                // parse the file
                OperationResult<AppArchive> parseResult = ParseAppArchive(file);

                // if it parses, check to be sure it isn't a duplicate and if not, load it
                // note: logging and error handling for the parse operation, is contained within ParseAppArchive() for brevity.
                if (parseResult.ResultCode != OperationResultCode.Failure)
                {
                    if (retVal.Result.Find(a => a.FQN == parseResult.Result.FQN) == null)
                        retVal.Result.Add(parseResult.Result);
                    else
                        retVal.AddWarning("The App archive '" + System.IO.Path.GetFileName(parseResult.Result.FileName) + "' contains an App with the same Fully Qualified Name as a previously parsed App.  The duplicate App will not be available to install.");

                    // if warnings were generated during the parse, add them to the list of warnings in the return value
                    if (parseResult.ResultCode == OperationResultCode.Warning)
                        foreach (OperationResultMessage message in parseResult.Messages)
                            retVal.AddWarning(System.IO.Path.GetFileName(parseResult.Result.FileName) + " " + message.Message);
                }
                // if the parse failed
                else
                {
                    retVal.AddWarning("The archive '" + System.IO.Path.GetFileName(file) + "' does not contain a valid App.");
                }
            }
            return retVal;
        }

        /// <summary>
        /// Reloads all of the AppArchives found in the configured folder into a list and returns it.
        /// </summary>
        /// <returns>An OperationResult containing a list of the loaded AppArchives</returns>
        /// <remarks>Included for convenience and clarity; calls LoadAppArchives() with no parameters.</remarks>
        public OperationResult<List<AppArchive>> ReloadAppArchives()
        {
            return LoadAppArchives();
        }

        /// <summary>
        /// Parses an App archive file into an AppArchive object and validates it.
        /// </summary>
        /// <param name="fileName">The App archive file to parse.</param>
        /// <returns>An OperationResult containing the parsed AppArchive.</returns>
        private OperationResult<AppArchive> ParseAppArchive(string fileName)
        {
            OperationResult<AppArchive> retVal = ParseAppArchive(fileName, manager.InternalSettings.AppConfigurationFileName, manager.PlatformManager.Platform);

            // the installation suceeed, with or without warnings
            if (retVal.ResultCode != OperationResultCode.Failure)
            {
                logger.Trace("Successfully parsed App '" + retVal.Result.FQN + "' from archive '" + System.IO.Path.GetFileName(retVal.Result.FileName) + "'.");

                // if any warnings were generated, print them to the logger
                if (retVal.ResultCode == OperationResultCode.Warning)
                    retVal.LogAllMessagesAsTrace(logger, "Warnings were generated during the parse:");
            }
            else
            {
                logger.Trace("Failed to parse a valid App from archive '" + System.IO.Path.GetFileName(fileName) + "'.");
                retVal.LogAllMessagesAsWarn(logger, "The following messages were generated during the parse:", "The App will not be available to install.");
            }

            return retVal;
        }

        /// <summary>
        /// Parses an App archive file into an AppArchive object and validates it.
        /// </summary>
        /// <param name="fileName">The App archive file to parse.</param>
        /// <param name="configFileName">The name of the App config file that should be present within the archive.</param>
        /// <param name="platform">The IPlatform instance to use to carry out the reinstallation.</param>
        /// <returns>An OperationResult containing the parsed AppArchive.</returns>
        private OperationResult<AppArchive> ParseAppArchive(string fileName, string configFileName, IPlatform platform)
        {
            OperationResult<AppArchive> retVal = new OperationResult<AppArchive>();

            logger.Trace("Found App archive '" + System.IO.Path.GetFileName(fileName) + "'.  Parsing...");

            try
            {
                logger.Trace("Parsing App archive '" + fileName + "'...");
                logger.Trace("Fetching a list of files matching '" + configFileName + "' from the archive...");

                // attempt to locate the App configuration file within the archive.
                string configFile = platform.GetZipFileList(fileName, configFileName).FirstOrDefault();

                // config file was found
                if (configFile != "")
                {
                    logger.Trace("Found configuration file.  Extracting to '" + manager.InternalSettings.TempDirectory + "'...");

                    // extract the config file from the zip
                    string extractedConfigFile = platform.ExtractFileFromZip(fileName, configFile, manager.InternalSettings.TempDirectory, true);

                    logger.Trace("Extracted config file to '" + extractedConfigFile + "'.  Reading contents...");

                    // read the config file into the config variable
                    string config = platform.ReadFile(extractedConfigFile);

                    logger.Trace("Fetched contents.  Deserializing contents...");

                    // deserialize the config file.  It should deserialize to an instance of AppArchive if it is valid.
                    retVal.Result = JsonConvert.DeserializeObject<AppArchive>(config);
                    logger.Trace("Successfully deserialized the contents of '" + extractedConfigFile + "' to an AppArchive object.");

                    // update the filename
                    retVal.Result.FileName = System.IO.Path.GetFileName(fileName);

                    logger.Trace("Validating deserialized AppArchive object...");

                    // create a variable for brevity
                    AppArchive a = retVal.Result;

                    logger.Trace("App; Name: " + a.Name + "; FQN: " + a.FQN + "; Version: " + a.Version + "; AppType: " + a.AppType + "; FileName: " + System.IO.Path.GetFileName(a.FileName));

                    if (a.Name == "") retVal.AddError("The Name field is blank.");
                    if (a.FQN == "") retVal.AddError("The FQN field is blank.");

                    if (a.FQN != System.IO.Path.GetFileNameWithoutExtension(a.FileName)) retVal.AddError("The FQN field doesn't match the archive name.");

                    string[] sfqn = a.FQN.Split('.');
                    if (sfqn[0] != manager.InternalSettings.ProductName) retVal.AddError("The FQN field doesn't start with '" + manager.InternalSettings.ProductName + "'.");
                    if (sfqn[1] != "App") retVal.AddError("The second tuple of the FQN field isn't 'App'");
                    if (sfqn[2] != a.Name) retVal.AddError("The FQN field doesn't end with Name.");

                    return retVal;
                }
                // config file not found
                else
                {
                    logger.Trace("Unable to find config file '" + manager.InternalSettings.AppConfigurationFileName + "' in the archive.  Failing validation.");
                    retVal.AddError("Unable to find configuration file '" + manager.InternalSettings.AppConfigurationFileName + "' in the archive.  The App can't be loaded.");
                }
            }
            catch(Exception ex)
            {
                string msg = "Caught exception parsing App archive '" + System.IO.Path.GetFileName(fileName) + "', parse failed.";
                logger.Trace(ex, msg);
                retVal.AddError(msg);
            }

            return retVal;
        }

        /// <summary>
        /// Searches the AppArchive list for an AppArchive with the supplied FQN and, if found, returns it.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the AppArchive to find.</param>
        public AppArchive FindAppArchive(string fqn)
        {
            return AppArchives.Where(a => a.FQN == fqn).FirstOrDefault();
        }

        /// <summary>
        /// Searches the App list for an App with the supplied FQN and, if found, returns it.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the App to find.</param>
        /// <returns></returns>
        public App FindApp(string fqn)
        {
            return Apps.Where(i => i.FQN == fqn).FirstOrDefault();
        }

        #endregion
    }
}
