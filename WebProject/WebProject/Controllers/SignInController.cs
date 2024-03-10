using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            // Предварительно заданные значения логина и пароля
            string validEmail = "user@example.com";
            string validPassword = "password";

            // Проверяем введенные значения с предварительно заданными
            if (email == validEmail && password == validPassword)
            {
                // Если логин и пароль верные, перенаправляем пользователя куда-то
                // Например, на главную страницу
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Если логин и/или пароль неверные, возвращаем обратно к форме входа
                ViewBag.ErrorMessage = "Invalid email or password";
                return View();
            }
        }
    }
}