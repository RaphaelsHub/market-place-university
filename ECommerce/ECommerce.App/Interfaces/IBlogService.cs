using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.DataTransferObjects;
using ECommerce.Core.DataTransferObjects.FeedBack.Standard;

namespace ECommerce.App.Interfaces
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