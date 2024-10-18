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
    }
}
