using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Bigstore.com.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(string Search)
        {
            var values = from a in _productService.GetAll() select a;
            if (!string.IsNullOrEmpty(Search))
            {
                values = values.Where(con => con.Title.ToLower().Contains(Search.ToLower()));
            }
            return View(values.OrderByDescending(r=>r.ID));
        }
    }
}
