using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models.Account;
using WebProject.Models.AddToCart;
using WebProject.Models.Order;
using WebProject.Models.Products;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class AdminController : Controller
    {
        UserData userData = new UserData();
        // GET: AdminAddProduct
        public ActionResult NewProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(Product product)
        {
            return ModelState.IsValid ? (ActionResult)RedirectToAction("Index", "Home") : View(product);
        }

        public ActionResult ViewProducts()
        {
            return View(userData);
        }

        public ActionResult EditDelivery()
        {
            return View(userData);
        }
    }
}