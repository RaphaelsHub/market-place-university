using System.Collections.Generic;
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
        
        public Task<IEnumerable<RateItemEf>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<RateItemEf> GetByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(RateItemEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(RateItemEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }
    }
}