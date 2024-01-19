using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CheckoutRestApi.Models.Validations
{
    public class Product_EnsurePriceCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value ,ValidationContext validationContext)
        {
            var product = validationContext.ObjectInstance as Product;

            if(product != null){
                if(product.Price <= 0){

                    return new ValidationResult("Price of product should be greater then 0.");
                }
            }
            return ValidationResult.Success;
        }
    }
}