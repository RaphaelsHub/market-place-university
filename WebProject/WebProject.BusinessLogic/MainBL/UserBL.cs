using System;
using System.Collections.Generic;
using WebProject.BusinessLogic.Core;
using WebProject.BusinessLogic.Core.Levels.GeneralResponse;
using WebProject.BusinessLogic.Interfaces;
using WebProject.Domain.Enum;
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
            if (responseProduct.IsExist == false)
                return false;

            if (responseProduct.Data.Amount < cartItem.Quantity)
                return false;

            CartItemEF newCartItemEF = new CartItemEF
            {
                User = responseUser.Data,
                Product = responseProduct.Data,
                Quantity = cartItem.Quantity
            };

            var finalResponse = _userRegisteredApi.AddToUserCart(newCartItemEF);

            if (finalResponse.Status == false)
                return false;

            return true;
        }

        public bool DeleteFromCart(CartItem cartItem)
        {
            var deletedCartItemEFResponse = _userRegisteredApi.FindCartItemEF(cartItem.Id, cartItem.Id_User);
            if (deletedCartItemEFResponse.IsExist == false)
                return false;

            var response = _userRegisteredApi.DeleteFromUserCart(deletedCartItemEFResponse.Data);
            if (response.Status == false)
                return false;

            return true;
        }

        public bool ProcessOrder(OrderModel orderModel)
        {
            var orderInfoReqest = GenerateEFOrderInfo(orderModel);
            var response = _userRegisteredApi.ProcessUserOrder(orderModel.OrderInfo.UserId, orderInfoReqest);
            if (response.IsExist == false)
                return false;

            return true;
        }

        public CartData ViewCart(int indexUser)
        {
            var response = _userRegisteredApi.ViewUserCart(indexUser);
            if (response.IsExist == false)
                return null;

            return GenerateCartData(response.Data);
        }

        public AllDeliveries ViewOrders(int indexUser)
        {
            var response = _userRegisteredApi.ViewUserOrders(indexUser);
            if (response.IsExist == false)
                return null;

            return GenerateDeliveries(response.Data);
        }


        //преобразования EntityFramework моделей в ASP.Net модели и наоборот
        static private Dictionary<string, StatusDelivery> StatusDeliveryDictionary = new Dictionary<string, StatusDelivery>
        {
            {"Pending", StatusDelivery.Pending},                // Ожидание
            {"Processing" , StatusDelivery.Processing},         // Обработка
            {"Shipped" , StatusDelivery.Shipped},               // Отправлено
            {"OutForDelivery" , StatusDelivery.OutForDelivery },// В пути
            {"Delivered" , StatusDelivery.Delivered },          // Доставлено
            {"Returned" , StatusDelivery.Returned },            // Возвращено
            {"Canceled" , StatusDelivery.Canceled }             // Отменено
        };
        static private StatusDelivery GenerateStatusDelivery(string RawOrderStatusEF)
        {
            if (StatusDeliveryDictionary.TryGetValue(RawOrderStatusEF, out StatusDelivery result))
            {
                return result;
            }
            else
            {
                return 0; //нужно придумать возврат некоректных данных
            }
        }
        static private Dictionary<StatusDelivery, string> ReverseStatusDeliveryDictionary = new Dictionary<StatusDelivery, string>
        {
            {StatusDelivery.Pending,    "Pending"},             // Ожидание
            {StatusDelivery.Processing, "Processing"},         // Обработка
            {StatusDelivery.Shipped,    "Shipped"},           // Отправлено
            {StatusDelivery.OutForDelivery, "OutForDelivery"},// В пути
            {StatusDelivery.Delivered , "Delivered"},        // Доставлено
            {StatusDelivery.Returned,   "Returned"},        // Возвращено
            {StatusDelivery.Canceled ,  "Canceled"}        // Отменено
        };
        private static OrderInfoReqest GenerateEFOrderInfo(OrderModel order)
        {
            var orderInfo = order.OrderInfo;
            string stringStatusDelivery = "Canceled";
            if (ReverseStatusDeliveryDictionary.ContainsKey(order.StatusDelivery))
                stringStatusDelivery = ReverseStatusDeliveryDictionary[order.StatusDelivery];
            return new OrderInfoReqest
            {
                OrderId = order.Id,
                Name = orderInfo.Name,
                Email = orderInfo.Email,
                Phone = orderInfo.Phone,
                Country = orderInfo.Country,
                City = orderInfo.City,
                Address = orderInfo.Address,
                Comment = orderInfo.Comment,
                StatusDelivery = stringStatusDelivery
            };
        }
        static private Product GenerateProduct(ProductDataEff data)
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
                PhotoUrl = null // написать ване
            };
        }
        static private CartData GenerateCartData(ICollection<CartItemEF> userCart)
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
        static private OrderModel GenerateOrderModel(OrderEF data)
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
        static private AllDeliveries GenerateDeliveries(List<OrderEF> orders)
        {
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
    }
}
