using System.Threading.Tasks;
using System.Web.Mvc;
using ECommerce.App.Interfaces.User;
using ECommerce.Core.Enums.Order;
using ECommerce.Core.Enums.Request;
using ECommerce.Core.Models.DTOs.Order;
using ECommerce.Core.Models.ViewModels;

namespace ECommerce.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var response =await _orderService.GetOrdersAsync(null, OrderStatus.Pending, 1, 10);
            return View(response.Data);
        }

        [HttpGet]
        public async Task<ActionResult> OrderDetails(int id)
        {
            var response =await _orderService.GetOrderAsync(id);
            return View(response.Data);
        }
        
        [HttpGet] 
        public ActionResult OrderDataForm() => View();
        
        [HttpPost] 
        public async Task<ActionResult> SaveDataOrder(OrderDataDto orderDto)
        {
            if (!ModelState.IsValid)
            {
                return View("OrderDataForm", orderDto); 
            }

            var response = await _orderService.CreateOrderAsync(orderDto);
            
            if (response.Status == OperationStatus.Error)
            {
                TempData["MessageResponse"] = new ConfirmationViewModel(OperationStatus.Error, response.Message);
                return View("OrderDataForm", orderDto);
            }
            
            TempData["MessageResponse"] = new ConfirmationViewModel(OperationStatus.Success, "Order has been successfully sent! Soon we will get in touch with you!");
    
            return RedirectToAction("Confirmation","Home");
        }
    }
}