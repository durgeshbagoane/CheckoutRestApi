using CheckoutRestApi.Models;

namespace CheckoutRestApi.Repositories
{
    public  class OfferRepositories
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

        public  Offer? GetOffer(string Name){
            return Offers.FirstOrDefault(Offer => Offer.Name == Name);
        }

        public void AddOffer(Offer Offer){
            Offers.Add(Offer);
        }

        public void UpdateOffer(Offer Offer){
            var OfferToUpdate = Offers.First(O => O.Name == Offer.Name);
            OfferToUpdate.Price = Offer.Price;
            OfferToUpdate.Quantity = Offer.Quantity;
        }

        public void DeleteOffer(String Name){
            var Offer = GetOffer(Name);
            if(Offer != null){
                Offers.Remove(Offer);
            }
        }
    }
}