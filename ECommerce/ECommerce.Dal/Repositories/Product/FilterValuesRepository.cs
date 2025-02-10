using System.Collections.Generic;
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
        
        public Task<IEnumerable<FilterValueEf>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<FilterValueEf> GetByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(FilterValueEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(FilterValueEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }
    }
}