using Microsoft.AspNetCore.Mvc;

namespace DigitalQ.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
