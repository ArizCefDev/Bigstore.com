using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Bigstore.com.ViewComponents.Contact
{
    public class ContactList : ViewComponent
    {
        private readonly IContactService _contactService;

        public ContactList(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _contactService.GetAll();
            return View(values);
        }
    }
}
