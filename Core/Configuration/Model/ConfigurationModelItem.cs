using System;
using Newtonsoft.Json;

namespace Symbiote.Core.Configuration.Model
{
    /// <summary>
    /// A generic container for model items within the configuration.
    /// </summary>
    [JsonObject]
    public class ConfigurationModelItem : ICloneable
    {
        public string FQN { get; set; }
        public string Definition { get; set; }

        public object Clone()
        {
            return new ConfigurationModelItem() { FQN = this.FQN, Definition = this.Definition };
        }

        public override bool Equals(object obj)
        {
            ConfigurationModelItem rightSide;

            try
            {
                rightSide = (ConfigurationModelItem)obj;
            }
            catch (InvalidCastException ex)
            {
                return false;
            }

            return (this.FQN == rightSide.FQN);
        }

        public override int GetHashCode()
        {
            return FQN.GetHashCode();
        }

        public override string ToString()
        {
            return "FQN = " + FQN + "; Definition = " + Definition;
        }
    }
}
