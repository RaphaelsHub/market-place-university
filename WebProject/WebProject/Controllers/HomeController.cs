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
        static public bool IsAuthorized { get; set; }
        static public bool IsAdmin { get; set; }
        static public AllCategories allCategories { get; set; }
        // GET: Home
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
            if (text == null)
            {
                return View(searchResults);
            }
            searchResults = AccountController.guest.GetProductByName(text);

            return View(searchResults);
        }
        public ActionResult ThanksForOrder() => View();
        public ActionResult Error() => View();
        public ActionResult Error404() => View();
    }
}
