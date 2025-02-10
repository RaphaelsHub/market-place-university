using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.DataTransferObjects.FeedBack.Standard;
using ECommerce.Core.DataTransferObjects.User;

namespace ECommerce.App.Interfaces
{
    public interface IOrderService
    {
        // CRUD Operations
        Task<ResponseType1<bool>> CreateOrderAsync(OrderDto order);
        Task<ResponseType1<OrderDto>> GetOrderByIdAsync(uint id);
        Task<ResponseType1<IEnumerable<OrderDto>>> GetUsersOrdersAsync(uint userId, uint currentPage, uint amountOfItemsPerPage);
        Task<ResponseType1<IEnumerable<OrderDto>>> GetAllOrdersAsync(uint currentPage, uint amountOfItemsPerPage);
        Task<ResponseType1<IEnumerable<OrderDto>>> GetAllOrdersByStatusAsync(string status, uint currentPage, uint amountOfItemsPerPage);
        Task<ResponseType1<bool>> UpdateOrderAsync(OrderDto order);
        Task<ResponseType1<bool>> DeleteOrderAsync(uint id);
    }
}