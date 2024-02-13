using CheckoutRestApi.Controllers.Filters;
using CheckoutRestApi.Models;
using CheckoutRestApi.src;
using CheckoutRestApi.src.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutRestApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CheckoutController : ControllerBase
    {
         private readonly ICheckoutLogic checkoutLogic;

         public CheckoutController(ICheckoutLogic checkoutlogic){
            checkoutLogic = checkoutlogic;
         }

        [HttpPost]
        [Checkout_ValidateCheckoutItemsFilter]
        public async Task<IActionResult> GetTotal([FromBody]Checkout Checkout)
        {
            try{
                Checkout.Total = await checkoutLogic.Total(Checkout.Items);
                return Ok(Checkout);
            }
            catch (AggregateException)
            {
                throw;
            }
        }
    }
}