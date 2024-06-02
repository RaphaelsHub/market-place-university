using System.Web.Mvc;
using WebProject.ModelAccessLayer.Model;
using WebProject.BusinessLogic.MainBL;

namespace WebProject.Controllers
{
    public class AccountController : BaseController
    {
        // GET: SighIn
        //работает
        public ActionResult Login() => CheckSessionAndReturnView("Login");

        // GET: SignUp
        //работает
        public ActionResult Registration() => CheckSessionAndReturnView("Registration");

        //работает
        [HttpPost]
        public ActionResult Login(LoginData loginData) => HandleUserAuthentication(loginData);

        //работает
        [HttpPost]
        public ActionResult Registration(RegistrationData registrationData) => HandleUserAuthentication(registrationData);

        //работает
        public ActionResult LogOut()
        {
            Session.Remove("UserData");

            _businessLogic.User = new GuestBL();

            return RedirectToAction("Index", "Home");
        }
    }
}