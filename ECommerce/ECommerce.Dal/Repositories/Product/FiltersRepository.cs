using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ECommerce.Core.Entities.Product;
using ECommerce.Core.Interfaces.Product;

namespace ECommerce.Dal.Repositories.Product
{
    public class FiltersRepository : IFiltersRepository<FilterEf>
    {
        private readonly StoreContext _context;

        public FiltersRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FilterEf>> GetAllAsync() =>
            await _context.Filters.ToListAsync();

        public async Task<FilterEf> GetByIdAsync(int id) =>
            await _context.Filters.FirstOrDefaultAsync(x => x.FilterId == id);

        public async Task CreateAsync(FilterEf entity)
        {
            _context.Filters.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FilterEf entity)
        {
            _context.Filters.Attach(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var filter = await _context.Filters.FirstOrDefaultAsync(x => x.FilterId == id);
            if (filter != null)
            {
                _context.Filters.Remove(filter);
                await _context.SaveChangesAsync();
            }
        }
    }
}