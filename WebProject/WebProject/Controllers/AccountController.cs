using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using WebProject.BusinessLogic.MainBL;
using WebProject.ModelAccessLayer.Model;

namespace WebProject.Controllers
{
    public class AccountController : Controller
    {
        static public UserData userData = null;
        static public AdminBL admin = null;
        static public UserBL user = null;
        static public GuestBL guest = null;

        public AccountController()
        {
            admin = new AdminBL();
            user = new UserBL();
            guest = new GuestBL();
        }

        // GET: SighIn
        public ActionResult Login() => View();
        // GET: SignUp
        public ActionResult Registration() => View();

        [HttpPost]
        public ActionResult Login(LoginData loginData)
        {
            userData = guest.Login(loginData);


            if (ModelState.IsValid && !(userData != null))
            {
                //Add To Saccion data
                //Open Cookies
                HomeController.IsAuthorized = true;
                return RedirectToAction("Index", "Home"); // Возвращаем перенаправление
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid email or password";
                return View(); // Возвращаем представление
            }
        }

        [HttpPost]
        public ActionResult Registration(RegistrationData registrationData)
        {
            userData = guest.Register(registrationData);

            if (ModelState.IsValid && !(userData != null))
            {
                //Add To Saccion data
                //Open Cookies
                HomeController.IsAuthorized = true;
                return RedirectToAction("Index", "Home");
            }

            return View(registrationData);
        }

        //[HttpPost]
        public ActionResult LogOut()
        {
            user.Logout(userData);
            //CloseCookies Cookies
            //Delete seccionData
            HomeController.IsAuthorized = false;
            return RedirectToAction("Index", "Home");
        }
    }
}
