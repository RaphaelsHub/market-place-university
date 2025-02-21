using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Core.Entities.Blog;
using ECommerce.Core.Interfaces.Blog;
using ExpressMapper;

namespace ECommerce.Dal.Repositories.Blog
{
    public class BlogsRepository : IBlogsRepository
    {
        private readonly StoreContext _context;
        
        public BlogsRepository(StoreContext context) => _context = context;
        
        public async Task<BlogEf> GetByIdAsync(int id) => 
            await _context.Blogs.FindAsync(id);
        
        public async Task<BlogEf> CreateAsync(BlogEf entity)
        {
            _context.Blogs.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<BlogEf> UpdateAsync(BlogEf entity)
        {
            var existingBlog = await _context.Blogs.FindAsync(entity.BlogId);
            if (existingBlog == null) return null;
            
            Mapper.Map(entity, existingBlog);

            await _context.SaveChangesAsync();
            return existingBlog;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var blogEf = await _context.Blogs.SingleOrDefaultAsync(b => b.BlogId == id);
            if (blogEf != null)
            {
                _context.Blogs.Remove(blogEf);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<IEnumerable<BlogEf>> GetPaginatedBlogsByNameAsync(string blogName, int page, int pageSize)
        {
            var request =  _context.Blogs.AsQueryable();
            if (!string.IsNullOrEmpty(blogName)) request = request.Where(x => x.Title.Contains(blogName));
            request = request.Skip((page - 1) * pageSize).Take(pageSize);
            return await request.ToListAsync();
        }

        public async Task<IEnumerable<BlogEf>> GetLatestBlogsAsync(int amountOfItems)
        {
            return await _context.Blogs.OrderByDescending(x=>x.DateTimePublished).Take(amountOfItems).ToListAsync();
        }
    }
}