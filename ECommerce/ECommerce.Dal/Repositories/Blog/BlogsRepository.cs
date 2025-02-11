using System.Collections.Generic;
using System.Data.Entity;
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
        
        public async Task<IEnumerable<BlogEf>> GetAllAsync() =>
            await _context.Blogs.ToListAsync();

        public async Task<BlogEf> GetByIdAsync(int id) =>
            await _context.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);

        public async Task CreateAsync(BlogEf entity)
        {
            _context.Blogs.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BlogEf entity)
        {
            _context.Blogs.Attach(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var blog = await _context.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
                await _context.SaveChangesAsync();
            }
        }
    }
}