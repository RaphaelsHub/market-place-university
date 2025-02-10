using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces.User;

namespace ECommerce.Dal.Repositories.User
{
    public class AddressesRepository : IAddressesRepository<AddressEf>
    {
        private readonly StoreContext _context;

        public AddressesRepository(StoreContext context)
        {
            _context = context;
        }
        
        public Task<IEnumerable<AddressEf>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<AddressEf> GetByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(AddressEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(AddressEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }
    }
}