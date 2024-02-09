using CheckoutRestApi.Models;
using CheckoutRestApi.Repositories.Interface;

namespace CheckoutRestApi.Repositories
{
    public class ProductRepositories : IProductRepositories
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

        public async Task<Product?> GetProduct(string Name){
            return Products.FirstOrDefault( Product => Product.Name == Name );
        }

        public async Task AddProduct(Product Product){
            Products.Add(Product);
        }

        public async Task UpdateProduct(Product Product){
            var ProductToUpdate = Products.First(P => P.Name == Product.Name);
            ProductToUpdate.Price = Product.Price;
        }

        public async Task DeleteProduct(String Name){
            var Product = await GetProduct(Name);
            if(Product != null){
                Products.Remove(Product);
            }
        }

    }
}