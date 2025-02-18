using System.Web.Mvc;
using ECommerce.Core.Models.DTOs.User;

namespace ECommerce.Controllers
{
    public class ManagementOrdersController : Controller
    {
        [HttpGet] public ActionResult Index(string searchByOrderName="", string time ="", string sort="", int page = 1, int usersPerPage= 100) => View();
        
        [HttpGet] public ActionResult ViewOrder(int id) => View();
        
        [HttpPost] public ActionResult AddOrder(UserDto userDto) => RedirectToAction("Index", "ManagementOrders");
        
        [HttpPost] public ActionResult UpdateOrder(UserDto userDto) => RedirectToAction("Index", "ManagementOrders");
        
        [HttpPost] public ActionResult DeleteOrder(int idUser) => RedirectToAction("Index", "ManagementOrders");
    }
}