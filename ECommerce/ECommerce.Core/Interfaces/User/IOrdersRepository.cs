using ECommerce.Core.Entities.User;

namespace ECommerce.Core.Interfaces.User
{
    public interface IOrdersRepository<T> : IGenericRepository<OrderEf>
    {
        
    }
}