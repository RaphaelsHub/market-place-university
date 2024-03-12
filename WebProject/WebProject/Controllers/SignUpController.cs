using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebProject.Models;
using WebProject.DateAccesClasses;

namespace WebProject.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationData registrationData)
        {
            // Обработка введенных данных

            bool userExists = CheckIfExistUser.Check(registrationData);

            if (userExists)
            {
                ViewBag.ErrorMessage1 = "User with this email already exists.";
                return View();
            }
            else
            {
                //запись в базу
                HomeController.IsAuthorized = true;

                // После успешной регистрации перенаправляем пользователя на главную страницу
                return RedirectToAction("Index", "Home");
            }
        }
    }

}