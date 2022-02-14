using System;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale.Terminal.DiscountCalculations
{
    public class DiscountCard
    {
        private readonly List<Discount> points;
        private decimal total = 0.0M;

        public DiscountCard(int baseDiscount, IEnumerable<Discount> discountPoints)
        {
            points = (new[] { new Discount(0.0M, baseDiscount) }).Concat(discountPoints).Reverse().ToList();
        }

        public int DiscountPercents
        {
            get => points.First(d => d.MinimumTotal <= total).DiscountPrecents;
        }

        public void AddTotal(decimal sum)
        {
            total += sum;
        }
    }
}
