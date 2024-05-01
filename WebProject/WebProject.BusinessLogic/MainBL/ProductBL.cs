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
//using WebProject.ModelAccessLayer.Model;

namespace WebProject.BusinessLogic.MainBL
{
    public class ProductBL : ProductAPI, IProduct
    {
        public ProductBL()
        {
        }
        public AllProducts GetAllProducts()
        {
            AllProducts allProducts = null;

            return allProducts;
        }
        public Product GetProductById(int id)
        {
            //FIndProduct
            Product product = null;
            return product;
        }
        public AllProducts GetProductByName(string text_search)
        {
            AllProducts product = null;

            return product;
        }
        public AllCategories GetCategoriesView()
        {
            AllCategories categories = null;
            // для view мне нужны только дети и родитель с именем и продуктами 
            // иннициализировать только имена и id их, если что можем именами оперировать вдруг у вас не получится
            return categories;
        }
        public Category GetCategoriesCatalog(int idChildCategory)
        {
            Category category = null;

            return category;
        }
        public Category GetCategoriesCatalog(int idChildCategory, SortBy sortBy)
        {
            Category category = null;

            return category;
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
    
    }
}
