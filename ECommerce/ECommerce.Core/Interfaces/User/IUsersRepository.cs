using WebProject.Core.Entities.User;

namespace WebProject.Core.Interfaces.User
{
    public interface IUsersRepository<T> : IGenericRepository<UserEf>
    {
        
    }
}