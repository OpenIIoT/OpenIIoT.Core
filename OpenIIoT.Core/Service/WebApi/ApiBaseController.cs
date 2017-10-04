namespace OpenIIoT.Core.Service.WebApi
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http.Formatting;
    using System.Web.Http;
    using Newtonsoft.Json;
    using OpenIIoT.SDK;
    using OpenIIoT.SDK.Common;

    public class ApiBaseController : ApiController
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiBaseController"/> class.
        /// </summary>
        [ExcludeFromCodeCoverage]
        protected ApiBaseController()
            : this(ApplicationManager.GetInstance())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiBaseController"/> class with the specified
        ///     <see cref="IApplicationManager"/> instance.
        /// </summary>
        /// <param name="manager">The IApplicationManager instance used to resolve dependencies.</param>
        protected ApiBaseController(IApplicationManager manager)
        {
            Manager = manager;
        }

        #endregion Public Constructors

        #region Protected Properties

        protected IApplicationManager Manager { get; set; }

        #endregion Protected Properties

        #region Protected Methods

        /// <summary>
        ///     Returns the JsonMediaTypeFormatter to use with this controller.
        /// </summary>
        /// <param name="resolverType">
        ///     A ContractResolverType representing the desired behavior of serializationProperties, OptIn or OptOut.
        /// </param>
        /// <param name="properties">
        ///     A list of properties to exclude or include, depending on the ContractResolverType, in the serialized result.
        /// </param>
        /// <returns>A configured instance of JsonMediaTypeFormatter</returns>
        protected JsonMediaTypeFormatter JsonFormatter(ContractResolverType resolverType, List<string> properties)
        {
            return JsonFormatter(resolverType, properties.ToArray());
        }

        protected JsonMediaTypeFormatter JsonFormatter(ContractResolverType resolverType, params string[] properties)
        {
            JsonMediaTypeFormatter retVal = new JsonMediaTypeFormatter();

            retVal.SerializerSettings = new JsonSerializerSettings();

            retVal.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            retVal.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            retVal.SerializerSettings.Formatting = Formatting.Indented;
            retVal.SerializerSettings.ContractResolver = new ContractResolver(resolverType, properties);
            retVal.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());

            return retVal;
        }

        protected JsonMediaTypeFormatter JsonFormatter(params string[] properties)
        {
            return JsonFormatter(ContractResolverType.OptIn, properties);
        }

        protected JsonMediaTypeFormatter JsonFormatter()
        {
            return JsonFormatter(ContractResolverType.OptOut);
        }

        #endregion Protected Methods
    }
}