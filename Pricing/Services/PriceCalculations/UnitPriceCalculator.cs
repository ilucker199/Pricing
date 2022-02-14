namespace PointOfSale.Terminal.PriceCalculations
{
    public class UnitPriceCalculator : IPriceCalculator
    {
        private readonly decimal unitPrice;

        public UnitPriceCalculator(decimal price)
        {
            unitPrice = price;
        }

        public decimal CalculatePrice(int productsCount, decimal discountRate) => unitPrice * productsCount * (1.0M - discountRate);

    }
}
