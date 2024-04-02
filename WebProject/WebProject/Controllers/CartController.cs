using System.Net.NetworkInformation;
using System.Reflection;
using System.Web.Mvc;
using WebProject.Models.Account;
using WebProject.Models.AddToCart;
using WebProject.Models.Order;
using WebProject.Models.Products;



namespace WebProject.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Buy()
        {
            return View(Check.ReturnUserData());
        }

        public ActionResult Delivery()
        {
            return View(Check.ReturDel());
        }

        [HttpPost]
        public ActionResult AddToCart(CartItem cartItem)
        {
            TempData["Message"] = "Was added successfully";
            Check.AddNewToCart(cartItem);
            return RedirectToAction("Item", "Catalog", new { id = cartItem.Id });
        }

        // GET: Order
        public ActionResult MakeAnOrder()
        {
            var user = Check.ReturnUserData();
            if (user.Cart_User != null && user.Cart_User.productList != null && user.Cart_User.productList.Count != 0)
                return View();
            else
                return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public ActionResult MakeAnOrder(OrderInfo orderInfo, CardCreditinals cardCreditinals)
        {
            if (ModelState.IsValid)
            {
                OrderModel orderModel = new OrderModel(orderInfo, cardCreditinals);

                Check.AddDel(orderModel);

                return RedirectToAction("ThanksForOrder", "Home");
            }

            return View(new OrderModel(orderInfo, cardCreditinals));
        }
    }
}