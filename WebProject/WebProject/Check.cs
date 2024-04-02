using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProject.Models.Account;
using WebProject.Models.AddToCart;
using WebProject.Models.Order;
using WebProject.Models.Products;

namespace WebProject
{
    public static class Check
    {
        static List<Product> products;
        static UserData user;

        public static List<Product> GetProducts()
        {
            string url1 = "https://cdn.discordapp.com/attachments/1221580786193399918/1221580959502172230/PCORDER.png?ex=661318ec&is=6600a3ec&hm=5dfe53031c0780933d95f94d6ea4c39de0be2a93047192fcebff5c9a2593ff55&";
            string url2 = "https://cdn.discordapp.com/attachments/1221580786193399918/1224084451861073982/emptyPhoto.png?ex=661c347b&is=6609bf7b&hm=77d48b73c6a44b5eca3b70a3c21207cd7370182e28d098bd4be5a6cd4d9226b0&";
            
            List<Product> a = new List<Product>();

            for (int i = 0; i < 22; i++)
            {
               var b = new Product { Id = i, Name = "Product "+ i, Details = "Details "+i, ShortDescription = "Short Description "+i, FullDescription = "Full Description "+i, Price = 10.99m + i, Amount = 13+i };
                a.Add(b);
                a[i].PhotoUrl.Add(url1);
                a[i].PhotoUrl.Add(url2);
            }
            products = a;

            return a;
        }

        public static Product FindProduct(int? id)
        {
            return products[(int)id];
        }

       public static void Init()
        {
            user = new UserData();
            user.ID_User = 100;
            user.Name_User = "Alex";
        }

        public static void AddNewToCart(CartItem cartItem) 
        {
            user.Cart_User.SumPrice += products[cartItem.Id].Price * cartItem.Quantity;
            user.Cart_User.DeliveryPrice = 10;
            user.Cart_User.FinalPrice = user.Cart_User.SumPrice + user.Cart_User.DeliveryPrice;
            user.Cart_User.productList.Add(Tuple.Create(products[cartItem.Id],cartItem.Quantity));
            products[cartItem.Id].Amount -=cartItem.Quantity;
        }

        public static UserData ReturnUserData()
        {
            return user;
        }

        public static void AddDel(OrderModel orderModel)
        {
            OrderModel d= new OrderModel(orderModel.OrderInfo,orderModel.CardCreditinals,user.Cart_User);
            user.Deliveries_User.AllOrders.Add(d);
            user.Cart_User.productList.Clear();
        }

        public static UserData ReturDel ()
        {
            return user;
        }
    }
}