using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class AdminViewProductsController : Controller
    {
        // GET: ViewAllProductsForAdmin
        [Route("ViewProducts")]
        public ActionResult ViewProducts()
        {
            return View();
        }
    }
}