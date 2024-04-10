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
        readonly BusinessLogic.BusinessLogic businessLogic = new BusinessLogic.BusinessLogic();

        // GET: Cart
        public ActionResult Buy()
        {
            if (Session["UserData"] != null)
                return View((UserData)Session["UserData"]);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult MakeAnOrder()
        {
            if (Session["UserData"] != null)
                return View();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Delivery()
        {
            if (Session["UserData"] != null)
                return View((UserData)Session["UserData"]);
            return RedirectToAction("Index", "Home");
        }


        //в бизнес ложик обмен данными
        [HttpPost]
        public ActionResult AddToCart(CartItem cartItem)
        {
            if (Session["UserData"] == null)
                return RedirectToAction("Login","Account");

            cartItem.Id_User = ((UserData)Session["UserData"]).IdUser;

            businessLogic.UserBL.AddToCart(cartItem);

            TempData["Message"] = "Was added successfully";

            return RedirectToAction("Item", "Catalog", new { id = cartItem.Id });
        }

        [HttpPost]
        public ActionResult MakeAnOrder(OrderInfo orderInfo, CardCreditionals cardCreditinals)
        {
            if (Session["UserData"] == null)
                return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                OrderModel orderModel = new OrderModel(orderInfo, cardCreditinals);

                businessLogic.UserBL.ProcessOrder(orderModel);

                return RedirectToAction("ThanksForOrder", "Home");
            }
            return View(new OrderModel(orderInfo, cardCreditinals));
        }

        [HttpPost]
        public ActionResult DeleteCartItem(CartItem cartItem)
        {
            if (Session["UserData"] == null)
                return RedirectToAction("Index", "Home");

            businessLogic.UserBL.DeleteFromCart(cartItem);
            return RedirectToAction("Buy", "Cart");
        }
    }
}