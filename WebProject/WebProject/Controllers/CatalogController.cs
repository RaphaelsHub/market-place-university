using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class CatalogController : Controller
    {
        // GET: Categories
        public ActionResult Items()
        {
            return View();
        }

        // GET: Product
        public ActionResult Item(int? id)
        {
            if (id.HasValue)
            {
                var product = new HomeController().GetProducts();
                return View(product[id.Value - 1]); // Временный пример вывода ID
            }
            else
            {
                // Если id не указан, выполнить редирект
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public ActionResult AddToCart(CartItem cartItem)
        {
            TempData["Message"] = "Was added successfully";
            return RedirectToAction("Item", new { id = cartItem.Id });
        }
    }

}