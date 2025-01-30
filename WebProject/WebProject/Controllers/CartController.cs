using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class CartController : BaseController
    {
        [HttpGet]
        public ActionResult ViewCart() => View();
        
        [HttpPatch]
        public ActionResult IncreaseQuantity(int id) => RedirectToAction("CartView");
        
        [HttpPatch]
        public ActionResult DecreaseQuantity(int id) => RedirectToAction("CartView");
        
        [HttpPost]
        public ActionResult AddItem(int id) => RedirectToAction("CartView");
        
        [HttpDelete]
        public ActionResult RemoveItem(int id) => RedirectToAction("CartView");

        [HttpPost]
        public ActionResult PromoCode(string code) => RedirectToAction("CartView");
        
        [HttpGet]
        [Authorize]
        public ActionResult Cart(int userId) => View();
    }
}