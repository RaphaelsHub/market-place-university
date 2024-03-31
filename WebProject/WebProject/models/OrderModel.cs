using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebProject.Models
{
    public class OrderModel
    {
        public OrderInfo OrderInfo { get; set; }
        public CardCreditinals CardCreditinals { get; set; }


        public OrderModel(OrderInfo orderInfo, CardCreditinals cardCreditinals) { 
            OrderInfo = orderInfo;
            CardCreditinals = cardCreditinals;
        }
    }
}