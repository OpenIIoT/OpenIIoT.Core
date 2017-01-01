/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄▄▄▄███▄▄▄▄                                           ▄▄▄▄███▄▄▄▄
      █    ▄██▀▀▀███▀▀▀██▄                                       ▄██▀▀▀███▀▀▀██▄
      █    ███   ███   ███  ██████  ██████▄     ▄█████  █        ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████
      █    ███   ███   ███ ██    ██ ██   ▀██   ██   █  ██        ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██
      █    ███   ███   ███ ██    ██ ██    ██  ▄██▄▄    ██        ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀
      █    ███   ███   ███ ██    ██ ██    ██ ▀▀██▀▀    ██        ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████
      █    ███   ███   ███ ██    ██ ██   ▄██   ██   █  ██▌    ▄  ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██
      █     ▀█   ███   █▀   ██████  ██████▀    ███████ ████▄▄██   ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016 JP Dillingham (jp@dillingham.ws)
      █
      █  This program is free software: you can redistribute it and/or modify
      █  it under the terms of the GNU Affero General Public License as published by
      █  the Free Software Foundation, either version 3 of the License, or
      █  (at your option) any later version.
      █
      █  This program is distributed in the hope that it will be useful,
      █  but WITHOUT ANY WARRANTY; without even the implied warranty of
      █  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      █  GNU Affero General Public License for more details.
      █
      █  You should have received a copy of the GNU Affero General Public License
      █  along with this program.  If not, see <http://www.gnu.org/licenses/>.
      █
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using Symbiote.SDK.Configuration;
using Symbiote.SDK;
using Symbiote.Core.Plugin;
using Newtonsoft.Json;
using NLog.xLogger;
using Utility.OperationResult;
using Symbiote.SDK.Model;
using System.Threading.Tasks;

namespace Symbiote.Core.Model
{
    /// <summary>
    ///     The ModelManager class manages the Model for the application.
    ///     TODO: pull the model stuff out into Model
    /// </summary>
    public class ModelManager : Manager, IConfigurable<ModelManagerConfiguration>, IModelManager
    {
        #region Private Fields

        /// <summary>
        ///     The Singleton instance of ModelManager.
        /// </summary>
        private static ModelManager instance;

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        new private xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        ///     Private constructor, only called by Instance()
        /// </summary>
        /// <param name="manager">The ApplicationManager instance for the application.</param>
        /// <param name="configurationManager">The ConfigurationManager instance for the application.</param>
        /// <param name="pluginManager">The PluginManager instance for the application.</param>
        private ModelManager(IApplicationManager manager, IConfigurationManager configurationManager, IPluginManager pluginManager)
        {
            base.logger = logger;
            Guid guid = logger.EnterMethod(true);

            ManagerName = "Model Manager";
            ItemProviderName = "Model";

            RegisterDependency<IApplicationManager>(manager);
            RegisterDependency<IConfigurationManager>(configurationManager);
            RegisterDependency<IPluginManager>(pluginManager);

            ItemProviders = new List<IItemProvider>();

            ChangeState(State.Initialized);
        }

        #endregion Private Constructors

        #region Public Properties

        public string ItemProviderName { get; private set; }

        /// <summary>
        ///     The Configuration for the Manager.
        /// </summary>
        public ModelManagerConfiguration Configuration { get; private set; }

        /// <summary>
        ///     The ConfigurationDefinition for the Manager.
        /// </summary>
        public ConfigurationDefinition ConfigurationDefinition { get { return GetConfigurationDefinition(); } }

        /// <summary>
        ///     A dictionary containing the Fully Qualified Names and references to all of the Items in the model.
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, Item> Dictionary { get; private set; }

        /// <summary>
        ///     Gets the List of registered Item Providers.
        /// </summary>
        [JsonIgnore]
        public List<IItemProvider> ItemProviders { get; private set; }

        /// <summary>
        ///     The root Item for the model.
        /// </summary>
        [JsonIgnore]
        public Item Model { get; private set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Returns the root node of the <see cref="Item"/> tree.
        /// </summary>
        /// <returns>The root node of the Item tree.</returns>
        public Item Browse()
        {
            return Model;
        }

        /// <summary>
        ///     Returns a list of the children <see cref="Item"/> instances for the specified Item within the Item tree.
        /// </summary>
        /// <param name="root">The Item for which the children are to be returned.</param>
        /// <returns>A List of type Item containing all of the specified Item's children.</returns>
        public virtual IList<Item> Browse(Item root)
        {
            return root == null ? Model.Children : root.Children;
        }

        /// <summary>
        ///     Asynchronously returns the root node of the <see cref="Item"/> tree.
        /// </summary>
        /// <returns>The root node of the Item tree.</returns>
        public async Task<Item> BrowseAsync()
        {
            return await Task.Run(() => Browse());
        }

        /// <summary>
        ///     Asynchronously returns a list of the children <see cref="Item"/> instances for the specified Item within the Item tree.
        /// </summary>
        /// <param name="root">The Item for which the children are to be returned.</param>
        /// <returns>A List of type Item containing all of the specified Item's children.</returns>
        public async Task<IList<Item>> BrowseAsync(Item root)
        {
            return await Task.Run(() => Browse(root));
        }

        /// <summary>
        ///     Finds and returns the <see cref="Item"/> matching the specified Fully Qualified Name.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to return.</param>
        /// <returns>The found Item, or the default(Item) if not found.</returns>
        public virtual Item Find(string fqn)
        {
            return FindItem(fqn);
        }

        /// <summary>
        ///     Asynchronously finds and returns the <see cref="Item"/> matching the specified Fully Qualified Name.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to return.</param>
        /// <returns>The found Item, or the default(Item) if not found.</returns>
        public virtual async Task<Item> FindAsync(string fqn)
        {
            return await Task.Run(() => Find(fqn));
        }

        /// <summary>
        ///     Returns the ConfigurationDefinition for the Model Manager.
        /// </summary>
        /// <returns>The ConfigurationDefinition for the Model Manager.</returns>
        public static ConfigurationDefinition GetConfigurationDefinition()
        {
            ConfigurationDefinition retVal = new ConfigurationDefinition();
            retVal.Form = "[\"name\",\"email\",{\"key\":\"comment\",\"type\":\"textarea\",\"placeholder\":\"Make a comment\"},{\"type\":\"submit\",\"style\":\"btn-info\",\"title\":\"OK\"}]";
            retVal.Schema = "{\"type\":\"object\",\"title\":\"Comment\",\"properties\":{\"name\":{\"title\":\"Name\",\"type\":\"string\"},\"email\":{\"title\":\"Email\",\"type\":\"string\",\"pattern\":\"^\\\\S+@\\\\S+$\",\"description\":\"Email will be used for evil.\"},\"comment\":{\"title\":\"Comment\",\"type\":\"string\",\"maxLength\":20,\"validationMessage\":\"Don\'t be greedy!\"}},\"required\":[\"name\",\"email\",\"comment\"]}";
            retVal.Model = typeof(ModelManagerConfiguration);
            return retVal;
        }

        /// <summary>
        ///     Returns the default Configuration for the Model Manager.
        /// </summary>
        /// <returns>The default Configuration for the Model Manager.</returns>
        public static ModelManagerConfiguration GetDefaultConfiguration()
        {
            ModelManagerConfiguration retVal = new ModelManagerConfiguration();
            retVal.Items.Add(
                new ModelManagerConfigurationItem()
                {
                    FQN = "",
                    SourceFQN = ""
                });
            return retVal;
        }

        /// <summary>
        ///     Adds an Item to the ModelManager's instance of Model and Dictionary.
        /// </summary>
        /// <param name="item">The Item to add.</param>
        /// <returns>A Result containing the added Item.</returns>
        public Result<Item> AddItem(Item item)
        {
            if (!IsInState(State.Running, State.Starting))
                return (Result<Item>)new Result()
                    .AddError("The current operation is invalid when the " + ManagerName + " is not in the Running or Starting states (it is currently in the " + State + " state).");

            return AddItem(Model, Dictionary, item);
        }

        public IList<IItemProvider> DiscoverItemProviders()
        {
            ItemProviders = Discoverer.Discover<IItemProvider>(Dependency<IApplicationManager>()).ToList();
            return ItemProviders;
        }

        /// <summary>
        ///     Attaches the provided Item to the supplied Item. This method should be used only to attach plugin Items to the
        ///     application model. When adding Items directly, use AddItem.
        /// </summary>
        /// <param name="item">The Item to attach to the Model.</param>
        /// <param name="parentItem">The Item to which the new Item should be attached.</param>
        /// <returns>A Result containing the result of the operation and the attached Item.</returns>
        public Result<Item> AttachItem(Item item, Item parentItem)
        {
            if (!IsInState(State.Running, State.Starting))
            {
                return (Result<Item>)new Result()
                    .AddError("The current operation is invalid when the " + ManagerName + " is not in the Running or Starting states (it is currently in the " + State + " state).");
            }

            Result<Item> retVal = new Result<Item>();
            if ((item == null) || (parentItem == null))
            {
                return retVal;
            }

            if (Dependency<IApplicationManager>().State != State.Starting)
            {
                logger.Info("Attaching Item '" + item.FQN + "' to '" + parentItem.FQN + "'...");
            }
            else
            {
                logger.Debug("Attaching Item '" + item.FQN + "' to '" + parentItem.FQN + "'...");
            }

            try
            {
                // create a 1:1 clone of the supplied item

                //retVal.ReturnValue = (Item)item.Clone();
                retVal.ReturnValue = (Item)item.CloneAs(parentItem.FQN + "." + item.Name);

                // set the SourceFQN of the new item to the FQN of the original item to create a link
                retVal.ReturnValue.SourceFQN = item.FQN;
                //retVal.ReturnValue.SourceItem = FQNResolver.Resolve(retVal.ReturnValue.SourceFQN);
                retVal.ReturnValue.SourceItem = Dependency<IApplicationManager>().ProviderRegistry.FindItem(retVal.ReturnValue.SourceFQN);

                // modify the FQN of the cloned item to reflect it's new path
                //((Item)retVal.ReturnValue).FQN = parentItem.FQN + "." + retVal.ReturnValue.Name;
                //retVal.ReturnValue.SetParent(parentItem);

                //parentItem.AddChild(retVal.ReturnValue);

                // create a temporary list of the items children
                IEnumerable<Item> children = retVal.ReturnValue.Children.Clone<Item>();

                // remove the children from the item (you leave my babies!)
                retVal.ReturnValue.Children.Clear();
                // they're my babies now, you commie son of a bitch!

                // add the cloned and cleaned item to the model
                logger.Info("Adding item '" + retVal.ReturnValue.FQN + "' to the model");
                AddItem(retVal.ReturnValue);

                // for each child of the original item, attach that item to the model under the cloned and cleaned parent
                foreach (Item child in children)
                {
                    AttachItem(child, retVal.ReturnValue);
                }
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown when attempting to Attach Item '" + item.FQN + "':" + ex);
                retVal.ReturnValue = default(Item);
            }

            if (Dependency<IApplicationManager>().State != State.Starting) retVal.LogResult(logger);
            else retVal.LogResult(logger.Debug);

            return retVal;
        }

        /// <summary>
        ///     Configures the Model Manager using the configuration stored in the Configuration Manager, or, failing that, using
        ///     the default configuration.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Configure()
        {
            logger.EnterMethod();

            logger.Debug("Attempting to Configure with the configuration from the Configuration Manager...");
            Result retVal = new Result();

            Result<ModelManagerConfiguration> fetchResult = Dependency<IConfigurationManager>().GetInstanceConfiguration<ModelManagerConfiguration>(this.GetType());

            // if the fetch succeeded, configure this instance with the result.
            if (fetchResult.ResultCode != ResultCode.Failure)
            {
                logger.Debug("Successfully fetched the configuration from the Configuration Manager.");
                Configure(fetchResult.ReturnValue);
            }
            // if the fetch failed, add a new default instance to the configuration and try again.
            else
            {
                logger.Debug("Unable to fetch the configuration.  Adding the default configuration to the Configuration Manager...");
                Result<ModelManagerConfiguration> createResult = Dependency<IConfigurationManager>().AddInstanceConfiguration<ModelManagerConfiguration>(this.GetType(), GetDefaultConfiguration());
                if (createResult.ResultCode != ResultCode.Failure)
                {
                    logger.Debug("Successfully added the configuration.  Configuring...");
                    Configure(createResult.ReturnValue);
                }
                else
                    retVal.Incorporate(createResult);
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Configures the Manager using the supplied configuration, then saves the configuration to the Model Manager.
        /// </summary>
        /// <param name="configuration">The configuration with which the Manager should be configured.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Configure(ModelManagerConfiguration configuration)
        {
            logger.EnterMethod(xLogger.Params(configuration));

            Result retVal = new Result();

            // update the configuration
            Configuration = configuration;
            logger.Debug("Successfully configured the Manager.");

            // save it
            logger.Debug("Saving the new configuration...");
            retVal.Incorporate(SaveConfiguration());

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Creates a copy of the specified Item and stores it at the specified FQN within the default Model and Dictionary.
        /// </summary>
        /// <param name="item">The Item to copy.</param>
        /// <param name="fqn">The Fully Qualified Name of the destination Item.</param>
        /// <returns>A Result containing the result of the operation and the newly created Item.</returns>
        public Result<Item> CopyItem(Item item, string fqn)
        {
            if (!IsInState(State.Running, State.Starting))
                return (Result<Item>)new Result()
                    .AddError("The current operation is invalid when the " + ManagerName + " is not in the Running or Starting states (it is currently in the " + State + " state).");

            return CopyItem(Model, Dictionary, item, fqn);
        }

        /// <summary>
        ///     Removes the specified <see cref="IItemProvider"/> from the list of providers stored in the
        ///     <see cref="ItemProviders"/> property.
        /// </summary>
        /// <param name="provider">The Item Provider to remove.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result DeRegisterItemProvider(IItemProvider provider)
        {
            logger.EnterMethod(xLogger.Params(provider));
            Result retVal = new Result();

            if (!ItemProviders.Contains(provider))
            {
                retVal.AddWarning("The specified ItemProvider '" + provider.ItemProviderName + "' has not been registered and therefore cannot be deregistered.");
            }
            else
            {
                ItemProviders.Remove(provider);
            }

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Returns the ModelItem from the Dictionary belonging to the ModelManager instance matching the supplied key.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the desired ModelItem.</param>
        /// <returns>The ModelItem from the Model corresponding to the supplied key.</returns>
        /// <remarks>Retrieves items from the Dictionary instance belonging to the ModelManager instance.</remarks>
        public Item FindItem(string fqn)
        {
            return FindItem(Dictionary, fqn);
        }

        /// <summary>
        ///     Moves the supplied Item from one place in the ModelManager's instances of Model and Dictionary to another based on
        ///     the supplied FQN.
        /// </summary>
        /// <param name="item">The Item to move.</param>
        /// <param name="fqn">The Fully Qualified Name representing the new location for the item.</param>
        /// <returns>A Result containing the moved Item.</returns>
        public Result<Item> MoveItem(Item item, string fqn)
        {
            if (!IsInState(State.Running, State.Starting))
                return (Result<Item>)new Result()
                    .AddError("The current operation is invalid when the " + ManagerName + " is not in the Running or Starting states (it is currently in the " + State + " state).");

            return MoveItem(Dictionary, item, fqn);
        }

        /// <summary>
        ///     Adds the specified <see cref="IItemProvider"/> to the list of providers stored in the <see cref="ItemProviders"/> property.
        /// </summary>
        /// <param name="provider">The Item Provider to add.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result RegisterItemProvider(IItemProvider provider)
        {
            logger.EnterMethod(xLogger.Params(provider));
            Result retVal = new Result();

            if (ItemProviders.Contains(provider))
            {
                retVal.AddError("The specified ItemProvider '" + provider.ItemProviderName + "' has already been registered.");
            }
            else
            {
                ItemProviders.Add(provider);
            }

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Removes an Item from the ModelManager's Dictionary and from its parent Item.
        /// </summary>
        /// <param name="item">The Item to remove.</param>
        /// <returns>A Result containing the removed Item.</returns>
        public Result<Item> RemoveItem(Item item)
        {
            if (!IsInState(State.Running, State.Starting))
                return (Result<Item>)new Result()
                    .AddError("The current operation is invalid when the " + ManagerName + " is not in the Running or Starting states (it is currently in the " + State + " state).");

            return RemoveItem(Dictionary, item);
        }

        /// <summary>
        ///     Saves the configuration to the Configuration Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result SaveConfiguration()
        {
            logger.EnterMethod();
            Result retVal = new Result();

            retVal.Incorporate(Dependency<IConfigurationManager>().UpdateInstanceConfiguration(this.GetType(), Configuration));

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Updates the supplied Item with the supplied Source Item.
        /// </summary>
        /// <param name="item">The Item to update.</param>
        /// <param name="sourceItem">The SourceItem with which to update the Item.</param>
        /// <returns>A Result containing the result of the operation and the updated Item.</returns>
        public Result<Item> UpdateItem(Item item, Item sourceItem)
        {
            logger.Info("Updating Item '" + item.FQN + "'s SourceItem to '" + sourceItem.FQN + "'...");

            if (!IsInState(State.Running, State.Starting))
                return (Result<Item>)new Result()
                    .AddError("The current operation is invalid when the " + ManagerName + " is not in the Running or Starting states (it is currently in the " + State + " state).");

            Result<Item> retVal = new Result<Item>();

            if (sourceItem != default(Item))
            {
                item.SourceItem = sourceItem;
                item.SourceFQN = sourceItem.FQN;

                retVal.ReturnValue = item;
            }
            else
                retVal.AddError("The supplied SourceItem is invalid.");

            retVal.LogResult(logger);
            return retVal;
        }

        #endregion Public Methods

        #region Internal Methods

        /// <summary>
        ///     Instantiates and/or returns the ModelManager instance.
        /// </summary>
        /// <remarks>
        ///     Invoked via reflection from ApplicationManager. The parameters are used to build an array of IManager parameters
        ///     which are then passed to this method. To specify additional dependencies simply insert them into the parameter list
        ///     for the method and they will be injected when the method is invoked.
        /// </remarks>
        /// <param name="manager">The ApplicationManager instance for the application.</param>
        /// <param name="configurationManager">The ConfigurationManager instance for the application.</param>
        /// <param name="pluginManager">The PluginManager instance for the application.</param>
        /// <returns>The Singleton instance of the ModelManager.</returns>
        internal static ModelManager Instantiate(IApplicationManager manager, IConfigurationManager configurationManager, IPluginManager pluginManager)
        {
            if (instance == null)
                instance = new ModelManager(manager, configurationManager, pluginManager);

            return instance;
        }

        #endregion Internal Methods

        #region Protected Methods

        protected override Result Shutdown(StopType stopType = StopType.Stop)
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Shutdown for '" + GetType().Name + "'...");
            Result retVal = new Result();

            if (!stopType.HasFlag(StopType.Exception))
            {
                retVal.Incorporate(SaveModel());
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        protected override Result Startup()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Startup for '" + GetType().Name + "'...");
            Result retVal = new Result();

            //--------------- - - -
            // Configure the Manager
            Result configureResult = Configure();

            if (configureResult.ResultCode == ResultCode.Failure)
                throw new Exception("Failed to configure the Model Manager: " + configureResult.GetLastError());

            retVal.Incorporate(configureResult);
            //--------------------------------  -

            //--  -  -- ---------------  -
            // Build the model
            ModelBuildResult modelBuildResult = BuildModel(Dependency<IApplicationManager>().InstanceName, Configuration.Items);

            if (modelBuildResult.ResultCode == ResultCode.Failure)
                throw new Exception("Failed to build the model: " + modelBuildResult.GetLastError());

            retVal.Incorporate(modelBuildResult);

            logger.Checkpoint("Model Built", xLogger.Vars(modelBuildResult.Dictionary.Count, modelBuildResult.Model.FQN, modelBuildResult.Model.Children.Count), xLogger.Names("Dictionary Count", "Root FQN", "Root Children Count"));

            //--- - ------------

            //------------------------------   -
            // Attach the newly built model to the Model Manager
            Result attachResult = AttachModel(modelBuildResult);

            if (attachResult.ResultCode == ResultCode.Failure)
                throw new Exception("Failed to attach the model to the Model Manager: " + attachResult.GetLastError());

            retVal.Incorporate(attachResult);
            //---- - ------------  -

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        ///     Parses and returns an Item name from the given FQN.
        /// </summary>
        /// <param name="itemFQN">The FQN from which to parse the name.</param>
        /// <returns>The Item name.</returns>
        private static string GetItemNameFromItemFQN(string itemFQN)
        {
            return itemFQN.Split('.')[itemFQN.Split('.').Length - 1];
        }

        /// <summary>
        ///     Parses and returns an Item path from the given FQN.
        /// </summary>
        /// <param name="itemFQN">The FQN from which to parse the path.</param>
        /// <returns>The Item path.</returns>
        private static string GetParentFQNFromItemFQN(string itemFQN)
        {
            string[] retObj = itemFQN.Split('.');

            if (retObj.Length > 1)
                return String.Join(".", retObj.Take(retObj.Count() - 1));

            // the root item has no path.
            return "";
        }

        /// <summary>
        ///     Adds an Item to the given Model and Dictionary.
        /// </summary>
        /// <param name="model">The Model to which to add the Item.</param>
        /// <param name="dictionary">The Dictionary to which to add the Item.</param>
        /// <param name="item">The Item to add.</param>
        /// <param name="findParentByFQN">A value indicating whether the parent Item should be located using the Item's FQN.</param>
        /// <returns>A Result containing the added Item.</returns>
        private Result<Item> AddItem(Item model, Dictionary<string, Item> dictionary, Item item, bool findParentByFQN = false)
        {
            logger.EnterMethod();

            if (Dependency<IApplicationManager>().State != State.Starting)
            {
                logger.Info("Adding item '" + item.FQN + "' to the model...");
            }
            else
            {
                logger.Debug("Adding item '" + item.FQN + "' to the model...");
            }

            Result<Item> retVal = new Result<Item>();
            retVal.ReturnValue = item;

            string parentFQN = GetParentFQNFromItemFQN(item.FQN);

            // if the parent FQN couldn't be parsed, this is the root node so clone it to the existing ModelItem representing the root.
            if (parentFQN == "")
            {
                //Result<Item> rootSetResult = SetModelRoot(model, dictionary, item);
                //retVal.Incorporate(rootSetResult);
                //retVal.ReturnValue = rootSetResult.ReturnValue;
            }
            else
            {
                // ensure the item hasn't been added already.
                Item foundItem = FindItem(dictionary, item.FQN);
                if (foundItem != default(Item))
                {
                    retVal.AddError("The item already exists in the dictionary.");
                }
                else
                {
                    // ensure the parent exists
                    if (dictionary.ContainsKey(parentFQN))
                    {
                        try
                        {
                            logger.Trace("Adding item to model as child of " + parentFQN + ": " + item.ToString());
                            FindItem(dictionary, parentFQN).AddChild(item);
                            logger.Trace("Adding item to dictionary with key: " + item.FQN);
                            dictionary.Add(item.FQN, item);

                            retVal.ReturnValue = item;
                        }
                        catch (Exception ex)
                        {
                            retVal.AddError("Exception thrown while attempting to add Item '" + item.FQN + "' to the model: " + ex.Message);
                            logger.Trace("Exception: " + ex);
                        }
                    }
                    else
                        retVal.AddError("The parent for item '" + item.FQN + " ('" + parentFQN + "') could not be found.");
                }
            }

            if (Dependency<IApplicationManager>().State != State.Starting) retVal.LogResult(logger);
            else retVal.LogResult(logger.Debug);
            logger.ExitMethod();
            return retVal;
        }

        /// <summary>
        ///     Assigns the Model and Dictionary contained within the supplied ModelBuildResult to the supplied model and dictionary.
        /// </summary>
        /// <param name="modelBuildResult">The built model to attach.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        private Result AttachModel(ModelBuildResult modelBuildResult)
        {
            logger.Info("Attaching Model...");

            if (!IsInState(State.Running, State.Starting))
                return new Result().AddError("The current operation is invalid when the " + ManagerName + " is not in the Running or Starting states (it is currently in the " + State + " state).");

            Result retVal = new Result();

            // if the ModelBuildResult that was passed in built successfully, update the Model and Dictionary properties with the
            // contents of the build result
            if (modelBuildResult.ResultCode != ResultCode.Failure)
            {
                Model = modelBuildResult.Model;
                Dictionary = modelBuildResult.Dictionary;
            }
            else
                retVal.AddError("Unable to attach a model that failed to build.");

            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        ///     Builds a Model using the Model Configuration stored within the ApplicationManager and returns a ModelBuildResult
        ///     containing the result.
        /// </summary>
        /// <returns>A new instance of ModelBuildResult containing the results of the build operation.</returns>
        private ModelBuildResult BuildModel()
        {
            if (!IsInState(State.Running, State.Starting))
                return (ModelBuildResult)new Result().AddError("The current operation is invalid in the current state (it is currently in the " + State + " state).");

            return BuildModel(Dependency<IApplicationManager>().InstanceName, Configuration.Items);
        }

        /// <summary>
        ///     Builds a Model using the provided list of ConfigurationItems and returns a ModelBuildResult containing the result.
        /// </summary>
        /// <param name="instanceName">The name of the application instance, to be used as the root node.</param>
        /// <param name="itemList">A list of ConfigurationItems containing Model Items to build.</param>
        /// <returns>A new instance of ModelBuildResult containing the results of the build operation.</returns>
        private ModelBuildResult BuildModel(string instanceName, List<ModelManagerConfigurationItem> itemList)
        {
            logger.EnterMethod();

            logger.Info("Building Model...");
            ModelBuildResult retVal = new ModelBuildResult() { UnresolvedList = itemList.Clone() };

            BuildModel(instanceName, itemList, retVal);

            retVal.LogResult(logger);

            // if the model was built successfully (with or without warnings), report the success and show some statistics.
            if (retVal.ResultCode != ResultCode.Failure)
            {
                logger.Info(retVal.ResolvedList.Count() + " Item(s) were resolved.");

                // if any items were unresolved, print them.
                if (retVal.UnresolvedList.Count() > 0)
                {
                    logger.Info("Unresolved Item(s):");
                    foreach (ModelManagerConfigurationItem mi in retVal.UnresolvedList)
                        logger.Info("\t" + mi.FQN);
                }
            }

            logger.ExitMethod();
            return retVal;
        }

        /// <summary>
        ///     Accepts a list of Configuration.Items and recursively instantiates items in the Model corresponding to the items in
        ///     the list.
        /// </summary>
        /// <param name="instanceName">The name of the application instance, to be used as the root node.</param>
        /// <param name="itemList">A list of model items from which to build the model.</param>
        /// <param name="result">
        ///     An instance of ModelBuildResult, ideally new. The method will recursively pass it to itself and return it to the
        ///     calling method when complete.
        /// </param>
        /// <param name="depth">The current depth of recursion. Defaults to 0 if omitted.</param>
        /// <returns>A ModelBuildResult containing the result of the build operation.</returns>
        private ModelBuildResult BuildModel(string instanceName, List<ModelManagerConfigurationItem> itemList, ModelBuildResult result, int depth = 0)
        {
            // we build the model recursively starting with root items (items with only one tuple in the FQN) and in ascending
            // order of the number of tuples in the FQN, e.x., "Symbiote.Platform.CPU.% Idle Time" is considered to be at level 4.
            // while "Symbiote.Platform.CPU" is level 3.
            //
            // the rationale behind this approach is that if the model is built in a breadth-first fashion there should not be any
            // instances where the code attempts to instantiate an item whos parent item has not yet been instantiated (but may
            // later be), unless the parent item was missing from the provided list or if the code failed to instantiate the parent
            // when it was processed.
            //
            // each recursive call of the method adds any unresolved items to the provided resolvedList. items should be added to
            // the list if their parent did not exist at the time of the attempted instantiation, or if the item itself failed to
            // be instantiated.
            //
            // if the SourceFQN for an item is a model item (rather than a plugin item) and if it is at a further depth than the
            // current item, we want to create the item without resolving the source item and add it to a list of deffered items so
            // that the source can be resolved after the model is built.

            // create an IEnumerable containing a list of all the items in the provided itemList at the requested depth
            List<ModelManagerConfigurationItem> items = itemList.Where(i => (i.FQN.Split('.').Length - 1) == depth).ToList();

            // iterate through the list of items
            foreach (ModelManagerConfigurationItem item in items)
            {
                try
                {
                    logger.Trace(new String('-', 30));

                    Item newItem;
                    newItem = new Item(instanceName + item.FQN, item.SourceFQN);

                    logger.Checkpoint("Created New Item", xLogger.Vars(newItem), xLogger.Names("newItem"));

                    // set the FQN of the ModelItem to the FQN of the ConfigurationModelItem
                    // this will be set "officially" when SetParent() is called to bind the item to its parent
                    //newItem.FQN = item.FQN;

                    // resolve the SourceFQN of the new item to an existing item ignore items with a blank SourceFQN; add those
                    // directly to the model.
                    if (newItem.SourceFQN != "")
                    {
                        logger.Trace("Attempting to resolve " + newItem.SourceFQN + "...");

                        // determine whether we should defer the resolution of the source item if the source of the item is a model
                        // item, and that item's depth is greater than this item, defer the resolution of the source item until
                        // after the model has been fully built.
                        string[] splitFQN = newItem.SourceFQN.Split('.');

                        if ((splitFQN[0] == Dependency<IApplicationManager>().InstanceName) && (splitFQN.Length - 1 >= depth))
                        {
                            logger.Info("Deferring the resolution of the SourceFQN for '" + newItem.FQN + "'.");
                            result.DeferredList.Add(newItem);
                        }
                        // the sourceitem is either not a model item or is at a shallower depth than the current item, so it is
                        // safe to resolve.
                        else
                        {
                            Item resolvedItem = Dependency<IApplicationManager>().ProviderRegistry.FindItem(newItem.SourceFQN);

                            if (resolvedItem == default(Item))
                                result.AddWarning("The Source FQN '" + newItem.SourceFQN + "' for item '" + newItem.FQN + "' could not be found.");
                            else
                            {
                                newItem.SourceItem = resolvedItem;

                                logger.Trace("Successfully resolved SourceFQN of Item '" + newItem.FQN + "' to '" + newItem.SourceItem.FQN + "'.");
                            }
                        }
                    }

                    if (GetParentFQNFromItemFQN(newItem.FQN) == string.Empty)
                    {
                        // the item we are working with has no parent and is therefore the root node of the model.
                        result.Dictionary.Add(newItem.FQN, newItem);
                        result.Model = newItem; //SetModelRoot(result.Model, result.Dictionary, newItem).ReturnValue;
                    }
                    else
                    {
                        Result<Item> addResult = AddItem(result.Model, result.Dictionary, newItem);

                        if (addResult.ResultCode != ResultCode.Failure)
                        {
                            result.UnresolvedList.Remove(item);
                            result.ResolvedList.Add(item);
                            logger.Info("Added item '" + newItem.FQN + "' to the Model.");
                        }
                        else
                        {
                            result.AddWarning("Failed to add item '" + newItem.FQN + "' to the Model: " + addResult.GetLastError());
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.AddWarning("Failed to add the item '" + item.FQN + "' to the Model: " + ex.Message);
                    logger.Trace("Exception: " + ex);
                    continue;
                }
            }

            // if at least one item was processed at this depth, recursively call this method one level deeper
            if (items.Count() > 0)
                BuildModel(instanceName, itemList, result, depth + 1);
            // if nothing was processed at this depth the model is fully built. resolve the source FQNs of any deferred items
            else
            {
                if (result.DeferredList.Count() > 0)
                {
                    logger.Info("Resolving the SourceFQN of " + result.DeferredList.Count() + " deferred Item(s)...");

                    foreach (Item item in result.DeferredList)
                    {
                        logger.Trace("Attempting to resolve the SourceItem '" + item.SourceFQN + "' for item " + item.FQN + "'...");

                        // make sure the item exists in the dictionary
                        if (result.Dictionary.ContainsKey(item.FQN))
                        {
                            // make sure the model contains the source FQN
                            if (result.Dictionary.ContainsKey(item.SourceFQN))
                            {
                                result.Dictionary[item.FQN].SourceItem = result.Dictionary[item.SourceFQN];
                                logger.Info("Resolved the SourceFQN of '" + item.FQN + "' to '" + result.Dictionary[item.FQN].SourceItem.FQN + "'.");
                            }
                            else
                                result.AddWarning("The Source FQN '" + item.SourceFQN + "' for item '" + item.FQN + "' could not be found.");
                        }
                        else
                            result.AddWarning("Item '" + item.FQN + "' was deferred for source resolution but can't be found in the model.");
                    }
                }
            }

            return result;
        }

        /// <summary>
        ///     Creates a copy of the specified Item and stores it at the specified FQN within the specified Model and Dictionary.
        /// </summary>
        /// <param name="model">The Model in which to copy the Item.</param>
        /// <param name="dictionary">The Dictionary in which to copy the Item.</param>
        /// <param name="item">The Item to copy.</param>
        /// <param name="fqn">The Fully Qualified Name of the destination Item.</param>
        /// <returns>A Result containing the result of the operation and the newly created Item.</returns>
        private Result<Item> CopyItem(Item model, Dictionary<string, Item> dictionary, Item item, string fqn)
        {
            Result<Item> retVal = new Result<Item>();
            if ((item == null) || (fqn == "")) return retVal;

            logger.Info("Copying Item '" + item.FQN + "' to FQN '" + fqn + "'...");

            Item parent = FindItem(dictionary, GetParentFQNFromItemFQN(fqn));

            if (parent == default(Item))
                retVal.AddError("The parent item '" + GetParentFQNFromItemFQN(fqn) + "' was not found in the model.");
            else
            {
                // create a clone of the item we are copying
                Item copiedItem = (Item)item.Clone();

                // set the FQN to the new FQN
                Result<Item> renameResult = RenameItemInstance(copiedItem, fqn);
                retVal.Incorporate(renameResult);

                if (renameResult.ResultCode != ResultCode.Failure)
                {
                    // add the new item to the model
                    Result<Item> addResult = AddItem(model, dictionary, renameResult.ReturnValue);
                    retVal.ReturnValue = addResult.ReturnValue;

                    retVal.Incorporate(addResult);
                }
            }

            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        ///     Returns the ModelItem from the supplied Dictionary matching the supplied key.
        /// </summary>
        /// <param name="dictionary">The Dictionary from which to retrieve the item.</param>
        /// <param name="fqn">The Fully Qualified Name of the desired ModelItem.</param>
        /// <returns>The ModelItem stored in the supplied Dictionary corresponding to the supplied key.</returns>
        private Item FindItem(Dictionary<string, Item> dictionary, string fqn)
        {
            logger.EnterMethod(xLogger.Params(xLogger.Exclude(), fqn));
            Item retVal = default(Item);

            if (dictionary != default(Dictionary<string, Item>) && dictionary.ContainsKey(fqn))
            {
                retVal = dictionary[fqn];
            }

            logger.ExitMethod(retVal?.FQN);
            return retVal;
        }

        /// <summary>
        ///     Moves the supplied Item from one place in the supplied Model and Dictionary to another based on the supplied FQN.
        /// </summary>
        /// <param name="dictionary">The Dictionary containing the supplied Item.</param>
        /// <param name="item">The Item to move.</param>
        /// <param name="fqn">The Fully Qualified Name representing the new location for the Item.</param>
        /// <returns>A Result containing the moved Item.</returns>
        private Result<Item> MoveItem(Dictionary<string, Item> dictionary, Item item, string fqn)
        {
            logger.Info("Moving Item '" + item.FQN + "' to new FQN '" + fqn + "'...");
            Result<Item> retVal = new Result<Item>();

            // find the parent item first to ensure the provided FQN is valid
            Item parent = FindItem(dictionary, GetParentFQNFromItemFQN(fqn));

            if (parent == default(Item))
                retVal.AddError("The parent item '" + GetParentFQNFromItemFQN(fqn) + "' was not found in the model.");
            else
            {
                // copy the item to the new location
                Result copyResult = CopyItem(item, fqn);
                retVal.Incorporate(copyResult);

                if (copyResult.ResultCode != ResultCode.Failure)
                {
                    Result deleteResult = RemoveItem(dictionary, item);
                    retVal.Incorporate(deleteResult);
                }
            }

            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        ///     Removes an Item from the provided Dictionary and removes it from its parent Item.
        /// </summary>
        /// <param name="dictionary">The Dictionary from which to remove the Item.</param>
        /// <param name="item">The Item to remove.</param>
        /// <returns>A Result containing the removed Item.</returns>
        private Result<Item> RemoveItem(Dictionary<string, Item> dictionary, Item item)
        {
            if (item != default(Item))
                logger.Info("Removing Item '" + item.FQN + "' from the model...");
            else
                return new Result<Item>().AddError("The specified Item is null.");

            Result<Item> retVal = new Result<Item>();
            retVal.ReturnValue = item;

            try
            {
                if (item.Parent == item)
                {
                    retVal.AddError("Removing the root Item in the model is not permitted.");
                }
                else
                {
                    // pretty brutal, forcing the parent to kill one of it's children.
                    item.Parent.RemoveChild(item);

                    // remove the item itself from the dictionary
                    dictionary.Remove(item.FQN);

                    // remove any children of this item. find any item in the dictionary with the first part of it's FQN fully
                    // matching the FQN of the removed item
                    List<string> fqnsToDelete = new List<string>();

                    // iterate over the list of matching items and delete them from the dictionary note that we can't iterate over
                    // dictionary itself while we are changing it, hence the temporary list.
                    foreach (KeyValuePair<string, Item> child in dictionary.Where(kvp => kvp.Key.StartsWith(item.FQN + ".")))
                    {
                        fqnsToDelete.Add(child.Key);
                    }

                    foreach (string fqn in fqnsToDelete)
                    {
                        dictionary.Remove(fqn);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Trace("Exception thrown removing item '" + item.FQN + "' from the model: " + ex.Message);
                retVal.AddError("Exception thrown removing item '" + item.FQN + "'.");
            }

            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        ///     Renames the provided Item and all child Items "in place" without affecting the model. This method supports the
        ///     CopyItem and MoveItem methods; if you want to move something in the model as well as rename it, use MoveItem. To be
        ///     crystal clear, this is not a CRUD operation!
        /// </summary>
        /// <param name="item">The Item to rename.</param>
        /// <param name="fqn">The new Fully Qualified Name for the Item.</param>
        /// <returns>A renamed clone of the provided Item.</returns>
        private Result<Item> RenameItemInstance(Item item, string fqn)
        {
            logger.Debug("Renaming Item '" + item.FQN + "' to '" + fqn + "'");
            Result<Item> retVal = new Result<Item>();

            retVal.ReturnValue = (Item)item.Clone();

            // TODO: fix this?
            //retVal.ReturnValue.FQN = fqn;

            IEnumerable<Item> childrenToRename = retVal.ReturnValue.Children.Clone();

            foreach (Item child in childrenToRename)
            {
                Result<Item> renameResult = RenameItemInstance(child, retVal.ReturnValue.FQN + '.' + child.Name);
                if (renameResult.ResultCode != ResultCode.Failure)
                {
                    retVal.ReturnValue.RemoveChild(child);
                    retVal.ReturnValue.AddChild(renameResult.ReturnValue);
                }

                retVal.Incorporate(renameResult);
            }

            retVal.LogResult(logger.Debug);
            return retVal;
        }

        /// <summary>
        ///     Generates a list of ConfigurationModelItems based on the current Model and updates the Configuration. If
        ///     flushToDisk is true, saves the updated Configuration to disk.
        /// </summary>
        /// <returns>A Result containing the list of saved ConfigurationModelItems.</returns>
        private Result<List<ModelManagerConfigurationItem>> SaveModel()
        {
            logger.EnterMethod();
            logger.Info("Saving Model...");

            if (!IsInState(State.Running, State.Stopping))
                return (Result<List<ModelManagerConfigurationItem>>)new Result()
                    .AddError("The current operation is invalid when the " + ManagerName + " is not in the Running or Stopping states (it is currently in the " + State + " state).");

            Result<List<ModelManagerConfigurationItem>> configuration = new Result<List<ModelManagerConfigurationItem>>();
            configuration.ReturnValue = new List<ModelManagerConfigurationItem>();

            Result<List<ModelManagerConfigurationItem>> retVal = SaveModel(Model, configuration);

            if (retVal.ResultCode != ResultCode.Failure)
            {
                Configuration.Items = retVal.ReturnValue;
                SaveConfiguration();
            }

            retVal.LogResult(logger);
            logger.ExitMethod();
            return retVal;
        }

        /// <summary>
        ///     Updates and returns the provided Result containing the list of ConfigurationModelItems with the recursively listed
        ///     contents of the provided ModelItem.
        /// </summary>
        /// <param name="itemRoot">The ModelItem from which to start recursively updating the list.</param>
        /// <param name="configuration">A Result containing the list of ConfigurationModelItems to update.</param>
        /// <returns>A Result containing the list of saved ConfigurationModelItems.</returns>
        private Result<List<ModelManagerConfigurationItem>> SaveModel(Item itemRoot, Result<List<ModelManagerConfigurationItem>> configuration)
        {
            configuration.ReturnValue.Add((ModelManagerConfigurationItem)new ModelManagerConfigurationItem() { FQN = itemRoot.FQN.Replace(Dependency<IApplicationManager>().InstanceName, ""), SourceFQN = itemRoot.SourceFQN });

            foreach (Item mi in itemRoot.Children)
            {
                SaveModel(mi, configuration);
            }

            return configuration;
        }

        private Result<Item> SetModelRoot(Item model, Dictionary<string, Item> dictionary, Item item)
        {
            logger.EnterMethod(xLogger.Params(model, item));

            Result<Item> retVal = new Result<Item>();

            // only one root item can be defined.
            if (model.Name != "")
            {
                retVal.AddError("The Model root has already been defined.");
            }

            // update the model root item with the details of the supplied item
            logger.Trace("Setting Model root to a new instance of Item()");

            logger.Checkpoint("Root item", xLogger.Params(item));

            //model.Clone(item);
            model = item;

            logger.Checkpoint("root set", xLogger.Params(model));

            logger.Trace("Adding item to dictionary with key: " + item.FQN);
            dictionary.Add(model.FQN, model);

            retVal.ReturnValue = model;

            logger.ExitMethod(retVal);
            return retVal;
        }

        #endregion Private Methods
    }

    /// <summary>
    ///     The Model namespace encapsulates the model for the application. The model consists of two collections of Items; a
    ///     parent/child tree of Items that implements the composite design pattern, and a dictionary keyed on the FQN of Items and
    ///     containing a reference to the keyed Item.
    ///
    ///     The Item composite allows for logical management and retrieval of data from the model, while the dictionary provides
    ///     fast lookups of model items.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    internal class NamespaceDoc
    { }
}