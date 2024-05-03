using Microsoft.AspNetCore.Mvc;

namespace Chattero.Controllers
{
    public class MessaggioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
