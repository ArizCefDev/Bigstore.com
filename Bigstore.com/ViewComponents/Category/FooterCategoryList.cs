using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Bigstore.com.ViewComponents.Category
{
    public class FooterCategoryList : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public FooterCategoryList(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryService.GetAll();
            return View(values);
        }
    }
}
