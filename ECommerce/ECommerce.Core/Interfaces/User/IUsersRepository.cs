using System.Threading.Tasks;
using ECommerce.Core.Entities.User;

namespace ECommerce.Core.Interfaces.User
{
    public interface IUsersRepository : IGenericRepository<UserEf>
    {
        Task<UserEf> GetByEmailAsync(string email);
    }
}