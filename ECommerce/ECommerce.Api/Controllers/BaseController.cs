using System;
using System.Web.Mvc;
using ECommerce.Helper;

namespace ECommerce.Controllers
{
    public class BaseController : Controller
    {
        protected string GetLastUrl() => Request.UrlReferrer?.ToString() ?? "/";
        
        protected ActionResult RedirectToLastUrl() => Redirect(GetLastUrl());
        
        protected  ActionResult RedirectToErrorPage(int errorCode) 
            =>  RedirectToAction("Error", "Home", new 
                { errorCode, errorMessage = ErrorHelper.GetErrorMessage(errorCode) });
    }
}