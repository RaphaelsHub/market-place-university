using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class StoreController : Controller
    {
        // CRUD Operations for Products
        [HttpGet]
        public ActionResult Product() => View();
        
        [HttpGet]
        public ActionResult Product(object obj) => View();
        
        [HttpGet]
        public ActionResult Products(int page = 0) => View();
        
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