using System;
using System.Collections.Generic;
using System.Reflection;
using NLog;
using Symbiote.Core.Platform;
using System.Linq;
using Symbiote.Core.Configuration;
using Symbiote.Core.Plugin.Connector;
using Symbiote.Core.Plugin.Endpoint;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Symbiote.Core.Plugin
{
    /// <summary>
    /// The PluginManager class controls the plugin subsystem.
    /// </summary>
    public class PluginManager : IManager, IConfigurable<PluginManagerConfiguration>
    {
        #region Variables

        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static PluginManager instance;
        private bool pluginsLoaded = false;

        #endregion

        #region Properties

        public bool Running { get; private set; }

        public ConfigurationDefinition ConfigurationDefinition { get { return GetConfigurationDefinition(); } }

        public PluginManagerConfiguration Configuration { get; private set; }

        /// <summary>
        /// A list of currently loaded plugin assemblies.
        /// </summary>
        public List<PluginAssembly> PluginAssemblies { get; private set; }

        /// <summary>
        /// A list of all plugin instances.
        /// </summary>
        //public List<IPluginInstance> PluginInstances { get; private set; }
        public Dictionary<string, IPluginInstance> PluginInstances { get; private set; }

        public List<PluginArchive> PluginArchives { get; private set; }

        public List<InvalidPluginArchive> InvalidPluginArchives { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Private constructor, only called by Instance()
        /// </summary>
        /// <param name="manager">The ProgramManager instance for the application.</param>
        private PluginManager(ProgramManager manager) {
            this.manager = manager;
            PluginAssemblies = new List<PluginAssembly>();
            PluginInstances = new Dictionary<string, IPluginInstance>();
        }

        /// <summary>
        /// Instantiates and/or returns the PluginManager instance.
        /// </summary>
        /// <param name="manager">The ProgramManager instance for the application.</param>
        /// <returns>The Singleton instance of PluginManager.</returns>
        internal static PluginManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new PluginManager(manager);

            return instance;
        }

        #endregion

        #region Instance Methods

        #region IManager Implementation

        public OperationResult Start()
        {
            MethodLogger.Enter(logger);
            OperationResult retVal = new OperationResult();

            logger.Info("Starting the Plugin Manager...");

            OperationResult configureResult = Configure();
            if (configureResult.ResultCode == OperationResultCode.Failure)
                throw new Exception("Failed to start the Plugin Manager: " + configureResult.GetLastError());

            retVal.Incorporate(configureResult);

            #region Plugin Archive Loading

            //---------------- - ------- - - -
            // generate a list of valid archive files in the archive directory 
            PluginArchiveLoadResult pluginArchiveLoadResult = LoadPluginArchives();
            if (pluginArchiveLoadResult.ResultCode != OperationResultCode.Failure)
            {
                PluginArchives = pluginArchiveLoadResult.ValidArchives;
                InvalidPluginArchives = pluginArchiveLoadResult.InvalidArchives;
            }

            retVal.Incorporate(pluginArchiveLoadResult);

            logger.Info("Valid Plugin Archives:");

            foreach (PluginArchive archive in PluginArchives)
                logger.Info("\t" + System.IO.Path.GetFileName(archive.FileName) + " (" + archive.Plugin.FQN + ")");

            if (InvalidPluginArchives.Count > 0) logger.Info("Invalid Plugin Archives:");

            foreach (InvalidPluginArchive invalidArchive in InvalidPluginArchives)
                logger.Info("\t" + System.IO.Path.GetFileName(invalidArchive.FileName) + " (" + invalidArchive.Message + ")");

            logger.Info(PluginArchives.Count + " Plugin Archives loaded.");
            //-------------------------------------------  - 

            #endregion

            Running = (retVal.ResultCode != OperationResultCode.Failure);

            if (Running)
                SaveConfiguration();

            retVal.LogResult(logger);
            MethodLogger.Exit(logger);
            return retVal;
        }

        public OperationResult Restart()
        {
            return new OperationResult();
        }

        public OperationResult Stop()
        {
            Running = false;
            return new OperationResult();
        }

        #endregion

        #region IConfigurable<> Implementation

        public OperationResult Configure()
        {
            OperationResult retVal = new OperationResult();

            OperationResult<PluginManagerConfiguration> fetchResult = manager.ConfigurationManager.GetInstanceConfiguration<PluginManagerConfiguration>(this.GetType());

            // if the fetch succeeded, configure this instance with the result.  
            if (fetchResult.ResultCode != OperationResultCode.Failure)
                Configure(fetchResult.Result);
            // if the fetch failed, add a new default instance to the configuration and try again.
            else
            {
                OperationResult<PluginManagerConfiguration> createResult = manager.ConfigurationManager.AddInstanceConfiguration<PluginManagerConfiguration>(this.GetType(), GetDefaultConfiguration());
                if (createResult.ResultCode != OperationResultCode.Failure)
                    Configure(createResult.Result);
            }

            return Configure(manager.ConfigurationManager.GetInstanceConfiguration<PluginManagerConfiguration>(this.GetType()).Result);
        }

        public OperationResult Configure(PluginManagerConfiguration configuration)
        {
            Configuration = configuration;
            return new OperationResult();
        }

        public OperationResult SaveConfiguration()
        {
            return manager.ConfigurationManager.UpdateInstanceConfiguration(this.GetType(), Configuration);
        }

        #endregion

        #region Plugin and PluginArchive Management

        /// <summary>
        /// Loads all valid Plugin Archives in the archive directory into a list of type PluginArchive and returns it.
        /// </summary>
        /// <returns>An instance of PluginArchiveLoadResult.</returns>
        public PluginArchiveLoadResult LoadPluginArchives()
        {
            return LoadPluginArchives(manager.Directories.Archives, GetPluginArchiveExtension() , manager.Platform);
        }

        /// <summary>
        /// Loads all valid Plugin Archives matching the supplied searchPattern in the supplied directory using the supplied IPlatform 
        /// into a list of type PluginArchive and returns it.
        /// </summary>
        /// <param name="directory">The directory to search.</param>
        /// <param name="searchPattern">The file extension of Plugin Archives.</param>
        /// <param name="platform">The IPlatform instance to use to perform the search.</param>
        /// <returns>An instance of PluginArchiveLoadResult.</returns>
        private PluginArchiveLoadResult LoadPluginArchives(string directory, string searchPattern, IPlatform platform)
        {
            Guid guid = MethodLogger.Enter(logger, MethodLogger.Params(directory, searchPattern, platform), true);

            logger.Info("Loading Plugin Archives...");
            PluginArchiveLoadResult retVal = new PluginArchiveLoadResult();

            // retrieve a list of probable plugin archive files from the configured plugin archive directory
            logger.Trace("Listing matching files...");
            OperationResult<List<string>> searchResult = platform.ListFiles(directory, searchPattern);
            logger.Debug("Found " + searchResult.Result.Count + " Archives.");

            retVal.Incorporate(searchResult);

            // iterate over the list of found files
            foreach (string fileName in searchResult.Result)
            {
                logger.Debug("Parsing Archive file '" + fileName + "'...");

                // parse the current plugin archive file
                OperationResult<PluginArchive> parseResult = ParsePluginArchive(fileName);

                if (parseResult.ResultCode != OperationResultCode.Failure)
                {
                    parseResult.Result.SetFileName(System.IO.Path.GetFileName(fileName));
                    retVal.ValidArchives.Add(parseResult.Result);
                }
                else
                    retVal.InvalidArchives.Add(new InvalidPluginArchive(System.IO.Path.GetFileName(fileName), parseResult.GetLastError()));

                parseResult.LogResultDebug(logger, "ParsePluginArchive");
            }

            retVal.LogResult(logger);

            MethodLogger.Exit(logger, guid);
            return retVal;
        }

        /// <summary>
        /// Refreshes the lists of valid and invalid Plugin Archives.
        /// </summary>
        /// <returns>An instance of PluginArchiveLoadResult.</returns>
        public PluginArchiveLoadResult ReloadPluginArchives()
        {
            Guid guid = MethodLogger.Enter(logger, true);

            logger.Info("Reloading Plugin Archives...");
            PluginArchiveLoadResult retVal = LoadPluginArchives();

            if (retVal.ResultCode != OperationResultCode.Failure)
            {
                PluginArchives = retVal.ValidArchives;
                InvalidPluginArchives = retVal.InvalidArchives;
            }

            retVal.LogResult(logger);
            MethodLogger.Exit(logger, guid);
            return retVal;
        }

        /// <summary>
        /// Parses a Plugin Archive file into a PluginArchive object and validates it using default parameters.
        /// </summary>
        /// <param name="fileName">The Plugin Archive file to parse.</param>
        /// <returns>An OperationResult containing the result of the operation and the parsed PluginArchive.</returns>
        private OperationResult<PluginArchive> ParsePluginArchive(string fileName)
        {
            return ParsePluginArchive(fileName, GetPluginArchiveConfigurationFileName(), GetPluginArchivePayloadFileName(), manager.Platform);
        }

        /// <summary>
        /// Parses a Plugin Archive file into a PluginArchive object and validates it.
        /// </summary>
        /// <param name="fileName">The Plugin Archive file to parse.</param>
        /// <param name="configFileName">The name of the Plugin config file expected to be found within the archive.</param>
        /// <param name="payloadFileName">The name of the file containing the Plugin files expected to be found within the archive.</param>
        /// <param name="platform">The IPlatform instance to use to carry out the parse.</param>
        /// <returns>An OperationResult containing the result of the operation and the parsed PluginArchive.</returns>
        private OperationResult<PluginArchive> ParsePluginArchive(string fileName, string configFileName, string payloadFileName, IPlatform platform)
        {
            Guid guid = MethodLogger.Enter(logger, MethodLogger.Params(fileName, configFileName, payloadFileName, platform), true);

            logger.Trace("Parsing Plugin Archive '" + fileName + "'...");
            OperationResult<PluginArchive> retVal = new OperationResult<PluginArchive>();
            retVal.Result = new PluginArchive(fileName);


            //------  -          ------------ - 
            // retrieve the contents of the configuration file and deserialize it to an instance of Plugin
            logger.Trace("Retrieving the configuration file...");
            OperationResult<List<string>> zipFileListResult = platform.ListZipFiles(fileName, configFileName);
            if (zipFileListResult.ResultCode != OperationResultCode.Failure)
            {
                // ensure that a file named configFileName exists within the archive
                string foundConfigFile = zipFileListResult.Result.FirstOrDefault();
                if (foundConfigFile != default(string))
                {
                    logger.Trace("Configuration file found.  Extracting it from the archive...");

                    // extract the config file to the temp directory
                    OperationResult<string> extractConfigFileResult = platform.ExtractZipFile(fileName, foundConfigFile, manager.Directories.Temp);
                    if (extractConfigFileResult.ResultCode != OperationResultCode.Failure)
                    {
                        logger.Trace("File extracted successfully.  Attempting to read contents...");
                        // read the contents of the file
                        OperationResult<string> readConfigFileResult = platform.ReadFile(extractConfigFileResult.Result);
                        if (readConfigFileResult.ResultCode != OperationResultCode.Failure)
                        {
                            // the contents of the config file are in readConfigFileResult.Result.  try to deserialize it..
                            try
                            {
                                logger.Trace("File contents read.  Attempting to deserialize...");
                                retVal.Result.SetPlugin(Newtonsoft.Json.JsonConvert.DeserializeObject<Plugin>(readConfigFileResult.Result));
                            }
                            catch (Exception ex)
                            {
                                retVal.AddError("Failed to deserialize the contents of the configuration file.");
                                logger.Trace(ex, "Exception thrown during deserialization: ");
                            }
                        }
                        else retVal.AddError("Failed to read the contents of the extracted file.");
                    }
                    else retVal.AddError("Failed to extract the configuration file.");
                }
                else retVal.AddError("The file does not contain a valid plugin configuration file.");
            }
            else retVal.AddError("Failed to retrieve a list of files from zip file.");
            //------------------ - -      -------- - 


            //-------------- - ------
            // clean up the temp directory.  this will fail if the file wasn't extracted but we don't care.
            logger.Trace("Cleaning up the temp directory...");
            platform.DeleteFile(System.IO.Path.Combine(manager.Directories.Temp, configFileName));
            //----------- - -


            // if we've encountered any errors, bail out.
            if (retVal.ResultCode == OperationResultCode.Failure)
            {
                MethodLogger.Exit(logger, guid);
                return retVal;
            }

      
            // create a place to stash the payload checksum
            string payloadChecksum = "";


            //------------- -------------- - 
            // ensure the plugin contains the Plugin.zip file and calculate its checksum
            logger.Trace("Looking for the Plugin payload file...");
            OperationResult<List<string>> zipPayloadCheckResult = platform.ListZipFiles(fileName, payloadFileName);
            if (zipPayloadCheckResult.ResultCode != OperationResultCode.Failure)
            {
                // ensure that the payload file exists within the zip
                string foundPayloadFile = zipPayloadCheckResult.Result.FirstOrDefault();
                if (foundPayloadFile != default(string))
                {
                    logger.Trace("Payload file found.  Attempting to extract...");

                    // extract the file to the temp directory
                    OperationResult<string> extractPayloadResult = platform.ExtractZipFile(fileName, foundPayloadFile, manager.Directories.Temp);
                    if (extractPayloadResult.ResultCode != OperationResultCode.Failure)
                    {
                        logger.Trace("Payload file extracted.  Attempting to calculate checksum...");

                        // compute the checksum of the file
                        OperationResult<string> payloadChecksumResult = platform.ComputeFileChecksum(extractPayloadResult.Result);
                        if (payloadChecksumResult.ResultCode != OperationResultCode.Failure)
                        {
                            logger.Trace("Payload checksum: " + payloadChecksumResult.Result);
                            payloadChecksum = payloadChecksumResult.Result;
                        }
                        else retVal.AddError("Failed to compute the checksum of the payload: " + payloadChecksumResult.GetLastError());

                        // if the plugin archive contains a Connector or Endpoint, make sure the zip file contains a .dll with the proper name.
                        if ((retVal.Result.Plugin.PluginType == PluginType.Connector) || (retVal.Result.Plugin.PluginType == PluginType.Connector))
                        {
                            logger.Trace("The Plugin contains a binary.  Make sure it exists...");

                            OperationResult<List<string>> zipFileDllResult = platform.ListZipFiles(extractPayloadResult.Result, "*.dll");
                            if (zipFileDllResult.ResultCode != OperationResultCode.Failure)
                                if (zipFileDllResult.Result.Where(d => d == retVal.Result.Plugin.FQN + ".dll").FirstOrDefault() == default(string))
                                    retVal.AddError("The archive does not contain a dll with the expected name (" + retVal.Result.Plugin.FQN + ".dll)");

                            retVal.Incorporate(zipFileDllResult);
                        }
                    }
                    else retVal.AddError("Failed to extract the payload from the archive: " + extractPayloadResult.GetLastError());
                }
                else retVal.AddError("The file does not contain a valid payload.");
            }
            else retVal.AddError("Failed to retrieve a list of files from zip file: " + zipPayloadCheckResult.GetLastError());
            //-------------------- - ------------- - ----- - ---------  ---------------------               ---------- - 


            //-------------- - ------
            // clean up the temp directory.  this will fail if the file wasn't extracted but we don't care.
            logger.Trace("Cleaning up the temp directory (again)...");
            platform.DeleteFile(System.IO.Path.Combine(manager.Directories.Temp, payloadFileName));
            //------------------- - -


            // if we've encountered any errors up to this point, bail out.
            if (retVal.ResultCode == OperationResultCode.Failure)
            {
                MethodLogger.Exit(logger, guid);
                return retVal;
            }


            //--------------------- - -          -
            // validate the deserialized Plugin.
            logger.Trace("Validating Plugin contents...");
            Plugin p = retVal.Result.Plugin;

            if (p.FQN != System.IO.Path.GetFileNameWithoutExtension(fileName)) retVal.AddError("The filename doesn't match the FQN of the plugin.");

            if (p.Name == "") retVal.AddError("The Name field is blank.");
            if (p.FQN == "") retVal.AddError("The FQN field is blank.");
            if (p.Version == "") retVal.AddError("The Version field is null or invalid.");
            if (p.PluginType == default(PluginType)) retVal.AddError("The PluginType field is invalid (expected: Connector, Endpoint or App, actual: " + p.PluginType + ").");
            if (p.Fingerprint.Length != 64) retVal.AddError("The Fingerprint field is invalid (expected length: 64, actual: " + p.Fingerprint.Length + ").");

            string[] sfqn = p.FQN.Split('.');
            if (sfqn[0] != manager.ProductName) retVal.AddError("The FQN field doesn't start with '" + manager.ProductName + "'.");
            if (sfqn[1] != "Plugin") retVal.AddError("The second tuple of the FQN isn't 'Plugin'.");
            if (sfqn[2] != p.PluginType.ToString()) retVal.AddError("The third tuple of the FQN doesn't agree with the PluginType field (FQN: '" + sfqn[2] + "'; PluginType: '" + p.PluginType + "').");
            if (sfqn[3] != p.Name) retVal.AddError("The final tuple of the FQN doesn't agree with the Name field (Name: '" + p.Name + "'; FQN: '" + sfqn[3] + "').");
            //----------------- - ---------------------------  --


            //------------------------------ - -  --------- - 
            // validate the fingerprint.
            logger.Trace("Validating Plugin fingerprint...");

            if (!Cryptography.FingerprintValidator.Validate(p.Fingerprint, p.FQN, p.Version, payloadChecksum))
                retVal.AddError("The fingerprint is invalid.");
            //---------- - ------------------            -------------- - 


            retVal.LogResultTrace(logger);
            MethodLogger.Exit(logger, guid);
            return retVal;
        }

        /// <summary>
        /// Asynchronously installs the Plugin contained within the supplied PluginArchive.
        /// </summary>
        /// <param name="archive">The PluginArchive from which the Plugin is to be installed.</param>
        /// <returns>An OperationResult containing the result of the operation and the installed Plugin.</returns>
        public async Task<OperationResult<Plugin>> InstallPluginAsync(PluginArchive archive)
        {
            return await Task.Run(() => InstallPlugin(archive));
        }

        /// <summary>
        /// Installs the Plugin contained within the supplied PluginArchive.
        /// </summary>
        /// <param name="archive">The PluginArchive from which the Plugin is to be installed.</param>
        /// <param name="updatePlugin">When true, bypasses checks that prevent</param>
        /// <returns>An OperationResult containing the result of the operation and the installed Plugin.</returns>
        public OperationResult<Plugin> InstallPlugin(PluginArchive archive, bool updatePlugin = false)
        {
            return InstallPlugin(archive, Configuration, manager.Platform, updatePlugin);
        }

        /// <summary>
        /// Installs the Plugin contained within the supplied PluginArchive using the supplied IPlatform and adds the installed Plugin to the
        /// supplied PluginManagerConfiguration.
        /// 
        /// Prior to installing, the Plugin Archive is re-parsed to ensure it did not changed between the time it was loaded into the PluginArchives
        /// list and when installation was requested.  If the Plugin within the archive is the same as the loaded plugin, installation continues, otherwise
        /// the operation fails and requests that the user refreshes the list.
        /// </summary>
        /// <param name="archive">The PluginArchive from which the Plugin is to be installed.</param>
        /// <param name="configuration">The PluginManagerConfiguration to which the installed Plugin should be added.</param>
        /// <param name="platform">The IPlatform instance with which the archive should be extracted.</param>
        /// <param name="updatePlugin">When true, bypasses checks that prevent</param>
        /// <returns>An OperationResult containing the result of the operation and the created Plugin instance.</returns>
        private OperationResult<Plugin> InstallPlugin(PluginArchive archive, PluginManagerConfiguration configuration, IPlatform platform, bool updatePlugin = false)
        {
            logger.Info("Installing Plugin '" + archive.Plugin.FQN + "' from archive '" + System.IO.Path.GetFileName(archive.FileName) + "'...");
            OperationResult<Plugin> retVal = new OperationResult<Plugin>();

            string fullFileName = System.IO.Path.Combine(manager.Directories.Archives, archive.FileName);

            object methodLock = new object();

            // check to see if the app is installed already
            Plugin foundPlugin = FindPlugin(archive.Plugin.FQN);
            if (foundPlugin != default(Plugin))
            {
                // plugin was found.  If we aren't updating then add an error.
                if (!updatePlugin)
                    retVal.AddError("A Plugin with the name '" + archive.Plugin.Name + "' is already installed.");
                else
                {
                    // we are updating.  Make sure the plugins have the same Name, FQN and PluginType.
                    // updated plugins are expected to be different among Version and Fingerprint.
                    Plugin p = foundPlugin;
                    Plugin a = archive.Plugin;
                    if ((p.Name != a.Name) || (p.FQN != a.FQN) || (p.PluginType != a.PluginType))
                        retVal.AddError("The archive '" + System.IO.Path.GetFileName(archive.FileName) + "' can't be used to update the Plugin '" + foundPlugin.FQN + "'; one or more of the Name, FQN or PluginType fields are different.");
                }
            }
            else
            {
                //--------------------- - -------------------- - 
                // re-validate the file; it may have changed between the time it was loaded and when installation was requested.
                logger.Debug("Re-parsing the archive to ensure that it hasn't changed since it was loaded.");
                OperationResult<PluginArchive> parseResult = ParsePluginArchive(System.IO.Path.Combine(manager.Directories.Archives, archive.FileName));
                if (parseResult.ResultCode != OperationResultCode.Failure)
                {
                    if (!parseResult.Result.Plugin.Equals(archive.Plugin))
                        retVal.AddError("The archive '" + System.IO.Path.GetFileName(archive.FileName) + "' has changed since it was loaded.  Refresh Plugin Archives and try again.");
                }

                retVal.Incorporate(parseResult);

                // exit if we encountered an error
                if (retVal.ResultCode == OperationResultCode.Failure)
                {
                    retVal.LogResult(logger);
                    return retVal;
                }
                //---------------------- - - ---- - ---------------------


                //------- - -
                // determine the destination folders
                logger.Debug("Determining output directories...");
                string tempDestination;
                string destination;

                tempDestination = System.IO.Path.Combine(manager.Directories.Temp, archive.Plugin.FQN);

                // ..\Web\AppName
                if (archive.Plugin.PluginType == PluginType.App)
                    destination = System.IO.Path.Combine(manager.Directories.Web, archive.Plugin.Name);
                // ..\Plugins\(Connector|Endpoint)\AppName
                else
                    destination = System.IO.Path.Combine(manager.Directories.Plugins, archive.Plugin.PluginType.ToString(), archive.Plugin.Name);

                logger.Debug("Temp: '" + tempDestination + "'; Plugin: '" + destination + "'");
                //---------------- - --------------------------------- -   - - -   -  


                //--------------------- - ----------------  -- 
                // extract the archive; first to the temp directory, then extract the payload to the plugin destination and copy the configuration file
                logger.Info("Extracting '" + System.IO.Path.GetFileName(fullFileName) + "' to '" + tempDestination.Replace(manager.Directories.Root, "") + "'...");

                OperationResult extractResult;
                OperationResult payloadExtractResult;

                // lock the file system and InstalledPlugins manipulation to ensure thread safety
                lock (methodLock)
                {
                    // extract the archive to the temp directory
                    logger.Debug("Extracting the archive to the temp directory...");
                    extractResult = platform.ExtractZip(fullFileName, tempDestination, true);
                    if (extractResult.ResultCode != OperationResultCode.Failure)
                    {
                        // ensure the payload archive was extracted properly
                        logger.Debug("Checking to ensure the payload file was extracted...");
                        string payloadFileName = System.IO.Path.Combine(tempDestination, GetPluginArchiveConfigurationFileName());
                        if (platform.FileExists(payloadFileName))
                        {
                            // extract the payload archive to the plugin destination
                            logger.Debug("Extracting the payload file to the Plugin destination...");
                            payloadExtractResult = platform.ExtractZip(System.IO.Path.Combine(tempDestination, GetPluginArchivePayloadFileName()), destination, true);
                            if (payloadExtractResult.ResultCode != OperationResultCode.Failure)
                            {
                                logger.Debug("Payload extracted successfully.");

                                // the payload extracted without any issues.  if the plugin is a binary, calculate the checksum of the dll
                                // and store it in the Fingerprint field.
                                if ((archive.Plugin.PluginType == PluginType.Connector) || (archive.Plugin.PluginType == PluginType.Endpoint))
                                {
                                    logger.Debug("Attempting to locate the extracted assembly...");
                                    OperationResult<List<string>> findDllResult = platform.ListFiles(destination, "*.dll");
                                    if (findDllResult.ResultCode != OperationResultCode.Failure)
                                    {
                                        logger.Debug("Trying to fetch '" + archive.Plugin.FQN + ".dll' from the list of files...");
                                        string dllFile = findDllResult.Result.Where(f => System.IO.Path.GetFileName(f) == archive.Plugin.FQN + ".dll").FirstOrDefault();
                                        if (dllFile != default(string))
                                        {
                                            logger.Debug("Assembly found.  Calculating checksum for the Plugin fingerprint...");
                                            OperationResult<string> checksumResult = platform.ComputeFileChecksum(dllFile);
                                            if (checksumResult.ResultCode != OperationResultCode.Failure)
                                            {
                                                logger.Trace("Checksum: " + checksumResult.Result);

                                                string hash = Utility.ComputeHash(checksumResult.Result, archive.Plugin.FQN + archive.Plugin.Version);
                                                logger.Trace("Hash: " + hash);

                                                archive.Plugin.SetFingerprint(hash);
                                            }
                                        }
                                        else
                                            retVal.AddError("Error calculating checksum for Plugin fingerprint; unable to find the plugin assembly in the destination directory.");
                                    }
                                    else
                                        retVal.AddError("Failed to calculate checksum for the plugin assembly; unable to list the files in the destination directory.");

                                    retVal.Incorporate(findDllResult);
                                }

                                logger.Debug("Adding the installed Plugin to the InstalledPlugin list...");
                                retVal.Result = archive.Plugin;
                                configuration.InstalledPlugins.Add(retVal.Result);
                            }

                            retVal.Incorporate(payloadExtractResult);
                        }
                        else
                            retVal.AddError("The payload archive is missing from the extraction directory.");
                    }
                    retVal.Incorporate(extractResult);
                }
                //----------- - -----------  - ---   


                //------------ - -
                // cleanup the temp directory
                logger.Debug("Cleaning up the temporary directory...");
                platform.DeleteDirectory(tempDestination);
                //------- - -
            }

            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Asynchronously uninstalls the supplied plugin by deleting the directory using the default IPlatform, then removes it from the default
        /// PluginManagerConfiguration.
        /// </summary>
        /// <param name="plugin">The Plugin to uninstall.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public async Task<OperationResult> UninstallPluginAsync(Plugin plugin)
        {
            return await Task.Run(() => UninstallPlugin(plugin));
        }

        /// <summary>
        /// Uninstalls the supplied plugin by deleting the directory using the default IPlatform, then removes it from the default 
        /// PluginManagerConfiguration.
        /// </summary>
        /// <param name="plugin">The Plugin to uninstall.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult UninstallPlugin(Plugin plugin)
        {
            return UninstallPlugin(plugin, Configuration, manager.Platform);
        }

        /// <summary>
        /// Uninstalls the supplied Plugin by deleting the directory using the supplied IPlatform, then removes it from the supplied
        /// PluginManagerConfiguration.
        /// </summary>
        /// <param name="plugin">The Plugin to uninstall.</param>
        /// <param name="configuration">The PluginManagerConfiguration from which the Plugin is to be removed.</param>
        /// <param name="platform">The IPlatform instance with which the directory should be deleted.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        private OperationResult UninstallPlugin(Plugin plugin, PluginManagerConfiguration configuration, IPlatform platform)
        {
            if (plugin == default(Plugin))
                return new OperationResult().AddError("The specified Plugin is invalid.");

            logger.Info("Uninstalling Plugin '" + plugin.FQN + "'...");
            OperationResult retVal = new OperationResult();

            object methodLock = new object();

            Plugin foundPlugin = FindPlugin(plugin.FQN);
            // ensure the plugin is installed
            if (foundPlugin != default(Plugin))
            {
                string pluginDirectory = GetPluginDirectory(plugin);
                try
                {
                    logger.Debug("Deleting Plugin from directory '" + pluginDirectory + "'...");

                    // lock the file system and InstalledPlugins manipulations to ensure thread safety
                    lock (methodLock)
                    {
                        OperationResult deleteResult = platform.DeleteDirectory(pluginDirectory);
                        if (deleteResult.ResultCode != OperationResultCode.Failure)
                        {
                            logger.Debug("Removing Plugin from PluginManager configuration...");
                            configuration.InstalledPlugins.Remove(plugin);
                        }

                        retVal.Incorporate(deleteResult);
                    }
                }
                catch (Exception ex)
                {
                    retVal.AddError("Exception caught while attempting to delete directory '" + pluginDirectory + "': " + ex.Message);
                    logger.Debug(ex);
                }
            }
            else
                retVal.AddError("The specified Plugin '" + plugin.FQN + "' is not installed.");

            retVal.LogResult(logger);
            return retVal;
        }
        
        /// <summary>
        /// Asynchronously reinstalls the specified Plugin by uninstalling, then installing from the original archive.
        /// </summary>
        /// <param name="plugin">The Plugin to reinstall.</param>
        /// <returns>An OperationResult containing the result of hte operation.</returns>
        public async Task<OperationResult> ReinstallPluginAsync(Plugin plugin)
        {
            return await Task.Run(() => ReinstallPlugin(plugin));
        }

        /// <summary>
        /// Reinstalls the specified Plugin by uninstalling, then installing from the original archive.
        /// </summary>
        /// <param name="plugin">The Plugin to reinstall.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult ReinstallPlugin(Plugin plugin)
        {
            logger.Info("Reinstalling Plugin '" + plugin.FQN + "'...");
            OperationResult retVal = new OperationResult();

            logger.Debug("Attempting to locate the Plugin Archive for the supplied Plugin...");
            PluginArchive foundArchive = FindPluginArchiveByFQN(plugin.FQN);
            if (foundArchive == default(PluginArchive))
                retVal.AddError("Unable to locate the Plugin Archive for the supplied Plugin.  The Plugin can not be reinstalled.");
            else
            {
                logger.Debug("Uninstalling the Plugin...");
                retVal.Incorporate(UninstallPlugin(plugin));

                logger.Debug("Reinstalling the Plugin...");
                if (retVal.ResultCode != OperationResultCode.Failure)
                    retVal.Incorporate(InstallPlugin(foundArchive));
            }

            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Asynchronously Updates the Plugin contained within the specified PluginArchive.
        /// </summary>
        /// <param name="archive">The PluginArchive to use for the update.</param>
        /// <returns>An OperationResult containing the result of the operation and the updated Plugin.</returns>
        public async Task<OperationResult<Plugin>> UpdatePluginAsync(PluginArchive archive)
        {
            return await Task.Run(() => UpdatePlugin(archive));
        }

        /// <summary>
        /// Updates the Plugin contained withing the specified PluginArchive.
        /// </summary>
        /// <param name="archive">The PluginArchive to use for the update.</param>
        /// <returns>An OperationResult containing the result of the operation and the updated Plugin.</returns>
        public OperationResult<Plugin> UpdatePlugin(PluginArchive archive)
        {
            return InstallPlugin(archive, true);
        }

        /// <summary>
        /// Searches the Plugin Archive list for a Plugin with a filename matching the supplied filename and returns it if found.
        /// </summary>
        /// <param name="fileName">The filename to match.</param>
        /// <returns>The PluginArchive in the Plugin Archive list matching the supplied filename.</returns>
        public PluginArchive FindPluginArchiveByFileName(string fileName)
        {
            return PluginArchives.Where(p => p.FileName == fileName).FirstOrDefault();
        }

        /// <summary>
        /// Searches the Plugin Archive list for a Plugin with an FQN matching the supplied FQN and returns it if found.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name to match.</param>
        /// <returns>The PluginArchive in the Plugin Archive list matching the supplied FQN.</returns>
        public PluginArchive FindPluginArchiveByFQN(string fqn)
        {
            return PluginArchives.Where(p => p.Plugin.FQN == fqn).FirstOrDefault();
        }

        public Plugin FindPlugin(string fqn)
        {
            return Configuration.InstalledPlugins.Where(p => p.FQN == fqn).FirstOrDefault();
        }
        #endregion


        #region OLD CODE

        /// <summary>
        /// Given a list of files, validate and load each assembly found in the list.
        /// </summary>
        /// <remarks>
        /// The checks performed on the files is as such:
        ///      Compute the MD5 checksum of the plugin and check it against the configuration
        ///         If it is in the authorized plugin list, proceed to the next step
        ///         If it is in the unauthorized plugin list, continue to the next file (no further checks)
        ///         If it is in neither list, add it to the unauthorized list and continue to the next file
        ///      Using GetAssemblyName, ensure the file is a valid assembly
        ///      Pass the retrieved assembly name to GetPluginValidationMessage to ensure the name meets the application requirements
        ///      If the name is correct, Load the assembly
        /// </remarks>
        /// <param name="folder">The folder containing the plugin files to load.</param>
        public void LoadPlugins(string folder)
        {
            // prevent assemblies from being loaded twice
            if (pluginsLoaded)
                throw new Exception("Error: plugins already loaded.  Restart the application to re-load.");

            // fetch a list of files from the specified directory using the platform-independent GetFileList method
            List<string> files = manager.PlatformManager.Platform.ListFiles(folder, "*.dll").Result;

            // iterate through the found files
            foreach (string plugin in files)
            {
                AssemblyName assemblyName;
                Assembly assembly;

                logger.Trace("Found plugin: " + plugin + "'; authorizing...");

                PluginAuthorization auth = GetPluginAuthorization(plugin);

                // if the plugin authorization is unknown it does not yet exist in the list of assemblies in the config file.
                // add it to the list and, depending on configuration, either authorize it or leave it unauthorized.
                // try to add it but we don't care if it fails.
                if (auth == PluginAuthorization.Unknown)
                {
                    try
                    {
                        // update auth with the result of AddNewPlugin.  If AuthorizeNewPlugins is true this will result in authorization.
                        auth = AddNewPlugin(plugin);
                    }
                    catch (Exception ex)
                    {
                        logger.Trace("Failed to add new plugin '" + plugin + "' to the internal list of assemblies.");
                    }
                }
                    
                // the plugin hasn't been authorized yet, log a warning and move on to the next plugin.
                if (auth != PluginAuthorization.Authorized) 
                {
                    logger.Warn("Plugin '" + plugin + "' has not been added to the list of authorized plugins and will not be loaded.");
                    continue;
                }

                // ensure the file is a valid assembly and that the name meets the application requirements
                logger.Trace("Attempting to determine assembly name...");
                try
                {
                    // ensure the file is a valid assembly
                    assemblyName = AssemblyName.GetAssemblyName(plugin);

                    // check that the name meets the application requirements
                    OperationResult validationResult = ValidatePluginAssemblyName(assemblyName);
                    if (validationResult.ResultCode == OperationResultCode.Failure)
                        throw new Exception("Error validating plugin assembly name: " + validationResult.GetLastError());
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Plugin file '" + plugin + "' is not a valid plugin assembly.");                    
                    continue;
                }

                // attempt to load the assembly and add it to the internal list of plugins
                logger.Trace("Validated assembly name '" + assemblyName.ToString() + "'; attempting to load...");
                try
                {
                    assembly = Assembly.Load(assemblyName);

                    logger.Trace("Loaded assembly.  Validating...");

                    OperationResult<Type> validationResult = ValidatePluginAssembly(assembly);
                    Type pluginType;
                    
                    if (validationResult.ResultCode == OperationResultCode.Failure)
                        throw new Exception("Error validating plugin assembly: " + validationResult.GetLastError());
                    else
                    {
                        pluginType = validationResult.Result;
                        logger.Trace("Plugin type '" + pluginType.Name + "' was found in assembly '" + assembly.GetName().Name);
                    }

                    PluginAssemblies.Add(
                        new PluginAssembly(
                            assembly.GetName().Name, 
                            assembly.FullName, 
                            assembly.GetName().Version.ToString(), 
                            GetPluginType(assembly.GetName().Name),
                            "",
                            pluginType, 
                            assembly
                        )
                    );
                    logger.Info("Loaded plugin '" + plugin + "' as type " + pluginType.ToString());
                    logger.Trace("Plugin attributes:");
                    logger.Trace("\tName: " + assembly.GetName().Name);
                    logger.Trace("\tFull Name: " + assembly.FullName);
                    logger.Trace("\tVersion: " + assembly.GetName().Version);
                    logger.Trace("\tPluginType: " + GetPluginType(assembly.GetName().Name).ToString());
                    logger.Trace("\tType: " + pluginType.ToString());

                    OperationResult registerResult = manager.ConfigurationManager.RegisterType(pluginType);
                    if (registerResult.ResultCode == OperationResultCode.Failure)
                        throw new Exception("Failed to register the assembly type with the Configuration Manager.");
                    
                }
                catch (System.Reflection.ReflectionTypeLoadException ex)
                {
                    foreach (Exception le in ex.LoaderExceptions)
                    {
                        logger.Error(le, "\tLoader Exception: " + le.Message);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Failed to load assembly from plugin file '" + plugin + "'.  Ignoring.");
                }
            }
            pluginsLoaded = true;
        }

        private PluginAuthorization AddNewPlugin(string fileName)
        {
            logger.Info("Encountered new plugin '" + fileName + "'; adding it to the list of assemblies.");

            AssemblyName assemblyName = AssemblyName.GetAssemblyName(fileName);

            // check that the name meets the application requirements
            // just forget it if we get any errors
            OperationResult validationResult = ValidatePluginAssemblyName(assemblyName);
            if (validationResult.ResultCode == OperationResultCode.Failure)
                return PluginAuthorization.Unknown;

            PluginManagerConfigurationPluginAssembly newPlugin = new PluginManagerConfigurationPluginAssembly()
            {
                Name = assemblyName.Name,
                FullName = assemblyName.FullName,
                Version = assemblyName.Version.ToString(),
                PluginType = GetPluginType(assemblyName.Name).ToString(),
                FileName = System.IO.Path.GetFileName(fileName),
                Checksum = GetPluginChecksum(fileName)
            };

            logger.Trace("Adding plugin assembly to configuration file with attributes:");
            logger.Trace("\tName: " + newPlugin.Name);
            logger.Trace("\tFull Name: " + newPlugin.FullName);
            logger.Trace("\tVersion: " + newPlugin.Version);
            logger.Trace("\tPluginType: " + newPlugin.PluginType.ToString());
            logger.Trace("\tFileName: " + newPlugin.FileName);
            logger.Trace("\tChecksum: " + newPlugin.Checksum);

            // TODO: check to see if the plugin exists by name only, and if so update the checksum if the config enables it
            if (Configuration.AuthorizeNewPlugins)
            {
                newPlugin.Authorization = PluginAuthorization.Authorized;
            }
            else
            {
                newPlugin.Authorization = PluginAuthorization.Unauthorized;
            }

            logger.Trace("\tAuthorization: " + newPlugin.Authorization.ToString());

            Configuration.Assemblies.Add(newPlugin);
            SaveConfiguration();
            return newPlugin.Authorization;
        }

        public string GetPluginChecksum(string fileName)
        {
            logger.Trace("Computing checksum for plugin file '" + fileName + "'...");
            string retVal = manager.PlatformManager.Platform.ComputeFileChecksum(fileName).Result;
            logger.Trace("MD5 checksum for file '" + fileName + "' computed as '" + retVal + ".");
            return retVal;
        }

        public PluginAuthorization GetPluginAuthorization(string fileName)
        {
            string checksum = GetPluginChecksum(fileName);

            logger.Trace("Determining authorization for plugin file '" + fileName + "' with checksum '" + checksum + "'...");

            PluginManagerConfigurationPluginAssembly retObj = Configuration.Assemblies
                        .Where(p => p.FileName == System.IO.Path.GetFileName(fileName))
                        .Where(p => p.Checksum == checksum)
                        .FirstOrDefault();

            if (retObj != null)
            {
                logger.Trace("Retrieved authoriation for plugin '" + fileName + "': " + retObj.Authorization.ToString());
                return retObj.Authorization;
            }

            logger.Trace("Unable to find a matching entry in the assembly configuration for this plugin.  Returning Unknown authorization.");
            return PluginAuthorization.Unknown;
        }

        /// <summary>
        /// Given a string containing the FQN of a loaded plugin assembly, return the matching IPluginAssembly object.
        /// </summary>
        /// <param name="fqn"></param>
        /// <returns>The instance of IPluginAssembly matching the requested FQN</returns>
        public PluginAssembly FindPluginAssembly(string fqn)
        {
            return PluginAssemblies.Where(p => p.Name == fqn).FirstOrDefault();
        }

        /// <summary>
        /// Creates and returns an instance of the specified plugin type with the specified name
        /// </summary>
        /// <remarks>
        /// The instanceName is propagated through the plugin instance and any internal reference (such as a ConnectorItem).  This name
        /// should match references to the plugin, either through fully qualified addressing or configuration.
        /// 
        /// Note that this is only called via reflection so the references will always be zero. 
        /// </remarks>
        /// <param name="instanceName">The desired internal name of the instance</param>
        /// <returns></returns>
        public T CreatePluginInstance<T>(string instanceName)
        {
            // check to see if the instance name has already been used
            if (FindPluginInstance(instanceName) == default(IPluginInstance))
            {
                logger.Trace("Creating instance of plugin type '" + typeof(T).ToString() + "' with instance name '" + instanceName + "'");
                T newPluginInstance = (T)Activator.CreateInstance(typeof(T), instanceName);
                //PluginInstances.Add((IPluginInstance)newPluginInstance);
                PluginInstances.Add(instanceName, (IPluginInstance)newPluginInstance);
                return newPluginInstance;
            }
            else
            {
                logger.Warn("A plugin with InstanceName '" + instanceName + "' has already been intantiated.");
                return default(T);
            }
        }

        /// <summary>
        /// Attempts to resolve the supplied plugin item Fully Qualified Name to an instance of Item contained in a Connector plugin.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the instance to find.</param>
        /// <returns>The found Item.</returns>
        public Item FindPluginItem(string fqn)
        {
            logger.Trace("Attempting to find Connector Item '" + fqn + "'...");
            IConnector originPlugin = (IConnector)FindPluginInstance(fqn.Split('.')[0]);
            try
            {
                if (originPlugin != default(IConnector))
                {
                    logger.Trace("Origin Plugin is '" + originPlugin.ToString() + "'.  Passing FQN to plugin FindItem() method...");

                    Item retVal = originPlugin.FindItem(fqn);
                    logger.Trace("Resolved Item: " + retVal.ToJson());
                    return retVal;
                }
            }
            catch (Exception ex)
            {
                logger.Trace("Exception thrown from FindPluginItem(): " + ex);
            }

            logger.Trace("Origin plugin '" + fqn.Split('.')[0] + "' not found.");
            return default(Item);
        }

        /// <summary>
        /// Given an instance name string, return the matching instance of IPluginInstance.
        /// </summary>
        /// <param name="instanceName">The name of the instance to find.</param>
        /// <param name="pluginType">The Type of instance to find.</param>
        /// <returns>The instance of IPluginInstance matching the requested InstanceName.</returns>
        public IPluginInstance FindPluginInstance(string instanceName, PluginType pluginType = PluginType.Connector)
        {
            //return PluginInstances.Where(p => p.PluginType == pluginType).Where(p => p.InstanceName == instanceName).FirstOrDefault();
            if (PluginInstances.ContainsKey(instanceName))
                return PluginInstances[instanceName];
            else return null;
        }

        public void InstantiatePlugins()
        {
            InstantiatePlugins(Configuration);
        }

        public void InstantiatePlugins(PluginManagerConfiguration configuration)
        {
            // iterate over the configured plugin instances from the configuration
            foreach (PluginManagerConfigurationPluginInstance instance in configuration.Instances)
            {
                PluginAssembly assembly = FindPluginAssembly(instance.AssemblyName);
                if (assembly == default(PluginAssembly))
                    throw new Exception("Plugin assembly '" + instance.AssemblyName + "' not found in the collection.");

                MethodInfo method = this.GetType().GetMethod("CreatePluginInstance").MakeGenericMethod(assembly.Type);
                method.Invoke(this, new object[] { instance.InstanceName });

                logger.Info("Instantiated " + assembly.PluginType.ToString() + " plugin '" + instance.InstanceName + "'.");
            }
        }

        public void StartPlugins()
        {
            foreach (string key in PluginInstances.Keys)
            {
                logger.Info("Starting Plugin '" + key + "'...");
                PluginInstances[key].Start();
            }
        }

        public OperationResult PerformAutoBuild()
        {
            return PerformAutoBuild(PluginInstances, Configuration.Instances.Where(pi => pi.AutoBuild.Enabled = true));
        }

        public OperationResult PerformAutoBuild(Dictionary<string, IPluginInstance> plugins, IEnumerable<PluginManagerConfigurationPluginInstance> autoBuildInstances)
        {
            OperationResult retVal = new OperationResult();

            foreach (PluginManagerConfigurationPluginInstance instance in autoBuildInstances)
            {
                logger.Info("Attempting to auto build instance '" + instance.InstanceName + "'...");
                IConnector foundPluginInstance = (IConnector)FindPluginInstance(instance.InstanceName);
                if (foundPluginInstance == default(IConnector))
                {
                    retVal.AddWarning("Unable to find plugin instance with InstanceName '" + instance.InstanceName + "', continuing auto build");
                    continue;
                }
                else
                {
                    logger.Trace("Attempting to attach plugin items for instance '" + instance.InstanceName + "' to '" + instance.AutoBuild.ParentFQN + "'");

                    Item anchor = manager.ModelManager.FindItem(instance.AutoBuild.ParentFQN);
                    if (anchor == default(Item))
                    {
                        retVal.AddWarning("Unable to find the parent FQN '" + instance.AutoBuild.ParentFQN + "' for instance '" + instance.InstanceName + "'; skipping auto build for this instance.");
                        continue;
                    }

                    OperationResult attachResult = manager.ModelManager.AttachItem(foundPluginInstance.Browse(), null);
                    attachResult.LogResult(logger);
                    
                    logger.Info("AutoBuild of Plugin instance '" + instance.InstanceName + "' complete.");
                }
            }
            return retVal;
        }

        #endregion

        #endregion

        #region Static Methods

        public static ConfigurationDefinition GetConfigurationDefinition()
        {
            ConfigurationDefinition retVal = new ConfigurationDefinition();
            retVal.SetForm("[\"name\",\"email\",{\"key\":\"comment\",\"type\":\"textarea\",\"placeholder\":\"Make a comment\"},{\"type\":\"submit\",\"style\":\"btn-info\",\"title\":\"OK\"}]");
            retVal.SetSchema("{\"type\":\"object\",\"title\":\"Comment\",\"properties\":{\"name\":{\"title\":\"Name\",\"type\":\"string\"},\"email\":{\"title\":\"Email\",\"type\":\"string\",\"pattern\":\"^\\\\S+@\\\\S+$\",\"description\":\"Email will be used for evil.\"},\"comment\":{\"title\":\"Comment\",\"type\":\"string\",\"maxLength\":20,\"validationMessage\":\"Don\'t be greedy!\"}},\"required\":[\"name\",\"email\",\"comment\"]}");
            retVal.SetModel(typeof(PluginManagerConfiguration));
            return retVal;
        }

        public static PluginManagerConfiguration GetDefaultConfiguration()
        {
            PluginManagerConfiguration retVal = new PluginManagerConfiguration();
            retVal.AuthorizeNewPlugins = true;
            retVal.Assemblies = new List<PluginManagerConfigurationPluginAssembly>();
            retVal.Instances = new List<PluginManagerConfigurationPluginInstance>();

            PluginManagerConfigurationPluginInstance sim = new PluginManagerConfigurationPluginInstance();
            sim.InstanceName = "Simulation";
            sim.AssemblyName = "Symbiote.Plugin.Connector.Simulation";
            sim.Configuration = "";
            sim.AutoBuild = new PluginManagerConfigurationPluginInstanceAutoBuild() { Enabled = true, ParentFQN = ProgramManager.Instance().InstanceName };

            retVal.InstalledPlugins = new List<Plugin>();

            retVal.Instances.Add(sim);
            return retVal;
        }

        /// <summary>
        /// Evaluates the supplied assembly name for correctness and returns an error message if it is incorrect.
        /// </summary>
        /// <remarks>
        /// The expected format of an assembly name is:  "Symbiote.Plugin.[Connector|Service].&gt;PluginName&lt;"
        /// If/when the plugin system expands this code will need to be made to be more dynamic.
        /// </remarks>
        /// <param name="assemblyName">The AssemblyName to be validated.</param>
        private static OperationResult ValidatePluginAssemblyName(AssemblyName assemblyName)
        {
            OperationResult retVal = new OperationResult();

            string[] name = assemblyName.Name.Split('.');
            if (name.Length != 4)
                retVal.AddError("Invalid assembly name (required: 4 tuples, supplied: " + name.Length + ")");
            if (name[0] != "Symbiote")
                retVal.AddError("Invalid application identifier (required: Symbiote, supplied: " + name[0] + ")");
            if (name[1] != "Plugin")
                retVal.AddError("Invalid namespace identifier (required: Plugin, supplied: " + name[1] + ")");
            if (GetPluginType(assemblyName.Name) == default(PluginType))
                retVal.AddError("Invalid plugin type identifier (supplied: " + name[2] + ")");
            return retVal;
        }

        /// <summary>
        /// Determines whether the supplied assembly is a valid plugin, and if so, returns the plugin type.
        /// </summary>
        /// <param name="assembly">The assembly to validate.</param>
        /// <returns>An OperationResult containing the result of the operation and, if successful, the plugin type.</returns>
        private static OperationResult<Type> ValidatePluginAssembly(Assembly assembly)
        {
            logger.Trace("Validating plugin assembly '" + assembly.FullName + "'...");
            OperationResult<Type> retVal = new OperationResult<Type>();

            logger.Trace("Validating plugin assembly name...");
            OperationResult nameValidationResult = ValidatePluginAssemblyName(assembly.GetName());
            if (nameValidationResult.ResultCode == OperationResultCode.Failure)
            {
                retVal.Messages = nameValidationResult.Messages;
                retVal.ResultCode = nameValidationResult.ResultCode;
                logger.Trace("Name validationg failed.  " + retVal.GetLastError());
                return retVal;
            }

            logger.Trace("Name validated; searching for the type that implements IConfigurable<> and either IConnector or IEndpoint...");
            // passed name validation, find an implementation of IConfigurable and either IConnector or IEndpoint
            foreach (Type t in assembly.GetTypes())
            {
                logger.Trace("Checking type '" + t.Name + "'...");
                // ensure the type implements IConfigurable<>
                if (t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IConfigurable<>)))
                {
                    logger.Trace("IConfigurable is implemented.  Looking for either IConnector or IEndpoint...");
                    // ensure it implements either IConnector or IEndpoint
                    if ((t.GetInterfaces().Contains(typeof(IConnector))) || (t.GetInterfaces().Contains(typeof(IEndpoint))))
                    {
                        retVal.Result = t;
                        break;
                    }
                }
            }

            if (retVal.Result == default(Type)) logger.Trace("Didn't find a suitable type.");

            if (retVal.Result == default(Type)) retVal.AddError("The supplied assembly '" + assembly.GetName() + "' does not contain any implementations of IConfigureable.");
            return retVal;

        }

        /// <summary>
        /// Returns an enumeration instance representing the type of the plugin, derived from the third tuple of the plugin name.
        /// </summary>
        /// <param name="name">The fully qualified assembly name from which to parse the plugin type.</param>
        /// <returns>An instance of PluginType corresponding to the parsed type.</returns>
        private static PluginType GetPluginType(string name)
        {
            logger.Trace("Attempting to determine Plugin type for '" + name + "'...");
            PluginType retVal;
            if (Enum.TryParse<PluginType>(name.Split('.')[2], out retVal))
            {
                logger.Trace("Plugin type: " + retVal);
                return retVal;
            }
            else
            {
                logger.Warn("Invalid PluginType for plugin '" + name + "'");
                return default(PluginType);
            }
        }

        private static string GetPluginDirectory(Plugin plugin)
        {
            if (plugin.PluginType == PluginType.App)
                return System.IO.Path.Combine(ProgramManager.Instance().Directories.Web, plugin.Name);
            else
                return System.IO.Path.Combine(ProgramManager.Instance().Directories.Plugins, plugin.PluginType.ToString(), plugin.Name);
        }

        private static string GetPluginArchiveConfigurationFileName()
        {
            return Utility.GetSetting("PluginArchiveConfigurationFileName", "SymbiotePlugin.json");
        }

        private static string GetPluginArchivePayloadFileName()
        {
            return Utility.GetSetting("PluginArchivePayloadFileName", "Plugin.zip");
        }

        private static string GetPluginArchiveExtension()
        {
            return Utility.GetSetting("PluginArchiveExtension", "*.zip");
        }

        #endregion
    }
}
