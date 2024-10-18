
using Xunit;

namespace CheckoutKataTests
{
    public class TestItemCatalog
    {
        [Fact]
        public void can_add_item()
        {
            // ARRANGE
            var catalog = new ItemCatalog();

            // ACT
            catalog.UpdateItemUnitPrice("A", 50);

            // ASSERT
            Assert.Equal(50, catalog.GetUnitPriceForItem("A"));
        }

        [Fact]
        public void can_remove_item()
        {
            // ARRANGE
            var catalog = new ItemCatalog();
            catalog.UpdateItemUnitPrice("A", 50);

            // ACT
            catalog.RemoveItem("A");

            // ASSERT
            Assert.Throws<UnknownSkuException>(
                ()=>  catalog.GetUnitPriceForItem("A"));
        }
    }
}