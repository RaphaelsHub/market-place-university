using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Entities.Blog;

namespace ECommerce.Core.Interfaces.Blog
{
    public interface IBlogsRepository : IGenericRepository<BlogEf>
    {
        Task<IEnumerable<BlogEf>> GetPaginatedBlogsByNameAsync(string blogName, int page, int pageSize);
        Task<IEnumerable<BlogEf>> GetLatestBlogsAsync(int amountOfItems);
    }
}