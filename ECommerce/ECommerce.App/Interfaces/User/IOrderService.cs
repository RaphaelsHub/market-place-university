using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.DataTransferObjects.Responses;
using ECommerce.Core.DataTransferObjects.User;

namespace ECommerce.App.Interfaces.User
{
    public interface IOrderService
    {
        // CRUD Operations
        Task<ResponseType1<bool>> CreateOrderAsync(OrderDto order);
        Task<ResponseType1<OrderDto>> GetOrderAsync(int id);
        Task<ResponseType1<IEnumerable<OrderDto>>> GetOrdersAsync(uint currentPage = 1, uint amountOfItemsPerPage = 16);
        Task<ResponseType1<bool>> UpdateOrderAsync(OrderDto order);
        Task<ResponseType1<bool>> DeleteOrderAsync(int id);
        
        
        
        Task<ResponseType1<IEnumerable<OrderDto>>> GetUsersOrdersAsync(uint userId, uint currentPage, uint amountOfItemsPerPage);
        Task<ResponseType1<IEnumerable<OrderDto>>> GetAllOrdersAsync(uint currentPage, uint amountOfItemsPerPage);
        Task<ResponseType1<IEnumerable<OrderDto>>> GetAllOrdersByStatusAsync(string status, uint currentPage, uint amountOfItemsPerPage);

    }
}