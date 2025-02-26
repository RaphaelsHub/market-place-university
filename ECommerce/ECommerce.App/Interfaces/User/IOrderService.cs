using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Enums.Order;
using ECommerce.Core.Models.DTOs.GenericResponses;
using ECommerce.Core.Models.DTOs.Order;

namespace ECommerce.App.Interfaces.User
{
    public interface IOrderService
    {
        Task<BaseResponse<OrderDto>> CreateOrderAsync(OrderDataDto order);
        Task<BaseResponse<OrderDto>> UpdateOrderAsync(OrderStatusDto order);
        Task<BaseResponse<OrderDto>> GetOrderAsync(int id);
        Task<BaseResponse<bool>> DeleteOrderAsync(int id);
        Task<BaseResponse<IEnumerable<OrderDto>>> GetOrdersAsync(int? userId, OrderStatus orderStatus, int currentPage,
            int amountOfItemsPerPage);
    }
}