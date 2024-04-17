using System.Web.Mvc;
using WebProject.ModelAccessLayer.Model;


namespace WebProject.Controllers
{
    public class CatalogController : Controller
    {
        readonly BusinessLogic.BusinessLogic _businessLogic = new BusinessLogic.BusinessLogic();

        // GET: Catalog
        public ActionResult Items(int? idChildCategory)
        {
            if (idChildCategory.HasValue)
            {
                Category category = _businessLogic.ProductBL.GetCategoriesCatalog(idChildCategory.Value); 
                return View(category);
            }
            else
            {
                return RedirectToAction("Error404", "Home");
            }
        }
        public ActionResult Item(int? id)
        {
            if (id.HasValue)
            {
                Product product = _businessLogic.ProductBL.GetProductById(id.Value);
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