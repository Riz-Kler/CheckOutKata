using Xunit;

namespace CheckoutKataTests
{
    public class CheckoutTests
    {
        public CheckoutTests()
        {
            var catalog = new ItemCatalog()
                    .UpdateItemUnitPrice("A", 50)
                    .UpdateItemUnitPrice("B", 30)
                    .UpdateItemUnitPrice("C", 20)
                    .UpdateItemUnitPrice("D", 15);
            var specialprices = new SpecialPrices()
                    .SpecialPriceItemUnit("A", 3, 130)
                    .SpecialPriceItemUnit("B", 2, 45);
            checkout = new Checkout(catalog, specialprices);
        }
           
           [Fact]
            public void price_of_a_single_item_A()
            {
                // Arrange                                                           
                //var checkout = new Checkout();

                // Act                                                               
                checkout.Scan("A");

                // Assert                                                            
                Assert.Equal(50, checkout.Total);
            } 

            [Fact]
            public void price_of_a_single_item_B()
            {
                // Arrange                                                           
                var checkout = new Checkout();

                // Act                                                               
                checkout.Scan("B");

                // Assert                                                            
                Assert.Equal(30, checkout.Total);
            }
            [Theory]
            [InlineData('A', 50)]
            [InlineData('B', 30)]
            [InlineData('C', 20)]
            [InlineData('D', 15)]
            public void price_of_any_single_item(string sku, int expected_total)
            {
                // Arrange                                                           
                //var checkout = new Checkout();

                // Act                                                               
                checkout.Scan(sku);

                // Assert                                                            
                Assert.Equal(expected_total, checkout.Total);
            }

    }
}
