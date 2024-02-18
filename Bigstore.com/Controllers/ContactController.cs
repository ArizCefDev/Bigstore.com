using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Bigstore.com.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values=_contactService.GetAll();
            return View(values);
        }
    }
}
