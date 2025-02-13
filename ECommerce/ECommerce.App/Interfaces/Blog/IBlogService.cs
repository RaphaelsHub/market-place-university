using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.DataTransferObjects;
using ECommerce.Core.DataTransferObjects.Responses;

namespace ECommerce.App.Interfaces.Blog
{
    /// <summary>
    ///  Blog service, which allows to create, read, update, delete blog, find blog by search
    /// </summary>
    public interface IBlogService
    {
        Task<ResponseType1<bool>> CreateBlogAsync(BlogDto blog);
        Task<ResponseType1<BlogDto>> GetBlogAsync(int idBlog);
        Task<ResponseType1<IEnumerable<BlogDto>>> GetBlogsAsync(int currentPage = 1, int amountOfItems = 16);
        Task<IEnumerable<BlogDto>> FindBlogsAsync(string search, int currentPage = 1, int amountOfItems = 16);
        Task<ResponseType1<bool>> UpdateBlogAsync(BlogDto blog);
        Task<ResponseType1<bool>> DeleteBlogAsync(int idBlog);
        
        
        

    }
}