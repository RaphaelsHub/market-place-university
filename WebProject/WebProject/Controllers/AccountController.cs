using System.Web.Mvc;
using WebProject.ModelAccessLayer.Model;

namespace WebProject.Controllers
{
    public class AccountController : Controller
    {
        readonly BusinessLogic.BusinessLogic businessLogic = new BusinessLogic.BusinessLogic();

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
            UserData userData = businessLogic.GuestBL.Login(loginData);

            if (ModelState.IsValid && userData != null)
            {
                userData.StatusUser = Domain.Enum.StatusUser.Admin;

                Session["UserData"] = userData;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid email or password";
                return View();
            }

        }

        [HttpPost]
        public ActionResult Registration(RegistrationData registrationData)
        {
            UserData userData = businessLogic.GuestBL.Register(registrationData);

            if (ModelState.IsValid && userData != null)
            {
                Session["UserData"] = userData;

                return RedirectToAction("Index", "Home");
            }
            else
            {

                return View(registrationData);
            }

        }

        public ActionResult LogOut()
        {
            if (businessLogic.UserBL.Logout((UserData)Session["UserData"]))
                Session.Remove("UserData");

            return RedirectToAction("Index", "Home");
        }
    }
}
