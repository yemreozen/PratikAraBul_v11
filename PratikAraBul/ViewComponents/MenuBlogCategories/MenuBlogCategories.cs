using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PratikAraBul.ViewComponents.MenuBlogCategories
{
    public class MenuBlogCategories:ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());   
        public IViewComponentResult Invoke()
        {
            var values = cm.GetAllCategories();
            return View(values);
        }
    }
}
