using System.Web.Mvc;
using WebProject.ModelAccessLayer.Model;




namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        readonly BusinessLogic.BusinessLogic _businessLogic = new BusinessLogic.BusinessLogic();

        public static AllCategories AllCategories { get; private set; }

        // GET: Home
        public ActionResult ThanksForOrder() => View();
        public ActionResult Error() => View();
        public ActionResult Error404() => View();
        public ActionResult Index()
        {
            AllCategories = _businessLogic.ProductBL.GetCategoriesView();

            return View(_businessLogic.ProductBL.GetAllProducts());
        }
        public ActionResult Search(string text)
        {
            AllProducts searchResults = _businessLogic.ProductBL.GetProductByName(text);

            return (text == null) ? View(searchResults) : View(_businessLogic.ProductBL.GetProductByName(text));
        }
    }
}

