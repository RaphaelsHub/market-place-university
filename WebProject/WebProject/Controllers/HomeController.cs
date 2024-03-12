using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        static public bool IsAuthorized {  get; set; } = false;
        static public bool IsAdmin {  get; set; } = false;
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.IsAuthorized = IsAuthorized;    
            ViewBag.IsAdmin = IsAdmin;   
            
            return View();
        }
  

    }
}