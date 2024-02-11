using Microsoft.AspNetCore.Mvc;

namespace Bigstore.com.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
