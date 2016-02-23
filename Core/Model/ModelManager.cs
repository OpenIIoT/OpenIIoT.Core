using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Symbiote.Core.Configuration.Model;

namespace Symbiote.Core.Model
{
    /// <summary>
    /// The ModelManager class manages the Model for the application.
    /// </summary>
    public class ModelManager
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
        private static ModelManager instance;

        #endregion

        #region Properties

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

        private ModelManager(ProgramManager manager)
        {
            this.manager = manager;
        }

        internal static ModelManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new ModelManager(manager);

            return instance;
        }

        #endregion

        #region Instance Methods

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
            {
                retVal.AddError("Unable to attach a model that failed to build.");
                throw new ModelAttachException("Unable to attach a model that failed to build.");
            }

            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Builds a Model using the Model Configuration stored within the ProgramManager and returns a ModelBuildResult containing the result.
        /// </summary>
        /// <returns>A new instance of ModelBuildResult containing the results of the build operation.</returns>
        public ModelBuildResult BuildModel()
        {
            return BuildModel(manager.ConfigurationManager.Configuration.Model.Items);
        }

        /// <summary>
        /// Builds a Model using the provided list of ConfigurationItems and returns a ModelBuildResult containing the result.
        /// </summary>
        /// <param name="itemList">A list of ConfigurationItems containing Model Items to build.</param>
        /// <returns>A new instance of ModelBuildResult containing the results of the build operation.</returns>
        public ModelBuildResult BuildModel(List<ConfigurationModelItem> itemList)
        {
            logger.Info("Building Model...");

            ModelBuildResult retVal = new ModelBuildResult() { ResultCode = OperationResultCode.Success, UnresolvedList = itemList.Clone() };

            BuildModel(itemList, retVal);

            retVal.LogResult(logger);

            // if the model was built successfully (with or without warnings), report the success and show some statistics.
            if (retVal.ResultCode != OperationResultCode.Failure)
            {
                logger.Info(retVal.ResolvedList.Count() + " items were resolved.");

                // if any items were unresolved, print them.
                if (retVal.UnresolvedList.Count() > 0)
                {
                    logger.Info("Unresolved items:");
                    foreach (ConfigurationModelItem mi in retVal.UnresolvedList)
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
        private ModelBuildResult BuildModel(List<ConfigurationModelItem> itemList, ModelBuildResult result, int depth = 0)
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

            // create an IEnumerable containing a list of all the items in the provided itemList at the requested depth
            IEnumerable<ConfigurationModelItem> items = itemList.Where(i => (i.FQN.Split('.').Length - 1) == depth);

            // iterate through the list of items
            foreach (ConfigurationModelItem i in items)
            {
                Item newItem;
                try
                {
                    logger.Trace(new String('-', 30));
                    logger.Trace("ConfigurationModelItem: " + i.ToString());
                    newItem = JsonConvert.DeserializeObject<Item>(i.Definition);
                    logger.Trace("Deserialized: " + newItem.ToString());

                    // set the FQN of the ModelItem to the FQN of the ConfigurationModelItem
                    // this will be set "officially" when SetParent() is called to bind the item to its parent
                    newItem.FQN = i.FQN;

                    // make sure the deserialization went ok
                    if (newItem == null) throw new ItemJsonInvalidException(i.ToString());
                    if (newItem.IsValid() != true) throw new ItemValidationException(i.ToString());

                    // resolve the SourceAddress of the new item to an existing item
                    if (newItem.SourceAddress != "")
                    {
                        logger.Trace("Attempting to resolve " + newItem.SourceAddress + "...");
                        Item resolvedItem = AddressResolver.Resolve(newItem.SourceAddress);
                        if (resolvedItem == default(Item))
                            throw new ItemSourceUnresolvedException("Address resolver returned default Item.", newItem, newItem.SourceAddress);
                        else
                        {
                            newItem.SourceItem = resolvedItem;
                            logger.Trace("Successfully resolved SourceAddress of Item '" + newItem.FQN + "' to '" + newItem.SourceItem.FQN + "'.");
                        }
                    }
                    
                    AddItem(result.Model, result.Dictionary, newItem);

                    result.UnresolvedList.Remove(i);
                    result.ResolvedList.Add(i);
                    logger.Trace("Added item '" + newItem.FQN + "' to the Model.");    
                }
                catch (ItemParentMissingException ex)
                {
                    result.AddWarning("The parent item for item '" + i.FQN + "' was not found in the model; ignoring.");
                    logger.Trace("ItemParentMissingException thrown: " + ex.Message);
                }
                catch (ItemJsonInvalidException ex)
                {
                    result.AddWarning("Invalid configuration json for item '" + i.FQN + "'; ignoring.");
                    logger.Trace("ItemJsonInvalidException thrown: " + ex.Message);
                }
                catch (ItemValidationException ex)
                {
                    result.AddWarning("Configuration json for item '" + i.FQN + "' deserialized to an invalid item; ignoring.");
                    logger.Trace("ItemValidationException thrown: " + ex.Message);
                }
                catch (ItemSourceUnresolvedException ex)
                {
                    result.AddWarning("Source item for '" + ex.Item.FQN + "' (" + ex.SourceAddress + ") could not be resolved; ignoring.");
                    logger.Trace("ItemSourceUnresolvedException thrown: " + ex.Message + " Item: " + ex.Item.FQN + " SourceAddress: " + ex.SourceAddress);
                }
                catch (Exception ex)
                {
                    result.AddWarning("Failed to add the item '" + i.FQN + "' to the model; ignoring.");
                    logger.Trace("Exception: " + ex.Message);
                    continue;
                }
            }

            // if at least one item was processed at this depth, recursively call this method one level deeper
            if (items.Count() > 0)
                BuildModel(itemList, result, depth + 1);

            return result;
        }

        /// <summary>
        /// Generates a list of ConfigurationModelItems based on the current Model and updates the Configuration.  If flushToDisk is true, saves the updated Configuration to disk.
        /// </summary>
        /// <param name="flushToDisk">Save the updated Configuration to disk.</param>
        /// <returns>An OperationResult containing the list of saved ConfigurationModelItems.</returns>
        public OperationResult<List<ConfigurationModelItem>> SaveModel(bool flushToDisk = false)
        {
            logger.Info("Saving Model" + (flushToDisk ? " and flushing the Configuration to disk" : "") + "...");

            OperationResult<List<ConfigurationModelItem>> configuration = new OperationResult<List<ConfigurationModelItem>>();
            configuration.Result = new List<ConfigurationModelItem>();

            OperationResult<List<ConfigurationModelItem>> retVal = SaveModel(Model, configuration, manager.ConfigurationManager.ItemSerializationProperties);

            if (retVal.ResultCode != OperationResultCode.Failure)
            {
                manager.ConfigurationManager.Configuration.Model.Items = retVal.Result;

                if (flushToDisk)
                {
                    if (!manager.ConfigurationManager.SaveConfiguration())
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
        /// <param name="itemSerializationProperties">A list of propery names to include in the serialization of the model items.</param>
        /// <returns>An OperationResult containing the list of saved ConfigurationModelItems.</returns>
        private OperationResult<List<ConfigurationModelItem>> SaveModel(Item itemRoot, OperationResult<List<ConfigurationModelItem>> configuration, List<string> itemSerializationProperties)
        {
            configuration.Result.Add(new ConfigurationModelItem() { FQN = itemRoot.FQN, Definition = itemRoot.ToJson(new ContractResolver(itemSerializationProperties)) });

            foreach(Item mi in itemRoot.Children)
            {
                SaveModel(mi, configuration, itemSerializationProperties);
            }

            return configuration;
        }

        /// <summary>
        /// Adds an Item to the ModelManager's instance of Model and Dictionary.
        /// </summary>
        /// <param name="item">The Item to add.</param>
        /// <param name="suppressLogging">True if log messages should be suppressed during the operation, false otherwise.</param>
        /// <returns>An OperationResult containing the added Item.</returns>
        public OperationResult<Item> AddItem(Item item, bool suppressLogging = true)
        {
            if (!suppressLogging) logger.Info("Adding Item '" + item.FQN + "' to the Model...");

            OperationResult<Item> retVal = AddItem(Model, Dictionary, item);

            if (!suppressLogging) retVal.LogResult(logger);

            return retVal;
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
                    model.Type = item.Type;
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
                    try
                    {
                        logger.Trace("Adding item to model as child of " + parentFQN + ": " + item.ToString());
                        FindItem(dictionary, parentFQN).AddChild(item);
                        logger.Trace("Adding item to dictionary with key: " + item.FQN);
                        dictionary.Add(item.FQN, item);

                        retVal.Result = item;
                    }
                    catch (KeyNotFoundException ex)
                    {
                        retVal.AddError("The parent for item '" + model.FQN + " [" + parentFQN + "] could not be found.");
                    }
                }
            }

            return retVal;
        }

        /// <summary>
        /// Attaches the provided Item to the Item with the supplied FQN.
        /// </summary>
        /// <param name="item">The Item to attach to the Model.</param>
        /// <param name="parentItemFQN">The Fully Qualified Name of the Item to which the new Item should be attached.</param>
        /// <param name="suppressLogging">True if log messages should be suppressed during the operation, false otherwise.</param>
        /// <returns>The attached Item.</returns>
        public OperationResult<Item> AttachItem(Item item, string parentItemFQN, bool suppressLogging = true)
        {
            Item foundItem = FindItem(parentItemFQN);

            if (foundItem == default(Item))
                return new OperationResult<Item>().AddError("The parent item '" + parentItemFQN + "' could not be found.");

            return AttachItem(item, foundItem);
        }

        /// <summary>
        /// Attaches the provided Item to the supplied Item.
        /// </summary>
        /// <param name="item">The Item to attach to the Model.</param>
        /// <param name="parentItem">The Item to which the new Item should be attached.</param>
        /// <param name="suppressLogging">True if log messages should be suppressed during the operation, false otherwise.</param>
        /// <returns>The attached Item.</returns>
        public OperationResult<Item> AttachItem(Item item, Item parentItem, bool suppressLogging = true)
        {
            if (!suppressLogging) logger.Info("Attaching Item '" + item.FQN + "' to '" + parentItem.FQN + "'...");

            OperationResult<Item> retVal = new OperationResult<Item>();

            try
            {
                // create a 1:1 clone of the supplied item
                retVal.Result = (Item)item.Clone();

                // set the SourceAddress of the new item to the FQN of the original item to create a link
                retVal.Result.SourceAddress = retVal.Result.FQN;
                retVal.Result.SourceItem = AddressResolver.Resolve(retVal.Result.SourceAddress);

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
                    AttachItem(child, retVal.Result, suppressLogging);
                }
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown when attempting to Attach Item '" + item.FQN + "':" + ex);
                retVal.Result = default(Item);
            }

            if (!suppressLogging) retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Removes an Item matching the supplied FQN from the ModelManager's Dictionary and its parent Item.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to remove.</param>
        /// <returns>An OperationResult containing the removed Item.</returns>
        public OperationResult<Item> RemoveItem(string fqn)
        {
            return RemoveItem(FindItem(fqn));
        }

        /// <summary>
        /// Removes an Item from the ModelManager's Dictionary and from its parent Item.
        /// </summary>
        /// <param name="item">The Item to remove.</param>
        /// <returns>An OperationResult containing the removed Item.</returns>
        public OperationResult<Item> RemoveItem(Item item)
        {
            logger.Info("Removing Item '" + item.FQN + "' from model...");

            OperationResult<Item> retVal = RemoveItem(Dictionary, item);

            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Removes an Item from the provided Dictionary and removes it from its parent Item.
        /// </summary>
        /// <param name="dictionary">The Dictionary from which to remove the Item.</param>
        /// <param name="item">The Item to remove.</param>
        /// <returns>An OperationResult containing the removed Item.</returns>
        private OperationResult<Item> RemoveItem(Dictionary<string, Item> dictionary, Item item)
        {
            OperationResult<Item> retVal = new OperationResult<Item>();
            retVal.Result = item;

            try
            {
                if (item == default(Item))
                {
                    retVal.AddError("The supplied Item is invalid.");
                }
                else if (item.Parent == item)
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
            logger.Info("Moving Item '" + item.FQN + "' to new FQN '" + fqn + "'...");
            OperationResult<Item> retVal = MoveItem(Model, Dictionary, item, fqn);

            if (retVal.ResultCode != OperationResultCode.Failure)
                SaveModel();

            retVal.LogResult(logger);
            return retVal;
        }

        /// <summary>
        /// Moves the supplied Item from one place in the supplied Model and Dictionary to another based on the supplied FQN.
        /// </summary>
        /// <param name="model">The Model containing the supplied Item.</param>
        /// <param name="dictionary">The Dictionary containing the supplied Item.</param>
        /// <param name="item">The Item to move.</param>
        /// <param name="fqn">The Fully Qualified Name representing the new location for the Item.</param>
        /// <returns>An OperationResult containing the moved Item.</returns>
        private OperationResult<Item> MoveItem(Item model, Dictionary<string, Item> dictionary, Item item, string fqn)
        {
            OperationResult<Item> retVal = new OperationResult<Item>();

            // find the parent item first to ensure the provided FQN is valid
            Item parent = FindItem(dictionary, GetParentFQNFromItemFQN(fqn));

            if (parent == default(Item))
                retVal.AddError("The parent item '" + GetParentFQNFromItemFQN(fqn) + "' was not found in the model.");
            else
            {
                // delete the existing item
                RemoveItem(dictionary, item);

                // add it to the new location
                item.FQN = fqn;
                AddItem(model, dictionary, item);
                retVal.Result = item;
            }
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
            try
            {
                return dictionary[fqn];
            }
            catch (Exception ex)
            {
                return default(Item);
            }

        }

        #endregion

        #region Static Methods

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
