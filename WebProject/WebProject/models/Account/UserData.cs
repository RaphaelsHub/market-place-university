using WebProject.Models.Products;
using WebProject.Models.Order;

namespace WebProject.Models.Account
{
    public class UserData
    {
        public int ID_User { get; set; }
        public string Name_User { get; set; }
        public CartData Cart_User { get; set; }
        public AllDeliveries Deliveries_User { get; set;}
        public AllProducts Products_Admin { get; set; }
        public AllDeliveries Deliveries_Admin { get; set; }

        public UserData()
        {
            Cart_User = new CartData();
            Deliveries_User = new AllDeliveries();

            Products_Admin = new AllProducts();
            Deliveries_Admin = new AllDeliveries();
        }
    }
}