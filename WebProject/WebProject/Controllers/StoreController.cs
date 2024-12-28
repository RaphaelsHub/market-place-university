using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class StoreController : Controller
    {
        public ActionResult SingleProduct()
        {
            return View();
        }

        // GET: Store
        public ActionResult AllProducts()
        {
            return View();
        }
    }
}