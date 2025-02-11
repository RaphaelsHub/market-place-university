using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ECommerce.Core.Entities.Product;
using ECommerce.Core.Interfaces.Product;

namespace ECommerce.Dal.Repositories.Product
{
    public class FilterValuesRepository : IFilterValuesRepository<FilterValueEf>
    {
        private readonly StoreContext _context;

        public FilterValuesRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FilterValueEf>> GetAllAsync() =>
            await _context.FilterValues.ToListAsync();

        public async Task<FilterValueEf> GetByIdAsync(int id) =>
            await _context.FilterValues.FirstOrDefaultAsync(x => x.FilterValueId == id);

        public async Task CreateAsync(FilterValueEf entity)
        {
            _context.FilterValues.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FilterValueEf entity)
        {
            _context.FilterValues.Attach(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var filterValue = await _context.FilterValues.FirstOrDefaultAsync(x => x.FilterValueId == id);
            if (filterValue != null)
            {
                _context.FilterValues.Remove(filterValue);
                await _context.SaveChangesAsync();
            }
        }
    }
}