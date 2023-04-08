using Microsoft.AspNetCore.Mvc;

namespace DigitalQ.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
