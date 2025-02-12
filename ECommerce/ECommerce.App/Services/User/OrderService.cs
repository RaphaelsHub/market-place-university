using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.App.Interfaces.User;
using ECommerce.Core.DataTransferObjects.Responses;
using ECommerce.Core.DataTransferObjects.User;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces.User;

namespace ECommerce.App.Services.User
{
    public class OrderService : IOrderService
    {
        private readonly IOrdersRepository<OrderEf> _ordersRepository;
        
        public OrderService(IOrdersRepository<OrderEf> ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        
        public Task<ResponseType1<bool>> CreateOrderAsync(OrderDto order)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<OrderDto>> GetOrderAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<IEnumerable<OrderDto>>> GetOrdersAsync(uint currentPage = 1, uint amountOfItemsPerPage = 16)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<OrderDto>> GetOrderByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> DeleteOrderAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<IEnumerable<OrderDto>>> GetUsersOrdersAsync(uint userId, uint currentPage, uint amountOfItemsPerPage)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<IEnumerable<OrderDto>>> GetAllOrdersAsync(uint currentPage, uint amountOfItemsPerPage)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<IEnumerable<OrderDto>>> GetAllOrdersByStatusAsync(string status, uint currentPage, uint amountOfItemsPerPage)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> UpdateOrderAsync(OrderDto order)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> DeleteOrderAsync(uint id)
        {
            throw new System.NotImplementedException();
        }
    }
}