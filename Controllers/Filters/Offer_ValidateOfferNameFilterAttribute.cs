using System.Text.RegularExpressions;
using CheckoutRestApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CheckoutRestApi.Controllers.Filters
{
    public partial class Offer_ValidateProductNameFilterAttribute: ActionFilterAttribute{
        private readonly OfferRepositories OfferRepositories;
        public Offer_ValidateProductNameFilterAttribute(){
            OfferRepositories = new OfferRepositories();
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var ProductName = context.ActionArguments["Name"] as string;
            if(ProductName != null) {
                if(ProductName.Length != 1){
                    context.ModelState.AddModelError("ProductName","Product name should only contain a single letter.");
                    var ProblemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(ProblemDetails);
                }else if(!MyRegex().IsMatch(ProductName))
                {
                    context.ModelState.AddModelError("ProductName","Product name should only contain a single letter from a-z or A-Z.");
                    var ProblemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(ProblemDetails);
                } else if(!OfferRepositories.OfferExists(ProductName)){
                    context.ModelState.AddModelError("ProductName","Offer doesn't exists.");
                    var ProblemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(ProblemDetails);
                }
            }

        }

        [GeneratedRegex(@"^[a-zA-Z]+$")]
        private static partial Regex MyRegex();
    }
}