using Microsoft.AspNetCore.Mvc;

namespace DigitalQ.Controllers
{
    public class FilaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
