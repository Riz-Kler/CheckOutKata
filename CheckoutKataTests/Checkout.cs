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
    }
}