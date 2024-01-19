using System.Text.RegularExpressions;
using CheckoutRestApi.Models;
using CheckoutRestApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CheckoutRestApi.Controllers.Filters
{
    public partial class Offer_ValidateAddOfferFilterAttribute: ActionFilterAttribute{
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var Offer = context.ActionArguments["Offer"] as Offer;
            if(Offer == null) {

                context.ModelState.AddModelError("Offer","Offer Object is null.");
                var ProblemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(ProblemDetails);
                 
            }else if(Offer.Name !=null && OfferRepositories.OfferExists(Offer.Name)){
                context.ModelState.AddModelError("Offer","Product offer already exists.");
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