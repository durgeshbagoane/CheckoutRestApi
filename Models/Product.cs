using System.ComponentModel.DataAnnotations;
using CheckoutRestApi.Models.Validations;

namespace CheckoutRestApi.Models
{
	public class Product
	{
		[Required]
		[StringLength(1)]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
		public string? Name { get; set; }

		[Product_EnsurePriceCheck]
		public double Price { get; set; }
	}
}