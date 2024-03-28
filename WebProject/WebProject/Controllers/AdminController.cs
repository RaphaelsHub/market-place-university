using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }

        public ActionResult EditDelivery()
        {
            return View();
        }
    }
}