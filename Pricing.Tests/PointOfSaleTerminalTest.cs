using NUnit.Framework;
using PointOfSale.Terminal;
using PointOfSale.Terminal.DiscountCalculations;
using System;

namespace Pricing.Tests
{
    public class Tests
    {
        [TestCase("", 0.0)]
        [TestCase("A", 1.25)]
        [TestCase("AA", 2.5)]
        [TestCase("AAA", 3.0)]
        [TestCase("ABCDABA", 13.25)]
        [TestCase("CCCCCCC", 6.0)]
        [TestCase("ABCD", 7.25)]
        public void ScanProducts_WithDefaultPricesSet(string productCodes, decimal expectedResult)
        {
            var terminal = new PointOfSaleTerminal(
                new ProductsBuilder()
                    .AddProduct("A", 1.25M, 3, 3.0M)
                    .AddProduct("B", 4.25M)
                    .AddProduct("C", 1.0M, 6, 5.0M)
                    .AddProduct("D", 0.75M)
                    .GetAllProducts());

            foreach (char ch in productCodes)
            {
                terminal.Scan(ch.ToString());
            }

            Assert.AreEqual(expectedResult, terminal.CalculateTotal());
        }

        [TestCase(1, 99.0)]
        [TestCase(3, 200.0)]
        [TestCase(4, 299.0)]
        public void ApplyDiscountCard_WithDefaultDiscountCard(int productsCount, decimal expectedResult)
        {
            var terminal = new PointOfSaleTerminal(
                new ProductsBuilder()
                    .AddProduct('A'.ToString(), 100.0M, 3, 200.0M)
                    .GetAllProducts());
            var discountCard = new DiscountCard(1, new[]
                {
                    new Discount(1000.0M, 5),
                    new Discount(10000.0M, 10),
                });

            foreach (char ch in new string('A', productsCount))
            {
                terminal.Scan(ch.ToString());
            }

            Assert.AreEqual(expectedResult, terminal.CalculateTotal(discountCard));
        }


        [TestCase(1, 99.0)]
        [TestCase(9, 99.0)]
        [TestCase(10, 95.0)]
        [TestCase(100, 90.0)]
        public void DiscountRateChanges_WithDefaultDiscountCard(int productsCount, decimal expectedResult)
        {
            var discountCard = new DiscountCard(1, new[]
                {
                    new Discount(1000.0M, 5),
                    new Discount(10000.0M, 10),
                });
            Func<int, decimal> scanItems = count =>
            {
                var terminal = new PointOfSaleTerminal(
                    new ProductsBuilder()
                        .AddProduct('A'.ToString(), 100.0M)
                        .GetAllProducts());
                foreach (char ch in new string('A', count))
                {
                    terminal.Scan(ch.ToString());
                }
                return terminal.CalculateTotal(discountCard);
            };

            scanItems(productsCount);
            decimal actualResult = scanItems(1);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}