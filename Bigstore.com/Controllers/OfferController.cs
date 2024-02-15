using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Bigstore.com.Controllers
{
    public class OfferController : Controller
    {
        private readonly IProductService _productService;

        public OfferController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var values = _productService.GetAll().Where(x=>x.Status=="Endirimli");
            return View(values.OrderByDescending(r => r.ID));
        }
    }
}
