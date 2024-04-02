using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;
using WebProject.Models.Account;
using WebProject.Models.AddToCart;
using WebProject.Models.Order;
using WebProject.Models.Products;

namespace WebProject.Controllers
{
    public class CatalogController : Controller
    {
        // GET: Catalog
        public ActionResult Items()=>View();
        public ActionResult Item(int? id) => id.HasValue ? View(Check.FindProduct(id)) : (ActionResult)RedirectToAction("Error", "Home");
    }
}