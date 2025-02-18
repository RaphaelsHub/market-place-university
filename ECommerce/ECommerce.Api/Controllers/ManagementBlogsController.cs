using System.Web.Mvc;
using ECommerce.Core.Models.DTOs.Blog;

namespace ECommerce.Controllers
{
    public class ManagementBlogsController : BaseController
    {
        [HttpGet] public ActionResult Index(string searchByName="", int page = 1, int usersPerPage= 100) => View();
        [HttpGet] public ActionResult ViewBlog(int id) => View();
        
        [HttpPost] public ActionResult AddBlog(BlogDto blogDto) => RedirectToAction("Index", "ManagementBlogs");
        
        [HttpPost] public ActionResult UpdateBlog(BlogDto blogDto) => RedirectToAction("Index", "ManagementBlogs");
        
        [HttpPost] public ActionResult DeleteBlog(int idBlog) => RedirectToAction("Index", "ManagementBlogs");
    }
}