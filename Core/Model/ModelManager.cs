using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Symbiote.Core.Model
{
    public class ModelManager
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private ProgramManager manager;
        private static ModelManager instance;

        internal ModelItem Model { get; private set; }

        private ModelManager(ProgramManager manager)
        {
            this.manager = manager;
            Model = new ModelItem();
        }

        public void BuildModel()
        {
            foreach (string i in manager.Configuration.Model.Items)
            {
                logger.Info(i);
                ModelItem mi = JsonConvert.DeserializeObject<ModelItem>(i);
                logger.Info("Deserialized item:");
                logger.Info("Name: " + mi.Name);
                logger.Info("FQN: " + mi.FQN);
                logger.Info("Path: " + mi.Path);
                Model.AddChild(mi);
            }
        }

        public void SaveModel()
        {
            manager.Configuration.Model.Items.Clear();
            SaveModelItem(manager.Model);
        }

        private void SaveModelItem(ModelItem modelItem)
        {
            manager.Configuration.Model.Items.Add(modelItem.ToJson());
            
            foreach (ModelItem mi in modelItem.Children)
            {
                SaveModelItem(mi);
            }
        }

        internal static ModelManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new ModelManager(manager);

            return instance;
        }
    }
}
