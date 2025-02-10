using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class AdminController : BaseController
    {
        [HttpGet]
        public ActionResult AdminPanel() => View();
    }
}


