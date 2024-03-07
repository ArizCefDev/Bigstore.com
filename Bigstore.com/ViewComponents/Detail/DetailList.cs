using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bigstore.com.ViewComponents.Detail
{
	public class DetailList : ViewComponent
	{
		private readonly IProductService _productService;

		public DetailList(IProductService productService)
		{
			_productService = productService;
		}

        public IViewComponentResult Invoke(int id)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(x => x.Type == "Id")?.Value);
            ViewBag.id = userId;
            ViewBag.postid = id;

            
            var values = _productService.GetById(id);
            return View(values);
        }
    }
}
