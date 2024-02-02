using CheckoutRestApi.Controllers.Filters;
using CheckoutRestApi.Models;
using CheckoutRestApi.src;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutRestApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CheckoutController(CheckoutLogic checkoutlogic) : ControllerBase
    {
         private readonly CheckoutLogic checkoutLogic = checkoutlogic;

        [HttpPost]
        [Checkout_ValidateCheckoutItemsFilter]
        public IActionResult GetTotal([FromBody]Checkout Checkout)
        {
            Checkout.Total = checkoutLogic.Total(Checkout.Items);
            return Ok(Checkout);
        }
    }
}