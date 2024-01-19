using System.Text.RegularExpressions;
using CheckoutRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CheckoutRestApi.Controllers.Filters
{
    public partial class Checkout_ValidateCheckoutItemsFilterAttribute: ActionFilterAttribute{
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var Checkout = context.ActionArguments["Checkout"] as Checkout;
            if(Checkout == null) {

                context.ModelState.AddModelError("Checkout","Checkout Object is null.");
                var ProblemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(ProblemDetails);
                 
            }else if(Checkout.Items == null ){
                context.ModelState.AddModelError("Checkout","Items is empty");
                var ProblemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(ProblemDetails);
            }else if(!MyRegex().IsMatch(Checkout.Items)){
                context.ModelState.AddModelError("Checkout","Items name should only contain a letters");
                var ProblemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(ProblemDetails);
            }

        }

        [GeneratedRegex(@"^[a-zA-Z]+$")]
        private static partial Regex MyRegex();
    }
}