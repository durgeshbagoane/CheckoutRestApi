using System.ComponentModel.DataAnnotations;

namespace CheckoutRestApi.Models.Validations
{
    public class Offer_EnsurePriceCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value ,ValidationContext validationContext)
        {
            var offer = validationContext.ObjectInstance as Offer;

            if(offer != null){
                if(offer.Price <= 0){

                    return new ValidationResult("Price of product should be greater then 0.");
                }
            }
            return ValidationResult.Success;
        }
    }
}