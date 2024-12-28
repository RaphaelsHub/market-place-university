using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class ErrorController : BaseController
    {
        [HttpGet]
        public ActionResult NotFound()
        { 
            
            string lastUrl = Request.UrlReferrer?.ToString();

            if (lastUrl == null)
                return RedirectToAction("Index", "Home");
            ViewBag.LastUrl = lastUrl;
            return View();
        }
    }
}