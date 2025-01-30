using WebProject.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.Core.DTO.ResponcesDto;

namespace WebProject.App.Interfaces
{
    public interface IBlogService
    {
        Task<Response<bool>> CreateBlogAsync(BlogDto blog);
        Task<Response<BlogDto>> GetBlogAsync(uint id);
        Task<Response<IEnumerable<BlogDto>>> GetBlogsAsync(uint currentPage, uint amountOfItems);
        Task<IEnumerable<BlogDto>> FindBlogsAsync(string search, uint currentPage, uint amountOfItems);
        Task<Response<bool>> UpdateBlogAsync(BlogDto blog);
        Task<Response<bool>> DeleteBlogAsync(uint idBlog);
    }
}