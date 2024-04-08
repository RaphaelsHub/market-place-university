using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.BusinessLogic.Interfaces;
using WebProject.ModelAccessLayer.Model;

namespace WebProject.BusinessLogic.MainBL
{
    public class UserBL : IUserBase
    {
        public bool AddToCart(CartItem cartItem)
        {
            return true;
        }

        public bool Logout(UserData userData)
        {
            return true;
        }

        public bool ProcessOrder(OrderModel orderModel)
        {
            return true;
        }

        public UserData SynchronizeWithDb(UserData userData)
        {
            throw new NotImplementedException();
        }

        public CartData ViewCart()
        {
            CartData cartData = null;

            return cartData;
        }

       public AllDeliveries ViewOrders()
        {
            AllDeliveries deliveries = null;

            return deliveries;
        }
    }
}
