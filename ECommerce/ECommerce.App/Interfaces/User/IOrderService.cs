using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Models;
using ECommerce.Core.Models.DTOs.Order;
using ECommerce.Core.Models.ViewModels;

namespace ECommerce.App.Interfaces.User
{
    public interface IOrderService
    {
        // CRUD Operations
        Task<ResponseViewModel<bool>> CreateOrderAsync(OrderDataDto order);
        Task<ResponseViewModel<OrderDataDto>> GetOrderAsync(int id);
        Task<ResponseViewModel<IEnumerable<OrderDataDto>>> GetOrdersAsync(uint currentPage = 1, uint amountOfItemsPerPage = 16);
        Task<ResponseViewModel<bool>> UpdateOrderAsync(OrderDataDto order);
        Task<ResponseViewModel<bool>> DeleteOrderAsync(int id);
        
        
        
        Task<ResponseViewModel<IEnumerable<OrderDataDto>>> GetUsersOrdersAsync(uint userId, uint currentPage, uint amountOfItemsPerPage);
        Task<ResponseViewModel<IEnumerable<OrderDataDto>>> GetAllOrdersAsync(uint currentPage, uint amountOfItemsPerPage);
        Task<ResponseViewModel<IEnumerable<OrderDataDto>>> GetAllOrdersByStatusAsync(string status, uint currentPage, uint amountOfItemsPerPage);

    }
}