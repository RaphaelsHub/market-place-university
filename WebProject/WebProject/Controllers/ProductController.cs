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
        /*
        public ActionResult Item()
        {
            return RedirectToAction("Index","Home");
        }
        */

        // GET: Product
        public ActionResult Item(int id)
        {
            // Здесь вы можете использовать переданный ID продукта для получения информации из базы данных или других источников
            // Например:
            // Product product = productService.GetProductById(id);
            // return View(product);

            var product = new HomeController().GetProducts();
            return View(product[id-1]); // Временный пример вывода ID
        }


        [HttpPost]
        public ActionResult AddToCart(CartItem cartItem)
        {
            //Логика по передачи cartItem в domain для добавления в корзину

            TempData["Message"] = "Was added successfully";
            return RedirectToAction("Item", new { id = cartItem.Id});
        }
    }
}