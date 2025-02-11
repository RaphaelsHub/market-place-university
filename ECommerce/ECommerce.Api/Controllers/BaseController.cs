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
        
    }
}