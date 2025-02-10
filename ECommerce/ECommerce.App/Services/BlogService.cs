using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.App.Interfaces;
using ECommerce.Core.DataTransferObjects;
using ECommerce.Core.DataTransferObjects.FeedBack.Standard;
using ECommerce.Core.Entities.Blog;
using ECommerce.Core.Interfaces.Blog;

namespace ECommerce.App.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogsRepository<BlogEf> _blogsRepository;
        
        public BlogService(IBlogsRepository<BlogEf> blogsRepository)
        {
            _blogsRepository = blogsRepository;
        }
        
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