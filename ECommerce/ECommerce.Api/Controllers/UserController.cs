using System.Web.Mvc;
using ECommerce.App.Interfaces.User;
// using Newtonsoft.Json;

namespace ECommerce.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        // [HttpGet]
        // public UserDto Users()
        // {
        //     return new UserDto();
        // }
        //
        // [HttpGet]
        // public JsonResult FindUser(string search)
        // {
        //     _userService.GetUserByUserName(search);
        //     return Json { search, JsonRequestBehavior.AllowGet };   
        // }
        //
        // [HttpPost]
        // public ActionResult AddUser()
        // {
        //     _userService.AddUser(new UserDto());
        //     return RedirectToAction("Users");
        // }
        //
        // [HttpPatch]
        // public ActionResult UpdateUser()
        // {
        //     _userService.UpdateUser(new UserDto());
        //     return RedirectToAction("Users");
        // }
        //
        // [HttpDelete]
        // public ActionResult DeleteUser()
        // {
        //     _userService.DeleteUser(new UserDto());
        //     return RedirectToAction("Users");
        // }
        //
        // // User Admin Actions
        // [HttpGet]
        // public ActionResult Users()
        // {
        //     _userService.GetUsers();
        //     return RedirectToAction("Index", "Home");
        // }
        //
        // [HttpGet]
        // public ActionResult FindUser(string search)
        // {
        //     _userService.GetUserByUserName(search);
        //     return RedirectToAction("Index", "Home");
        // }
        //
        // [HttpPost]
        // public ActionResult AddUser()
        // {
        //     _userService.AddUser(new UserDto());
        //     return RedirectToAction("Users");
        // }
        //
        // [HttpPatch]
        // public ActionResult UpdateUser()
        // {
        //     _userService.UpdateUser(new UserDto());
        //     return RedirectToAction("Users");
        // }
        //
        // [HttpDelete]
        // public ActionResult DeleteUser()
        // {
        //     _userService.DeleteUser(new UserDto());
        //     return RedirectToAction("Users");
        // }
    }
}