using CheckoutRestApi.Models;

namespace CheckoutRestApi.src.Interface
{
    public interface ICheckoutLogic
    {
        public Task<double> Total(string Items);
        
    }
}
