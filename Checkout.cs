using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Checkout
    {
        public Checkout(ItemCatalog catalog, SpecialPrices specialprices)
        {
            this.Catalog = catalog;
            this.SpecialPrices = specialprices;
            this.ScannedItems = new Dictionary<string, int>();
        }

        private readonly ItemCatalog Catalog;
        private readonly SpecialPrices SpecialPrices;
        private readonly Dictionary<string, int> ScannedItems;

        public void Scan(string sku, int times = 1)
        {
            if (ScannedItems.ContainsKey(sku))
            {
                ScannedItems[sku] += times;
            }
            else
            {
                ScannedItems.Add(sku, times);
            }
        }

        public int Total
        {
            get
            {
                var total = 0;
                foreach (var group in ScannedItems)
                {
                    var sku = group.Key;
                    var number_of_items = group.Value;
                    total += Discounts.GetDiscountedPrice(sku, ref number_of_items);
                    total += number_of_items * Catalog.GetPriceForProduct(group.Key);
                }
                return total;
            }
        }
    }
}