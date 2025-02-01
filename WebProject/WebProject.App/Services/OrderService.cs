using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.App.Interfaces;
using WebProject.Core.DTO;
using WebProject.Core.DTO.FeedBack.Standard;

namespace WebProject.App.Services
{
    public class OrderService : IOrderService
    {
        public Task<Response<bool>> CreateOrderAsync(OrderDto order)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<OrderDto>> GetOrderByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<IEnumerable<OrderDto>>> GetUsersOrdersAsync(uint userId, uint currentPage, uint amountOfItemsPerPage)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<IEnumerable<OrderDto>>> GetAllOrdersAsync(uint currentPage, uint amountOfItemsPerPage)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<IEnumerable<OrderDto>>> GetAllOrdersByStatusAsync(string status, uint currentPage, uint amountOfItemsPerPage)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> UpdateOrderAsync(OrderDto order)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> DeleteOrderAsync(uint id)
        {
            throw new System.NotImplementedException();
        }
    }
}