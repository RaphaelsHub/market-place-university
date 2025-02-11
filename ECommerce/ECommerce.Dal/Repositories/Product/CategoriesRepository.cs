using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ECommerce.Core.Entities.Product;
using ECommerce.Core.Interfaces.Product;

namespace ECommerce.Dal.Repositories.Product
{
    public class CategoriesRepository : ICategoriesRepository<CategoryEf>
    {
        private readonly StoreContext _context;

        public CategoriesRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryEf>> GetAllAsync() =>
            await _context.Categories.ToListAsync();

        public async Task<CategoryEf> GetByIdAsync(int id) =>
            await _context.Categories.FirstOrDefaultAsync(x => x.ParentCategoryId == id);

        public async Task CreateAsync(CategoryEf entity)
        {
            _context.Categories.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CategoryEf entity)
        {
            _context.Categories.Attach(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.ParentCategoryId == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}