using Microsoft.AspNetCore.Mvc;

namespace Pricing.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
