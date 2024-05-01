using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.BusinessLogic.Core.Levels;
using WebProject.BusinessLogic.Interfaces;
using WebProject.Domain.Entities.DBModels;
using WebProject.Domain.Enum;
using WebProject.ModelAccessLayer.Model;

namespace WebProject.BusinessLogic.MainBL
{
    public class GuestBL : GuestAPI, IGuestUser
    {
        public UserData Login(LoginData loginData)
        {
            var result = CheckLogin(loginData);
            if (!result.IsExist) 
            {
                return null;
            }
            var userDataEF = result.Data;
            var tmp = new UserData
            {
                IdUser = userDataEF.Id,
                NameUser = userDataEF.Name,
                CartUser = GenerateCartData(userDataEF.CartItems),

            };


            UserData userData = new UserData();
            return userData;
        }

        public UserData Register(RegistrationData registrationData)
        {
            UserData userData = new UserData();

            return userData;
        }

        private OrderModel GetOrder(OrderEF data)
        {
            var orderInfo = new OrderInfo
            { 
                UserId = data.UserId,

                Name = data.Name,
                Email = data.Email,
                Phone = data.Phone,
                Country = data.Country,
                City = data.City,
                Address = data.Address,
                Comment = data.Comment,
            };
            var cardCred = new CardCreditionals();
            var cartData = GenerateCartData(data.CartItems);

            var StatusDelivery = WebProject.Domain.Enum.StatusDelivery.Pending;

            return new OrderModel
            {
                Id = data.Order_Id,
                OrderInfo = orderInfo,
                CardCreditinals = cardCred,
                CartData = cartData,
                StatusDelivery = StatusDelivery
            };

        }
        private AllDeliveries GetDeliveries(ICollection<OrderEF> orders)
        {

        }
        private Product GenerateProduct(ProductDataEF data)
        {
            return new Product
            {
                Id = data.Id,
                Name = data.Name,
                Details = data.Details,
                FullDescription = data.FullDescription,
                ShortDescription = data.ShortDescription,
                Amount = data.Amount,
                Price = data.Price,
                filter = null,
                PhotoUrl = null // написать ване
            };
        }

        private CartData GenerateCartData(ICollection<CartItemEF> userCart)
        {
            List<Tuple<Product, int>> productList = new List<Tuple<Product, int>>();
            decimal sumPrice = 0;
            decimal deliveryPrice = 0;
            decimal finalPrice = 0;

            foreach (CartItemEF cartItem in userCart) 
            {
                var par = new Tuple<Product, int>(
                    GenerateProduct(cartItem.Product), 
                    cartItem.Quantity);
                sumPrice += cartItem.Product.Price * cartItem.Quantity;
                productList.Add(par);
            }
            finalPrice = sumPrice + deliveryPrice;
            return new CartData
            { 
                SumPrice = sumPrice,
                DeliveryPrice = deliveryPrice,
                FinalPrice = finalPrice,
                productList = productList
            };
        }
    }
}
