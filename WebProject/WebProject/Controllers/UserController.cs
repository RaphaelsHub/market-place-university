using System.Web.Helpers;
using System.Web.Mvc;
using WebProject.App.Interfaces;
using WebProject.Core.DTO.User;
using Newtonsoft.Json;

namespace WebProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public UserDto Users()
        {
            return new UserDto();
        }

        [HttpGet]
        public JsonResult FindUser(string search)
        {
            _userService.GetUserByUserName(search);
            return Json { search, JsonRequestBehavior.AllowGet };   
        }

        [HttpPost]
        public ActionResult AddUser()
        {
            _userService.AddUser(new UserDto());
            return RedirectToAction("Users");
        }
        
        [HttpPatch]
        public ActionResult UpdateUser()
        {
            _userService.UpdateUser(new UserDto());
            return RedirectToAction("Users");
        }

        [HttpDelete]
        public ActionResult DeleteUser()
        {
            _userService.DeleteUser(new UserDto());
            return RedirectToAction("Users");
        }
    }
}