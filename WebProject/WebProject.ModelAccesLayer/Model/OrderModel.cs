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
        public CardCreditionals CardCreditinals { get; set; }
        public CartData CartData { get; set; }
        public StatusDelivery StatusDelivery { get; set; } = StatusDelivery.Pending;
        


        public OrderModel(OrderInfo orderInfo, CardCreditionals cardCreditinals, CartData cartData)
        {
            OrderInfo = orderInfo;
            CardCreditinals = cardCreditinals;
            CartData = cartData;
        }
        public OrderModel(OrderInfo orderInfo, CardCreditionals cardCreditinals)
        {
            OrderInfo = orderInfo;
            CardCreditinals = cardCreditinals;
        }
    }
}
