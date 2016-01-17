using System.Collections.Generic;
using Symbiote.Core.Configuration.Model;

namespace Symbiote.Core.Model
{
    public class ModelBuildResult
    {
        public ModelBuildResultCode Result { get; set; }
        public List<string> Messages { get; set; }
        public ModelItem Model { get; set; }
        public Dictionary<string, ModelItem> Dictionary { get; set; }
        public List<ConfigurationModelItem> ResolvedList { get; set; }
        public List<ConfigurationModelItem> UnresolvedList { get; set; }

        public ModelBuildResult()
        {
            Result = ModelBuildResultCode.Success;
            Model = new ModelItem();
            Dictionary = new Dictionary<string, ModelItem>();
            Messages = new List<string>();
            ResolvedList = new List<ConfigurationModelItem>();
            UnresolvedList = new List<ConfigurationModelItem>();
        }
    }
}
