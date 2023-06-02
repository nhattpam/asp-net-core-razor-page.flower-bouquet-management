using BusinessObjects.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CategoryRepo
{
    public class CategoryRepository: ICategoryRepository
    {
        public IEnumerable<Category> GetCategoryList()
        {
            return CategoryDAO.Instance.GetCategoryList();
        }
        public Category GetCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(string categoryName)
        {
            return CategoryDAO.Instance.GetCategory(categoryName);
        }
    }
}
