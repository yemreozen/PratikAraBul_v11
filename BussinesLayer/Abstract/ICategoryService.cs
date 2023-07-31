using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        void CategoryDelete(Category category);
        void CategoryUpdate(Category category);
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        Category GetListCategoryByBlogId(int id);
    }
}
