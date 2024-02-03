using CheckoutRestApi.Models;
using CheckoutRestApi.Repositories;
namespace CheckoutRestApi.src
{
    /*
    *Main logic of checkout Items amount total wrt discounts
    */
    public class CheckoutLogic(OfferRepositories Offerrepository,ProductRepositories Productrepositories) {

         private char[] ScannedProducts = new char[]{};
         private readonly List<Product> Products = Productrepositories.GetProducts();
         private readonly List<Offer> Offers = Offerrepository.GetOffers();

        /*
         *Intial call method to get total amount of Items
        */
        public double Total(string Items){

            double WithOutDiscountTotal = 0;
            double DiscountTotal = 0;
           
            if( Items != null){
                ScannedProducts = Items.ToCharArray();
                WithOutDiscountTotal = ScannedProducts.Sum(item => ItemPrice(Char.ToString(item)));
                DiscountTotal = Offers.Sum(O => CalculateDiscount(O, ScannedProducts));
            }

            return WithOutDiscountTotal - DiscountTotal;
        }

        /*
        *Get price wrt product name.
        */
        private double ItemPrice(String item){
            var Product = Products.FirstOrDefault(Product => Product.Name == item);
            if(Product != null){
                return Product.Price;
            }
            return 0;
        }
        
        /*
        *Calculating the total discount amount wrt items in the checkout.
        */
         private double CalculateDiscount(Offer Offer, char[] ScannedProducts)
        {
            int itemCount = ScannedProducts.Count(item => Char.ToString(item) == Offer.Name);
            int DiscountCount = itemCount / Offer.Quantity;
           
            return DiscountCount * ( ItemPrice(Offer.Name) * Offer.Quantity - Offer.Price);
        }

    }
}