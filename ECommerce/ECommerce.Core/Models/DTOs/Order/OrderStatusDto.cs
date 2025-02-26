using System;
using ECommerce.Core.Enums.Order;

namespace ECommerce.Core.Models.DTOs.Order
{
    public class OrderStatusDto
    {
        public DateTime OrderDate { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}