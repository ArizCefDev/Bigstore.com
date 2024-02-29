using Business.Abstract;
using DataAccess.Entity;
using DTO.EntityDTO;
using Microsoft.AspNetCore.Mvc;

namespace Bigstore.com.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ICategoryService _categoryService;
        private readonly IContactService _contactService;
        private readonly IMessageService _messageService;
        private readonly IProductService _productService;

        public AdminController(IAboutService aboutService, ICategoryService categoryService, IContactService contactService, IMessageService messageService, IProductService productService)
        {
            _aboutService = aboutService;
            _categoryService = categoryService;
            _contactService = contactService;
            _messageService = messageService;
            _productService = productService;
        }

        //Dashboard
        public IActionResult Index()
        {
            return View();
        }

        //About
        public IActionResult AboutIndex()
        {
            var values = _aboutService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AboutAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AboutAdd(AboutDTO p)
        {
            _aboutService.Insert(p);
            return RedirectToAction("AboutIndex");
        }

        public IActionResult AboutDelete(int id)
        {
            _aboutService.Delete(id);
            return RedirectToAction("AboutIndex");
        }

        //Category
        public IActionResult CategoryIndex()
        {
            var values = _categoryService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(CategoryDTO p)
        {
            _categoryService.Insert(p);
            return RedirectToAction("CategoryIndex");
        }

        public IActionResult CategoryDelete(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("CategoryIndex");
        }

        //Messages
        public IActionResult MessagesIndex()
        {
            var values = _messageService.GetAll();
            return View(values.OrderByDescending(row=>row.ID));
        }

        public IActionResult MessagesDelete(int id)
        {
            _messageService.Delete(id);
            return RedirectToAction("MessagesIndex");
        }

		//Contact
		public IActionResult ContactIndex()
		{
			var values = _contactService.GetAll();
			return View(values);
		}

		[HttpGet]
		public IActionResult ContactAdd()
		{
			return View();
		}

		[HttpPost]
		public IActionResult ContactAdd(ContactDTO p)
		{
			_contactService.Insert(p);
			return RedirectToAction("ContactIndex");
		}

		public IActionResult ContactDelete(int id)
		{
			_contactService.Delete(id);
			return RedirectToAction("ContactIndex");
		}

        //Product
        public IActionResult ProductIndex()
        {
            var values = _productService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult ProductAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProductAdd(ProductDTO p)
        {
            p.Date = DateTime.Now;
            _productService.Insert(p);
            return RedirectToAction("ProductIndex");
        }

        public IActionResult ProductDelete(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("ProductIndex");
        }
    }
}
