using ECommerce.Core.Entities.User;

namespace ECommerce.Core.Interfaces.User
{
    public interface IUsersRepository<T> : IGenericRepository<UserEf>
    {
        
    }
}