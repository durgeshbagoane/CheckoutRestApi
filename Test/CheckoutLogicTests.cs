using Xunit;
using CheckoutRestApi.src;

public class CheckoutLogicTests
{
    CheckoutLogic CheckoutLogic = new CheckoutLogic();

    [Fact]
    public void PassingTotalTest(){
        Assert.Equal(0,CheckoutLogic.Total(""));
        Assert.Equal(50,CheckoutLogic.Total("A"));
        Assert.Equal(80,CheckoutLogic.Total("AB"));
        Assert.Equal(115,CheckoutLogic.Total("CDBA"));
        Assert.Equal(100,CheckoutLogic.Total("AA"));
        Assert.Equal(130,CheckoutLogic.Total("AAA"));
        Assert.Equal(175,CheckoutLogic.Total("AAABB"));
    }
}