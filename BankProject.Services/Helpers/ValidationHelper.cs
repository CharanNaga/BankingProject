using BankProject.Exceptions;
using BankProject.ServiceContracts.Dto;
using System.ComponentModel.DataAnnotations;

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

            if (!isValid && obj is AccountAddRequest || obj is AccountUpdateRequest)
                throw new AccountException(validationResults.FirstOrDefault()?.ErrorMessage);
        }
    }
}
