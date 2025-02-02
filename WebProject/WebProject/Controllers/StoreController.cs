using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class StoreController : Controller
    {
        // CRUD Operations for Products
        [HttpGet]
        public ActionResult Product() => View();
        
        [HttpGet]
        //int page = 0
        public ActionResult Products() => View();
        
        [HttpPost]  
        public ActionResult AddProduct() => RedirectToAction("Products");
        
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