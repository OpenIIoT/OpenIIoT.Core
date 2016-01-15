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

        internal Item Model { get; private set; }
        internal Dictionary<string, Item> Dictionary { get; private set; }

        private ModelManager(ProgramManager manager)
        {
            this.manager = manager;

            // create a blank Item to serve as the model's root
            Model = new Item();
        }

        internal static ModelManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new ModelManager(manager);

            return instance;
        }

        public void BuildModel()
        {
            BuildModel(manager.Configuration.Model.Items);
        }

        public void BuildModel(List<ModelItem> itemList)
        {
            List<ModelItem> resolvedList = BuildModel(itemList, new List<ModelItem>(), 0);

            logger.Info("resolved: " + resolvedList.Count() + "; original: " + itemList.Count());

            //IEnumerable<ModelItem> unresolvedList = resolvedList.Except(itemList);

            //logger.Info("unresolved: " + unresolvedList.Count());

            //if (unresolvedList.Count() > 0)
            //{
            //    logger.Info("The following model items in the configuration were unresolved:");
            //    foreach (Configuration.ModelItem i in unresolvedList)
            //    {
            //        logger.Info("Item: " + i.FQN);
            //    }
            //}
        }
        public List<ModelItem> BuildModel(List<ModelItem> itemList, List<ModelItem> resolvedList, int sequence)
        {
            IEnumerable<Configuration.ModelItem> items = itemList.Where(i => (i.FQN.Split('.').Length - 1) == sequence);

            foreach (Configuration.ModelItem i in items)
            {
                logger.Info("FQN: " + i.FQN + "; Config: " + i.Definition);

                // deserialize i.Configuration to Item
                Item newItem;
                try
                {
                    //newItem = i.Definition;
                    //newItem.FQN = i.FQN;
                    //newItem.Path = newItem.FQN.Split('.')[newItem.FQN.Split('.').Length - 1];
                    newItem = JsonConvert.DeserializeObject<Model.Item>(i.Definition);


                    logger.Info("Deserialized item: " + newItem.FQN + " type: " + newItem.Type.ToString());
                    if (newItem == null) throw new ApplicationException("Deserialized to null");
                    if (newItem.IsValid() != true) throw new ApplicationException("Item is invalid");
                }
                catch (Exception ex)
                {
                    logger.Warn("Failed to deserialize configuration for item '" + i.FQN + "'; ignoring.");
                    continue;
                }

                //logger.Info("Deserialized Item: " + newItem.FQN);

                //Dictionary.Add(i.FQN, new Item() { FQN = i.FQN });
                resolvedList.Add((ModelItem)i.Clone());
            }
            if (items.Count() > 0)
                BuildModel(itemList, resolvedList, sequence + 1);

            return resolvedList;
        }
    }
}
