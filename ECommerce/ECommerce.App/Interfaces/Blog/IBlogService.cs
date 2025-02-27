using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Models.DTOs.Blog;
using ECommerce.Core.Models.DTOs.GenericResponses;

namespace ECommerce.App.Interfaces.Blog
{
    public interface IBlogService
    {
        Task<BaseResponse<BlogDto>> CreateBlogAsync(BlogDto blogDto);
        Task<BaseResponse<BlogDto>> UpdateBlogAsync(BlogDto blogDto);
        Task<BaseResponse<bool>> DeleteBlogByIdAsync(int id);
        Task<BaseResponse<BlogDto>> GetBlogByIdAsync(int id);
        Task<BaseResponse<List<BlogDto>>> GetBlogsByTitleAsync(string title, int currentPage, int amountOfItems);
        Task<BaseResponse<List<BlogDto>>> GetLatestBlogsAsync(int amountOfItems);
        Task<BaseResponse<bool>> AddMessageToBlogAsync(int idBlog, MessageDto message);
        Task<BaseResponse<bool>> DeleteMessageFromBlogAsync(int idBlog, int idMessage);
    }
}