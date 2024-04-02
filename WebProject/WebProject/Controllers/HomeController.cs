using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using WebProject.Models; // Импорт модели Product
using WebProject.Models.Account;
using WebProject.Models.AddToCart;
using WebProject.Models.Order;
using WebProject.Models.Products;



namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        static public bool IsAuthorized { get; set; } = false;
        static public bool IsAdmin { get; set; } = false;

        // Для примера, создадим некоторые тестовые данные вместо получения их из леера домена
        public List<Product> GetProducts()
        {
            string reference = "https://cdn.discordapp.com/attachments/1221580786193399918/1221580959502172230/PCORDER.png?ex=661318ec&is=6600a3ec&hm=5dfe53031c0780933d95f94d6ea4c39de0be2a93047192fcebff5c9a2593ff55&";
            string red1 = "https://cdn.discordapp.com/attachments/1221580786193399918/1224084451861073982/emptyPhoto.png?ex=661c347b&is=6609bf7b&hm=77d48b73c6a44b5eca3b70a3c21207cd7370182e28d098bd4be5a6cd4d9226b0&";
            var products = new List<Product>
    {
        new Product { Id = 1, Name = "Product 1", Details = "Details 1", ShortDescription = "Short Description 1", FullDescription = "Full Description 1", Price = 10.99m, Amount = 13 },
        new Product { Id = 2, Name = "Product 2", Details = "Details 2", ShortDescription = "Short Description 2", FullDescription = "Full Description 2", Price = 20.99m, Amount = 15 },
        new Product { Id = 3, Name = "Product 3", Details = "Details 3", ShortDescription = "Short Description 3", FullDescription = "Full Description 3", Price = 30.99m, Amount = 16 },
        new Product { Id = 4, Name = "Product 4", Details = "Details 4", ShortDescription = "Short Description 4", FullDescription = "Full Description 4", Price = 40.99m, Amount = 11 },
        new Product { Id = 5, Name = "Product 5", Details = "Details 5", ShortDescription = "Short Description 5", FullDescription = "Full Description 5", Price = 50.99m, Amount = 12 },
        new Product { Id = 6, Name = "Product 6", Details = "Details 6", ShortDescription = "Short Description 6", FullDescription = "Full Description 6", Price = 60.99m, Amount = 13 }
    };

            foreach (var product in products)
            {
                product.PhotoUrl.Add(reference);
                product.PhotoUrl.Add(red1);
            }

            return products;
        }

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.IsAuthorized = IsAuthorized;
            ViewBag.IsAdmin = IsAdmin;

            // Получаем список продуктов с базы данных, сейчас тут тестовый вариант
            List<Product> products = GetProducts();

            // Передаем список продуктов в представление
            return View(products);
        }
        public ActionResult ThanksForOrder() => View();
        public ActionResult Error() => View();
    }
}
