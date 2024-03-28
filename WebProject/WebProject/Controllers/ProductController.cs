using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Item(int id)
        {
            var product = new HomeController().GetProducts();
            return View(product[id-1]); // Временный пример вывода ID
        }


        [HttpPost]
        public ActionResult AddToCart(CartItem cartItem)
        {
            TempData["Message"] = "Was added successfully";
            return RedirectToAction("Item", new { id = cartItem.Id});
        }
    }
}