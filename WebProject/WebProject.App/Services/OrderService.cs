using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.App.Interfaces;
using WebProject.Core.DTO;
using WebProject.Core.DTO.FeedBack.Standard;
using WebProject.Core.DTO.User;

namespace WebProject.App.Services
{
    public class OrderService : IOrderService
    {
        public Task<ResponseType1<bool>> CreateOrderAsync(OrderDto order)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<OrderDto>> GetOrderByIdAsync(uint id)
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