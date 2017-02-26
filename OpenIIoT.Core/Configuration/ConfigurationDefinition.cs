/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ▄████████                                                                                                      ████████▄
      █   ███    ███                                                                                                     ███   ▀███
      █   ███    █▀   ██████  ██▄▄▄▄     ▄█████  █     ▄████▄  ██   █     █████   ▄█████      ██     █   ██████  ██▄▄▄▄  ███    ███    ▄█████    ▄█████  █  ██▄▄▄▄   █      ██     █   ██████  ██▄▄▄▄
      █   ███        ██    ██ ██▀▀▀█▄   ██   ▀█ ██    ██    ▀  ██   ██   ██  ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄ ███    ███   ██   █    ██   ▀█ ██  ██▀▀▀█▄ ██  ▀███████▄ ██  ██    ██ ██▀▀▀█▄
      █   ███        ██    ██ ██   ██  ▄██▄▄    ██▌  ▄██       ██   ██  ▄██▄▄█▀   ██   ██     ██  ▀ ██▌ ██    ██ ██   ██ ███    ███  ▄██▄▄     ▄██▄▄    ██▌ ██   ██ ██▌     ██  ▀ ██▌ ██    ██ ██   ██
      █   ███    █▄  ██    ██ ██   ██ ▀▀██▀▀    ██  ▀▀██ ███▄  ██   ██ ▀███████ ▀████████     ██    ██  ██    ██ ██   ██ ███    ███ ▀▀██▀▀    ▀▀██▀▀    ██  ██   ██ ██      ██    ██  ██    ██ ██   ██
      █   ███    ███ ██    ██ ██   ██   ██      ██    ██    ██ ██   ██   ██  ██   ██   ██     ██    ██  ██    ██ ██   ██ ███   ▄███   ██   █    ██      ██  ██   ██ ██      ██    ██  ██    ██ ██   ██
      █   ████████▀   ██████   █   █    ██      █     ██████▀  ██████    ██  ██   ██   █▀    ▄██▀   █    ██████   █   █  ████████▀    ███████   ██      █    █   █  █      ▄██▀   █    ██████   █   █
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Establishes a common object to represent the configuration details for various application items.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016 JP Dillingham (jp@dillingham.ws)
      █
      █  This program is free software: you can redistribute it and/or modify
      █  it under the terms of the GNU Affero General Public License as published by
      █  the Free Software Foundation, either version 3 of the License, or
      █  (at your option) any later version.
      █
      █  This program is distributed in the hope that it will be useful,
      █  but WITHOUT ANY WARRANTY; without even the implied warranty of
      █  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      █  GNU Affero General Public License for more details.
      █
      █  You should have received a copy of the GNU Affero General Public License
      █  along with this program.  If not, see <http://www.gnu.org/licenses/>.
      █
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

using System;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Configuration;
using Utility.OperationResult;

namespace OpenIIoT.Core.Configuration
{
    /// <summary>
    ///     Establishes a common object to represent the configuration details for various application items.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The configuration is comprised of two strings, a form and a schema, a Type representing the model, and a default
    ///         value for the model. The strings are intended to contain json data; the form containing a json representation of an
    ///         HTML form, and the schema containing a logical schema to be used as the basis of the form.
    ///     </para>
    ///     <para>
    ///         When the configuration is edited (or a new instance created), the form and schema are used to generate an HTML form
    ///         client side. Angular Schemaform (schemaform.io) is used client-side (alternatives can be used, but this is the
    ///         primary vector) to generate the form. Schemaform creates a model using the form and schema and the client returns
    ///         the model to the application.
    ///     </para>
    ///     <para>
    ///         The returned model is deserialized to the Type specified in the Model property and an instance is returned to the
    ///         owner object.
    ///     </para>
    ///     <para>
    ///         When the owner starts or loads the configuration, the ConfigurationManager retrieves the relevant json from the
    ///         configuration file and deserializes it to an instance of type Model and returns it. The owner then manipulates the
    ///         instance and when finished saves it back to the configuration manager, which in turn saves it to the configuration
    ///         file as serialized json.
    ///     </para>
    /// </remarks>
    public class ConfigurationDefinition : IConfigurationDefinition
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConfigurationDefinition"/> class.
        /// </summary>
        public ConfigurationDefinition() : this(string.Empty, string.Empty, null, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConfigurationDefinition"/> class with the supplied form and schema strings.
        /// </summary>
        /// <param name="form">A string containing the json representation of an HTML form.</param>
        /// <param name="schema">A string containing a json representation of the schema to populate using the form.</param>
        /// <param name="model">A type representing the model to be built from the schema.</param>
        /// <param name="defaultConfiguration">The default instance of the configuration.</param>
        public ConfigurationDefinition(string form, string schema, Type model, object defaultConfiguration)
        {
            Form = form;
            Schema = schema;
            Model = model;
            DefaultConfiguration = defaultConfiguration;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets or sets the default configuration.
        /// </summary>
        /// <remarks>Must be an instance of the Type specified in the <see cref="Model"/> property.</remarks>
        public object DefaultConfiguration { get; set; }

        /// <summary>
        ///     Gets or sets a string containing a json representation of an HTML configuration form.
        /// </summary>
        public string Form { get; set; }

        /// <summary>
        ///     Gets or sets an object representing the model to be built from the schema.
        /// </summary>
        public Type Model { get; set; }

        /// <summary>
        ///     Gets or sets a string containing a json representation of the schema to populate using the form.
        /// </summary>
        public string Schema { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Returns a value indicating whether this instance is valid.
        /// </summary>
        /// <remarks>
        ///     To be considered valid, the <see cref="Form"/> and <see cref="Schema"/> properties must contain valid Json, the
        ///     <see cref="Model"/> property must not be null, and the Type of the value contained in
        ///     <see cref="DefaultConfiguration"/> must be of the same Type specified in the Model property.
        /// </remarks>
        /// <returns>A value indicating whether this instance is valid.</returns>
        public IResult<bool> IsValid()
        {
            Result<bool> retVal = new Result<bool>();
            retVal.ReturnValue = false;

            if (!Form.IsValidJson())
            {
                retVal.AddError("The Form property does not contain valid Json data.");
            }

            if (!Schema.IsValidJson())
            {
                retVal.AddError("The Schema property does not contain valid Json data.");
            }

            if (Model == default(Type))
            {
                retVal.AddError("The Model property does not contain a valid Type.");
            }

            if (DefaultConfiguration != null && !DefaultConfiguration.GetType().Equals(Model))
            {
                retVal.AddError("The Default property does not contain an instance of an object corresponding to the Type specified in the Model property.");
            }

            if (retVal.ResultCode != ResultCode.Failure)
            {
                retVal.ReturnValue = true;
            }

            return retVal;
        }

        #endregion Public Methods
    }
}