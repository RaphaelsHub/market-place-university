    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.ModelAccessLayer.Model;

namespace WebProject.BusinessLogic.Interfaces
{
    public interface IRegistered
    {
        bool AddToCart(CartItem cartItem);
        bool DeleteFromCart(CartItem cartItem);
        bool ProcessOrder(OrderModel orderModel);
        CartData ViewCart(int indexUser);
        List<OrderModel> ViewOrders(int indexUser);
    }
}
