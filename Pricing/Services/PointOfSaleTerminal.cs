using PointOfSale.Terminal.DiscountCalculations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale.Terminal
{
    public class PointOfSaleTerminal
    {
        private readonly Dictionary<string, ProductsCounter> ProductData;

        public PointOfSaleTerminal(IEnumerable<Product> products)
        {
            if (products == null || !products.Any())
                throw new Exception("This product code doesn't exist!");

            ProductData = products.ToDictionary(p => p.ProductCode, p => new ProductsCounter(p.PriceCalculator));
        }

        public void Scan(string productCode)
        {
            if (!ProductData.ContainsKey(productCode))
                throw new Exception("This product code doesn't exist!");

            ProductData[productCode].AddItem();
        }

        public decimal CalculateTotal(decimal discountRate = 0.0M)
        {
            return ProductData.Aggregate(0.0M, (a, pr) => a + pr.Value.GetTotalPrice(discountRate));
        }

        public decimal CalculateTotal(DiscountCard discountCard)
        {
            decimal discountRate = discountCard.DiscountPercents / 100.0M;
            discountCard.AddTotal(CalculateTotal());
            return CalculateTotal(discountRate);
        }
    }
}
