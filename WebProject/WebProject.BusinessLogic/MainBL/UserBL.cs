using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.BusinessLogic.Core;
using WebProject.BusinessLogic.Interfaces;
using WebProject.Domain.Entities.DBModels;
using WebProject.ModelAccessLayer.Model;

namespace WebProject.BusinessLogic.MainBL
{
    public class UserBL : UserAPI, IUserBase
    {
        public bool AddToCart(CartItem cartItem)
        {

            return true;
        }

        public bool DeleteFromCart(CartItem cartItem)
        {
            return true;
        }

        public bool ProcessOrder(OrderModel orderModel)
        {
            return true;
        }

        public CartData ViewCart(int indexUser)
        {
            return null;
        }

        public AllDeliveries ViewOrders(int indexUser)
        {
            return null;
        }
    }
}
