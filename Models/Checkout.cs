using System.ComponentModel.DataAnnotations;
using CheckoutRestApi.Models.Validations;

namespace CheckoutRestApi.Models
{
	public class Checkout
	{
		[Required]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string? Items { get; set; }
		

		public double Total { get; set; }
	}
}