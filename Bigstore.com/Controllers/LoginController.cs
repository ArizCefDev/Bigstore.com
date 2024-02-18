using Microsoft.AspNetCore.Mvc;

namespace Bigstore.com.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
    }
}
