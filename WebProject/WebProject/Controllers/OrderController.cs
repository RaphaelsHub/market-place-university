using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult MakeAnOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MakeAnOrder(OrderInfo orderInfo, CardCreditinals cardCreditinals)
        {
            OrderModel orderModel = new OrderModel(orderInfo, cardCreditinals);
            // Заказ валидация
            // Обработка заказа...


            return RedirectToAction("Index", "Home");
        }
    }
}