using System;
using System.Collections.Generic;
using ECommerce.Core.Entities.Product;
using ECommerce.Core.Enums.Entity;
using ECommerce.Core.Enums.Product;

namespace ECommerce.Core.Models.DTOs.Product
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public int StartAmount { get; set; }
        public int CurrentAmount { get; set; }
        public int Views { get; set; }
        
        public string Name { get; set; }    
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public float PercentageDiscount { get; set; }
        public decimal Price { get; set; }
        
        public decimal PriceWithDiscount => Price - Price * (decimal)PercentageDiscount / 100;
        public DateTime DatePost { get; set; } = DateTime.Now;
        public ProductSellType ProductSellType { get; set; }
        public ProductStockStatus ProductStatus { get; set; }
        public EntityStatus EntityStatus { get; set; }
        public byte[][] Image { get; set; }
        public string CategoryId { get; set; }
    }
}