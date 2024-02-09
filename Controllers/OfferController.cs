using CheckoutRestApi.Controllers.Filters;
using CheckoutRestApi.Models;
using CheckoutRestApi.Repositories;
using CheckoutRestApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutRestApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OfferController: ControllerBase
    {
        private readonly IOfferRepositories OfferRepository;

        public OfferController(IOfferRepositories Offerrepository){
            OfferRepository = Offerrepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetOffers()
        {
            
            return Ok(OfferRepository.GetOffers());
        }
        
        [HttpGet("{Name}")]
        [Offer_ValidateProductNameFilter]
        public async Task<IActionResult> GetOffer(string Name)
        {
            Offer offer = await OfferRepository.GetOffer(Name);
            return Ok(offer);
        }

        [HttpPost]
        [Offer_ValidateAddOfferFilter]
        public async Task<IActionResult> AddOffer([FromBody] Offer Offer)
        {
            await OfferRepository.AddOffer(Offer);            
            return CreatedAtAction("AddOffer",Offer);
        }

        [HttpPut]
        [Offer_ValidateUpdateOfferFilter]
         public async Task<IActionResult> UpdateOffer([FromBody]Offer Offer)
        {
            await OfferRepository.UpdateOffer(Offer);
            return NoContent();
        }

        [HttpDelete("{Name}")]
        [Offer_ValidateProductNameFilter]
        public async Task<IActionResult> DeleteOffer(String Name)
        {
            var Product = await GetOffer(Name);
            OfferRepository.DeleteOffer(Name);

            return Ok(Product);
        }
    }
}