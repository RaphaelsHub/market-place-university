using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public ActionResult GetOrderForm() => View();
        
        [HttpPost]
        public ActionResult SendOrderForm() =>RedirectToAction("Thanks","Home");
        
        [HttpGet]
        public ActionResult GetOrderInfo(int idOrder) => View();
        
        [HttpPatch]
        public ActionResult UserUpdateOrderInfo(int idOrder) => RedirectToAction("Orders");
        
        [HttpPatch]
        public ActionResult AdminUpdateOrderInfo(int idOrder) => RedirectToAction("Orders");
        
        [HttpGet]
        public ActionResult UserGetOrders() => View();
        
        [HttpGet]
        public ActionResult AdminGetOrders() => View();
        
        [HttpDelete]
        public ActionResult DeleteOrder(int idOrder) => RedirectToAction("Orders");
    }
}