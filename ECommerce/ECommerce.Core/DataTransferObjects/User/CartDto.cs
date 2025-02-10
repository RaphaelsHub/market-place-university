using System;
using System.Collections.Generic;

namespace ECommerce.Core.DataTransferObjects.User
{
    public class CartDto
    {
        public List<Tuple<ProductDto, int>> Products { get; set; }
        public float DiscountPercentage { get; set; }
        public bool HasDiscount { get; set; }
    }
}