namespace CheckOutKata
{
public class Item
{
    public Product(string sku, int unitprice)
    {
        this.UnitPrice = unitprice;
        this.Sku = sku;
    }

    public readonly string Sku;
    public readonly int UnitPrice;
}
}