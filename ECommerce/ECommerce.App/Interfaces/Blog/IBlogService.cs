using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Models;
using ECommerce.Core.Models.DTOs.Blog;
using ECommerce.Core.Models.ViewModels;

namespace ECommerce.App.Interfaces.Blog
{
    /// <summary>
    ///  Blog service, which allows to create, read, update, delete blog, find blog by search
    /// </summary>
    public interface IBlogService
    {
        Task<ResponseViewModel<bool>> CreateBlogAsync(BlogDto blog);
        Task<ResponseViewModel<BlogDto>> GetBlogAsync(int idBlog);
        Task<ResponseViewModel<IEnumerable<BlogDto>>> GetBlogsAsync(int currentPage = 1, int amountOfItems = 16);
        Task<IEnumerable<BlogDto>> FindBlogsAsync(string search, int currentPage = 1, int amountOfItems = 16);
        Task<ResponseViewModel<bool>> UpdateBlogAsync(BlogDto blog);
        Task<ResponseViewModel<bool>> DeleteBlogAsync(int idBlog);
        
        
        

    }
}