using System.Web.Mvc;
using WebProject.ModelAccessLayer.Model;

namespace WebProject.Controllers
{
    public class AccountController : BaseController
    {
        // GET: SighIn
        public ActionResult Login() => CheckSessionAndReturnView("Login");

        // GET: SignUp
        public ActionResult Registration() => CheckSessionAndReturnView("Registration");

        [HttpPost]
        public ActionResult Login(LoginData loginData) => HandleUserAuthentication(loginData);


        [HttpPost]
        public ActionResult Registration(RegistrationData registrationData) => HandleUserAuthentication(registrationData);


        public ActionResult LogOut()
        {
            Session.Remove("UserData");

            _businessLogic.User = new GuestUserBL();

            return RedirectToAction("Index", "Home");
        }
    }
}