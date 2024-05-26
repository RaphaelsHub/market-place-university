using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.BusinessLogic.Interfaces;
using WebProject.Domain.Enum;
using WebProject.ModelAccessLayer.Model;
using WebProject.BusinessLogic.Core.Levels;
using WebProject.Domain.Entities.User;
using WebProject.Domain.Entities.DBModels;
using System.Collections;
//using WebProject.ModelAccessLayer.Model;

namespace WebProject.BusinessLogic.MainBL
{
    public class ProductBL : ProductAPI, IProduct
    {
        //public ProductBL() { }
        public new AllProducts GetAllProducts()
        {
            var AllProductsResponse = base.GetAllProducts();
            if (AllProductsResponse.IsExist == false)
            { 
                return null; 
            }

            return ConvertAllProducts(AllProductsResponse.Data);
        }
        public Product GetProductById(int id)
        {
            var responseProd = GetSingleProductData(id);
            if (responseProd.IsExist == false)
            {
                return null;
            }

            return ConvertProduct(responseProd.Data);
        }
        public AllProducts GetProductByName(string text_search)
        {
            var AllProductsResponse = base.GetProductsByName(text_search);
            if (AllProductsResponse.IsExist == false)
            {
                return null;
            }

            return ConvertAllProducts(AllProductsResponse.Data);
        }
        public AllCategories GetCategoriesView()
        {
            var baseCategory = GetBaseCategory();
            return null;
            //return ConvertAllCategories(baseCategory.Data.ChildCategories); //all base.ChildCategories -> real basic Categories
        }
        public Category GetCategoriesCatalog(int idChildCategory)
        {
            var categoryResponse = GetCategoryById(idChildCategory);
            if (categoryResponse.IsExist == false) // если категории не существует
            {
                return null;
            }

            var productsResponse = GetProductsByCategory(categoryResponse.Data);
            var category = ConvertCategory(categoryResponse.Data);

            if (productsResponse.IsExist == true) // если у категории есть продукты
            {
                var productList = ConvertAllProducts(productsResponse.Data);
                category.Products = productList.Products;
            }

            return category;
        }
        public Category GetCategoriesCatalog(int idChildCategory, SortBy sortBy)
        {
            var unsortedCategory = GetCategoriesCatalog(idChildCategory);
            switch (sortBy)
            {
                case SortBy.Low:
                    unsortedCategory.Products.Sort((x, y) => x.Price.CompareTo(y.Price));
                    break;
                case SortBy.High:
                    unsortedCategory.Products.Sort((x, y) => y.Price.CompareTo(x.Price));
                    break;
                case SortBy.AZ :
                    unsortedCategory.Products.Sort((x, y) => x.Name.CompareTo(y.Name));
                    break;
                case SortBy.ZA :
                    unsortedCategory.Products.Sort((x, y) => y.Name.CompareTo(x.Name));
                    break;
                case SortBy.None: break;
            }
            unsortedCategory.SortBy = sortBy;
            return unsortedCategory;
        }
        
        //Convert metods
        static private Product ConvertProduct(ProductDataEF data)
        {
            return new Product
            {
                Id = data.Id,
                Name = data.Name,
                Details = data.Details,
                filter = null, // По вопросам к Саше или Ивану
                ShortDescription = data.ShortDescription,
                FullDescription = data.FullDescription,
                PhotoUrl = data.GetPhotos(),
                Price = data.Price,
                Amount = data.Amount
            };
        }
        
        static private AllProducts ConvertAllProducts(List<ProductDataEF> listData)
        {
            var allProductList = new List<Product>();
            foreach(ProductDataEF productData in listData)
            {
                allProductList.Add(ConvertProduct(productData));
            }

            return new AllProducts { Products = allProductList };
        }

        static private Category ConvertCategory(CategoryTypeEF data) 
        {
            var prods = new List<Product>(); // По вопросам к Ивану
            var filters = new List<Feature>(); // По вопросам к Саше или Ивану
            var childrens = new List<Category>();

            if (data.ChildCategories != null)
                foreach (CategoryTypeEF child in data.ChildCategories)
                {
                    childrens.Add(ConvertCategory(child)); // рекурсивное чудо юдо (при очень большой бд ебанёт)
                }

            return new Category
            {
                IdCategory = data.CategoryTypeId,
                Name = data.CategoryName,
                Subcategories = childrens,
                Products = prods,
                Filters = filters
            };
        }

        static private AllCategories ConvertAllCategories(ICollection<CategoryTypeEF> categories) 
        {
            var allCategories = new List<Category>();
            foreach (CategoryTypeEF category in categories)
            {
                allCategories.Add(ConvertCategory(category));
            }
            return new AllCategories { Categories = allCategories };    
        }
    }
}
