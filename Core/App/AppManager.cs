using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Newtonsoft.Json;

namespace Symbiote.Core.App
{
    public class AppManager
    {
        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static AppManager instance;

        public List<AppArchive> AppArchives { get; private set; }
        public List<App> Apps { get; private set; }

        private AppManager(ProgramManager manager)
        {
            this.manager = manager;
            AppArchives = new List<AppArchive>();
            Apps = new List<App>();
        }

        internal static AppManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new AppManager(manager);

            return instance;
        }

        public ActionResult<List<App>> LoadApps()
        {
            // TODO: grab the list of apps from the configuration, fix them up and add them to the list of installed apps
            // TODO: check that the filename exists and that the URL folder exists and contains at least a config file and index.html
            return null;
        }

        public AppArchive FindAppArchive(string fqn)
        {
            return AppArchives.Where(a => a.FQN == fqn).FirstOrDefault();
        }

        public App FindInstalledApp(string fqn)
        {
            return Apps.Where(i => i.FQN == fqn).FirstOrDefault();
        }

        public async Task<ActionResult<App>> InstallAppAsync(string fqn)
        {
            AppArchive foundArchive = FindAppArchive(fqn);

            if (foundArchive != default(AppArchive))
                return await InstallAppAsync(foundArchive);
            else
                return new ActionResult<App>().AddError("Unable to find App Archive with Fully Qualified Name '" + fqn + "'."); 
        }

        public async Task<ActionResult<App>> InstallAppAsync(AppArchive appArchive, string configuration = "")
        {
            ActionResult<App> retVal = new ActionResult<App>();

            if (FindInstalledApp(appArchive.FQN) != null)
                retVal.AddError("The App Archive '" + appArchive.FQN + "' has already been installed.  Use the reinstall function to reinstall install it.");
            else
            {
                try
                {
                    logger.Info("Installing App '" + appArchive.Name + "' from archive '" + appArchive.FQN + "...");
                    string destination = System.IO.Path.Combine(manager.InternalSettings.WebDirectory, appArchive.Name);
                    logger.Trace("Destination: " + destination);
                    manager.PlatformManager.Platform.ExtractZip(appArchive.FileName, destination, true);
                    logger.Trace("Successfully extracted the archive '" + System.IO.Path.GetFileName(appArchive.FileName) + "' to '" + destination + "'.");

                    string relativeDestination = destination.Replace(manager.InternalSettings.RootDirectory, "");
                    logger.Info("Successfully installed App '" + appArchive.Name + "' to '" + relativeDestination + "'.");

                    retVal.Result = new App(appArchive);
                    retVal.Result.SetURL("/" + appArchive.Name.ToLower() + "/");

                    // if a configuration was passed to the method, configure the InstalledApp with it
                    if (configuration != "")
                        retVal.Result.Configure(configuration);

                    // add the new app to the list of installed apps
                    Apps.Add(retVal.Result);
                }
                catch (Exception ex)
                {
                    logger.Warn(ex, "Encountered an error installing App from '" + appArchive.FileName + "'.");
                    retVal.AddError("Encountered an error while installing the App: " + ex.ToString());
                }
            }

            return retVal;
        }

        public List<AppArchive> ReloadAppArchives()
        {
            return LoadAppArchives();
        }

        public List<AppArchive> LoadAppArchives()
        {
            AppArchives = ParseAppArchives();
            return AppArchives;
        }

        private List<AppArchive> ParseAppArchives()
        {
            return ParseAppArchives(manager.InternalSettings.AppDirectory, manager.InternalSettings.AppExtension);
        }

        private List<AppArchive> ParseAppArchives(string folder, string searchPattern)
        {
            List<AppArchive> foundApps = new List<AppArchive>();

            logger.Trace("Searching for Apps in '" + folder + "' with searchPattern = '" + searchPattern);
            List<string> files = manager.PlatformManager.Platform.GetFileList(folder, searchPattern);
            logger.Trace("Found " + files.Count + " matching file(s). Parsing...");

            foreach (string file in files)
            {
                ActionResult<AppArchive> parseResult = ParseAppArchive(file);

                if (parseResult.ResultCode == ActionResultCode.Success)
                {
                    if (foundApps.Find(a => a.FQN == parseResult.Result.FQN) == null)
                        foundApps.Add(parseResult.Result);
                    else
                        logger.Warn("The App archive '" + System.IO.Path.GetFileName(parseResult.Result.FileName) + "' contains an App with the same Fully Qualified Name as a previously parsed App.  The duplicate App will not be available to install.");
                }
            }
            return foundApps;
        }

        private ActionResult<AppArchive> ParseAppArchive(string fileName)
        {
            return ParseAppArchive(fileName, manager.InternalSettings.AppConfigurationFileName);
        }

        private ActionResult<AppArchive> ParseAppArchive(string fileName, string configFileName)
        {
            ActionResult<AppArchive> retVal = new ActionResult<AppArchive>();
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

                    retVal.Result.SetFileName(fileName);

                    logger.Trace("Validating deserialized App object...");
                    AppArchive a = retVal.Result;

                    if (a.Name == "") retVal.AddError("The Name field is blank.");
                    if (a.FQN == "") retVal.AddError("The FQN field is blank.");

                    if (a.FQN != System.IO.Path.GetFileNameWithoutExtension(a.FileName)) retVal.AddError("The FQN field doesn't match the archive name.");

                    string[] sfqn = a.FQN.Split('.');
                    if (sfqn[0] != manager.InternalSettings.ProductName) retVal.AddError("The FQN field doesn't start with '" + manager.InternalSettings.ProductName + "'.");
                    if (sfqn[1] != "App") retVal.AddError("The second tuple of the FQN field isn't 'App'");
                    if (sfqn[2] != a.Name) retVal.AddError("The FQN field doesn't end with Name.");

                    if ((retVal.ResultCode == ActionResultCode.Success) || (retVal.ResultCode == ActionResultCode.Warning))
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
                        foreach (string message in retVal.Messages)
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
    }
}
