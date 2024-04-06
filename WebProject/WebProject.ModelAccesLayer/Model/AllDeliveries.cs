using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.ModelAccessLayer.Model
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
