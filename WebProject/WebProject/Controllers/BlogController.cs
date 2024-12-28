using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult SingleBlog()
        {
            return View();
        }

        public ActionResult AllBlogs()
        {
            return View();
        }
    }
}