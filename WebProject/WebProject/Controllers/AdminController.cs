using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.BusinessLogic.MainBL;
using WebProject.Domain.Enum;
using WebProject.ModelAccessLayer.Model;


namespace WebProject.Controllers
{
    public class AdminController : Controller
    {
        readonly BusinessLogic.BusinessLogic businessLogic = new BusinessLogic.BusinessLogic();
        // GET: AdminAddProduct
        public ActionResult NewProduct()
        {
            if (Session["UserData"] != null && ((UserData)Session["UserData"]).StatusUser == StatusUser.Admin)
                return View();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ViewProducts()
        {
            if (Session["UserData"] != null && ((UserData)Session["UserData"]).StatusUser == StatusUser.Admin)
            {
                ((UserData)Session["UserData"]).ProductsAdmin = businessLogic.AdminBL.GetAllProducts();
                return View((UserData)Session["UserData"]);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ViewDelivery()
        {
            if (Session["UserData"] != null && ((UserData)Session["UserData"]).StatusUser == StatusUser.Admin)
            {
                ((UserData)Session["UserData"]).DeliveriesUser = businessLogic.AdminBL.GetAllActiveOrder();
                
                return View((UserData)Session["UserData"]);
            }
            return RedirectToAction("Index", "Home");
        }


        //в бизнес ложик обмен данными
        [HttpPost]
        public ActionResult NewProduct(Product product)
        {
            if (Session["UserData"] == null || ((UserData)Session["UserData"]).StatusUser != StatusUser.Admin)
                return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                businessLogic.AdminBL.AddProduct(product);

                return RedirectToAction("Index", "Home");
            }
            else
                return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(int id)
        {
            if (Session["UserData"] == null || ((UserData)Session["UserData"]).StatusUser != StatusUser.Admin)
                return RedirectToAction("Index", "Home");

            return View(businessLogic.ProductBL.GetProductById(id));
        }

        [HttpPost]
        public ActionResult ReplaceProduct(Product product)
        {
            if (Session["UserData"] == null || ((UserData)Session["UserData"]).StatusUser != StatusUser.Admin)
                return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                businessLogic.AdminBL.EditProduct(product);

                return RedirectToAction("ViewProducts", "Admin");
            }
            else
                return RedirectToAction("EditProduct", "Admin", product.Id);
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            if (Session["UserData"] == null || ((UserData)Session["UserData"]).StatusUser != StatusUser.Admin)
                return RedirectToAction("Index", "Home");

            businessLogic.AdminBL.DeleteProduct(id);

            return RedirectToAction("ViewProducts", "Admin");
        }

        [HttpPost]
        public ActionResult DeleteDelivery(int id)
        {
            if (Session["UserData"] == null || ((UserData)Session["UserData"]).StatusUser != StatusUser.Admin)
                return RedirectToAction("Index", "Home");

            businessLogic.AdminBL.DeleteOrderModel(id);
            return RedirectToAction("ViewDelivery", "Admin");
        }
    }
}