using System.ComponentModel.DataAnnotations;

namespace Project.Models.ValidateAttribute
{
    public class ValidateAddressAttribute: ValidationAttribute
    {
        // Address (Cairo-Alex-Giza)
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value.ToString().ToLower().Contains("cairo") || value.ToString().ToLower().Contains("alex") || value.ToString().ToLower().Contains("giza") )
            {
                // Success
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Your Address Must Be In Cairo Or Alex Or Giza");
            }
        }
    }
}
