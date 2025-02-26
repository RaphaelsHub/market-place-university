using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.App.Interfaces.JWT;
using ECommerce.App.Interfaces.User;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Enums.Order;
using ECommerce.Core.Enums.Request;
using ECommerce.Core.Interfaces.User;
using ECommerce.Core.Models.DTOs.GenericResponses;
using ECommerce.Core.Models.DTOs.Order;
using ExpressMapper;

namespace ECommerce.App.Services.User
{
    public class OrderService : IOrderService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IJwtService _jwtService;
        
        public OrderService(IOrdersRepository ordersRepository, IJwtService jwtService)
        {
            _ordersRepository = ordersRepository;
            _jwtService = jwtService;
        }


        public async Task<BaseResponse<OrderDto>> CreateOrderAsync(OrderDataDto order)
        {
            var addressEf = Mapper.Map<OrderDataDto, AddressEf>(order);
            var orderEf = new OrderEf()
            {
                Address = addressEf,
                UserId = await _jwtService.GetUserIdFromToken(),
                PaymentMethod = order.PaymentType
            };
                
            
            
            var result = await _ordersRepository.CreateAsync(orderEf);
            var orderDto = Mapper.Map<OrderEf, OrderDto>(result);
            return new BaseResponse<OrderDto>(orderDto,OperationStatus.Success, "Order has been successfully created!");
        }
        
        public Task<BaseResponse<OrderDto>> GetOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<OrderDto>> UpdateOrderAsync(OrderStatusDto order)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<bool>> DeleteOrderAsync(int id)
        {
            await _ordersRepository.DeleteByIdAsync(id);
            return new BaseResponse<bool>(true, OperationStatus.Success, "Order has been successfully deleted!");
        }

        public async Task<BaseResponse<IEnumerable<OrderDto>>> GetOrdersAsync(int? userId, OrderStatus orderStatus,
            int currentPage, int amountOfItemsPerPage)
        {
            var list = await _ordersRepository.GetOrdersAsync(userId, orderStatus, currentPage, amountOfItemsPerPage);
            var listDto = Mapper.Map<List<OrderEf>, List<OrderDto>>(list);
            return new BaseResponse<IEnumerable<OrderDto>>(listDto, OperationStatus.Success, "Orders have been successfully fetched!");
        }
    }
}