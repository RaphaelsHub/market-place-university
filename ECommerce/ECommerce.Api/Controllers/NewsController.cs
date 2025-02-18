using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class NewsController : BaseController
    {
        [HttpGet] public ActionResult Index(string search = "", string sort = "", int? page = 1, int? blogsPerPage = 20) => View(); 
        [HttpGet] public ActionResult Blog(int? idBlog) => View();
    }
}