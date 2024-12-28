using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult Index() => View();
        
        [HttpGet]
        public ActionResult AboutUs() => View();
        
        [HttpGet]
        public ActionResult ContactUs() => View();
        
        [HttpGet]
        public ActionResult Thanks() => View();
        
        [HttpPost]
        public ActionResult MailSuccess() => View();
        
        [HttpPost]
        public ActionResult GetDiscount(string email) => RedirectToAction(GetLastUrl());
    }
}