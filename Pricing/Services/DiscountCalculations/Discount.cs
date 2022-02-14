namespace PointOfSale.Terminal.DiscountCalculations
{
    public struct Discount
    {
        public Discount(decimal minimumTotal, int discountPercents)
        {
            MinimumTotal = minimumTotal;
            DiscountPrecents = discountPercents;
        }

        public decimal MinimumTotal { get; set; }

        public int DiscountPrecents { get; set; }
    }
}
