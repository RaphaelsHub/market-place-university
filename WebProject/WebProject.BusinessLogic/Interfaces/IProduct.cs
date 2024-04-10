using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.ModelAccessLayer.Model;
using WebProject.Domain.Enum;

namespace WebProject.BusinessLogic.Interfaces
{
    internal interface IProduct
    {
        AllProducts GetAllProducts();
        Product GetProductById(int id);
        AllProducts GetProductByName(string text_search);
        AllCategories GetCategoriesView();
        Category GetCategoriesCatalog(int idChildCategory);
        Category GetCategoriesCatalog(int idChildCategory, SortBy sortBy);
    }
}
