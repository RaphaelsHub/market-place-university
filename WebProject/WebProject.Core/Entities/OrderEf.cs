using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebProject.Core.Enums;

namespace WebProject.Core.Entities
{
    public class OrderEf
    {
        [Key]
        public uint Id { get; set; }
        public float Discount { get; set; }
        public decimal ShippingPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal FinalPrice { get; set; }
        private DateTime _dateTime = DateTime.Now;
        public DateTime DateOrdered { get; set; } = DateTime.Now;
        public DateTime DateDelivered
        {
            get => _dateTime;
            set => _dateTime = Status == OrderStatus.Delivered ? DateTime.Now : _dateTime;
        }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        [ForeignKey("User")]
        public uint UserId { get; set; }
        public UserEf User { get; set; }

        public List<uint> ProductIds { get; set; }
    }
}