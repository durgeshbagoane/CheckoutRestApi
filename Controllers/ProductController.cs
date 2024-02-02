using CheckoutRestApi.Controllers.Filters;
using CheckoutRestApi.Models;
using CheckoutRestApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutRestApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController(ProductRepositories Productrepositories): ControllerBase
    {
        private readonly ProductRepositories ProductRepositories = Productrepositories;
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(ProductRepositories.GetProducts());
        }

        [HttpGet("{Name}")]
        [Product_ValidateProductNameFilter]
        public IActionResult GetProduct(string Name)
        {
            return Ok(ProductRepositories.GetProduct(Name));
        }

        [HttpPost]
        [Product_ValidateAddProductFilter]
        public IActionResult AddProduct([FromBody]Product Product)
        {
            ProductRepositories.AddProduct(Product);            
            return CreatedAtAction("AddProduct",Product);
        }

        [HttpPut]
        [Product_ValidateUpdateProductFilter]
         public IActionResult UpdateProduct([FromBody]Product Product)
        {

            ProductRepositories.UpdateProduct(Product);
            
            return NoContent();
        }

        [HttpDelete("{Name}")]
        [Product_ValidateProductNameFilter]
        public IActionResult DeleteProduct(String Name)
        {
            var Product = GetProduct(Name);
            ProductRepositories.DeleteProduct(Name);

            return Ok(Product);
        }
    }
}