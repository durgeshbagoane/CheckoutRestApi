using CheckoutRestApi.Controllers.Filters;
using CheckoutRestApi.Models;
using CheckoutRestApi.src;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutRestApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CheckoutController: ControllerBase
    {

        [HttpPost]
        [Checkout_ValidateCheckoutItemsFilter]
        public IActionResult GetTotal([FromBody]Checkout Checkout)
        {
            CheckoutLogic checkoutLogic = new();
            Checkout.Total = checkoutLogic.Total(Checkout.Items);
            
            return Ok(Checkout);
        }
    }
}