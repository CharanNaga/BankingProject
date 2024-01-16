using BankProject.Exceptions;
using BankProject.ServiceContracts.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Services.Helpers
{
    public class ValidationHelper
    {
        internal static void ModelValidation(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            if (!isValid && obj is CustomerAddRequest || obj is CustomerUpdateRequest)
                throw new CustomerException(validationResults.FirstOrDefault()?.ErrorMessage);

            if (!isValid)
                throw new AccountException(validationResults.FirstOrDefault()?.ErrorMessage);
        }
    }
}
