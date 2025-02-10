using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces.User;

namespace ECommerce.Dal.Repositories.User
{
    public class UsersRepository : IUsersRepository<UserEf>
    {
        private readonly StoreContext _context;
        
        public UsersRepository(StoreContext context)
        {
            _context = context;
        }
        
        public Task<IEnumerable<UserEf>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<UserEf> GetByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(UserEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(UserEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }
    }
}