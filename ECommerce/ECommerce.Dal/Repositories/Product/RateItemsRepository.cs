using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ECommerce.Core.Entities.Product;
using ECommerce.Core.Interfaces.Product;

namespace ECommerce.Dal.Repositories.Product
{
    public class RateItemsRepository : IRateItemsRepository<RateItemEf>
    {
        private readonly StoreContext _context;

        public RateItemsRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RateItemEf>> GetAllAsync() =>
            await _context.RateItems.ToListAsync();

        public async Task<RateItemEf> GetByIdAsync(int id) =>
            await _context.RateItems.FirstOrDefaultAsync(x => x.RateItemId == id);

        public async Task CreateAsync(RateItemEf entity)
        {
            _context.RateItems.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RateItemEf entity)
        {
            _context.RateItems.Attach(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var rateItem = await _context.RateItems.FirstOrDefaultAsync(x => x.RateItemId == id);
            if (rateItem != null)
            {
                _context.RateItems.Remove(rateItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}