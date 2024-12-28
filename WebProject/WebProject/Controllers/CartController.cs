using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class CartController : BaseController
    {
        [HttpGet]
        public ActionResult CartView() => View();

        [HttpPost]
        public ActionResult RemoveItem(int id) => RedirectToAction("CartView");

        [HttpPost]
        public ActionResult PromoCode(string code) => RedirectToAction("CartView");
    }
}