using System.Collections.Generic;
using WebProject.Domain.Enum;

namespace WebProject.ModelAccessLayer.Model
{
    public class UserData
    {
        public int IdUser { get; set; }
        public string NameUser { get; set; }
        public StatusUser StatusUser { get; set; } = StatusUser.Unknown;
        public CartData CartData { get; set; }
        public List<OrderModel> AllOrders { get; set; }

        public UserData()
        {
            CartData = new CartData();
            AllOrders = new List<OrderModel>();
        }
    }
}