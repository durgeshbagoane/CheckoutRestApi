using CheckoutRestApi.Models;

namespace CheckoutRestApi.Repositories.Interface
{
    public interface IProductRepositories
    {
        public bool ProductExists (String Name);
        public List<Product> GetProducts ();
        public Task <Product?> GetProduct(string Name);
        public Task AddProduct(Product Product);

        public Task UpdateProduct(Product Product);
        public Task DeleteProduct(String Name);
        
    }
}
