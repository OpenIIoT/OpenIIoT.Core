namespace OpenIIoT.Core.Service.WebApi.ModelValidation
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    [DataContract]
    public class ModelValidationField
    {
        #region Public Constructors

        public ModelValidationField()
        {
            Messages = new List<string>();
        }

        #endregion Public Constructors

        #region Public Properties

        [DataMember(Order = 1)]
        [JsonProperty(Order = 1)]
        public string Field { get; set; }

        [DataMember(Order = 2)]
        [JsonProperty(Order = 2)]
        public List<string> Messages { get; set; }

        #endregion Public Properties
    }
}