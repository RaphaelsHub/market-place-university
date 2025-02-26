using System.Threading.Tasks;
using System.Web.Mvc;
using ECommerce.App.Interfaces.Blog;
using ECommerce.Core.Models.DTOs.Blog;

namespace ECommerce.Controllers
{
    public class NewsController : BaseController
    {
        private readonly IBlogService _blogService;
        
        public NewsController(IBlogService blogService)=>
            _blogService = blogService;

        [HttpGet]
        public async Task<ActionResult> Index(string search = "", int page = 1, int blogsPerPage = 20)
        {
            var response = await _blogService.GetBlogsByTitleAsync(search, page, blogsPerPage);
            return View(response);
        }

        [HttpGet]
        public async Task<ActionResult> Blog(int idBlog)
        {
            var response = await _blogService.GetBlogByIdAsync(idBlog);
            return View(response);
        }

        [HttpPost]
        public async Task<ActionResult> AddMessageToBlogAsync(int idBlog, MessageDto message)
        {
            var response = await _blogService.AddMessageToBlogAsync(idBlog, message);
            return Json(response.Data);
        }
    }
}