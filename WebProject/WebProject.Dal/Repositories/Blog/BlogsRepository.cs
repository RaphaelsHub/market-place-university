using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.Core.Entities.Blog;
using WebProject.Core.Interfaces.Blog;

namespace WebProject.Dal.Repositories.Blog
{
    public class BlogsRepository : IBlogsRepository<BlogEf>
    {
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