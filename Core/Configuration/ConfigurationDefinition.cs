using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Configuration
{
    /// <summary>
    /// Establishes a common object to represent the configuration details for various application items.  
    /// The configuration is comprised of two strings; a form and a schema.  Both strings are intended to contain json data;
    /// the form containing a json representation of an HTML form, and the schema containing a logical schema to be used as the basis of the form.
    /// 
    /// The mechanism that uses objects of type ConfigurationDefinition is as such:
    ///     An actor requests the ConfigurationDefinition for an object.  Most likely this is via the Web API.
    ///     The actor then generates a form using the contents of the Form property and presents it to some external user or service.
    ///     The external user or service completes the form and submits it.
    ///     The actor extracts data from the completed form and uses it to populate the schema.
    ///     The actor sends the schema back to the application.
    ///     The application applies the returned schema to the object or instance.
    /// </summary>
    public class ConfigurationDefinition
    {
        #region Properties

        /// <summary>
        /// A string containing a json representation of an HTML configuration form
        /// </summary>
        public string Form { get; private set; }
        /// <summary>
        /// A string containing a json representation of the schema to populate using the form
        /// </summary>
        public string Schema { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor.  Creates a blank ConfigurationDefinition.
        /// </summary>
        public ConfigurationDefinition() : this("", "") { }

        /// <summary>
        /// Creates a new ConfigurationDefinition with the supplied form and schema strings.
        /// </summary>
        /// <param name="form">A string containing the json representation of an HTML form.</param>
        /// <param name="schema">A string containing a json representation of the schema to populate using the form.</param>
        public ConfigurationDefinition(string form, string schema)
        {
            Form = form;
            Schema = schema;
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

        #endregion
    }
}
