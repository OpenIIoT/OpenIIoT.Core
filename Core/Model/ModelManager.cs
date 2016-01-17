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
            Dictionary = new Dictionary<string, ModelItem>();
        }

        internal static ModelManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new ModelManager(manager);

            return instance;
        }

        /// <summary>
        /// Default overload for BuildModel(); builds the Model using the list of items from the Configuration.
        /// </summary>
        public void BuildModel()
        {
            ModelBuildResult result = BuildModel(manager.Configuration.Model.Items);

            if ((result.Result == ModelBuildResultCode.Success) || (result.Result == ModelBuildResultCode.Warning))
            {
                Model = result.Model;
                Dictionary = result.Dictionary;
                logger.Info("The Model was built successfully.");
                logger.Info("Top level items: " + Model.Children.Count());

                logger.Info("Resolved items: " + result.ResolvedList.Count() + "; Unresolved items: " + result.UnresolvedList.Count());
            }

            if (result.Result == ModelBuildResultCode.Warning)
            {
                logger.Warn("The following warning(s) were generated during the build:");

                foreach (string message in result.Messages)
                {
                    logger.Warn("\t" + message);
                }
            }
            else if (result.Result == ModelBuildResultCode.Failure)
            {
                logger.Error("The Model failed to build.  The following errors and warnings were generated during the build:");
                foreach (string message in result.Messages)
                {
                    logger.Error("\t" + message);
                }
            }
        }

        /// <summary>
        /// Accepts a list of Configuration.ModelItems and passes it to the overloaded BuildModel() along with a new instance of ModelBuildResult.
        /// </summary>
        /// <param name="itemList">A list of model items from which to build the model.</param>
        /// <returns>The ModelBuildResult returned by the called overload of BuildModel()</returns>
        /// <remarks>Abstracts the instantiation of the ModelBuildResult by instantiating the ModelBuildResult and determining the final result of the build.</remarks>
        private ModelBuildResult BuildModel(List<ConfigurationModelItem> itemList)
        {
            ModelBuildResult retVal = BuildModel(itemList, new ModelBuildResult() { UnresolvedList = itemList.Clone() });

            // if the result code hasn't been set by the time the assignment above returns the ModelBuildResult
            // no errors or warnings were encountered during the recursive calls and therefore the build was
            // a success.
            if (retVal.Result == ModelBuildResultCode.Unknown)
                retVal.Result = ModelBuildResultCode.Success;

            return retVal;
        }

        /// <summary>
        /// Accepts a list of Configuration.ModelItems and recursively instantiates items in the Model corresponding to the items in the list.
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

            // prepare an instance of ModelBuildResult to return
            ModelBuildResult retVal = new ModelBuildResult();

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
                    logger.Info("Added item '" + i.FQN + "' to the Model.  top level tags: " + result.Dictionary.Count());    
                    foreach (KeyValuePair<string, ModelItem> kvp in result.Dictionary)
                    {
                        logger.Info("\t\tItem: " + kvp.Key);
                    }       
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
            logger.Trace("sddddddddddddddddddReturning model with root : " + result.Model.FQN + " : children: " + result.Model.Children.Count());
            // if at least one item was processed at this depth, recursively call this method one level deeper
            if (items.Count() > 0)
                BuildModel(itemList, result, depth + 1);

            logger.Trace("Returning model with root : " + result.Model.FQN + " : children: " + result.Model.Children.Count());

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
            return Dictionary[fqn];
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
                    dictionary.Add(model.FQN, item);
                }
            }
            else
            {
                try
                {
                    logger.Trace("Adding item to model as child of " + parentFQN + ": " + item.ToString());
                    FindItem(dictionary, parentFQN).AddChild(item);
                    logger.Trace("Parent now has: " + FindItem(dictionary, parentFQN).Children.Count() + " children.");

                    foreach(ModelItem i in FindItem(dictionary, parentFQN).Children)
                    {
                        logger.Trace("Child: " + i.FQN);
                    }

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

        private void PrintItemChildren(Model.ModelItem root, int indent)
        {
            logger.Info(new string('\t', indent) + root.ToJson() + " children: " + root.Children.Count());

            foreach (Model.ModelItem i in root.Children)
            {
                PrintItemChildren(i, indent + 1);
            }
        }
    }
}
