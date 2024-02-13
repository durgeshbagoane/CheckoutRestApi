using CheckoutRestApi.Controllers.Filters;
using CheckoutRestApi.Models;
using CheckoutRestApi.Repositories;
using CheckoutRestApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutRestApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController: ControllerBase
    {
        private readonly IProductRepositories ProductRepositories;

        public ProductController(IProductRepositories Productrepositories){
            ProductRepositories = Productrepositories;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(ProductRepositories.GetProducts());
        }

        [HttpGet("{Name}")]
        [Product_ValidateProductNameFilter]
        public async Task<IActionResult> GetProduct(string Name)
        {
            try{
                return Ok(await ProductRepositories.GetProduct(Name));
            }
            catch (AggregateException)
            {
                throw;
            }
        }

        [HttpPost]
        [Product_ValidateAddProductFilter]
        public async Task<IActionResult> AddProduct([FromBody]Product Product)
        {
            try{
                await ProductRepositories.AddProduct(Product);            
                return CreatedAtAction("AddProduct",Product);
            }
            catch (AggregateException)
            {
                throw;
            }
        }

        [HttpPut]
        [Product_ValidateUpdateProductFilter]
         public async Task<IActionResult> UpdateProduct([FromBody]Product Product)
        {
            try{
                await ProductRepositories.UpdateProduct(Product);
                return NoContent();
            }
            catch (AggregateException)
            {
                throw;
            }
        }

        [HttpDelete("{Name}")]
        [Product_ValidateProductNameFilter]
        public async Task<IActionResult> DeleteProduct(String Name)
        {
            try{
                var Product = await GetProduct(Name);
                await ProductRepositories.DeleteProduct(Name);

                return Ok(Product);
            }
            catch (AggregateException)
            {
                throw;
            }
        }
    }
}