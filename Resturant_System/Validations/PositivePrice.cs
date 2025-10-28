using System.ComponentModel.DataAnnotations;

namespace Resturant_System.Validations
{
    public class PositivePrice : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return new ValidationResult("Price is required");
            }
            
            if(value is decimal Price)
            {
                if(Price <= 0)
                {
                    return new ValidationResult("Must be Positive Number");
                }

            return ValidationResult.Success;
            }
            return new ValidationResult("Invalid number format");
        }
    }
}
