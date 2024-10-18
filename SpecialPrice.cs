using System.Collections.Generic;
using System.Linq;

namespace SupermarketCheckout
{
    public class SpecialPrice
    {
        public SpecialPrice (string sku, int numberOfItems, int packagePrice)
        {
            this.Sku = sku;
            this.NumberOfItems = numberOfItems;
            this.PackagePrice = packagePrice;
        }

        public readonly string Sku;
        public readonly int NumberOfItems;
        public readonly int PackagePrice;
    }

    public class SpecialPrices
    {
        private List<SpecialPrice> specialprices = new List<SpecialPrice>();

        public SpecialPrices SpecialPriceItem(string sku, int numberOfItems, int packagePrice)
        {
            this.specialprices.RemoveAll(x => x.Sku == sku);
            this.specialprices.Add(new SpecialPrice(sku, numberOfItems, packagePrice));
            return this;
        }

        public int GetDiscountedPrice(string sku, ref int numberOfItemsToCalculatePriceFor)
        {
            var specialprice = this.specialprices.Where(x => x.Sku == sku).FirstOrDefault();
            if (specialprice == null) return 0;

            var discountedPrice = (numberOfItemsToCalculatePriceFor / specialprice.NumberOfItems) * specialprice.PackagePrice;

            numberOfItemsToCalculatePriceFor = numberOfItemsToCalculatePriceFor % specialprice.NumberOfItems;

            return discountedPrice;
        }
    }
}