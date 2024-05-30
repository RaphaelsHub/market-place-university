using System.Runtime.Remoting.Contexts;
using System.Web.Mvc;
using WebProject.ModelAccessLayer.Model;
using WebProject.Domain.Entities;
using WebProject.Domain.Entities.User;
using System;
using WebProject.Domain;
using System.Linq;




namespace WebProject.Controllers
{
    public class HomeController : BaseController
    {
        public static AllCategories AllCategories { get; private set; }

        // GET: Home
        public ActionResult ThanksForOrder() => View();

        public ActionResult Error() => View();

        public ActionResult Error404() => View();

        public ActionResult Index()
        {
            AllCategories = _businessLogic.User.GetCategoriesView();
            return View(_businessLogic.User.GetAllProducts());
        }

        public ActionResult Search(string text)
        {
            AllProducts allProducts = null;

            return (text == null) ? View(allProducts) : View(_businessLogic.User.GetProductByName(text));
        }
    }
}

