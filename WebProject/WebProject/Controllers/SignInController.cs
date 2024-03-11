using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebProject.Controllers
{
    public class SignInController : Controller
    {
        // GET: SighIn
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            //Рандомный емаил и пароль
            string validEmail = "user@example.com";
            string validPassword = "password";


            if (email == validEmail && password == validPassword)
            {
                HomeController.IsAuthorized = true;
                HomeController.IsAdmin = true;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Если логин и/или пароль неверные, возвращаем обратно к форме входаs
                ViewBag.ErrorMessage = "Invalid email or password";
                return View();
            }
        }

        public ActionResult LogOut()
        {
            HomeController.IsAuthorized = false;
            HomeController.IsAdmin = false;
            return RedirectToAction("Index", "Home");
        }

    }
}