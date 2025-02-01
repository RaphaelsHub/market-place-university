using System.Web.Mvc;
using WebProject.Core.DTO;
using WebProject.Core.DTO.User;

namespace WebProject.Controllers
{
    public class AccountController : BaseController
    {
        /************** Sign In **************/
        [HttpGet]
        public ActionResult SignIn() => View();
        
        [HttpPost]
        public ActionResult SignIn(SignInDto loginDto)
        {
            if(!ModelState.IsValid)
                return View(loginDto);
            return RedirectToAction("Index", "Home");
        }
        
        
        /************** Sign Up **************/
        [HttpGet]
        public ActionResult SignUp() => View();
     
        [HttpPost]
        public ActionResult SignUp(SignUpDto registerDto)
        {
            if(!ModelState.IsValid)
                return View(registerDto);
            return RedirectToAction("Index", "Home");
        }
        
        
        /************** Sign Out **************/
        [HttpGet]
        public ActionResult SignOut() => RedirectToAction("Index", "Home");


        

        
        
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