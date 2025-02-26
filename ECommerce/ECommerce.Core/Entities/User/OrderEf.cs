using System;
using System.Collections.Generic;
using ECommerce.Core.Enums.Order;

namespace ECommerce.Core.Entities.User
{
    public class OrderEf
    {
        public int OrderId { get; set; }
        public decimal SubFinalPrice { get; set; }
        public float Discount { get; set; } = 0;
        public decimal FinalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public PaymentType PaymentMethod { get; set; }
        public DateTime DateOrdered { get; set; } = DateTime.Now;
        public DateTime DateDelivered => Status == OrderStatus.Delivered ? DateTime.Now : new DateTime();
        public int UserId { get; set; }
        public UserEf User { get; set; }
        
        public int AddressId { get; set; }
        public AddressEf Address { get; set; }
        
        public List<OrderItemEf>  OrderItems { get; set; } = new List<OrderItemEf>();
    }
}