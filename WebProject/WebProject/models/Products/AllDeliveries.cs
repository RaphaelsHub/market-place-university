using System.Collections.Generic;
using WebProject.Models.Order;

namespace WebProject.Models.Products
{
    public class AllDeliveries
    {
        public List<OrderModel> AllOrders { get; set; }

        public AllDeliveries()
        {
            AllOrders = new List<OrderModel>();
        }
    }
}