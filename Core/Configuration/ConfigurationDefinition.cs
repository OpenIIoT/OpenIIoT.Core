using System;

namespace Symbiote.Core.Configuration
{
    /// <summary>
    /// Establishes a common object to represent the configuration details for various application items.  
    /// The configuration is comprised of two strings, a form and a schema, and a Type representing the model.  The strings are intended to contain json data;
    /// the form containing a json representation of an HTML form, and the schema containing a logical schema to be used as the basis of the form.
    ///
    /// When the configuration is edited (or a new instance created), the form and schema are used to generate an HTML form client side.  Angular Schemaform (schemaform.io)
    /// is used client-side (alternatives can be used, but this is the primary vector) to generate the form.  Schemaform creates a model using the form and schema and the client
    /// returns the model to the application.
    /// 
    /// The returned model is deserialized to the Type specified in the Model property and an instance is returned to the owner object.
    /// 
    /// When the owner starts or loads the configuration, the ConfigurationManager retrieves the relevant json from the configuration file and deserializes it to an instance of type Model
    /// and returns it.  The owner then manipulates the instance and when finished saves it back to the configuration manager, which in turn saves it to the configuration file as serialized
    /// json.
    /// </summary>
    /// <remarks>
    /// The ability to store the default configuration within this object was explored and due to the need to be able to statically call GetConfigurationDefinition,
    /// returning a generic instance of this class (ConfigurationDefinition(T)) would be too sloppy, requiring a ton more reflection than is already being used.
    /// Based on previous attempts to do neat tricks with reflection the goal is to minimize the usage wherever possible.
    /// </remarks>
    public class ConfigurationDefinition
    {
        #region Properties

        /// <summary>
        /// A string containing a json representation of an HTML configuration form.
        /// </summary>
        public string Form { get; private set; }
        
        /// <summary>
        /// A string containing a json representation of the schema to populate using the form.
        /// </summary>
        public string Schema { get; private set; }

        /// <summary>
        /// An object representing the model to be built from the schema.
        /// </summary>
        public Type Model { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor.  Creates a blank ConfigurationDefinition.
        /// </summary>
        public ConfigurationDefinition() : this("", "", null) { }

        /// <summary>
        /// Creates a new ConfigurationDefinition with the supplied form and schema strings.
        /// </summary>
        /// <param name="form">A string containing the json representation of an HTML form.</param>
        /// <param name="schema">A string containing a json representation of the schema to populate using the form.</param>
        /// <param name="model">A type representing the model to be built from the schema.</param>
        public ConfigurationDefinition(string form, string schema, Type model)
        {
            Form = form;
            Schema = schema;
            Model = model;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Sets the value of the Form property to the supplied string.
        /// </summary>
        /// <param name="form">A string containing the json representation of an HTML form.</param>
        /// <returns>The modified ConfigurationDefinition object.</returns>
        public ConfigurationDefinition SetForm(string form)
        {
            Form = form;
            return this;
        }

        /// <summary>
        /// Sets the value of the Schema property to the supplied string.
        /// </summary>
        /// <param name="schema">A string containing a json representation of the schema to populate using the form.</param>
        /// <returns>The modified ConfigurationDefinition object.</returns>
        public ConfigurationDefinition SetSchema(string schema)
        {
            Schema = schema;
            return this;
        }

        /// <summary>
        /// Sets the value of the Model property to the supplied Type.
        /// </summary>
        /// <param name="model">The Type of the Configuration model.</param>
        /// <returns>The modified ConfigurationDefinition object.</returns>
        public ConfigurationDefinition SetModel(Type model)
        {
            Model = model;
            return this;
        }

        #endregion
    }
}
