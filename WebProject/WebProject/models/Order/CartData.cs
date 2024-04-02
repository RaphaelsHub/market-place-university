using System;
using System.Collections.Generic;
using WebProject.Models.Products;


namespace WebProject.Models.Order
{
    public class CartData
    {
        public decimal SumPrice { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal FinalPrice { get; set; }

        public List<Tuple<Product, int>> productList;
   
        public CartData()
        {
            productList = new List<Tuple<Product, int>>();
        }
    }
}