using System.Web.Mvc;
using WebProject.ModelAccessLayer.Model;
using WebProject.Domain.Enum;
using WebProject.BusinessLogic.Interfaces;


namespace WebProject.Controllers
{
    public class CartController : BaseController
    {
        // GET: Cart
        public ActionResult Buy()
        {
            if (Session["UserData"] != null && _businessLogic.User is IRegistered)
            {
                (Session["UserData"] as UserData).CartData = ((IRegistered)_businessLogic.User).ViewCart(((UserData)Session["UserData"]).IdUser);
                return View((Session["UserData"] as UserData).CartData);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult MakeAnOrder()
        {
            if (Session["UserData"] != null && _businessLogic.User is IRegistered)
                return View();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delivery()
        {
            if (Session["UserData"] != null && _businessLogic.User is IRegistered)
            {
                (Session["UserData"] as UserData).AllOrders = ((IRegistered)_businessLogic.User).ViewOrders(((UserData)Session["UserData"]).IdUser);
                return View((Session["UserData"] as UserData).AllOrders);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult AddToCart(CartItem cartItem)
        {
            if (Session["UserData"] == null || _businessLogic is IGuest)
                return RedirectToAction("Login", "Account");

            if (_businessLogic.User is IRegistered registred)
            {
                cartItem.Id_User = ((UserData)Session["UserData"]).IdUser;

                bool WasAdded = registred.AddToCart(cartItem);

                TempData["Message"] = !WasAdded ? "Some Error" : "Was added successfully";
            }
            return RedirectToAction("Item", "Catalog", new { id = cartItem.Id });
        }

        [HttpPost]
        public ActionResult MakeAnOrder(OrderInfo orderInfo)
        {
            if (Session["UserData"] == null || _businessLogic.User is IGuest)
                return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                OrderModel orderModel = new OrderModel(orderInfo);

                bool WasAdded = (_businessLogic.User as IRegistered).ProcessOrder(orderModel);

                return WasAdded ? RedirectToAction("ThanksForOrder", "Home") : RedirectToAction("Error404", "Home");
            }

            return View(orderInfo);
        }

        [HttpPost]
        public ActionResult DeleteCartItem(CartItem cartItem)
        {
            if (Session["UserData"] == null || _businessLogic.User is IGuest)
                return RedirectToAction("Index", "Home");

            ((IRegistered)_businessLogic.User).DeleteFromCart(cartItem);

            return RedirectToAction("Buy", "Cart");
        }
    }
}