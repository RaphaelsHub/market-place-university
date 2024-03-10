using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult Registration()
        {
            return View();
        }
    }
}