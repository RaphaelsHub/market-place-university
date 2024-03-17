using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class CartData
    {
        public List<CartItem> Items;

        public CartData()
        {
            Items = new List<CartItem>();
        }
    }
}