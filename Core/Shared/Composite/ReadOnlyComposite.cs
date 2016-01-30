using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Symbiote.Core.Composite
{
    public class ReadOnlyComposite : ReadWriteComposite
    {
        public override bool IsWriteable { get { return false; } }

        /// <summary>
        /// An empty constructor used for instantiating the root node of a model.
        /// </summary>
        public ReadOnlyComposite() : base("", typeof(object), "", false, false, true) { }

        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name to be used as the root of a model.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="isRoot">True if the item is to be created as a root model item, false otherwise.</param>
        public ReadOnlyComposite(string fqn, bool isRoot) : this(fqn, typeof(object), "", false, false, isRoot) { }

        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name and type.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="type">The Type of the Item's value.</param>
        /// <param name="sourceAddress">The Fully Qualified Name of the source item.</param>
        /// <param name="isDataStructure">True if the item is a data structure containing members (rather than a logical grouping such as a folder), false otherwise.</param>
        /// <remarks>This constructor is used for deserialization.</remarks>
        [JsonConstructor]
        public ReadOnlyComposite(string fqn, Type type, string sourceAddress, bool isDataStructure) : base(fqn, type, sourceAddress, isDataStructure, false, false) { }

        /// <summary>
        /// Creates an instance of an Item with the given Fully Qualified Name and type.  If isRoot is true, marks the Item as the root item in a model.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to create.</param>
        /// <param name="type">The Type of the Item's value.</param>
        /// <param name="sourceAddress">The Fully Qualified Name of the source item.</param>
        /// <param name="isDataStructure">True if the item is a data structure containing members (rather than a logical grouping such as a folder), false otherwise.</param>
        /// <param name="isDataMember">True if the item is a data member contained within a data structure, false otherwise.</param>
        /// <param name="isRoot">True if the item is to be created as a root model item, false otherwise.</param>
        public ReadOnlyComposite(string fqn, Type type = null, string sourceAddress = "", bool isDataStructure = false, bool isDataMember = false, bool isRoot = false) : base(fqn, type, sourceAddress, isDataStructure, isDataMember, isRoot) { }

        public override bool Write(object value)
        {
            throw new ItemNotWriteableException("Error writing to '" + this.FQN + "'; the item is not writeable.");
        }
        public override Task<bool> WriteAsync(object Value)
        {
            throw new ItemNotWriteableException("Error writing to '" + this.FQN + "'; the item is not writeable.");
        }
    }
}
