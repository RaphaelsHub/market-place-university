using System;
using System.Collections.Generic;
using WebProject.Core.Enums;

namespace WebProject.Core.Entities
{
    public class OrderEf
    {
        public uint Id { get; set; }
        public uint UserId { get; set; }
        public uint AddressId { get; set; }
        public List<uint> ProductIds { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public DateTime DateOrdered { get; set; } = DateTime.Now;
        public DateTime DateDelivered { get; set; }
        public Decimal TotalPrice { get; set; }
        public double Discount { get; set; }
        public decimal FinalPrice { get; set; }
    }
}