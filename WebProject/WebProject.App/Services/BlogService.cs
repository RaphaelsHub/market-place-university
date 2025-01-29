using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.App.Interfaces;
using WebProject.Core.DTO;
using WebProject.Core.DTO.FeedBack.Standard;

namespace WebProject.App.Services
{
    public class BlogService : IBlogService
    {
        public Task<ResponseType1<bool>> CreateBlogAsync(BlogDto blog)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<BlogDto>> GetBlogAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<IEnumerable<BlogDto>>> GetBlogsAsync(uint currentPage, uint amountOfItems)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<BlogDto>> FindBlogsAsync(string search, uint currentPage, uint amountOfItems)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> UpdateBlogAsync(BlogDto blog)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> DeleteBlogAsync(uint idBlog)
        {
            throw new System.NotImplementedException();
        }
    }
}