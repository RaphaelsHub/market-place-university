using System.Web.Mvc;
using ECommerce.Core.DataTransferObjects.Responses;
using ECommerce.Core.DataTransferObjects.User;
using ECommerce.Core.Enums.Operation;

namespace ECommerce.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public ActionResult GetOrderForm() => View();
        

        [HttpPost]
        public ActionResult SendOrderForm(OrderDto orderDto)
        {
            if (!ModelState.IsValid)
            {
                return View("GetOrderForm", orderDto); 
            }

            TempData["MessageResponse"] = new MessageResponseDto(1, "Order has been successfully sent! Soon we will get in touch with you!", RequestStatus.Success);
    
            return RedirectToAction("Confirmation","Home");
        }


        
        [HttpGet]
        public ActionResult GetOrderInfo(int idOrder) => View();
        
        [HttpPatch]
        public ActionResult UserUpdateOrderInfo(int idOrder) => RedirectToAction("Orders");
        
        [HttpPatch]
        public ActionResult AdminUpdateOrderInfo(int idOrder) => RedirectToAction("Orders");
        
        [HttpGet]
        public ActionResult UserGetOrders() => View();
        
        [HttpGet]
        public ActionResult AdminGetOrders() => View();
        
        [HttpDelete]
        public ActionResult DeleteOrder(int idOrder) => RedirectToAction("Orders");
    }
}