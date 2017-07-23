using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace OpenIIoT.Core.Service.WebAPI
{
    // MimeTypesOperationFilter.cs
    public class MimeTypesOperationFilter : IOperationFilter
    {
        #region Private Fields

        private static readonly string[] SupportedAccepts = new[] { "application/json", "application/xml" };
        private static readonly string[] SupportedContentTypes = new[] { "application/json", "application/xml" };

        #endregion Private Fields

        #region Public Methods

        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            operation.consumes = SupportedAccepts;
            operation.produces = SupportedContentTypes;
        }

        #endregion Public Methods
    }
}