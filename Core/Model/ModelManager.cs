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
    public class ModelManager
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private ProgramManager manager;
        private static ModelManager instance;

        internal Item Model { get; private set; }
        internal Dictionary<string, Item> Dictionary { get; private set; }

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

        /// <summary>
        /// Assigns the Model and Dictionary contained within the supplied ModelBuildResult to the manager's Model and Dictionary properties.
        /// </summary>
        /// <param name="modelBuildResult">The built model to attach to the manager.</param>
        public void AttachModel(ModelBuildResult modelBuildResult)
        {
            if (modelBuildResult.Result == ModelBuildResultCode.Success)
            {
                Model = modelBuildResult.Model;
                Dictionary = modelBuildResult.Dictionary;
            }
            else
                throw new ModelAttachException("Unable to attach a model that failed to build.");
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
            // clear the build result
            //BuildResult = new ModelBuildResult() { UnresolvedList = itemList.Clone() };
            // build the model
            ModelBuildResult BuildResult = BuildModel(itemList, new ModelBuildResult() { UnresolvedList = itemList.Clone() });

            // if the model was built successfully (with or without warnings), report the success and show some statistics.
            if ((BuildResult.Result == ModelBuildResultCode.Success) || (BuildResult.Result == ModelBuildResultCode.Warning))
            {
                logger.Info("The Model was built successfully.");
                logger.Info(BuildResult.ResolvedList.Count() + " items were resolved.");

                // if any items were unresolved, print them.
                if (BuildResult.UnresolvedList.Count() > 0)
                {
                    logger.Info("Unresolved items:");
                    foreach (ConfigurationModelItem mi in BuildResult.UnresolvedList)
                    {
                        logger.Info("\t" + mi.FQN);
                    }
                }

                // if any warnings were generated, print the list of messages.
                if (BuildResult.Result == ModelBuildResultCode.Warning)
                {
                    logger.Warn("The following warning(s) were generated during the build:");

                    foreach (string message in BuildResult.Messages)
                    {
                        logger.Warn("\t" + message);
                    }
                    //return ModelBuildResultCode.Warning;
                }
                //return ModelBuildResultCode.Success;
            }
            else if (BuildResult.Result == ModelBuildResultCode.Failure)
            {
                logger.Error("The Model failed to build.  The following errors and warnings were generated during the build:");
                foreach (string message in BuildResult.Messages)
                {
                    logger.Error("\t" + message);
                }
                //return ModelBuildResultCode.Failure;
            }
            return BuildResult;
        }

        /// <summary>
        /// Accepts a list of Configuration.Items and recursively instantiates items in the Model corresponding to the items in the list.
        /// </summary>
        /// <param name="itemList">A list of model items from which to build the model.</param>
        /// <param name="result">An instance of ModelBuildResult, ideally new.  The method will recursively pass it to itself and return it to the calling method when complete.</param>
        /// <param name="depth">The current depth of recursion. Defaults to 0 if omitted.</param>
        /// <returns>A list containing the items from itemList that were successfully instantiated in the model.</returns>
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

                    AddItem(result.Model, result.Dictionary, newItem);

                    result.UnresolvedList.Remove(i);
                    result.ResolvedList.Add(i);
                    logger.Info("Added item '" + newItem.FQN + "' to the Model.");    
                }
                catch (ItemParentMissingException ex)
                {
                    result.Result = ModelBuildResultCode.Warning;
                    result.Messages.Add("The parent item for item '" + i.FQN + "' was not found in the model; ignoring.");
                    logger.Trace("ItemParentMissingException thrown: " + ex.Message);
                }
                catch (ItemJsonInvalidException ex)
                {
                    result.Result = ModelBuildResultCode.Warning;
                    result.Messages.Add("Invalid configuration json for item '" + i.FQN + "'; ignoring.");
                    logger.Trace("ItemJsonInvalidException thrown: " + ex.Message);
                }
                catch (ItemValidationException ex)
                {
                    result.Result = ModelBuildResultCode.Warning;
                    result.Messages.Add("Configuration json for item '" + i.FQN + "' deserialized to an invalid item; ignoring.");
                    logger.Trace("ItemValidationException thrown: " + ex.Message);
                }
                catch (Exception ex)
                {
                    logger.Warn("Failed to add the item '" + i.FQN + "' to the model; ignoring.");
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
        /// <returns>Returns true if the save succeeded, false otherwise.</returns>
        public bool SaveModel(bool flushToDisk = false)
        {
            List<ConfigurationModelItem> updatedItems = SaveModel(Model, new List<ConfigurationModelItem>());
            manager.ConfigurationManager.Configuration.Model.Items = updatedItems;

            if (flushToDisk)
                return manager.ConfigurationManager.SaveConfiguration();

            return true;
        }

        /// <summary>
        /// Updates and returns the provided list of ConfigurationModelItems with the recursively listed contents of the provided ModelItem.
        /// </summary>
        /// <param name="itemRoot">The ModelItem from which to start recursively updating the list.</param>
        /// <param name="configuration">The list of ConfigurationModelItems to update.</param>
        /// <returns>Returns true if the save succeeded, false otherwise.</returns>
        private List<ConfigurationModelItem> SaveModel(Item itemRoot, List<ConfigurationModelItem> configuration)
        {
            configuration.Add(new ConfigurationModelItem() { FQN = itemRoot.FQN, Definition = itemRoot.ToJson() });

            foreach(Item mi in itemRoot.Children)
            {
                SaveModel(mi, configuration);
            }

            return configuration;
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

        /// <summary>
        /// Adds an Item to the ModelManager's instance of Model and Dictionary.
        /// </summary>
        /// <param name="item">The Item to add.</param>
        /// <returns>The added Item.</returns>
        public Item AddItem(Item item)
        {
            try
            {
                return AddItem(Model, Dictionary, item);
            }
            catch (ItemAlreadyAddedException ex)
            {
                logger.Warn("The item '" + item.FQN + "' has already been added.  Returing the existing instance.");
                return ex.ExistingItem;
            }
            catch (Exception ex)
            {
                logger.Warn("The item '" + item.FQN + "' could not be added to the model: " + ex.Message);
                return default(Item);
            }
        }

        /// <summary>
        /// Adds an Item to the given Model and Dictionary.
        /// </summary>
        /// <param name="model">The Model to which to add the Item.</param>
        /// <param name="dictionary">The Dictionary to which to add the Item.</param>
        /// <param name="item">The Item to add.</param>
        /// <returns>The added Item.</returns>
        private Item AddItem(Item model, Dictionary<string, Item> dictionary, Item item)
        {
            string parentFQN = GetParentFQNFromItemFQN(item.FQN);

            // if the parent FQN couldn't be parsed, this is the root node so clone it to the existing ModelItem representing the root.
            if (parentFQN == "")
            {
                // only one root item can be defined.  
                if (model.Name != "") { throw new ApplicationException("Model root has already been defined."); }
                else
                {
                    logger.Trace("Setting Model root to a new instance of ModelItem()");
                    model.Name = item.Name;
                    model.FQN = item.FQN;
                    model.Path = item.Path;
                    model.Type = item.Type;
                    logger.Trace("Adding item to dictionary with key: " + item.FQN);
                    dictionary.Add(model.FQN, model);
                    return model;
                }
            }
            else
            {
                // ensure the item hasn't been added already.
                Item foundItem = FindItem(dictionary, item.FQN);
                if (foundItem != default(Item))
                    throw new ItemAlreadyAddedException("The item already exists in the dictionary.", foundItem);

                try
                {
                    logger.Trace("Adding item to model as child of " + parentFQN + ": " + item.ToString());
                    FindItem(dictionary, parentFQN).AddChild(item);
                    logger.Trace("Adding item to dictionary with key: " + item.FQN);
                    dictionary.Add(item.FQN, item);
                    return item;
                }
                catch (KeyNotFoundException ex)
                {
                    throw new ItemParentMissingException("The parent for item '" + model.FQN + " [" + parentFQN + "] could not be found.");
                }
            }
        }

        /// <summary>
        /// Attaches the provided Item to the Item with the supplied FQN.
        /// </summary>
        /// <param name="item">The Item to attach to the Model.</param>
        /// <param name="parentItemFQN">The Fully Qualified Name of the Item to which the new Item should be attached.</param>
        /// <returns>The attached Item.</returns>
        public Item AttachItem(Item item, string parentItemFQN)
        {
            Item foundItem = FindItem(parentItemFQN);

            if (foundItem == default(Item))
                throw new ItemParentMissingException("The supplied Item can't be attached to '" + parentItemFQN + "' because the parent item wasn't found in the model.");

            return AttachItem(item, FindItem(parentItemFQN));
        }

        /// <summary>
        /// Attaches the provided Item to the supplied Item.
        /// </summary>
        /// <param name="item">The Item to attach to the Model.</param>
        /// <param name="parentItem">The Item to which the new Item should be attached.</param>
        /// <returns>The attached Item.</returns>
        public Item AttachItem(Item item, Item parentItem)
        {
            logger.Info("Attaching " + item.ToString() + " to " + parentItem.ToString());

            // create a 1:1 clone of the supplied item
            Item newItem = (Item)item.Clone();

            // set the SourceAddress of the new item to the FQN of the original item to create a link
            newItem.SourceAddress = newItem.FQN;

            // modify the FQN of the cloned item to reflect it's new path
            newItem.FQN = parentItem.FQN + "." + newItem.Name;

            // create a temporary list of the items children
            List<Item> children = newItem.Children.Clone<Item>();

            // remove the children from the item (you leave my babies!)
            newItem.Children.Clear();
            // they're my babies now, you commie son of a bitch!

            // add the cloned and cleaned item to the model
            AddItem(newItem);

            // for each child of the original item, attach that item to the model under the cloned and cleaned parent
            foreach(Item child in children)
            {
                AttachItem(child, newItem);
            }
            return newItem;
        }

        /// <summary>
        /// Removes an Item from the ModelManager's Dictionary and removes it from its parent Item.
        /// </summary>
        /// <param name="item">The Item to remove.</param>
        /// <returns>The removed Item.</returns>
        public Item RemoveItem(Item item)
        {
            return RemoveItem(Dictionary, item);
        }

        /// <summary>
        /// Removes an Item from the Model using the supplied FQN to first find the item.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the item to remove.</param>
        /// <returns>The item that was found by the lookup of the supplied FQN.  Returns a default Item if the lookup fails.</returns>
        public Item RemoveItem(string fqn)
        {
            Item foundItem = FindItem(fqn);

            if (foundItem == default(Item))
                return foundItem;
            else
                return RemoveItem(foundItem);
        }

        /// <summary>
        /// Removes an Item from the provided Dictionary and removes it from its parent Item.
        /// </summary>
        /// <param name="dictionary">The Dictionary from which to remove the Item.</param>
        /// <param name="item">The Item to remove.</param>
        /// <returns>The removed Item.</returns>
        private Item RemoveItem(Dictionary<string, Item> dictionary, Item item)
        {
            try
            {
                if (item == default(Item)) return item;
                if (item.Parent == item)
                    throw new ModelRootRemovalException("Removing a Model's root is not permitted.");

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

                logger.Info("Dictionary contents-----------------------------------------------------------------------");
                foreach (var kvp in dictionary)
                {
                    logger.Info("\t\t" + kvp.Key);
                }


            }
            catch (Exception ex)
            {
                logger.Trace("Exception thrown removing item '" + item.FQN + "' from the model: " + ex.Message);
            }
            return item;
        }

        /// <summary>
        /// Moves the supplied Item from one place in the ModelManager's instances of Model and Dictionary to another based on the supplied FQN.
        /// </summary>
        /// <param name="item">The Item to move.</param>
        /// <param name="fqn">The Fully Qualified Name representing the new location for the item.</param>
        /// <returns>The updated Item.</returns>
        public Item MoveItem(Item item, string fqn)
        {
            return MoveItem(Model, Dictionary, item, fqn);
        }

        /// <summary>
        /// Moves the supplied Item from one place in the supplied Model and Dictionary to another based on the supplied FQN.
        /// </summary>
        /// <param name="model">The Model containing the supplied Item.</param>
        /// <param name="dictionary">The Dictionary containing the supplied Item.</param>
        /// <param name="item">The Item to move.</param>
        /// <param name="fqn">The Fully Qualified Name representing the new location for the Item.</param>
        /// <returns>The updated Item.</returns>
        private Item MoveItem(Item model, Dictionary<string, Item> dictionary, Item item, string fqn)
        {
            // find the parent item first to ensure the provided FQN is valid
            // this will throw an exception if it fails.
            Item parent = FindItem(dictionary, GetParentFQNFromItemFQN(fqn));

            // delete the existing item
            RemoveItem(dictionary, item);

            // add it to the new location
            item.FQN = fqn;
            AddItem(model, dictionary, item);
            return item;
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
    }
}
