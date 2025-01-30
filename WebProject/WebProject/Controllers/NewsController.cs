using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
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