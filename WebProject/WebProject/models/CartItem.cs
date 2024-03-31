using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebProject.Models
{
    public class CartItem
    {
        public int Id { get; set; } 
        public int Quantity { get; set; } 

        public CartItem() { }
        public CartItem(int productId, int quantity)
        {
            Id = productId;
            Quantity = quantity;
        }
    }
}