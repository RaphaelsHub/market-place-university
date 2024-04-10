using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using WebProject.BusinessLogic.Interfaces;
using WebProject.BusinessLogic.MainBL;
using WebProject.ModelAccessLayer.Model;




namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        static public AllCategories allCategories { get; set; }

        // GET: Home
        public ActionResult ThanksForOrder() => View();
        public ActionResult Error() => View();
        public ActionResult Error404() => View();
        public ActionResult Index()
        {
            AccountController account = new AccountController();
            AllProducts allProducts = AccountController.guest.GetAllProducts();
            allCategories = AccountController.guest.GetCategoriesView();

            return View(allProducts);
        }
        public ActionResult Search(string text)
        {
            AllProducts searchResults = null;

            return (text == null) ? View(searchResults) : View(AccountController.guest.GetProductByName(text));
        }
    }
}

