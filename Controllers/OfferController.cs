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
            try{
                Offer offer = await OfferRepository.GetOffer(Name);
                return Ok(offer);
            }
            catch (AggregateException)
            {
                throw;
            }
        }

        [HttpPost]
        [Offer_ValidateAddOfferFilter]
        public async Task<IActionResult> AddOffer([FromBody] Offer Offer)
        {
            try{
                await OfferRepository.AddOffer(Offer);            
                return CreatedAtAction("AddOffer",Offer);
            }
            catch (AggregateException)
            {
                throw;
            }
        }

        [HttpPut]
        [Offer_ValidateUpdateOfferFilter]
         public async Task<IActionResult> UpdateOffer([FromBody]Offer Offer)
        {

            try{
                await OfferRepository.UpdateOffer(Offer);
                return NoContent();
            }
            catch (AggregateException)
            {
                throw;
            }
        }

        [HttpDelete("{Name}")]
        [Offer_ValidateProductNameFilter]
        public async Task<IActionResult> DeleteOffer(String Name)
        {

            try{
                var Product = await GetOffer(Name);
                OfferRepository.DeleteOffer(Name);
                return Ok(Product);
            }
            catch (AggregateException)
            {
                throw;
            }
        }
    }
}