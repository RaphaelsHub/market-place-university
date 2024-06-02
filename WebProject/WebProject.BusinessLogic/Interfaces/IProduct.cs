using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.ModelAccessLayer.Model;
using WebProject.Domain.Enum;

namespace WebProject.BusinessLogic.Interfaces
{
    public interface IProduct
    {
        Product GetProductById(int id);
        List<Category> GetCategoriesView();
        List<Product> GetAllProducts();
        List<Product> GetProductsByName(string textSearch);
        Category GetCategoriesCatalog(int idChildCategory);
        Category GetCategoriesCatalog(int idChildCategory, SortBy sortBy);
    }
}
