using Microsoft.AspNetCore.Mvc;

namespace DigitalQ.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
