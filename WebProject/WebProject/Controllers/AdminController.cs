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
        
        [HttpPost]
        public ActionResult EditProduct(int id)
        {
            Product editProduct =  AccountController.guest.GetProductById(id);

            return View(editProduct);
        }

        [HttpPost]
        public ActionResult ReplaceProduct(Product product) 
        {
            if (ModelState.IsValid)
            {
                AccountController.admin.EditProduct(product);

                return RedirectToAction("ViewProducts", "Admin");
            }
            else
                return RedirectToAction("EditProduct","Admin",product.Id);
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            AccountController.admin.DeleteProduct(id);
            return RedirectToAction("ViewProducts", "Admin");
        }
        
        [HttpPost]
        public ActionResult DeleteDelivery(int id)
        {
            AccountController.admin.DeleteOrderModel(id);   
            return RedirectToAction("ViewDelivery","Admin");
        }
    }
}