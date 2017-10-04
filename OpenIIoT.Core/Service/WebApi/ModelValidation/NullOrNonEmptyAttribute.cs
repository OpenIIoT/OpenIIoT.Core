using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.Core.Service.WebApi.ModelValidation
{
    public class NullOrNonEmptyAttribute : RequiredAttribute
    {
        #region Protected Methods

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value is string)
            {
                if (value != null && (string)value == string.Empty)
                {
                    return new ValidationResult("If supplied, the value can not be empty.");
                }
            }

            return ValidationResult.Success;
        }

        #endregion Protected Methods
    }
}