using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Domain.Enum;

namespace WebProject.ModelAccessLayer.Model
{
    public class OrderModel
    {
        public int Id { get; set; }
        public OrderInfo OrderInfo { get; set; }
        public CartData CartData { get; set; }
        public StatusDelivery StatusDelivery { get; set; } = StatusDelivery.Pending;
        
        public OrderModel(OrderInfo orderInfo) { this.OrderInfo = orderInfo; } //Chiril
        public OrderModel(CartData cartData) { this.CartData=cartData; } //Chiril
        public OrderModel(OrderInfo orderInfo, CartData cartData) { this.OrderInfo = orderInfo; this.CartData = cartData; } //Chiril
        public OrderModel()
        {
            OrderInfo = new OrderInfo();
            CartData = new CartData();
        }
    }
}
