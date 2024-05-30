using System.Web.Mvc;
using WebProject.ModelAccessLayer.Model;
using WebProject.BusinessLogic.MainBL;

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

            _businessLogic.User = new GuestBL();

            return RedirectToAction("Index", "Home");
        }
    }
}