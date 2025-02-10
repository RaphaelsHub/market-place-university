using System;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class BaseController : Controller
    {
        protected string GetLastUrl()
        {
            string lastUrl = Request.UrlReferrer?.ToString();
            return lastUrl?? "/";
        }
        
        protected ActionResult RedirectToLastUrl()
        {
            return Redirect(GetLastUrl());
        }
        
        protected ActionResult CheckIfLoggedIn()
        {
            try
            {
                // Check if the user is already logged in
                
                return View();
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home", new {errorCode = 500, errorMessage = e.Message});
            }
        }
    }
}