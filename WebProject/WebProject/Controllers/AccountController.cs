using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using WebProject.BusinessLogic.MainBL;
using WebProject.Domain.Enum;
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
        public ActionResult Login()
        {
            if (Session["UserData"] == null)
                return View();
            else
                return RedirectToAction("Index", "Home");
        }

        // GET: SignUp
        public ActionResult Registration()
        {
            if (Session["UserData"] == null)
                return View();
            else
                return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public ActionResult Login(LoginData loginData)
        {
            UserData userData = new UserData();

            if (ModelState.IsValid && userData != null)
            {
                userData.StatusUser = Domain.Enum.StatusUser.Admin;
                ;
                Session["UserData"] = userData;

                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Invalid email or password";
            return View();

        }

        [HttpPost]
        public ActionResult Registration(RegistrationData registrationData)
        {
            UserData userData = new UserData();

            if (ModelState.IsValid && userData != null)
            {
                Session["UserData"] = userData;

                return RedirectToAction("Index", "Home");
            }
            return View(registrationData);

        }

        public ActionResult LogOut()
        {
            if (user.Logout(userData))
                Session.Remove("UserData");

            return RedirectToAction("Index", "Home");
        }
    }
}
