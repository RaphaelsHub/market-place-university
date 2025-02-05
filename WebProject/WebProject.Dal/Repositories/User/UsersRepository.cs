using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.Core.Entities.User;
using WebProject.Core.Interfaces.User;

namespace WebProject.Dal.Repositories.User
{
    public class UsersRepository : IUsersRepository<UserEf>
    {
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