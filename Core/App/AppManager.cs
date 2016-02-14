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

        public List<IApp> AppArchives { get; private set; }
        public List<IApp> InstalledApps { get; private set; }

        public List<IAppInstance> LoadedApps { get; private set; }

        private AppManager(ProgramManager manager)
        {
            this.manager = manager;
        }

        internal static AppManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new AppManager(manager);

            return instance;
        }

        public ActionResult InstallApp(string fqn)
        {
            return new ActionResult();
        }

        public List<IApp> ReloadAppArchives()
        {
            return LoadAppArchives();
        }

        public List<IApp> LoadAppArchives()
        {
            AppArchives = ParseAppArchives();
            return AppArchives;
        }

        public List<IApp> ParseAppArchives()
        {
            return ParseAppArchives(manager.InternalSettings.AppDirectory, manager.InternalSettings.AppExtension);
        }

        public List<IApp> ParseAppArchives(string folder, string searchPattern)
        {
            List<IApp> foundApps = new List<IApp>();

            logger.Trace("Searching for Apps in '" + folder + "' with searchPattern = '" + searchPattern);
            List<string> files = manager.PlatformManager.Platform.GetFileList(folder, searchPattern);
            logger.Trace("Found " + files.Count + " matching file(s). Parsing...");

            foreach (string file in files)
            {
                AppParseResult validationResult = ParseAppArchive(file);

                if (validationResult.Result == ActionResultCode.Success)
                {
                    if (foundApps.Find(a => a.FQN == validationResult.App.FQN) == null)
                        foundApps.Add(validationResult.App);
                    else
                        logger.Warn("The App archive '" + System.IO.Path.GetFileName(validationResult.App.FileName) + "' contains an App with the same Fully Qualified Name as a previously parsed App.  The duplicate App will not be available to install.");
                }
            }
            return foundApps;
        }

        public AppParseResult ParseAppArchive(string fileName)
        {
            return ParseAppArchive(fileName, manager.InternalSettings.AppConfigurationFileName);
        }

        public AppParseResult ParseAppArchive(string fileName, string configFileName)
        {
            AppParseResult retVal = new AppParseResult();
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
                    retVal.App = JsonConvert.DeserializeObject<App>(config);
                    logger.Trace("Successfully deserialized the contents of '" + extractedConfigFile + "' to an App object.");

                    retVal.App.FileName = fileName;

                    logger.Trace("Validating deserialized App object...");
                    App a = retVal.App;

                    if (a.Name == "") retVal.AddError("The Name field is blank.");
                    if (a.FQN == "") retVal.AddError("The FQN field is blank.");

                    if (a.FQN != System.IO.Path.GetFileNameWithoutExtension(a.FileName)) retVal.AddError("The FQN field doesn't match the archive name.");

                    string[] sfqn = a.FQN.Split('.');
                    if (sfqn[0] != manager.InternalSettings.ProductName) retVal.AddError("The FQN field doesn't start with '" + manager.InternalSettings.ProductName + "'.");
                    if (sfqn[1] != "App") retVal.AddError("The second tuple of the FQN field isn't 'App'");
                    if (sfqn[2] != a.Name) retVal.AddError("The FQN field doesn't end with Name.");

                    if ((retVal.Result == ActionResultCode.Success) || (retVal.Result == ActionResultCode.Warning))
                    {
                        logger.Info("Successfully parsed App '" + retVal.App.FQN + "' from archive '" + System.IO.Path.GetFileName(retVal.App.FileName) + "'.");
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

        public void LoadApps(string folder)
        {

        }
    }
}
