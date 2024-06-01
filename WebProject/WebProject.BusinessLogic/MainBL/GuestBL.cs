using System;
using System.Collections.Generic;
using System.Linq;
using WebProject.BusinessLogic.Core.Levels;
using WebProject.BusinessLogic.Interfaces;
using WebProject.Domain.DB;
using WebProject.ModelAccessLayer.Model;

namespace WebProject.BusinessLogic.MainBL
{
    public class GuestBL : UserBaseBL, IGuest
    {
        private readonly UserGuestAPI _guestAPI = new UserGuestAPI();

        private Func<ICollection<OrderDataEF>, List<OrderModel>> GenerateDeliveries;
        private Func<ICollection<CartItemDataEF>, CartData> GenerateCartData;
        private Func<UserDataEF, UserData> GenerateUserData;


        public GuestBL()
        {
            GenerateCartData = cartItems =>
            {
                if (cartItems == null)
                    return null;

                var cartData = new CartData();

                foreach (var cartItem in cartItems)
                {
                    var product = GenerateProduct(cartItem.ProductId);
                    var par = new Tuple<Product, int>(product, cartItem.Quantity);
                    cartData.SumPrice += product.Price * cartItem.Quantity;
                    cartData.productList.Add(par);
                }

                cartData.FinalPrice = cartData.SumPrice + cartData.DeliveryPrice;
                return cartData;
            };
            GenerateDeliveries = orders =>
            {
                return orders?.Select(order => new OrderModel
                {
                    Id = order.OrderDataId,
                    StatusDelivery = order.StatusDelivery,
                    OrderInfo = new OrderInfo
                    {
                        UserId = order.UserDataId,
                        Name = order.Name,
                        Email = order.Email,
                        Address = order.Address,
                        City = order.City,
                        Country = order.Country,
                        Phone = order.Phone,
                        Comment = order.Comment
                    },
                    CartData = GenerateCartData(order.CartItems)
                }).ToList();
            };
            GenerateUserData = data =>
            {
                if (data == null) return null;

                return new UserData
                {
                    IdUser = data.UserDataId,
                    NameUser = data.Name,
                    StatusUser = data.StatusUser,
                    CartUser = GenerateCartData(data.CartItems),
                    DeliveriesUser = new AllDeliveries { AllOrders = GenerateDeliveries(data.Orders) }
                };
            };
        }

        public UserData Login(LoginData loginData)
        {
            var responseResult = _guestAPI.CheckLogin(loginData);

            return !responseResult.IsExist ? null : GenerateUserData(responseResult.Data);
        }
        public UserData Register(RegistrationData registrationData)
        {
            var responseResult = _guestAPI.RegistrateUser(registrationData);

            return !responseResult.IsExist ? null : GenerateUserData(responseResult.Data);
        }

        private Product GenerateProduct(int id) => GetProductById(id);
    }
}