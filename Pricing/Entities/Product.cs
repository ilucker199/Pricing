namespace PointOfSale.Terminal
{
    public class Product
    {
        public Product(string productCode, IPriceCalculator priceCalculator)
        {
            ProductCode = productCode;
            PriceCalculator = priceCalculator;
        }

        public string ProductCode { get; private set; }

        public IPriceCalculator PriceCalculator { get; private set; }
    }
}
