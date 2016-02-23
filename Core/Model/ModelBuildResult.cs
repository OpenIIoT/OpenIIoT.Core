using System.Collections.Generic;
using Symbiote.Core.Configuration.Model;

namespace Symbiote.Core.Model
{
    public class ModelBuildResult : OperationResult
    {
        public Item Model { get; set; }
        public Dictionary<string, Item> Dictionary { get; set; }
        public List<ConfigurationModelItem> ResolvedList { get; set; }
        public List<ConfigurationModelItem> UnresolvedList { get; set; }

        public ModelBuildResult() : base()
        {
            Model = new Item();
            Dictionary = new Dictionary<string, Item>();
            ResolvedList = new List<ConfigurationModelItem>();
            UnresolvedList = new List<ConfigurationModelItem>();
        }
    }
}
