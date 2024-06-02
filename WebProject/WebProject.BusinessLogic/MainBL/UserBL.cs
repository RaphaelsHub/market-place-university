using System;
using System.Collections.Generic;
using WebProject.BusinessLogic.Core;
using WebProject.BusinessLogic.Core.Levels.GeneralResponse;
using WebProject.BusinessLogic.Interfaces;
using WebProject.Domain.Enum;
using WebProject.Domain.DB;
using WebProject.ModelAccessLayer.Model;

namespace WebProject.BusinessLogic.MainBL
{
    public class UserBL : UserBaseBL, IRegistered
    {
        UserRegisteredAPI _userRegisteredApi = new UserRegisteredAPI();
        
        public bool AddToCart(CartItem cartItem)
        {
            var responseUser = _userRegisteredApi.FindUserEF(cartItem.Id_User);
            if (responseUser.IsExist == false)
                return false;

            var responseProduct = GetSingleProductData(cartItem.Id);
            if (responseProduct.IsExist == false || responseProduct.Data.Amount < cartItem.Quantity)
                return false;


            CartItemDataEF cartItemData = new CartItemDataEF
            {
                UserDataId = cartItem.Id_User,
                Quantity = cartItem.Quantity,
                ProductId = cartItem.Id
            };

             return _userRegisteredApi.AddToUserCart(cartItemData).Status==false ? false : true;
        }
        public bool DeleteFromCart(CartItem cartItem)
        {
            var response = _userRegisteredApi.DeleteFromUserCart(cartItem);

            return response.Status == false ? false : true;
        }
        public bool ProcessOrder(OrderModel orderModel)
        {
            var response = _userRegisteredApi.ProcessUserOrder(orderModel);

            return response.IsExist == false ? false : true;
        }
        public CartData ViewCart(int indexUser)
        {
            var response = _userRegisteredApi.ViewUserCart(indexUser);

            return response.IsExist == false ? null : ModelGeneratingClass.GenerateCartData(response.Data,GetProductById);
        }
        public AllDeliveries ViewOrders(int indexUser)
        {
            var response = _userRegisteredApi.ViewUserOrders(indexUser);

            return response.IsExist == false ? null : new AllDeliveries { AllOrders = ModelGeneratingClass.GenerateDeliveries(response.Data, GetProductById) }; 
        }
    }
}
