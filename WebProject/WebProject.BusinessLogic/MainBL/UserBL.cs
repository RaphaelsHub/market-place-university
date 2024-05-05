using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.BusinessLogic.Core;
using WebProject.BusinessLogic.Core.Levels;
using WebProject.BusinessLogic.Interfaces;
using WebProject.Domain.Entities.DBModels;
using WebProject.ModelAccessLayer.Model;

namespace WebProject.BusinessLogic.MainBL
{
    public class UserBL : UserAPI, IUserBase
    {
        private ProductAPI productAPI = new ProductAPI();
        public bool AddToCart(CartItem cartItem)
        {
            var responseUser = FindUserEF(cartItem.Id_User);
            if (responseUser.IsExist == false)
                return false;

            var responseProduct = productAPI.GetSingleProductData(cartItem.Id);
            if (responseProduct.IsExist == false)
                return false;

            if(responseProduct.Data.Amount < cartItem.Quantity) 
                return false;

            CartItemEF newCartItemEF = new CartItemEF
            {
                User = responseUser.Data,
                Product = responseProduct.Data,
                Quantity = cartItem.Quantity
            };

            var finalResponse = AddToUserCart(newCartItemEF);
            if(finalResponse.Status == false) 
                return false;

            return true;
        }
        public bool DeleteFromCart(CartItem cartItem)
        {
            var deletedCartItemEFResponse = FindCartItemEF(cartItem.Id, cartItem.Id_User);
            if (deletedCartItemEFResponse.IsExist == false)
                return false;

            var response = DeleteFromUserCart(deletedCartItemEFResponse.Data);
            if (response.Status == false) 
                return false;

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
