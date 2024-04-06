using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.BusinessLogic.MainBL;
using WebProject.ModelAccessLayer.Model;


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
            if (ModelState.IsValid)
            {
                AccountController.admin.AddProduct(product);

                return RedirectToAction("Index", "Home");
            }
            else
                return View(product);
        }

        public ActionResult ViewProducts()
        {
            UserData userData = new UserData();
            userData.ProductsAdmin = AccountController.admin.GetAllProducts();

            return View(userData);
        }

        public ActionResult ViewDelivery()
        {
            UserData userData = new UserData();
            userData.ProductsAdmin = AccountController.admin.GetAllProducts();

            return View(userData);
        }

        public ActionResult DeleteProduct()
        {
            return View();
        }
    }
}