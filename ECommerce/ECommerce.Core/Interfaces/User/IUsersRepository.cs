using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Enums.User;

namespace ECommerce.Core.Interfaces.User
{
    public interface IUsersRepository : IGenericRepository<UserEf>
    {
        Task<UserEf> GetByEmailAsync(string email);
        Task<IEnumerable<UserEf>> GetPaginatedUsersByEmailAndTypeAsync(string email, UserType userType, int page, int pageSize);
    }
}