using System;

namespace CheckoutKata
{
    public class UnknownSkuException : Exception
    {
        public UnknownSkuException(string sku) : base($"Unknown SKU = {sku}")
        {
        }
    }
}