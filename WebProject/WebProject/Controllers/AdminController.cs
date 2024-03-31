using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminAddProduct
        public ActionResult NewProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(Product product)
        {
            bool d = ModelState.IsValid;

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(product);
  
        }

        public ActionResult ViewProducts()
        {
            return View();
        }

        public ActionResult EditDelivery()
        {
            return View();
        }
    }
}