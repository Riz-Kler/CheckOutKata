using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class ItemCatalog
    {
        private List<Item> catalog = new List<Item>();

        public ItemCatalog UpdateItemUnitPrice(string sku, int itemprice)
        {
            this.catalog.RemoveAll(x => x.Sku == sku);
            this.catalog.Add(new Item(sku, itemprice));
            return this;
        }

        public ItemCatalog RemoveItem(string sku)
        {
            this.catalog.RemoveAll(x => x.Sku == sku);
            return this;
        }

        public int GetUnitPriceForItem(string sku)
        {
            var item = this.catalog.Where(x => x.Sku == sku).FirstOrDefault();
            if (item == null) throw new UnknownSkuException(sku);
            return item.UnitPrice;
        }
    }

   
}