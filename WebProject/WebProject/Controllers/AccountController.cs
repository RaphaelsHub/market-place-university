using System.Web.Mvc;
using WebProject.Core.DTO;

namespace WebProject.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public ActionResult Login() => View();
        
        [HttpGet]
        public ActionResult Register() => View();
     
        [HttpGet]
        public ActionResult LogOut() => RedirectToAction("Index", "Home");
        
        [HttpPost]
        public ActionResult Login(LoginDto loginDto) => View();
        
        [HttpPost]
        public ActionResult Register(RegisterDto registerDto) => View();
    }
}