using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using WebProject.Models; // Импорт модели Product
using WebProject.Models.Account;
using WebProject.Models.AddToCart;
using WebProject.Models.Order;
using WebProject.Models.Products;



namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        static public bool IsAuthorized { get; set; }
        static public bool IsAdmin { get; set; }

        // GET: Home
        public ActionResult Index() => View(Check.GetProducts());
        public ActionResult ThanksForOrder() => View();
        public ActionResult Error() => View();
    }
}
