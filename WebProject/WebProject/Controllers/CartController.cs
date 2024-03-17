using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Buy()
        {
            return View();
        }
    }
}