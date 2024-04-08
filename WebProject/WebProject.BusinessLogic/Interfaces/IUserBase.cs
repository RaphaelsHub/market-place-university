using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.ModelAccessLayer.Model;

namespace WebProject.BusinessLogic.Interfaces
{
    public interface IUserBase
    {
        UserData SynchronizeWithDb(UserData userData);
        bool AddToCart(CartItem cartItem);
        CartData ViewCart();
        bool ProcessOrder(OrderModel orderModel);
        AllDeliveries ViewOrders();
        bool Logout(UserData userData);
    }
}
