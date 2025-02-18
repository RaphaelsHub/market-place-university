using System;
using System.Collections.Generic;
using ECommerce.Core.Models.DTOs.Product;

namespace ECommerce.Core.Models.ViewModels
{
    public class CartDto
    {
        public List<Tuple<ProductDto, int>> Products { get; set; }
        public float DiscountPercentage { get; set; }
        public bool HasDiscount { get; set; }
    }
}