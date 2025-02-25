using System;
using ECommerce.Core.Enums.Entity;

namespace ECommerce.Core.Entities.Product
{
    public class ProductEf
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public int CurrentAmount { get; set; }
        public int StartAmount { get; set; }
        public int Views { get; set; }
        public decimal StartPrice { get; set; } = 0;
        public float Discount { get; set; } = 0;
        public decimal FinalPrice => StartPrice - StartPrice * (decimal)Discount / 100;
        public byte[] Image { get; set; }
        public DateTime DatePost { get; set; }
        public EntityStatus EntityStatus { get; set; }

        public int CategoryId { get; set; }
        public CategoryEf Category { get; set; }
    }
}
