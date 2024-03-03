using DTO.EntityDTO;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Business.Abstract;

namespace Bigstore.com.Controllers
{
    public class LoginController : Controller
    {
		private readonly IUserService _userService;

		public LoginController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SignUp(UserDTO p)
		{
			_userService.Insert(p);
			return RedirectToAction("SignIn","Login");
		}

		[HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

		[HttpPost]
		public IActionResult SignIn(UserDTO p)
		{
			var user=_userService.Login(p);
			Authenticate(user);

			return RedirectToAction("Index", "Home");
		}


		[HttpGet]
		public async Task<IActionResult> LogOut()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("SignIn", "Login");
		}

		//Cookie
		private void Authenticate(UserDTO user)
		{
			var claims = new List<Claim>
			{
				new Claim("Id", user.ID.ToString()),
				new Claim("UserName", user.Username),
				new Claim(ClaimTypes.Role, user.RoleName),
			};

			ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie");

			HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
		}
	}
}
