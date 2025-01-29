using WebProject.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.Core.DTO.FeedBack.Standard;

namespace WebProject.App.Interfaces
{
    public interface IBlogService
    {
        Task<ResponseType1<bool>> CreateBlogAsync(BlogDto blog);
        Task<ResponseType1<BlogDto>> GetBlogAsync(uint id);
        Task<ResponseType1<IEnumerable<BlogDto>>> GetBlogsAsync(uint currentPage, uint amountOfItems);
        Task<IEnumerable<BlogDto>> FindBlogsAsync(string search, uint currentPage, uint amountOfItems);
        Task<ResponseType1<bool>> UpdateBlogAsync(BlogDto blog);
        Task<ResponseType1<bool>> DeleteBlogAsync(uint idBlog);
    }
}