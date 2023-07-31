using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PratikAraBul.ViewComponents.Category
{
    public class CategoryListByFooter:ViewComponent
    {

        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var values = cm.GetAllCategories();
            return View(values);
        }
    }
}
