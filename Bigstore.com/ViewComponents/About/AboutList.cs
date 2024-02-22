using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Bigstore.com.ViewComponents.About
{
    public class AboutList : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public AboutList(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _aboutService.GetAll();
            return View(values);
        }
    }
}
