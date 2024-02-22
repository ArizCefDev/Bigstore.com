using Business.Abstract;
using DTO.EntityDTO;
using Microsoft.AspNetCore.Mvc;

namespace Bigstore.com.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMessageService _messageService;

        public ContactController(IContactService contactService, IMessageService messageService)
        {
            _contactService = contactService;
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            var values=_contactService.GetAll();
            return View(values);
        }


        [HttpPost]
        public IActionResult Add(MessageDTO p)
        {
            p.CreateDate = DateTime.Now;
            _messageService.Insert(p);
            return Content("Mesajınız bizə uğurla göndərildi.");
        }
    }
}
