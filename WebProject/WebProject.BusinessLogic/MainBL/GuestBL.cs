using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.BusinessLogic.Core;
using WebProject.BusinessLogic.Core.Levels;
using WebProject.BusinessLogic.Interfaces;
using WebProject.Domain.Entities.DBModels;
using WebProject.Domain.Entities.User;
using WebProject.Domain.Enum;
using WebProject.ModelAccessLayer.Model;

namespace WebProject.BusinessLogic.MainBL
{
    public class GuestBL : UserBaseBL, IGuest
    {
        //
        private readonly UserGuestAPI _guestAPI = new UserGuestAPI();


        public UserData Login(LoginData loginData)
        {
            var responseResult = _guestAPI.CheckLogin(loginData);
            if (!responseResult.IsExist) 
            {
                return null;
            }
            var uAPi = new UserRegisteredAPI();
            var isAdmin = uAPi.SetSuperAdmin(responseResult.Data);
            return GenerateUserLoginData(responseResult.Data);
        }

        public UserData Register(RegistrationData registrationData)
        {
            var responseResult = _guestAPI.RegistrateUser(registrationData);

            if (!responseResult.IsExist)
            {
                return null;
            }
            return GenerateUserLoginData(responseResult.Data);
        }

        //преобразования EntityFramework моделей в ASP.Net модели
        private static UserData GenerateUserLoginData(UserEF data)
        {
            if (data == null)
                return null;
            var uAPi = new UserRegisteredAPI();
            var superAdmin = uAPi.GetSuperAdmin();

            StatusUser userStatus = StatusUser.User;
            if (superAdmin != null && data.Id == superAdmin.UserId)
                userStatus = StatusUser.Admin;

            return new UserData
            {
                IdUser = data.Id,
                NameUser = data.Name,
                CartUser = GenerateCartData(data.CartItems),
                DeliveriesUser = GenerateDeliveries(data.Orders),
                StatusUser = userStatus,
                //ProductsAdmin не заполняется
                //DeliveriesAdmin не заполняется
                //причину не заполнения смотреть -> WebProject.ModelAccessLayer.Model.UserData
            };
        }
        private static Dictionary<string, StatusDelivery> StatusDeliveryDictionary = new Dictionary<string, StatusDelivery>
        {
            {"Pending", StatusDelivery.Pending},                // Ожидание
            {"Processing" , StatusDelivery.Processing},         // Обработка
            {"Shipped" , StatusDelivery.Shipped},               // Отправлено
            {"OutForDelivery" , StatusDelivery.OutForDelivery },// В пути
            {"Delivered" , StatusDelivery.Delivered },          // Доставлено
            {"Returned" , StatusDelivery.Returned },            // Возвращено
            {"Canceled" , StatusDelivery.Canceled }             // Отменено
        };
        private static StatusDelivery GenerateStatusDelivery(string RawOrderStatusEF)
        {
            if (GuestBL.StatusDeliveryDictionary.TryGetValue(RawOrderStatusEF, out StatusDelivery result))
            {
                return result;
            }
            else
            {
                return 0; //нужно придумать возврат некоректных данных
            }
        }
        private static OrderModel GenerateOrderModel(OrderEF data)
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
            var cartData = GenerateCartData(data.CartItems);

            var StatusDelivery = GenerateStatusDelivery(data.StatusDelivery);

            return new OrderModel
            {
                Id = data.Order_Id,
                OrderInfo = orderInfo,
                CartData = cartData,
                StatusDelivery = StatusDelivery
            };

        }
        private static AllDeliveries GenerateDeliveries(ICollection<OrderEF> orders)
        {
            if(orders == null)
                return null;

            var deliverisList = new List<OrderModel>();

            foreach (var order in orders)
            {
                deliverisList.Add(GenerateOrderModel(order));
            }
            return new AllDeliveries
            {
                AllOrders = deliverisList
            };
        }
        private static Product GenerateProduct(ProductDataEF data)
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
        private static CartData GenerateCartData(ICollection<CartItemEF> userCart)
        {
          
            if (userCart== null)
                return null;
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
