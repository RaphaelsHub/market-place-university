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
        // GET: Catalog
        [AllowAnonymous]
        public ActionResult Items(int? idChildCategory)
        {
            if (idChildCategory.HasValue)
            {
                Category category = AccountController.guest.GetCategoriesCatalog(idChildCategory.Value);
                return View(category);
            }
            else
            {
                return RedirectToAction("Error404", "Home");
            }
        }
        [AllowAnonymous]
        public ActionResult Item(int? id)
        {
            if (id.HasValue)
            {
                Product product = AccountController.guest.GetProductById(id.Value);
                if (product != null)
                    return View(product);
                else
                    return RedirectToAction("Error", "Home");
            }
            else
            {
                return RedirectToAction("Error404", "Home");
            }
        }
    }
}