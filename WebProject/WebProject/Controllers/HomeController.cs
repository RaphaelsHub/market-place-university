using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models; // Импорт модели Product



namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        // Для примера, создадим некоторые тестовые данные вместо получения их из леера домена
        private List<Product> GetProducts()
        {
            string reference = "https://cdn.discordapp.com/attachments/1221580786193399918/1221580959502172230/PCORDER.png?ex=661318ec&is=6600a3ec&hm=5dfe53031c0780933d95f94d6ea4c39de0be2a93047192fcebff5c9a2593ff55&";
            return new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Details = "Details 1", ShortDescription = "Description 1",FullDescription="Here will be description", PhotoUrl = reference, Price = 10.99m, Amount=13 },
                new Product { Id = 2, Name = "Product 2", Details = "Details 2", ShortDescription = "Description 2",FullDescription="Here will be description", PhotoUrl = reference, Price = 20.99m, Amount= 15 },
                new Product { Id = 3, Name = "Product 3", Details = "Details 3", ShortDescription = "Description 3",FullDescription="Here will be description", PhotoUrl = reference, Price = 30.99m , Amount = 16},
                new Product { Id = 1, Name = "Product 1", Details = "Details 1", ShortDescription = "Description 1", FullDescription = "Here will be description", PhotoUrl = reference, Price = 10.99m , Amount = 11},
                new Product { Id = 2, Name = "Product 2", Details = "Details 2", ShortDescription = "Description 2",FullDescription="Here will be description", PhotoUrl = reference, Price = 20.99m , Amount = 12},
                new Product { Id = 3, Name = "Product 3", Details = "Details 3", ShortDescription = "Description 3",FullDescription="Here will be description", PhotoUrl = reference, Price = 30.99m , Amount = 13}
            };
        }
        static public bool IsAuthorized {  get; set; } = false;
        static public bool IsAdmin {  get; set; } = false;
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
    }
}
 