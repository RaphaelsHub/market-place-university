using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.Core.DTO;
using WebProject.Core.DTO.ResponcesDto;

namespace WebProject.App.Interfaces
{
    public interface IOrderService
    {
        // CRUD Operations
        Task<Response<bool>> CreateOrderAsync(OrderDto order);
        Task<Response<OrderDto>> GetOrderByIdAsync(uint id);
        Task<Response<IEnumerable<OrderDto>>> GetUsersOrdersAsync(uint userId, uint currentPage, uint amountOfItemsPerPage);
        Task<Response<IEnumerable<OrderDto>>> GetAllOrdersAsync(uint currentPage, uint amountOfItemsPerPage);
        Task<Response<IEnumerable<OrderDto>>> GetAllOrdersByStatusAsync(string status, uint currentPage, uint amountOfItemsPerPage);
        Task<Response<bool>> UpdateOrderAsync(OrderDto order);
        Task<Response<bool>> DeleteOrderAsync(uint id);
    }
}