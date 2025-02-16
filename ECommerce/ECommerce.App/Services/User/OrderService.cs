using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.App.Interfaces.User;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces.User;
using ECommerce.Core.Models;
using ECommerce.Core.Models.DTOs.Order;
using ECommerce.Core.Models.ViewModels;

namespace ECommerce.App.Services.User
{
    public class OrderService : IOrderService
    {
        private readonly IOrdersRepository<OrderEf> _ordersRepository;
        
        public OrderService(IOrdersRepository<OrderEf> ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        

        public Task<ResponseViewModel<bool>> CreateOrderAsync(OrderDataDto order)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<OrderDataDto>> GetOrderAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<IEnumerable<OrderDataDto>>> GetOrdersAsync(uint currentPage = 1, uint amountOfItemsPerPage = 16)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<OrderDataDto>> GetOrderByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<bool>> DeleteOrderAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<IEnumerable<OrderDataDto>>> GetUsersOrdersAsync(uint userId, uint currentPage, uint amountOfItemsPerPage)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<IEnumerable<OrderDataDto>>> GetAllOrdersAsync(uint currentPage, uint amountOfItemsPerPage)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<IEnumerable<OrderDataDto>>> GetAllOrdersByStatusAsync(string status, uint currentPage, uint amountOfItemsPerPage)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<bool>> UpdateOrderAsync(OrderDataDto order)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<bool>> DeleteOrderAsync(uint id)
        {
            throw new System.NotImplementedException();
        }
    }
}