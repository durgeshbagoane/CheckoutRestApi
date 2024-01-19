using CheckoutRestApi.Models;

namespace CheckoutRestApi.Repositories
{
    public static class ProductRepositories
    {
        private static  List<Product> Products =
        [
            new() { Name = "A", Price = 50},
            new() { Name = "B", Price = 30},
            new() { Name = "C", Price = 20},
            new() { Name = "D", Price = 15},
        ];
        public static bool ProductExists (String Name){
            return Products.Any( Product => Product.Name == Name );
        }
        public static List<Product> GetProducts(){
            return Products;
        }

        public static Product? GetProduct(string Name){
            return Products.FirstOrDefault( Product => Product.Name == Name );
        }

        public static void AddProduct(Product Product){
            Products.Add(Product);
        }

        public static void UpdateProduct(Product Product){
            var ProductToUpdate = Products.First(P => P.Name == Product.Name);
            ProductToUpdate.Price = Product.Price;
        }

        public static void DeleteProduct(String Name){
            var Product = GetProduct(Name);
            if(Product != null){
                Products.Remove(Product);
            }
        }

    }
}