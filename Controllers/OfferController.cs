using CheckoutRestApi.Controllers.Filters;
using CheckoutRestApi.Models;
using CheckoutRestApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutRestApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OfferController(OfferRepositories Offerrepository): ControllerBase
    {
        private readonly OfferRepositories OfferRepository = Offerrepository;

        [HttpGet]
        public IActionResult GetOffers()
        {
            
            return Ok(OfferRepository.GetOffers());
        }
        
        [HttpGet("{Name}")]
        [Offer_ValidateProductNameFilter]
        public IActionResult GetOffer(string Name)
        {
            return Ok(OfferRepository.GetOffer(Name));
        }

        [HttpPost]
        [Offer_ValidateAddOfferFilter]
        public IActionResult AddOffer([FromBody] Offer Offer)
        {
            OfferRepository.AddOffer(Offer);            
            return CreatedAtAction("AddOffer",Offer);
        }

        [HttpPut]
        [Offer_ValidateUpdateOfferFilter]
         public IActionResult UpdateOffer([FromBody]Offer Offer)
        {
            OfferRepository.UpdateOffer(Offer);

            return NoContent();
        }

        [HttpDelete("{Name}")]
        [Offer_ValidateProductNameFilter]
        public IActionResult DeleteOffer(String Name)
        {
            var Product = GetOffer(Name);
            OfferRepository.DeleteOffer(Name);

            return Ok(Product);
        }
    }
}