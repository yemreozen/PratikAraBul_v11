using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PratikAraBul.ViewComponents.Category
{
    public class CategoryHeader : ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = cm.GetCategoryById(id);
            if(values != null)
            {
                ViewBag.categoryName = values.CategoryName;
            }
            return View(values);
        }   
    }
}
