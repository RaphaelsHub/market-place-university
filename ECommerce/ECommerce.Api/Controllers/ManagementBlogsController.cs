using System.Threading.Tasks;
using System.Web.Mvc;
using ECommerce.App.Interfaces.Blog;
using ECommerce.Core.Models.DTOs.Blog;

namespace ECommerce.Controllers
{
    public class ManagementBlogsController : BaseController
    {
        private readonly IBlogService _blogService;
        
        public ManagementBlogsController(IBlogService blogService) => 
            _blogService = blogService;

        [HttpGet]
        public async Task<ActionResult> Index(string searchByName = "", int page = 1, int blogs = 20)
        {
            var response =await _blogService.GetBlogsByTitleAsync(searchByName, page, blogs);
            return View(response.Data);
        }

        [HttpGet]
        public async Task<ActionResult> ViewBlog(int id)
        {
            var response =await _blogService.GetBlogByIdAsync(id);
            if(response.Data==null) return RedirectToAction("Index", "ManagementBlogs");
            return View(response);
        }

        [HttpGet] public ActionResult ViewBlog(BlogDto blogDto) => View(blogDto);
        
        [HttpPost]
        public async Task<ActionResult> AddBlog(BlogDto blogDto)
        {
            if (!ModelState.IsValid)
                return View("ViewBlog", blogDto);

            var response = await _blogService.CreateBlogAsync(blogDto);
            
            return RedirectToAction("Index", "ManagementBlogs");
        }

        [HttpPost]
        public async Task<ActionResult> UpdateBlog(BlogDto blogDto)
        {
            if (!ModelState.IsValid)
                return View("ViewBlog", blogDto);

            var response = await _blogService.UpdateBlogAsync(blogDto);
            return View("ViewBlog", response.Data);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteBlog(int idBlog)
        {
            var response = await _blogService.DeleteBlogByIdAsync(idBlog);
            return RedirectToAction("Index", "ManagementBlogs");
        }
    }
}