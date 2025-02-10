using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Entities.Blog;
using ECommerce.Core.Interfaces.Blog;

namespace ECommerce.Dal.Repositories.Blog
{
    public class BlogsRepository : IBlogsRepository<BlogEf>
    {
        private readonly StoreContext _context;
        
        public BlogsRepository(StoreContext context)
        {
            _context = context;
        }
        
        public Task<IEnumerable<BlogEf>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<BlogEf> GetByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(BlogEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(BlogEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }
    }
}