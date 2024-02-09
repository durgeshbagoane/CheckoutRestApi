using Xunit;
using CheckoutRestApi.src;
using CheckoutRestApi.Repositories;
using CheckoutRestApi.Repositories.Interface;

public class CheckoutLogicTests
{
    
    CheckoutLogic CheckoutLogic = new(new OfferRepositories(),new ProductRepositories());

    [Fact]
    public async void PassingTotalTest(){
        Assert.Equal(0,await CheckoutLogic.Total(""));
        Assert.Equal(50,await CheckoutLogic.Total("A"));
        Assert.Equal(80,await CheckoutLogic.Total("AB"));
        Assert.Equal(115,await CheckoutLogic.Total("CDBA"));
        Assert.Equal(100,await CheckoutLogic.Total("AA"));
        Assert.Equal(130,await CheckoutLogic.Total("AAA"));
        Assert.Equal(175,await CheckoutLogic.Total("AAABB"));
    }
}