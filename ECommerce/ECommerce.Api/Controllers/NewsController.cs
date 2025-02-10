using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class NewsController : Controller
    {
        [HttpGet]
        public ActionResult Blog() => View();

        [HttpGet]
        public ActionResult Blogs() => View();
        
        [HttpGet]
        public ActionResult FindBlogs(string search) => RedirectToAction("Blogs", search);
        
        [HttpPost]
        public ActionResult AddBlog() => RedirectToAction("Blogs");
        
        [HttpPatch]
        public ActionResult UpdateBlog() => RedirectToAction("Blogs");
        
        [HttpDelete]
        public ActionResult DeleteBlog() => RedirectToAction("Blogs");
    }
}