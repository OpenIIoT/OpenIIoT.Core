namespace OpenIIoT.Core.Service.WebApi.ParameterValidation
{
    using System;
    using System.Web.Http.ModelBinding;

    public class ParameterValidator
    {
        #region Public Constructors

        public ParameterValidator() : this(new ModelStateDictionary())
        {
        }

        public ParameterValidator(ModelStateDictionary state)
        {
            State = state;
        }

        #endregion Public Constructors

        #region Public Methods

        public ParameterValidator AddError(string key, string errorMessage)
        {
            State.AddModelError(key, errorMessage);
            return this;
        }

        public ParameterValidator AddError(string key, Exception exception)
        {
            State.AddModelError(key, exception);
            return this;
        }

        #endregion Public Methods

        #region Public Properties

        public bool IsValid => State.IsValid;

        public ParameterValidationResult Result => CreateResult(State);

        #endregion Public Properties

        #region Private Properties

        private ModelStateDictionary State { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Transforms the specified <see cref="ModelStateDictionary"/><paramref name="state"/> into a strongly typed data
        ///     transfer object containing the same information.
        /// </summary>
        /// <param name="state">The <see cref="ModelStateDictionary"/> to transform.</param>
        /// <returns>The transformed model state dictionary.</returns>
        private ParameterValidationResult CreateResult(ModelStateDictionary state)
        {
            ParameterValidationResult retVal = new ParameterValidationResult();

            foreach (string key in state.Keys)
            {
                ParameterValidationField property = new ParameterValidationField() { Field = key };

                foreach (ModelError error in state[key].Errors)
                {
                    if (!string.IsNullOrEmpty(error.ErrorMessage))
                    {
                        property.Messages.Add(error.ErrorMessage);
                    }

                    if (!string.IsNullOrEmpty(error.Exception?.Message))
                    {
                        property.Messages.Add(error.Exception.Message);
                    }
                }

                if (property.Messages.Count > 0)
                {
                    retVal.Parameters.Add(property);
                }
            }

            if (retVal.Parameters.Count > 0)
            {
                retVal.Message = "The request data is invalid.";
            }

            return retVal;
        }

        #endregion Public Methods
    }
}