using CheckoutRestApi.Controllers.Filters;
using CheckoutRestApi.Models;
using CheckoutRestApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutRestApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OfferController: ControllerBase
    {
        [HttpGet]
        public IActionResult GetOffers()
        {
            return Ok(OfferRepositories.GetOffers());
        }
        
        [HttpGet("{Name}")]
        [Offer_ValidateProductNameFilter]
        public IActionResult GetOffer(string Name)
        {
            return Ok(OfferRepositories.GetOffer(Name));
        }

        [HttpPost]
        [Offer_ValidateAddOfferFilter]
        public IActionResult AddOffer([FromBody] Offer Offer)
        {
            OfferRepositories.AddOffer(Offer);            
            return CreatedAtAction("AddOffer",Offer);
        }

        [HttpPut]
        [Offer_ValidateUpdateOfferFilter]
         public IActionResult UpdateOffer([FromBody]Offer Offer)
        {
            OfferRepositories.UpdateOffer(Offer);

            return NoContent();
        }

        [HttpDelete("{Name}")]
        [Offer_ValidateProductNameFilter]
        public IActionResult DeleteOffer(String Name)
        {
            var Product = GetOffer(Name);
            OfferRepositories.DeleteOffer(Name);

            return Ok(Product);
        }
    }
}