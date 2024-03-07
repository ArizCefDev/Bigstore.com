using Business.Abstract;
using DataAccess.Context;
using DataAccess.Entity;
using DTO.EntityDTO;
using Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bigstore.com.Controllers
{
    [Authorize(Roles = RoleKeywords.AdminRole)]
    public class AdminController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ICategoryService _categoryService;
        private readonly IContactService _contactService;
        private readonly IMessageService _messageService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly AppDBContext _dBContext;

        public AdminController(IAboutService aboutService, ICategoryService categoryService, IContactService contactService, IMessageService messageService, IProductService productService, IUserService userService, AppDBContext dBContext)
        {
            _aboutService = aboutService;
            _categoryService = categoryService;
            _contactService = contactService;
            _messageService = messageService;
            _productService = productService;
            _userService = userService;
            _dBContext = dBContext;
        }




        //Dashboard
        public IActionResult Index()
        {
            ViewBag.category = _dBContext.Categories.Count();
            ViewBag.message = _dBContext.Messages.Count();
            ViewBag.products = _dBContext.Products.Count();

            ViewBag.discountProduct = _dBContext.Products.Where(x => x.Status == "Endirimli").Count();
            ViewBag.product = _dBContext.Products.Where(x => x.Status != "Endirimli").Count();
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
            return View(values.OrderByDescending(row => row.ID));
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
            IEnumerable<SelectListItem> valuesGet = (from category in _categoryService.GetAll()
                                                 select new SelectListItem
                                                 {
                                                     Text = category.Name,
                                                     Value = category.ID.ToString()
                                                 }).ToList();

            ViewBag.c = valuesGet;
            return View();
        }

        [HttpPost]
        public IActionResult ProductAdd(ProductDTO p)
        {
            IEnumerable<SelectListItem> valuesGet = (from category in _categoryService.GetAll()
                                                     select new SelectListItem
                                                     {
                                                         Text = category.Name,
                                                         Value = category.ID.ToString()
                                                     }).ToList();

            ViewBag.c = valuesGet;

            p.Date = DateTime.Now;
            _productService.Insert(p);
            return RedirectToAction("ProductIndex");
        }

        public IActionResult ProductDelete(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("ProductIndex");
        }

        //User
        public IActionResult UserIndex()
        {
            var values = _userService.GetAll();
            return View(values.OrderByDescending(row => row.ID));
        }

        public IActionResult UserDelete(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("UserIndex");
        }

    }
}
