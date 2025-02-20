using System.Web.Mvc;
using ECommerce.Core.Enums.Message;
using ECommerce.Core.Models.DTOs.Order;
using ECommerce.Core.Models.ViewModels;

namespace ECommerce.Controllers
{
    public class OrdersController : Controller
    {
        [HttpGet] public ActionResult Index() => View();
        [HttpGet] public ActionResult OrderDetails(int id) => View();
        [HttpGet] public ActionResult OrderDataForm() => View(new OrderDataDto());
        [HttpPost] public ActionResult SaveDataOrder(OrderDataDto orderDto)
        {
            if (!ModelState.IsValid)
            {
                return View("OrderDataForm", orderDto); 
            }

            TempData["MessageResponse"] = new MessageViewModel(1, "Order has been successfully sent! Soon we will get in touch with you!", RequestStatus.Success);
    
            return RedirectToAction("Confirmation","Home");
        }
        [HttpPost] public ActionResult UpdateDataOrder(int idOrder) => RedirectToAction("Orders");
    }
}