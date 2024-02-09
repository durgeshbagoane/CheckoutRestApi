using CheckoutRestApi.Models;

namespace CheckoutRestApi.Repositories.Interface
{
    public interface IOfferRepositories
    {
        public bool OfferExists (String Name);
        public List<Offer> GetOffers ();
        public Task <Offer?> GetOffer(string Name);
        public Task AddOffer(Offer Offer);

        public Task UpdateOffer(Offer Offer);
        public void DeleteOffer(String Name);

        
    }
}
