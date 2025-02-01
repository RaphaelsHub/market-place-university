using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class CartController : BaseController
    {
        [HttpGet]
        public ActionResult Index() => View();
        
        [HttpPatch]
        public ActionResult IncreaseQuantity(int id) => RedirectToAction("Index");
        
        [HttpPatch]
        public ActionResult DecreaseQuantity(int id) => RedirectToAction("Index");
        
        [HttpPost]
        public ActionResult AddItem(int id) => RedirectToAction("Index");
        
        [HttpDelete]
        public ActionResult RemoveItem(int id) => RedirectToAction("Index");

        [HttpPost]
        public ActionResult PromoCode(string code) => RedirectToAction("Index");
        
        [HttpPost]
        [Authorize]
        public ActionResult Index1(int userId) => View();
    }
}