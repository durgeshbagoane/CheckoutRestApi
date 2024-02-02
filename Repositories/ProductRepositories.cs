using CheckoutRestApi.Models;

namespace CheckoutRestApi.Repositories
{
    public class ProductRepositories
    {
        private static  List<Product> Products =
        [
            new() { Name = "A", Price = 50},
            new() { Name = "B", Price = 30},
            new() { Name = "C", Price = 20},
            new() { Name = "D", Price = 15},
        ];
        public bool ProductExists (String Name){
            return Products.Any( Product => Product.Name == Name );
        }
        public List<Product> GetProducts(){
            return Products;
        }

        public Product? GetProduct(string Name){
            return Products.FirstOrDefault( Product => Product.Name == Name );
        }

        public void AddProduct(Product Product){
            Products.Add(Product);
        }

        public void UpdateProduct(Product Product){
            var ProductToUpdate = Products.First(P => P.Name == Product.Name);
            ProductToUpdate.Price = Product.Price;
        }

        public void DeleteProduct(String Name){
            var Product = GetProduct(Name);
            if(Product != null){
                Products.Remove(Product);
            }
        }

    }
}