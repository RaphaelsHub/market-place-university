using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Enums.Order;

namespace ECommerce.Core.Interfaces.User
{
    public interface IOrdersRepository : IGenericRepository<OrderEf>
    {
        Task<List<OrderEf>> GetOrdersAsync(int? userId, OrderStatus orderStatus,
            int currentPage, int amountOfItemsPerPage);
    }
}