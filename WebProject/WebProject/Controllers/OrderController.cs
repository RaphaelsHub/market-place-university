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
            if (ModelState.IsValid)
            {
                OrderModel orderModel = new OrderModel(orderInfo, cardCreditinals);

                // Здесь можно выполнить дополнительные операции, связанные с обработкой заказа 



                return RedirectToAction("ThanksForOrder", "Home");
            }
    
            return View(new OrderModel(orderInfo, cardCreditinals));
        }

    }
}
