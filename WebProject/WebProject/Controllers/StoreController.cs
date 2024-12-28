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
        [HttpGet]
        public ActionResult AllProducts()
        {
            return View();
        }

        public ActionResult AllProducts(string search)
        {
            return View();
        }

        public ActionResult Search(string search)
        {
            return RedirectToAction("AllProducts", search);
        }
        
        public ActionResult SortBy(string sort)
        {
            return RedirectToAction("AllProducts", "Store", sort);
        }
    }
}