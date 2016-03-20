using System.Collections.Generic;

namespace Symbiote.Core.Model
{
    /// <summary>
    /// The ModelBuildResult extends the OperationResult class and adds properties to return various
    /// products of a model build operation.
    /// 
    /// The model build operation produces the model itself, which implements the composite design pattern,
    /// and a dictionary used to faciliate fast lookups of model items without traversing the composite tree.
    /// 
    /// Two lists are also produced; a list of resolved items and a list of unresolved items.  As items are
    /// built from the list of items stored in the configuration, a number of checks and lookups are done
    /// to ensure that the items are valid.  Any items that are invalid are discarded and added to the unresolved list.
    /// </summary>
    public class ModelBuildResult : OperationResult
    {
        /// <summary>
        /// The Item model created by the build result.
        /// </summary>
        public Item Model { get; set; }

        /// <summary>
        /// The dictionary of model items and FQNs created by the build result.
        /// </summary>
        public Dictionary<string, Item> Dictionary { get; set; }

        /// <summary>
        /// The list of model items that were resolved during the build.
        /// </summary>
        public List<ModelManagerConfigurationItem> ResolvedList { get; set; }

        /// <summary>
        /// The list of model items that couldn't be resolved during the build.
        /// </summary>
        public List<ModelManagerConfigurationItem> UnresolvedList { get; set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        public ModelBuildResult() : base()
        {
            Model = new Item();
            Dictionary = new Dictionary<string, Item>();
            ResolvedList = new List<ModelManagerConfigurationItem>();
            UnresolvedList = new List<ModelManagerConfigurationItem>();
        }
    }
}
