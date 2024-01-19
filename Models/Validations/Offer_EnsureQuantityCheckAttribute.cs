using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CheckoutRestApi.Models.Validations
{
    public class Offer_EnsureQuantityCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value ,ValidationContext validationContext)
        {
            var offer = validationContext.ObjectInstance as Offer;

            if(offer != null){
                if(offer.Quantity <= 0){

                    return new ValidationResult("Quantity of product should be greater then 0.");
                }
            }
            return ValidationResult.Success;
        }
    }
}