namespace OpenIIoT.Core.Service.WebApi.ModelValidation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Http.ModelBinding;

    public class ModelValidator
    {
        #region Public Constructors

        public ModelValidator() : this(new ModelStateDictionary())
        {
        }

        public ModelValidator(ModelStateDictionary state)
        {
            State = state;
        }

        #endregion Public Constructors

        #region Public Methods

        public ModelValidator AddError(string key, string errorMessage)
        {
            State.AddModelError(key, errorMessage);
            return this;
        }

        public ModelValidator AddError(string key, Exception exception)
        {
            State.AddModelError(key, exception);
            return this;
        }

        #endregion Public Methods

        #region Public Properties

        public bool IsValid => State.IsValid;

        public ModelValidationResult Result => CreateResult(State);

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
        private ModelValidationResult CreateResult(ModelStateDictionary state)
        {
            ModelValidationResult retVal = new ModelValidationResult();

            foreach (string key in state.Keys)
            {
                ModelValidationField property = new ModelValidationField() { Field = key };

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
                    retVal.Model.Add(property);
                }
            }

            if (retVal.Model.Count > 0)
            {
                retVal.Message = "The request data is invalid.";
            }

            return retVal;
        }

        #endregion Public Methods
    }
}