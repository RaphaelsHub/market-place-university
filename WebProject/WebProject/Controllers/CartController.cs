using System.Net.NetworkInformation;
using System.Reflection;
using System.Web.Mvc;
using WebProject.ModelAccessLayer.Model;
using WebProject.Domain.Enum;
using WebProject.BusinessLogic.Interfaces;
using WebProject.BusinessLogic.MainBL;




namespace WebProject.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Buy()
        {
            CartData cartData = null;

            AccountController.user.ViewCart();
            
            return View(cartData);
        }

        public ActionResult Delivery()
        {
            AllDeliveries allDeliveries = null;

            allDeliveries = AccountController.user.ViewOrders();

            return View(allDeliveries);
        }

        [HttpPost]
        public ActionResult AddToCart(CartItem cartItem)
        {
            TempData["Message"] = "Was added successfully";

            AccountController.user.AddToCart(cartItem);

            return RedirectToAction("Item", "Catalog", new { id = cartItem.Id });
        }

        // GET: Order
        public ActionResult MakeAnOrder() => View();

        [HttpPost]
        public ActionResult MakeAnOrder(OrderInfo orderInfo, CardCreditionals cardCreditinals)
        {
            if (ModelState.IsValid)
            {
                OrderModel orderModel = new OrderModel(orderInfo, cardCreditinals);

                AccountController.user.ProcessOrder(orderModel);

                return RedirectToAction("ThanksForOrder", "Home");
            }
            return View(new OrderModel(orderInfo, cardCreditinals));
        }
    }
}