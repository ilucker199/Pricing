namespace PointOfSale.Terminal
{
    public interface IPriceCalculator
    {
        decimal CalculatePrice(int itemsCount, decimal discountRate);
    }
}
