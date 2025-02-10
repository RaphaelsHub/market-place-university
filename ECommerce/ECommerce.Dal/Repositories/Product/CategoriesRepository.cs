using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.Core.Entities.Product;
using WebProject.Core.Interfaces.Product;

namespace WebProject.Dal.Repositories.Product
{
    public class CategoriesRepository : ICategoriesRepository<CategoryEf>
    {
        private readonly StoreContext _context;

        public CategoriesRepository(StoreContext context)
        {
            _context = context;
        }
        
        public Task<IEnumerable<CategoryEf>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<CategoryEf> GetByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(CategoryEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(CategoryEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }
    }
}