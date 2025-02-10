using System.Collections.Generic;
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
        
        public Task<IEnumerable<FilterEf>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<FilterEf> GetByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(FilterEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(FilterEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }
    }
}