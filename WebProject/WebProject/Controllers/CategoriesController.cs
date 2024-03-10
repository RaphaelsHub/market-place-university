using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Items()
        {
            return View();
        }
    }
}