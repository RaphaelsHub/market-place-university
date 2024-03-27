using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebProject.Models;
using WebProject.DateAccesClasses;
using System.EnterpriseServices;

namespace WebProject.Controllers
{
    public class SignUpController : Controller
    {
        /*
        private readonly IUserService _userService;

        public SignUpController(IUserService userService)
        {
            _userService = userService;
        }
        */

        // GET: SignUp
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationData registrationData)
        {
            if (ModelState.IsValid && true)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(registrationData);
        }
    }
}