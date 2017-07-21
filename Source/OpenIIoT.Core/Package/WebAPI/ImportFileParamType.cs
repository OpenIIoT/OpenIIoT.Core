using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Web.Http.Description;

public class ImportFileParamType : IOperationFilter
{
    #region Public Methods

    public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
    {
        var requestAttributes = apiDescription.GetControllerAndActionAttributes<SwaggerFormAttribute>();
        foreach (var attr in requestAttributes)
        {
            operation.parameters = new List<Parameter>
                {
                    new Parameter
                    {
                        description = attr.Description,
                        name = attr.Name,
                        @in = "formData",
                        required = true,
                        type = "file",
                    }
                };
            operation.consumes.Add("multipart/form-data");
        }
    }

    #endregion Public Methods

    #region Public Classes

    [AttributeUsage(AttributeTargets.Method)]
    public sealed class SwaggerFormAttribute : Attribute
    {
        #region Public Constructors

        public SwaggerFormAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }

        #endregion Public Constructors

        #region Public Properties

        public string Description { get; private set; }
        public string Name { get; private set; }

        #endregion Public Properties
    }

    #endregion Public Classes
}