using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.Core.Entities.Product;
using WebProject.Core.Interfaces.Product;

namespace WebProject.Dal.Repositories.Product
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