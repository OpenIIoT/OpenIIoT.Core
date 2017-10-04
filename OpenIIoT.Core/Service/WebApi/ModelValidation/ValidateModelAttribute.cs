using OpenIIoT.SDK.Common;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace OpenIIoT.Core.Service.WebApi.ModelValidation
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        #region Public Methods

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.BadRequest, GetResult(actionContext.ModelState));
            }
        }

        #endregion Public Methods

        #region Private Methods

        private ModelValidationResult GetResult(ModelStateDictionary state)
        {
            ModelValidationResult retVal = new ModelValidationResult();
            retVal.Message = "The request data is invalid.";

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

            return retVal;
        }

        #endregion Private Methods
    }
}