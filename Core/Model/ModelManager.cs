using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Symbiote.Core.Configuration;

namespace Symbiote.Core.Model
{
    public class ModelManager
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private ProgramManager manager;
        private static ModelManager instance;

        internal ModelItem Model { get; private set; }
        internal Dictionary<string, ModelItem> Dictionary { get; private set; }

        private ModelManager(ProgramManager manager)
        {
            this.manager = manager;

            ModelBuildResult result = BuildModel(manager.Configuration.Model.Items);
            Model = result.Model;
            Dictionary = result.Dictionary;
        }

        internal static ModelManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new ModelManager(manager);

            return instance;
        }

        public ModelBuildResult BuildModel()
        {
            return BuildModel(manager.Configuration.Model.Items);
        }

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
        /// Accepts a list of Configuration.ModelItems and recursively instantiates items in the Model corresponding to the items in the list.
        /// </summary>
        /// <param name="itemList">A list of model items from which to build the model.</param>
        /// <param name="result">An instance of ModelBuildResult, ideally new.  The method will recursively pass it to itself and return it to the calling method when complete.</param>
        /// <param name="depth">The current depth of recursion. Defaults to 0 if omitted.</param>
        /// <returns>A list containing the items from itemList that were successfully instantiated in the model.</returns>
        public ModelBuildResult BuildModel(List<ConfigurationModelItem> itemList, ModelBuildResult result, int depth = 0)
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
                ModelItem newItem;
                try
                {
                    logger.Trace(new String('-', 30));
                    logger.Trace("ConfigurationModelItem: " + i.ToString());
                    newItem = JsonConvert.DeserializeObject<ModelItem>(i.Definition);
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
        /// Returns the ModelItem from the Dictionary belonging to the ModelManager instance matching the supplied key.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the desired ModelItem.</param>
        /// <returns>The ModelItem from the Model corresponding to the supplied key.</returns>
        /// <remarks>Retrieves items from the Dictionary instance belonging to the ModelManager instance.</remarks>
        public ModelItem FindItem(string fqn)
        {
            return FindItem(Dictionary, fqn);
        }

        /// <summary>
        /// Returns the ModelItem from the supplied Dictionary matching the supplied key.
        /// </summary>
        /// <param name="dictionary">The Dictionary from which to retrieve the item.</param>
        /// <param name="fqn">The Fully Qualified Name of the desired ModelItem.</param>
        /// <returns>The ModelItem stored in the supplied Dictionary corresponding to the supplied key.</returns>
        public ModelItem FindItem(Dictionary<string, ModelItem> dictionary, string fqn)
        {
            return dictionary[fqn];
        }

        public void AddItem(ModelItem item)
        {
            AddItem(Model, Dictionary, item);
        }

        private void AddItem(ModelItem model, Dictionary<string, ModelItem> dictionary, ModelItem item)
        {
            string parentFQN = GetParentFQNFromItemFQN(item.FQN);

            // if the parent FQN couldn't be parsed, this is the root node so add it to the Model directly.
            if (parentFQN == "")
            {
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
                }
            }
            else
            {
                try
                {
                    logger.Trace("Adding item to model as child of " + parentFQN + ": " + item.ToString());
                    FindItem(dictionary, parentFQN).AddChild(item);
                    logger.Trace("Adding item to dictionary with key: " + item.FQN);
                    dictionary.Add(item.FQN, item);
                }
                catch (KeyNotFoundException ex)
                {
                    throw new ItemParentMissingException(parentFQN);
                }
            }
        }

        private static string GetParentFQNFromItemFQN(string itemFQN)
        {
            string[] retObj = itemFQN.Split('.');

            if (retObj.Length > 1)
                return String.Join(".", retObj.Take(retObj.Count() - 1));

            return "";         
        }

        private static string GetItemNameFromItemFQN(string itemFQN)
        {
            return itemFQN.Split('.')[itemFQN.Split('.').Length - 1];
        }
    }
}
