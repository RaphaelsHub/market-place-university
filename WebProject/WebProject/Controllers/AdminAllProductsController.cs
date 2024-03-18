using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class AdminAllProductsController : Controller
    {
        // GET: AdminAllProducts
        public ActionResult ViewProducts()
        {
            return View();
        }
    }
}