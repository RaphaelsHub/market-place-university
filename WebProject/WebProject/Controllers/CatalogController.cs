using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.ModelAccessLayer.Model;


namespace WebProject.Controllers
{
    public class CatalogController : Controller
    {
        Product product=null;
        // GET: Catalog
        public ActionResult Items()=>View();
        public ActionResult Item(int? id)
        {
            if(id.HasValue)
            {
                Product product = AccountController.guest.GetProductById(id.Value);
                return View(product);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}