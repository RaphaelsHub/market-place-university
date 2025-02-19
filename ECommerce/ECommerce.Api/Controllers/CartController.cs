using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class CartController : BaseController
    {
        [HttpGet] public ActionResult Index() => View();
        
        [HttpPost] public ActionResult IncreaseQuantity(int idProduct) => RedirectToAction("Index");
        
        [HttpPost] public ActionResult DecreaseQuantity(int idProduct) => RedirectToAction("Index");
        
        [HttpPost] public ActionResult AddItem(int idProduct) => RedirectToAction("Index");
        
        [HttpPost] public ActionResult RemoveItem(int idProduct) => RedirectToAction("Index");
    }
}