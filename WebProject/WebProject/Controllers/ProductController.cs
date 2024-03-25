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
        [HttpPost]
        public ActionResult Item(Product product)
        {
            return View(product);
        }
        
        public ActionResult AddToCart(CartItem cartItem)
        {
            CartData cartData = new CartData();
            cartData.Items.Add(cartItem);

            return RedirectToAction("Buy", "Cart");
        }
    }
}