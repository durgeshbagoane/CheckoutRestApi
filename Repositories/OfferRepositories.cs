using CheckoutRestApi.Models;

namespace CheckoutRestApi.Repositories
{
    public static class OfferRepositories
    {
        private static  List<Offer> Offers =
        [
            new() { Name = "A", Quantity = 3, Price = 130},
            new() { Name = "B" ,Quantity = 2, Price = 45},
        ];

        public static bool OfferExists (String Name){
            return Offers.Any( Offer => Offer.Name == Name);
        }

        public static List<Offer> GetOffers (){
            return Offers;
        }

        public static Offer? GetOffer(string Name){
            return Offers.FirstOrDefault(Offer => Offer.Name == Name);
        }

        public static void AddOffer(Offer Offer){
            Offers.Add(Offer);
        }

        public static void UpdateOffer(Offer Offer){
            var OfferToUpdate = Offers.First(O => O.Name == Offer.Name);
            OfferToUpdate.Price = Offer.Price;
            OfferToUpdate.Quantity = Offer.Quantity;
        }

        public static void DeleteOffer(String Name){
            var Offer = GetOffer(Name);
            if(Offer != null){
                Offers.Remove(Offer);
            }
        }
    }
}