using System.Web.Mvc;
using System.Web.Routing;

namespace WebProject.Controllers
{
    public class BaseController : Controller
    {
        protected string GetLastUrl()
        {
            string lastUrl = Request.UrlReferrer?.ToString();
            return lastUrl?? "/";
        }
    }
}