namespace WebProject.Models.Order
{
    public class OrderModel
    {
        public int Id { get; set; }
        public OrderInfo OrderInfo { get; set; }
        public CardCreditinals CardCreditinals { get; set; }
        public CartData CartData { get; set; }


        public OrderModel(OrderInfo orderInfo, CardCreditinals cardCreditinals, CartData cartData) { 
            OrderInfo = orderInfo;
            CardCreditinals = cardCreditinals;
            CartData = cartData;
        }        
        public OrderModel(OrderInfo orderInfo, CardCreditinals cardCreditinals) { 
            OrderInfo = orderInfo;
            CardCreditinals = cardCreditinals;
        }
    }
}