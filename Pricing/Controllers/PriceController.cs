using Microsoft.AspNetCore.Mvc;
using PointOfSale.Terminal;

namespace Pricing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceController : Controller
    {

        [HttpGet("getTotalPrice")]
        public decimal PaymentStatusNotification(string products)
        {
            var terminal = new PointOfSaleTerminal(
                new ProductsBuilder()
                    .AddProduct("A", 1.25M, 3, 3.0M)
                    .AddProduct("B", 4.25M)
                    .AddProduct("C", 1.0M, 6, 5.0M)
                    .AddProduct("D", 0.75M)
                    .GetAllProducts());

            foreach (char ch in products)
            {
                terminal.Scan(ch.ToString());
            }

            return terminal.CalculateTotal();
        }
    }
}
