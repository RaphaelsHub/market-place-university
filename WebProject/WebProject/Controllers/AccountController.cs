using System.Web.Mvc;
using WebProject.Core.DTO;

namespace WebProject.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public ActionResult SignIn() => View();
        
        [HttpGet]
        public ActionResult SignUp() => View();
     
        [HttpGet]
        public ActionResult SignOut() => RedirectToAction("Index", "Home");
        
        [HttpPost]
        public ActionResult SignIn(LoginDto loginDto) => View();
        
        [HttpPost]
        public ActionResult SignUp(RegisterDto registerDto) => View();
        
        
        // User Admin Actions
        [HttpGet]
        public ActionResult Users() => View();
        
        [HttpGet]
        public ActionResult FindUser(string search) => RedirectToAction("Users");
        
        [HttpPost]
        public ActionResult AddUser() => RedirectToAction("Users");
        
        [HttpPatch]
        public ActionResult UpdateUser() => RedirectToAction("Users");
        
        [HttpDelete]
        public ActionResult DeleteUser() => RedirectToAction("Users");
    }
}