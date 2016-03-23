using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using Symbiote.Core.Configuration;

namespace Symbiote.Core.Model
{
    /// <summary>
    /// The Model namespace encapsulates the model for the application.  The model consists of two collections of Items;
    /// a parent/child tree of Items that implements the composite design pattern, and a dictionary keyed on the FQN of
    /// Items and containing a reference to the keyed Item.
    /// 
    /// The Item composite allows for logical management and retrieval of data from the model, while the dictionary provides
    /// fast lookups of model items.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc { }

    /// <summary>
    /// The ModelManager class manages the Model for the application.
    /// </summary>
    public class ModelManager : IManager, IConfigurable<ModelManagerConfiguration>
    {
        #region Variables

        /// <summary>
        /// The Logger for this class.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The ProgramManager for the application.
        /// </summary>
        private ProgramManager manager;

        /// <summary>
        /// The Singleton instance of ModelManager.
        /// </summary>
        private static ModelManager instance;

        #endregion

        #region Properties

        /// <summary>
        /// The state of the Manager.
        /// </summary>
        public bool Running { get; private set; }

        /// <summary>
        /// The ConfigurationDefinition for the Manager.
        /// </summary>
        public ConfigurationDefinition ConfigurationDefinition { get { return GetConfigurationDefinition(); } }

        /// <summary>
        /// The Configuration for the Manager.
        /// </summary>
        public ModelManagerConfiguration Configuration { get; private set; }

        /// <summary>
        /// The root Item for the model.
        /// </summary>
        internal Item Model { get; private set; }

        /// <summary>
        /// A dictionary containing the Fully Qualified Names and references to all of the Items in the model.
        /// </summary>
        internal Dictionary<string, Item> Dictionary { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Private constructor, only called by Instance()
        /// </summary>
        /// <param name="manager">The ProgramManager instance for the application.</param>
        private ModelManager(ProgramManager manager)
        {
            this.manager = manager;
            Running = false;
        }

        /// <summary>
        /// Instantiates and/or returns the ModelManager instance.
        /// </summary>
        /// <param name="manager">The ProgramManager instance for the application.</param>
        /// <returns>The Singleton instance of the ModelManager.</returns>
        internal static ModelManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new ModelManager(manager);

            return instance;
        }

        #endregion

        #region Instance Methods

        #region IManager Implementation

        /// <summary>
        /// Starts the Model manager.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Start()
        {
            logger.Info("Starting the Model Manager...");
            OperationResult retVal = new OperationResult();

            #region Configuration

            //--------------- - - -
            // Configure the Manager
            OperationResult configureResult = Configure();

            if (configureResult.ResultCode == OperationResultCode.Failure)
                throw new Exception("Failed to configure the Model Manager: " + configureResult.GetLastError());

            retVal.Incorporate(configureResult);
            //--------------------------------  -

            #endregion

            #region Model Building

            //--  -  -- ---------------  -
            // Build the model
            ModelBuildResult modelBuildResult = BuildModel(Configuration.Items);

            if (modelBuildResult.ResultCode == OperationResultCode.Failure)
                throw new Exception("Failed to build the model: " + modelBuildResult.GetLastError()); 

            retVal.Incorporate(modelBuildResult);
            //--- - ------------

            #endregion

            #region Model Attaching

            //------------------------------   -
            // Attach the newly built model to the Model Manager
            OperationResult attachResult = AttachModel(modelBuildResult);

            if (attachResult.ResultCode == OperationResultCode.Failure)
                throw new Exception("Failed to attach the model to the Model Manager: " + attachResult.GetLastError());

            retVal.Incorporate(attachResult);
            //---- - ------------  - 

            #endregion

            Running = (retVal.ResultCode != OperationResultCode.Failure);

            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Restarts the Configuration manager.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Restart()
        {
            logger.Info("Restarting the Model Manager...");
            OperationResult retVal = new OperationResult();

            retVal.Incorporate(Stop());
            retVal.Incorporate(Start());

            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Stops the Configuration manager.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Stop()
        {
            logger.Info("Stopping the Model Manager...");
            OperationResult retVal = new OperationResult();

            retVal.Incorporate(SaveModel());

            Running = false;

            retVal.LogResult(logger);
            return retVal;
        }

        #endregion

        #region IConfigurable Implementation

        /// <summary>
        /// Configures the Model Manager using the configuration stored in the Configuration Manager, or, failing that, using the default configuration.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Configure()
        {
            logger.Debug("Attempting to Configure with the configuration from the Configuration Manager...");
            OperationResult retVal = new OperationResult();

            OperationResult<ModelManagerConfiguration> fetchResult = manager.ConfigurationManager.GetInstanceConfiguration<ModelManagerConfiguration>(this.GetType());

            // if the fetch succeeded, configure this instance with the result.  
            if (fetchResult.ResultCode != OperationResultCode.Failure)
            {
                logger.Debug("Successfully fetched the configuration from the Configuration Manager.");
                Configure(fetchResult.Result);
            }
            // if the fetch failed, add a new default instance to the configuration and try again.
            else
            {
                logger.Debug("Unable to fetch the configuration.  Adding the default configuration to the Configuration Manager...");
                OperationResult createResult = manager.ConfigurationManager.AddInstanceConfiguration(this.GetType(), GetDefaultConfiguration());
                if (createResult.ResultCode != OperationResultCode.Failure)
                {
                    logger.Debug("Successfully added the configuration.  Configuring...");
                    Configure();
                }
                else
                    retVal.Incorporate(createResult);
            }

            retVal.LogResultDebug(logger);
            return retVal;
        }

        /// <summary>
        /// Configures the Model Manager using the supplied configuration, then saves the configuration to the Model Manager.
        /// </summary>
        /// <param name="configuration">The configuration with which the Model Manager should be configured.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Configure(ModelManagerConfiguration configuration)
        {
            logger.Debug("Configuring...");
            OperationResult retVal = new OperationResult();

            // update the configuration
            Configuration = configuration;

            // save it
            logger.Debug("Saving the new configuration...");
            retVal.Incorporate(SaveConfiguration());

            retVal.LogResultDebug(logger);
            return retVal;
        }

        /// <summary>
        /// Saves the configuration to the Configuration Manager.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult SaveConfiguration()
        {
            logger.Debug("Saving the configuration...");
            OperationResult retVal = new OperationResult();

            retVal.Incorporate(manager.ConfigurationManager.UpdateInstanceConfiguration(this.GetType(), Configuration));

            retVal.LogResultDebug(logger);
            return retVal;
        }

        #endregion

        #region Model Management (Build, Attach and Save)

        /// <summary>
        /// Builds a Model using the Model Configuration stored within the ProgramManager and returns a ModelBuildResult containing the result.
        /// </summary>
        /// <returns>A new instance of ModelBuildResult containing the results of the build operation.</returns>
        public ModelBuildResult BuildModel()
        {
            return BuildModel(Configuration.Items);
        }

        /// <summary>
        /// Builds a Model using the provided list of ConfigurationItems and returns a ModelBuildResult containing the result.
        /// </summary>
        /// <param name="itemList">A list of ConfigurationItems containing Model Items to build.</param>
        /// <returns>A new instance of ModelBuildResult containing the results of the build operation.</returns>
        private ModelBuildResult BuildModel(List<ModelManagerConfigurationItem> itemList)
        {
            logger.Info("Building Model...");
            ModelBuildResult retVal = new ModelBuildResult() { ResultCode = OperationResultCode.Success, UnresolvedList = itemList.Clone() };

            BuildModel(itemList, retVal);

            retVal.LogResult(logger);

            // if the model was built successfully (with or without warnings), report the success and show some statistics.
            if (retVal.ResultCode != OperationResultCode.Failure)
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

            return retVal;
        }

        /// <summary>
        /// Accepts a list of Configuration.Items and recursively instantiates items in the Model corresponding to the items in the list.
        /// </summary>
        /// <param name="itemList">A list of model items from which to build the model.</param>
        /// <param name="result">An instance of ModelBuildResult, ideally new.  The method will recursively pass it to itself and return it to the calling method when complete.</param>
        /// <param name="depth">The current depth of recursion. Defaults to 0 if omitted.</param>
        /// <returns>A ModelBuildResult containing the result of the build operation.</returns>
        private ModelBuildResult BuildModel(List<ModelManagerConfigurationItem> itemList, ModelBuildResult result, int depth = 0)
        {
            // we build the model recursively starting with root items (items with only one tuple in the FQN) and in ascending order
            // of the number of tuples in the FQN, e.x., "Symbiote.Platform.CPU.% Idle Time" is considered to be at level 4. while
            // "Symbiote.Platform.CPU" is level 3.
            //
            // the rationale behind this approach is that if the model is built in a breadth-first fashion there should not be 
            // any instances where the code attempts to instantiate an item whos parent item has not yet been instantiated (but may later be),
            // unless the parent item was missing from the provided list or if the code failed to instantiate the parent when it 
            // was processed.
            //
            // each recursive call of the method adds any unresolved items to the provided resolvedList.  items should be added
            // to the list if their parent did not exist at the time of the attempted instantiation, or if the item itself failed
            // to be instantiated.
            // 
            // if the SourceFQN for an item is a model item (rather than a plugin item) and if it is at a further depth than
            // the current item, we want to create the item without resolving the source item and add it to a list of deffered
            // items so that the source can be resolved after the model is built.

            // create an IEnumerable containing a list of all the items in the provided itemList at the requested depth
            IEnumerable<ModelManagerConfigurationItem> items = itemList.Where(i => (i.FQN.Split('.').Length - 1) == depth);

            // iterate through the list of items
            foreach (ModelManagerConfigurationItem item in items)
            {
                try
                {
                    logger.Trace(new String('-', 30));

                    Item newItem;
                    newItem = new Item(item.FQN, item.SourceFQN);

                    // set the FQN of the ModelItem to the FQN of the ConfigurationModelItem
                    // this will be set "officially" when SetParent() is called to bind the item to its parent
                    //newItem.FQN = item.FQN;

                    // resolve the SourceFQN of the new item to an existing item
                    // ignore items with a blank SourceFQN; add those directly to the model.
                    if (newItem.SourceFQN != "")
                    {
                        logger.Trace("Attempting to resolve " + newItem.SourceFQN + "...");

                        // determine whether we should defer the resolution of the source item
                        // if the source of the item is a model item, and that item's depth is greater than this item, defer the resolution
                        // of the source item until after the model has been fully built.
                        if ((FQNResolver.GetSource(newItem.SourceFQN) == FQNResolver.ItemSource.Model) && (newItem.SourceFQN.Split('.').Length - 1 >= depth))
                        {
                            logger.Info("Deferring the resolution of the SourceFQN for '" + newItem.FQN + "'.");
                            result.DeferredList.Add(newItem);
                        }
                        // the sourceitem is either not a model item or is at a shallower depth than the current item, so it is safe to 
                        // resolve.
                        else
                        {
                            Item resolvedItem = FQNResolver.Resolve(newItem.SourceFQN);

                            if (resolvedItem == default(Item))
                                result.AddWarning("The Source FQN '" + newItem.SourceFQN + "' for item '" + newItem.FQN + "' could not be found.");
                            else
                            {
                                newItem.SourceItem = resolvedItem;

                                logger.Trace("Successfully resolved SourceFQN of Item '" + newItem.FQN + "' to '" + newItem.SourceItem.FQN + "'.");
                            }
                        }
                    }
                    
                    OperationResult addResult = AddItem(result.Model, result.Dictionary, newItem);

                    if (addResult.ResultCode != OperationResultCode.Failure)
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
                catch (Exception ex)
                {
                    result.AddWarning("Failed to add the item '" + item.FQN + "' to the Model: " + ex.Message);
                    logger.Trace("Exception: " + ex);
                    continue;
                }
            }

            // if at least one item was processed at this depth, recursively call this method one level deeper
            if (items.Count() > 0)
                BuildModel(itemList, result, depth + 1);
            // if nothing was processed at this depth the model is fully built.  
            // resolve the source FQNs of any deferred items
            else
            {
                if (result.DeferredList.Count > 0)
                {
                    logger.Info("Resolving the SourceFQN of " + result.DeferredList.Count + " deferred Item(s)...");

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
        /// Assigns the Model and Dictionary contained within the supplied ModelBuildResult to the supplied model and dictionary.
        /// </summary>
        /// <param name="model">The model to which to attach the model contained within the ModelBuildResult.</param>
        /// <param name="dictionary">The dictionary to which to attach the dictionary contained within the ModelBuildResult.</param>
        /// <param name="modelBuildResult">The built model to attach.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult AttachModel(ModelBuildResult modelBuildResult)
        {
            logger.Info("Attaching Model...");

            OperationResult retVal = new OperationResult();

            // if the ModelBuildResult that was passed in built successfully, update the Model and Dictionary properties with the contents of the build result
            if (modelBuildResult.ResultCode != OperationResultCode.Failure)
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
        /// Generates a list of ConfigurationModelItems based on the current Model and updates the Configuration.  If flushToDisk is true, saves the updated Configuration to disk.
        /// </summary>
        /// <param name="flushToDisk">Save the updated Configuration to disk.</param>
        /// <returns>An OperationResult containing the list of saved ConfigurationModelItems.</returns>
        public OperationResult<List<ModelManagerConfigurationItem>> SaveModel(bool flushToDisk = false)
        {
            logger.Info("Saving Model" + (flushToDisk ? " and flushing the Configuration to disk" : "") + "...");

            OperationResult<List<ModelManagerConfigurationItem>> configuration = new OperationResult<List<ModelManagerConfigurationItem>>();
            configuration.Result = new List<ModelManagerConfigurationItem>();

            OperationResult<List<ModelManagerConfigurationItem>> retVal = SaveModel(Model, configuration);

            if (retVal.ResultCode != OperationResultCode.Failure)
            {
                Configuration.Items = retVal.Result;

                if (flushToDisk)
                {
                    // if the save fails, add a warning about the failure and copy the messages from that operationresult to this one.
                    if (manager.ConfigurationManager.SaveConfiguration().ResultCode == OperationResultCode.Failure)
                        retVal.AddWarning("The model was saved to the ConfigurationManager, however the flush to disk failed.");
                }
            }

            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Updates and returns the provided OperationResult containing the list of ConfigurationModelItems with the recursively listed contents of the provided ModelItem.
        /// </summary>
        /// <param name="itemRoot">The ModelItem from which to start recursively updating the list.</param>
        /// <param name="configuration">An OperationResult containing the list of ConfigurationModelItems to update.</param>
        /// <returns>An OperationResult containing the list of saved ConfigurationModelItems.</returns>
        private OperationResult<List<ModelManagerConfigurationItem>> SaveModel(Item itemRoot, OperationResult<List<ModelManagerConfigurationItem>> configuration)
        {
            configuration.Result.Add(new ModelManagerConfigurationItem() { FQN = itemRoot.FQN, SourceFQN = itemRoot.SourceFQN });

            foreach (Item mi in itemRoot.Children)
            {
                SaveModel(mi, configuration);
            }

            return configuration;
        }

        #endregion

        #region Model Item Management (CRUD)

        /// <summary>
        /// Adds an Item to the ModelManager's instance of Model and Dictionary.
        /// </summary>
        /// <param name="item">The Item to add.</param>
        /// <returns>An OperationResult containing the added Item.</returns>
        public OperationResult<Item> AddItem(Item item)
        {
            return AddItem(Model, Dictionary, item);
        }

        /// <summary>
        /// Adds an Item to the given Model and Dictionary.
        /// </summary>
        /// <param name="model">The Model to which to add the Item.</param>
        /// <param name="dictionary">The Dictionary to which to add the Item.</param>
        /// <param name="item">The Item to add.</param>
        /// <returns>An OperationResult containing the added Item.</returns>
        private OperationResult<Item> AddItem(Item model, Dictionary<string, Item> dictionary, Item item)
        {
            if (!manager.Starting) logger.Info("Adding item '" + item.FQN + "' to the model...");
            else logger.Debug("Adding item '" + item.FQN + "' to the model...");

            OperationResult<Item> retVal = new OperationResult<Item>();

            string parentFQN = GetParentFQNFromItemFQN(item.FQN);

            // if the parent FQN couldn't be parsed, this is the root node so clone it to the existing ModelItem representing the root.
            if (parentFQN == "")
            {
                // only one root item can be defined.  
                if (model.Name != "") { retVal.AddError("The Model root has already been defined."); }
                else
                {
                    // update the model root item with the details of the supplied item
                    logger.Trace("Setting Model root to a new instance of ModelItem()");
                    model.Name = item.Name;
                    model.FQN = item.FQN;
                    model.Path = item.Path;
                    logger.Trace("Adding item to dictionary with key: " + item.FQN);
                    dictionary.Add(model.FQN, model);

                    retVal.Result = model;
                }
            }
            else
            {
                // ensure the item hasn't been added already.
                Item foundItem = FindItem(dictionary, item.FQN);
                if (foundItem != default(Item))
                    retVal.AddError("The item already exists in the dictionary.");
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

                            retVal.Result = item;


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

            if (!manager.Starting) retVal.LogResult(logger);
            else retVal.LogResultDebug(logger);

            return retVal;
        }

        /// <summary>
        /// Returns the ModelItem from the Dictionary belonging to the ModelManager instance matching the supplied key.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the desired ModelItem.</param>
        /// <returns>The ModelItem from the Model corresponding to the supplied key.</returns>
        /// <remarks>Retrieves items from the Dictionary instance belonging to the ModelManager instance.</remarks>
        public Item FindItem(string fqn)
        {
            return FindItem(Dictionary, fqn);
        }

        /// <summary>
        /// Returns the ModelItem from the supplied Dictionary matching the supplied key.
        /// </summary>
        /// <param name="dictionary">The Dictionary from which to retrieve the item.</param>
        /// <param name="fqn">The Fully Qualified Name of the desired ModelItem.</param>
        /// <returns>The ModelItem stored in the supplied Dictionary corresponding to the supplied key.</returns>
        private Item FindItem(Dictionary<string, Item> dictionary, string fqn)
        {
            if (dictionary.ContainsKey(fqn))
                return dictionary[fqn];

            else return default(Item);
        }

        /// <summary>
        /// Updates the supplied Item with the supplied Source Item.
        /// </summary>
        /// <param name="item">The Item to update.</param>
        /// <param name="sourceItem">The SourceItem with which to update the Item.</param>
        /// <returns>An OperationResult containing the result of the operation and the updated Item.</returns>
        public OperationResult<Item> UpdateItem(Item item, Item sourceItem)
        {
            logger.Info("Updating Item '" + item.FQN + "'s SourceItem to '" + sourceItem.FQN + "'...");
            OperationResult<Item> retVal = new OperationResult<Item>();

            if (sourceItem != default(Item))
            {
                item.SourceItem = sourceItem;
                item.SourceFQN = sourceItem.FQN;

                retVal.Result = item;
            }
            else
                retVal.AddError("The supplied SourceItem is invalid.");

            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Removes an Item from the ModelManager's Dictionary and from its parent Item.
        /// </summary>
        /// <param name="item">The Item to remove.</param>
        /// <returns>An OperationResult containing the removed Item.</returns>
        public OperationResult<Item> RemoveItem(Item item)
        {
            return RemoveItem(Dictionary, item);
        }

        /// <summary>
        /// Removes an Item from the provided Dictionary and removes it from its parent Item.
        /// </summary>
        /// <param name="dictionary">The Dictionary from which to remove the Item.</param>
        /// <param name="item">The Item to remove.</param>
        /// <returns>An OperationResult containing the removed Item.</returns>
        private OperationResult<Item> RemoveItem(Dictionary<string, Item> dictionary, Item item)
        {
            if (item != default(Item))
                logger.Info("Removing Item '" + item.FQN + "' from the model...");
            else
                return new OperationResult<Item>().AddError("The specified Item is null.");

            OperationResult<Item> retVal = new OperationResult<Item>();
            retVal.Result = item;

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

                    // remove any children of this item.  find any item in the dictionary with the first part of it's FQN fully matching
                    // the FQN of the removed item
                    List<string> fqnsToDelete = new List<string>();

                    // iterate over the list of matching items and delete them from the dictionary
                    // note that we can't iterate over dictionary itself while we are changing it, hence the temporary list.
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
        /// Moves the supplied Item from one place in the ModelManager's instances of Model and Dictionary to another based on the supplied FQN.
        /// </summary>
        /// <param name="item">The Item to move.</param>
        /// <param name="fqn">The Fully Qualified Name representing the new location for the item.</param>
        /// <returns>An OperationResult containing the moved Item.</returns>
        public OperationResult<Item> MoveItem(Item item, string fqn)
        {
            return MoveItem(Dictionary, item, fqn);
        }

        /// <summary>
        /// Moves the supplied Item from one place in the supplied Model and Dictionary to another based on the supplied FQN.
        /// </summary>
        /// <param name="dictionary">The Dictionary containing the supplied Item.</param>
        /// <param name="item">The Item to move.</param>
        /// <param name="fqn">The Fully Qualified Name representing the new location for the Item.</param>
        /// <returns>An OperationResult containing the moved Item.</returns>
        private OperationResult<Item> MoveItem(Dictionary<string, Item> dictionary, Item item, string fqn)
        {
            logger.Info("Moving Item '" + item.FQN + "' to new FQN '" + fqn + "'...");
            OperationResult<Item> retVal = new OperationResult<Item>();

            // find the parent item first to ensure the provided FQN is valid
            Item parent = FindItem(dictionary, GetParentFQNFromItemFQN(fqn));

            if (parent == default(Item))
                retVal.AddError("The parent item '" + GetParentFQNFromItemFQN(fqn) + "' was not found in the model.");
            else
            {
                // copy the item to the new location
                OperationResult copyResult = CopyItem(item, fqn);
                retVal.Incorporate(copyResult);

                if (copyResult.ResultCode != OperationResultCode.Failure)
                {
                    OperationResult deleteResult = RemoveItem(dictionary, item);
                    retVal.Incorporate(deleteResult);
                }
            }

            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Creates a copy of the specified Item and stores it at the specified FQN within the default Model and Dictionary.
        /// </summary>
        /// <param name="item">The Item to copy.</param>
        /// <param name="fqn">The Fully Qualified Name of the destination Item.</param>
        /// <returns>An OperationResult containing the result of the operation and the newly created Item.</returns>
        public OperationResult<Item> CopyItem(Item item, string fqn)
        {
            return CopyItem(Model, Dictionary, item, fqn);
        }

        /// <summary>
        /// Creates a copy of the specified Item and stores it at the specified FQN within the specified Model and Dictionary.
        /// </summary>
        /// <param name="model">The Model in which to copy the Item.</param>
        /// <param name="dictionary">The Dictionary in which to copy the Item.</param>
        /// <param name="item">The Item to copy.</param>
        /// <param name="fqn">The Fully Qualified Name of the destination Item.</param>
        /// <returns>An OperationResult containing the result of the operation and the newly created Item.</returns>
        private OperationResult<Item> CopyItem(Item model, Dictionary<string, Item> dictionary, Item item, string fqn)
        {
            logger.Info("Copying Item '" + item.FQN + "' to FQN '" + fqn + "'...");
            OperationResult<Item> retVal = new OperationResult<Item>();

            Item parent = FindItem(dictionary, GetParentFQNFromItemFQN(fqn));

            if (parent == default(Item))
                retVal.AddError("The parent item '" + GetParentFQNFromItemFQN(fqn) + "' was not found in the model.");
            else
            {
                // create a clone of the item we are copying
                Item copiedItem = (Item)item.Clone();

                // set the FQN to the new FQN
                OperationResult<Item> renameResult = RenameItemInstance(copiedItem, fqn);
                retVal.Incorporate(renameResult);

                if (renameResult.ResultCode != OperationResultCode.Failure)
                {
                    // add the new item to the model
                    OperationResult<Item> addResult = AddItem(model, dictionary, renameResult.Result);
                    retVal.Result = addResult.Result;

                    retVal.Incorporate(addResult);
                }
            }

            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Attaches the provided Item to the supplied Item.  This method should be used only to attach plugin Items
        /// to the application model.  When adding Items directly, use AddItem.
        /// </summary>
        /// <param name="item">The Item to attach to the Model.</param>
        /// <param name="parentItem">The Item to which the new Item should be attached.</param>
        /// <returns>The attached Item.</returns>
        public OperationResult<Item> AttachItem(Item item, Item parentItem)
        {
            if (!manager.Starting) logger.Info("Attaching Item '" + item.FQN + "' to '" + parentItem.FQN + "'...");
            else logger.Debug("Attaching Item '" + item.FQN + "' to '" + parentItem.FQN + "'...");

            OperationResult<Item> retVal = new OperationResult<Item>();

            try
            {
                // create a 1:1 clone of the supplied item
                retVal.Result = (Item)item.Clone();

                // set the SourceFQN of the new item to the FQN of the original item to create a link
                retVal.Result.SourceFQN = retVal.Result.FQN;
                retVal.Result.SourceItem = FQNResolver.Resolve(retVal.Result.SourceFQN);

                // modify the FQN of the cloned item to reflect it's new path
                retVal.Result.FQN = parentItem.FQN + "." + retVal.Result.Name;

                // create a temporary list of the items children
                List<Item> children = retVal.Result.Children.Clone<Item>();

                // remove the children from the item (you leave my babies!)
                retVal.Result.Children.Clear();
                // they're my babies now, you commie son of a bitch!

                // add the cloned and cleaned item to the model
                AddItem(retVal.Result);

                // for each child of the original item, attach that item to the model under the cloned and cleaned parent
                foreach (Item child in children)
                {
                    AttachItem(child, retVal.Result);
                }
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown when attempting to Attach Item '" + item.FQN + "':" + ex);
                retVal.Result = default(Item);
            }

            if (!manager.Starting) retVal.LogResult(logger);
            else retVal.LogResultDebug(logger);

            return retVal;
        }

        #endregion

        /// <summary>
        /// Renames the provided Item and all child Items "in place" without affecting the model.  
        /// This method supports the CopyItem and MoveItem methods; if you want to move something in the model
        /// as well as rename it, use MoveItem.  To be crystal clear, this is not a CRUD operation!
        /// </summary>
        /// <param name="item">The Item to rename.</param>
        /// <param name="fqn">The new Fully Qualified Name for the Item.</param>
        /// <returns>A renamed clone of the provided Item.</returns>
        private OperationResult<Item> RenameItemInstance(Item item, string fqn)
        {
            logger.Debug("Renaming Item '" + item.FQN + "' to '" + fqn + "'");
            OperationResult<Item> retVal = new OperationResult<Item>();

            retVal.Result = (Item)item.Clone();

            retVal.Result.Name = GetItemNameFromItemFQN(fqn);
            retVal.Result.FQN = fqn;

            List<Item> childrenToRename = retVal.Result.Children.Clone();

            foreach (Item child in childrenToRename)
            {
                OperationResult<Item> renameResult = RenameItemInstance(child, retVal.Result.FQN + '.' + child.Name);
                if (renameResult.ResultCode != OperationResultCode.Failure)
                {
                    retVal.Result.RemoveChild(child);
                    retVal.Result.AddChild(renameResult.Result);
                }

                retVal.Incorporate(renameResult);
            }

            retVal.LogResultDebug(logger);
            return retVal;
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Returns the ConfigurationDefinition for the Model Manager.
        /// </summary>
        /// <returns>The ConfigurationDefinition for the Model Manager.</returns>
        public static ConfigurationDefinition GetConfigurationDefinition()
        {
            ConfigurationDefinition retVal = new ConfigurationDefinition();
            retVal.SetForm("[\"name\",\"email\",{\"key\":\"comment\",\"type\":\"textarea\",\"placeholder\":\"Make a comment\"},{\"type\":\"submit\",\"style\":\"btn-info\",\"title\":\"OK\"}]");
            retVal.SetSchema("{\"type\":\"object\",\"title\":\"Comment\",\"properties\":{\"name\":{\"title\":\"Name\",\"type\":\"string\"},\"email\":{\"title\":\"Email\",\"type\":\"string\",\"pattern\":\"^\\\\S+@\\\\S+$\",\"description\":\"Email will be used for evil.\"},\"comment\":{\"title\":\"Comment\",\"type\":\"string\",\"maxLength\":20,\"validationMessage\":\"Don\'t be greedy!\"}},\"required\":[\"name\",\"email\",\"comment\"]}");
            retVal.SetModel(typeof(ModelManagerConfiguration));
            return retVal;
        }

        /// <summary>
        /// Returns the default Configuration for the Model Manager.
        /// </summary>
        /// <returns>The default Configuration for the Model Manager.</returns>
        public static ModelManagerConfiguration GetDefaultConfiguration()
        {
            ModelManagerConfiguration retVal = new ModelManagerConfiguration();
            retVal.Items.Add(
                new ModelManagerConfigurationItem()
                {
                    FQN = "Symbiote",
                    SourceFQN = ""
                });
            return retVal;
        }

        /// <summary>
        /// Parses and returns an Item path from the given FQN.
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
        /// Parses and returns an Item name from the given FQN.
        /// </summary>
        /// <param name="itemFQN">The FQN from which to parse the name.</param>
        /// <returns>The Item name.</returns>
        private static string GetItemNameFromItemFQN(string itemFQN)
        {
            return itemFQN.Split('.')[itemFQN.Split('.').Length - 1];
        }

        #endregion
    }
}
