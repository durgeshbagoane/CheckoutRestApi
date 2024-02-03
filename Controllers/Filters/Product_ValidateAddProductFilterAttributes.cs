using System.Text.RegularExpressions;
using CheckoutRestApi.Models;
using CheckoutRestApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CheckoutRestApi.Controllers.Filters
{
    public partial class Product_ValidateAddProductFilterAttribute: ActionFilterAttribute{
        private readonly ProductRepositories ProductRepositories;
        public Product_ValidateAddProductFilterAttribute(){
            ProductRepositories = new ProductRepositories();
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var Product = context.ActionArguments["Product"] as Product;
            if(Product == null) {

                context.ModelState.AddModelError("Product","Product Object is null.");
                var ProblemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(ProblemDetails);
                 
            }else if(Product.Name !=null && ProductRepositories.ProductExists(Product.Name)){
                context.ModelState.AddModelError("ProductName","Product already exists.");
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