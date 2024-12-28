using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using WebProject.Domain.DB;
using WebProject.Domain.Enum;
using WebProject.ModelAccessLayer.Model;

namespace WebProject.BusinessLogic.Core
{
    internal static class ModelGeneratingClass
    {
        public static Func<ICollection<OrderDataEF>, Func<int, Product>, List<OrderModel>> GenerateDeliveries = (orders,getProductById)=>
        {
            return orders?.Select(order => new OrderModel
            {
                Id = order.OrderDataId,
                StatusDelivery = order.StatusDelivery,
                OrderInfo = GenerateInfoData(order),
                CartData = GenerateCartData(order.CartItems,getProductById)
            }).ToList();
        };

        public static Func<OrderDataEF, OrderInfo> GenerateInfoData = info =>
        {
            return new OrderInfo
            {
                Name = info.Name,
                Email = info.Email,
                Address = info.Address,
                City = info.City,
                Comment = info.Comment,
                Country = info.Country,
                Phone = info.Phone,
                UserId = info.UserDataId
            };
        };

        public static Func<OrderInfo, OrderDataEF> GenerateInfoDataEF = info =>
        {
            return new OrderDataEF
            {
                UserDataId = info.UserId,
                Name = info.Name,
                Email = info.Email,
                Address = info.Address,
                City = info.City,
                Country = info.Country,
                Phone = info.Phone,
                Comment = info.Comment
            };
        };

        public static Func<ICollection<CartItemDataEF>, Func<int, Product>, CartData> GenerateCartData = (cartItems, getProductById) =>
        {
            if (cartItems == null)
                return null;

            var cartData = new CartData();

            foreach (var cartItem in cartItems)
            {
                var product = getProductById(cartItem.ProductId);
                var par = new Tuple<Product, int>(product, cartItem.Quantity);
                cartData.SumPrice += product.Price * cartItem.Quantity;
                cartData.productList.Add(par);
            }

            cartData.FinalPrice = cartData.SumPrice + cartData.DeliveryPrice;
            return cartData;
        };

        public static Func<UserDataEF, Func<int, Product>, UserData> GenerateUserData = (data,getProductById) =>
        {
            if (data == null) return null;

            return new UserData
            {
                IdUser = data.UserDataId,
                NameUser = data.Name,
                StatusUser = (data.UserDataId==1) ? StatusUser.Admin:StatusUser.User,
                CartData = GenerateCartData(data.CartItems,getProductById),
                AllOrders =  GenerateDeliveries(data.Orders,getProductById)
            };
        };
        public static Func<Product, ProductDataEF> GenerateEfProduct = product =>
        {
            return new ProductDataEF
            {
                Name = product.Name,
                FullDescription = product.FullDescription,
                ShortDescription = product.ShortDescription,
                Price = product.Price,
                Amount = product.Amount,
                ProductDataId=product.Id,
                PhotoUrls = product.PhotoUrl[0]
                
            };
        };
        public static Func<ProductDataEF, Product> GenerateProduct = product =>
        {
            var a = new List<string>();
            a.Add(product.PhotoUrls);
            return new Product
            {
                Name = product.Name,
                Amount = product.Amount,
                ShortDescription = product.ShortDescription,
                Id = product.ProductDataId,
                FullDescription = product.FullDescription,
                Price = product.Price,
                PhotoUrl = a

            };
        };

        public static Func<List<ProductDataEF>, List<Product>> GenerateListOfProducts = product =>
        {
            List<Product> products = new List<Product>();
            foreach (var item in product)
            {
                products.Add(GenerateProduct(item));
            }
            return products;
        };
    }
}
