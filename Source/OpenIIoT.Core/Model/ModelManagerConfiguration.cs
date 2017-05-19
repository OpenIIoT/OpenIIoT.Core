using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[module: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleType", Justification = "Reviewed.")]

namespace OpenIIoT.Core.Model
{
    /// <summary>
    ///     A class representing the configuration items for the Model Manager.
    /// </summary>
    public class ModelManagerConfiguration
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ModelManagerConfiguration"/> class.
        /// </summary>
        public ModelManagerConfiguration()
        {
            Items = new List<ModelManagerConfigurationItem>();
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets or sets the list of Items contained within the model.
        /// </summary>
        public List<ModelManagerConfigurationItem> Items { get; set; }

        #endregion Public Properties
    }

    /// <summary>
    ///     A generic container for model items within the configuration.
    /// </summary>
    public class ModelManagerConfigurationItem : ICloneable
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the FQN of the item.
        /// </summary>
        public string FQN { get; set; }

        /// <summary>
        ///     Gets or sets the FQN of the source item.
        /// </summary>
        public string SourceFQN { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Creates a new copy of this item.
        /// </summary>
        /// <returns>A new copy of this item.</returns>
        public object Clone()
        {
            return new ModelManagerConfigurationItem() { FQN = this.FQN, SourceFQN = this.SourceFQN };
        }

        /// <summary>
        ///     Returns true if the provided object is equal to this object, false otherwise.
        /// </summary>
        /// <param name="obj">The object to which this object should be compared.</param>
        /// <returns>True of the objects are equal, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            ModelManagerConfigurationItem rightSide;

            try
            {
                rightSide = (ModelManagerConfigurationItem)obj;
            }
            catch
            {
                return false;
            }

            return FQN == rightSide.FQN;
        }

        /// <summary>
        ///     Returns the hashcode of this object.
        /// </summary>
        /// <returns>An integer equal to the hash of the FQN of this object.</returns>
        public override int GetHashCode()
        {
            return FQN.GetHashCode();
        }

        /// <summary>
        ///     Returns the string representation of the object.
        /// </summary>
        /// <returns>The string representation of the object.</returns>
        public override string ToString()
        {
            return "FQN = " + FQN + "; SourceFQN = " + SourceFQN;
        }

        #endregion Public Methods
    }
}