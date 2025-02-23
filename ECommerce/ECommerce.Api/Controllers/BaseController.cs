using System;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class BaseController : Controller
    {
        protected string GetLastUrl() => Request.UrlReferrer?.ToString() ?? "/Home";
        protected ActionResult RedirectToLastPage() => Redirect(GetLastUrl());
    }
}