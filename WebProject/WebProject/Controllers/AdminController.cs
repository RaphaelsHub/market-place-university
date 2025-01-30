using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class AdminController : BaseController
    {
        [HttpGet]
        public ActionResult AdminPanel() => View();
    }
}


