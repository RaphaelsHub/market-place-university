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
    }
}