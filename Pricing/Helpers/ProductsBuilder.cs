using PointOfSale.Terminal.PriceCalculations;
using System.Collections.Generic;

namespace PointOfSale.Terminal
{
    public class ProductsBuilder
    {
        private readonly List<Product> products = new List<Product>();

        public ProductsBuilder AddProduct(string productCode, decimal singleUnitPrice)
        {
            products.Add(new Product(productCode, new UnitPriceCalculator(singleUnitPrice)));
            return this;
        }

        public ProductsBuilder AddProduct(string productCode, decimal singleUnitPrice, int volumeSize, decimal volumePrice)
        {
            products.Add(new Product(productCode, new VolumePriceCalculator(singleUnitPrice, volumeSize, volumePrice)));
            return this;
        }

        public Product[] GetAllProducts()
        {
            return products.ToArray();
        }
    }
}
