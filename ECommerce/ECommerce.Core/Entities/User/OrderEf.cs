using System;
using System.Collections.Generic;
using ECommerce.Core.Enums.Order;

namespace ECommerce.Core.Entities.User
{
    public class OrderEf
    {
        public int OrderId { get; set; }
        public decimal SubTotalPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public float Discount { get; set; } = 0;
        public DateTime DateOrdered { get; set; } = DateTime.Now;
        public DateTime DateDelivered => Status == OrderStatus.Delivered ? DateTime.Now : new DateTime();
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public PaymentType PaymentMethod { get; set; } = PaymentType.None;
        
        public int UserId { get; set; }
        public UserEf User { get; set; }
        
        public int AddressId { get; set; }
        public AddressEf Address { get; set; }
        
        public List<OrderItemEf>  OrderItems { get; set; } = new List<OrderItemEf>();
    }
}