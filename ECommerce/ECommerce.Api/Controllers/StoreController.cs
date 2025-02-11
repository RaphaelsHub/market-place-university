using System.Web.Mvc;
using ECommerce.App.Interfaces.Product;
using ECommerce.Core.DataTransferObjects;

namespace ECommerce.Controllers
{
    public class StoreController : Controller
    {
        private readonly IProductService _storeService;

        public StoreController(IProductService storeService)
        {
            _storeService = storeService;
        }


        [HttpGet] public ActionResult Product(int? id)
        {
            if (id == null)
                return RedirectToAction("Products");
            
            var product = _storeService.GetProductAsync(id.Value);
            
            return View(product);
        }

        [HttpGet] public ActionResult Products(int page = 1) => View(_storeService.GetProductsAsync(1, page).Result.Data);
        
        [HttpPost] public ActionResult AddProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return View(productDto);

            var response = _storeService.CreateProductAsync(productDto);
            

            
            return RedirectToAction("Products",response.Result.Data);
        }
        
        [HttpPatch]
        public ActionResult UpdateProduct() => RedirectToAction("Products");
        
        [HttpDelete]
        public ActionResult DeleteProduct() => RedirectToAction("Products");
        
        
        // Find Product by name and Id
        [HttpGet]
        public ActionResult FindProductById(int id) => RedirectToAction("Product", new object());
        
        [HttpGet]
        public ActionResult FindProductByName(string name) => RedirectToAction("Product", new object());
        
        
        // Sort Products by Category and typeSearch
        [HttpGet]
        public ActionResult SortByCategory(string category) => RedirectToAction("Products", category);
        
        [HttpGet]
        public ActionResult SortBy(string sort)
        {
            return RedirectToAction("Products", "Store", sort);
        }
    }
}