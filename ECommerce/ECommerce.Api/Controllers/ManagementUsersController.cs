using System.Web.Mvc;
using ECommerce.App.Interfaces.User;
using ECommerce.Core.Enums.User;
using ECommerce.Core.Models.DTOs.User;

namespace ECommerce.Controllers
{
    public class ManagementUsersController : BaseController
    {
        
        private readonly IUserService _userService;
        
        public ManagementUsersController(IUserService userService)=> _userService = userService;
        
        [HttpGet] public ActionResult Index(
            string searchByEmail="", UserType userType = UserType.None, int page = 1, int usersPerPage= 40) => View();


        
        [HttpGet] public ActionResult ViewUser(int id) => View();
        
        [HttpPost] public ActionResult UpdateUser(UserDto userDto) => RedirectToAction("Index", "ManagementUsers");
        
        [HttpPost] public ActionResult DeleteUser(int id) => RedirectToAction("Index", "ManagementUsers");
    }
}