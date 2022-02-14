namespace PointOfSale.Terminal.PriceCalculations
{
    internal class VolumePriceCalculator : IPriceCalculator
    {
        private readonly UnitPriceCalculator unitCalculator;
        private readonly decimal volumePrice;
        private readonly int volumeSize;

        public VolumePriceCalculator(decimal singleUnitPrice, int volumeSize, decimal volumePrice)
        {
            unitCalculator = new UnitPriceCalculator(singleUnitPrice);
            this.volumeSize = volumeSize;
            this.volumePrice = volumePrice;
        }

        public decimal CalculatePrice(int itemsCount, decimal discountRate)
        {
            return (itemsCount / volumeSize) * volumePrice + unitCalculator.CalculatePrice(itemsCount % volumeSize, discountRate);
        }
    }
}
