using CheckoutRestApi.Models;
using CheckoutRestApi.Repositories.Interface;

namespace CheckoutRestApi.Repositories
{
    public  class OfferRepositories : IOfferRepositories
    {
        private static  List<Offer> Offers =
        [
            new() { Name = "A", Quantity = 3, Price = 130},
            new() { Name = "B" ,Quantity = 2, Price = 45},
        ];

        public bool OfferExists (String Name){
            return Offers.Any( Offer => Offer.Name == Name);
        }

        public List<Offer> GetOffers (){
            return Offers;
        }

        public async Task <Offer?> GetOffer(string Name){
            return Offers.FirstOrDefault(Offer => Offer.Name == Name);
        }

        public async Task AddOffer(Offer Offer){
            Offers.Add(Offer);
        }

        public async Task UpdateOffer(Offer Offer){
            var OfferToUpdate = Offers.First(O => O.Name == Offer.Name);
            OfferToUpdate.Price = Offer.Price;
            OfferToUpdate.Quantity = Offer.Quantity;
        }

        public async void DeleteOffer(String Name){
            var Offer = await GetOffer(Name);
            if(Offer != null){
                Offers.Remove(Offer);
            }
        }
    }
}