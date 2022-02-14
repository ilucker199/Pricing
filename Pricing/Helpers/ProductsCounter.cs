namespace PointOfSale.Terminal
{
    internal class ProductsCounter
    {
        private readonly IPriceCalculator priceCalculator;
        private int itemsCount = 0;

        public ProductsCounter(IPriceCalculator priceCalculator)
        {
            this.priceCalculator = priceCalculator;
        }

        public void AddItem()
        {
            itemsCount++;
        }

        public decimal GetTotalPrice(decimal discountRate)
        {
            return priceCalculator.CalculatePrice(itemsCount, discountRate);
        }
    }
}
