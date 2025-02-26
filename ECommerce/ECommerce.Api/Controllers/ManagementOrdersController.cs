using System.Threading.Tasks;
using System.Web.Mvc;
using ECommerce.App.Services.User;
using ECommerce.Core.Enums.Order;
using ECommerce.Core.Models.DTOs.Order;
using ECommerce.Core.Models.DTOs.User;

namespace ECommerce.Controllers
{
    public class ManagementOrdersController : Controller
    {
        private readonly OrderService _orderService;

        public ManagementOrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult> Index(string searchByOrderName = "", OrderStatus orderStatus = OrderStatus.Pending,
            int page = 1, int usersPerPage = 20)
        {
            var response =await _orderService.GetOrdersAsync(null, orderStatus, page, usersPerPage);
            return View(response.Data);
        }

        [HttpGet]
        public async Task<ActionResult> ViewOrder(int id)
        {
            var response =await _orderService.GetOrderAsync(id);
            return View(response);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateOrder(OrderStatusDto orderStatus)
        {
             var response = await _orderService.UpdateOrderAsync(orderStatus);
             return RedirectToAction("Index", "ManagementOrders");
        }
        
        [HttpPost]
        public async Task<ActionResult> DeleteOrder(int idUser)
        {
            await _orderService.DeleteOrderAsync(idUser);
            return RedirectToAction("Index", "ManagementOrders");
        }
    }
}