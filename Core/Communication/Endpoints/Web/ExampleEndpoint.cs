using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbiote.Core.Configuration;

namespace Symbiote.Core.Communication.Endpoints.Web
{
    /// <summary>
    /// This class is an example of an Endpoint.
    /// 
    /// Each Endpoint file should contain two classes; the Endpoint class and a class representing the model
    /// for the configuration of the Endpoint.  If no configuration is needed, or if it is very basic, a simple 
    /// object can be substituted for this configuration class.
    /// 
    /// All Endpoint classes must implement the IEndpoint and IConfigurable(T) interfaces, where T is the type of
    /// the configuration class for the Endpoint.
    /// </summary>
    public class ExampleEndpoint : IEndpoint, IConfigurable<ExampleEndpointConfiguration>
    {
        /// <summary>
        /// The ConfigurationDefinition property returns the Endpoint's configuration details.
        /// 
        /// A ConfigurationDefinition instance includes two strings; a Form and a Schema, and a Type corresponding
        /// to the model/configuration class.
        /// </summary>
        public ConfigurationDefinition ConfigurationDefinition { get; private set; }

        /// <summary>
        /// The Configuration property is the type of the model/configuration class.
        /// This corresponds to the value of T in IConfigurable(T).
        /// </summary>
        public ExampleEndpointConfiguration Configuration { get; private set; }

        /// <summary>
        /// The default and only constructor accepts a string corresponding to the name of the instance of the 
        /// Endpoint being created.
        /// 
        /// This instance name is used to retrieve the configuration for the instance from the ConfigurationManager.
        /// 
        /// The EndpointManager will always supply a valid instance name.
        /// </summary>
        /// <param name="instanceName">The name of the instance being created.</param>
        public ExampleEndpoint(string instanceName)
        {
            // call the static method to get the configuration details for this instance.
            ConfigurationDefinition = GetConfigurationDefinition();
        }

        /// <summary>
        /// The Configure method is called by external actors to configure or re-configure the Endpoint instance.
        /// 
        /// If anything inside the Endpoint needs to be refreshed to reflect changes to the configuration, do it in
        /// this method.
        /// </summary>
        /// <param name="configuration">The instance of the model/configuration type to apply.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Configure(ExampleEndpointConfiguration configuration)
        {
            Configuration = configuration;

            return new OperationResult();
        }

        /// <summary>
        /// The GetConfigurationDefinition method is static and returns the ConfigurationDefinition for the Endpoint.
        /// 
        /// This method is necessary so that the configuration defintion can be registered with the ConfigurationManager
        /// prior to any instances being created.  This method MUST be implemented, however it is not possible to specify
        /// static methods in an interface, so implementing IConfigurable will not enforce this.
        /// </summary>
        /// <returns>The ConfigurationDefinition for the Endpoint.</returns>
        public static ConfigurationDefinition GetConfigurationDefinition()
        {
            ConfigurationDefinition retVal = new ConfigurationDefinition();

            // to create the form and schema strings, visit http://schemaform.io/examples/bootstrap-example.html
            // use the example to create the desired form and schema, and ensure that the resulting model matches the model
            // for the endpoint.  When you are happy with the json from the above url, visit http://www.freeformatter.com/json-formatter.html#ad-output
            // and paste in the generated json and format it using the "JavaScript escaped" option.  Paste the result into the methods below.

            retVal.SetForm("[\"templateURL\",{\"type\":\"submit\",\"style\":\"btn-info\",\"title\":\"Save\"}]");
            retVal.SetSchema("{\"type\":\"object\",\"title\":\"XMLEndpoint\",\"properties\":{\"templateURL\":{\"title\":\"Template URL\",\"type\":\"string\"}},\"required\":[\"templateURL\"]}");

            // this will always be typeof(YourConfiguration/ModelObject)
            retVal.SetModel(typeof(ExampleEndpointConfiguration));
            return retVal;
        }

        /// <summary>
        /// The Send method sends the supplied value to the configured Endpoint.
        /// </summary>
        /// <param name="value">A generic object containing the value to send to the Endpoint.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        public OperationResult Send(object value)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// The ExampleEndpointConfiguration class is an example of what a configuration/model class for an Endpoint might look like.
    /// 
    /// The configuration model is not limited to just one class; complext examples may have any structure consisting of any number of classes.
    /// </summary>
    public class ExampleEndpointConfiguration
    {
        // this configuration model example contains one property of type string
        public string Example { get; set; }

        // typically the constructor wouldn't set any values, but this example does for illustrative purposes.
        public ExampleEndpointConfiguration()
        {
            Example = "Hello World!";
        }
    }
}
