using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.Core.Entities.User;
using WebProject.Core.Interfaces.User;

namespace WebProject.Dal.Repositories.User
{
    public class AddressesRepository : IAddressesRepository<AddressEf>
    {
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