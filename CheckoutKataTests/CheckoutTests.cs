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

        Checkout checkout;
           
           [Fact]
            public void can_find_price_of_a_single_item_A()
            {
                // Arrange                                                           
                //var checkout = new Checkout();

                // Act                                                               
                checkout.Scan("A");

                // Assert                                                            
                Assert.Equal(50, checkout.Total);
            } 

            [Fact]
            public void can_find_price_of_a_single_item_B()
            {
                // Arrange                                                           
                //var checkout = new Checkout();

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
            public void can_find_price_of_any_single_item(string sku, int expected_total)
            {
                // Arrange                                                           
                //var checkout = new Checkout();

                // Act                                                               
                checkout.Scan(sku);

                // Assert                                                            
                Assert.Equal(expected_total, checkout.Total);
            }

            [Theory]
            [InlineData('A', 2, 100)]
            [InlineData('B', 1, 30)]
            [InlineData('C', 10, 200)]
            [InlineData('D', 5, 75)]
            public void can_find_price_for_multiple_items(string sku, int number_of_items, int expected_total)
            {
                // Arrange                                                           
                //var checkout = new Checkout();

                // Act                                                               
                checkout.Scan(sku, number_of_items);

                // Assert                                                            
                Assert.Equal(expected_total, checkout.Total);
            }

            [Theory]
            [InlineData('A', 3, 130)]
            [InlineData('B', 2, 45)]
            [InlineData('A', 7, 310)]
            [InlineData('B', 11, 255)]
            public void can_calculate_specialdeals(string sku, int number_of_items, int expected_total)
            {
                // Act                                                               
                checkout.Scan(sku, number_of_items);

                // Assert                                                            
                Assert.Equal(expected_total, checkout.Total);
            }

            [Theory]
            [InlineData("AABCCDC", 205)]
            public void can_find_price_for_shopping_cart_of_items(string stream, int expected_total)
            {
                foreach (var sku in stream)
                {
                    checkout.Scan(""+sku);
                }

                Assert.Equal(expected_total, checkout.Total);
            }

    }
}
