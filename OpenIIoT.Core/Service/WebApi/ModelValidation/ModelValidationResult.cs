using Newtonsoft.Json;
using OpenIIoT.SDK.Common.OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.Core.Service.WebApi.ModelValidation
{
    [DataContract]
    public class ModelValidationResult
    {
        #region Public Constructors

        public ModelValidationResult()
        {
            Model = new List<ModelValidationField>();
        }

        #endregion Public Constructors

        #region Public Properties

        [DataMember(Order = 1)]
        [JsonProperty(Order = 1)]
        public string Message { get; set; }

        [DataMember(Order = 2)]
        [JsonProperty(Order = 2)]
        public List<ModelValidationField> Model { get; set; }

        #endregion Public Properties
    }
}