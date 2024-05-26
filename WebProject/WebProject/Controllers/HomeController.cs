using System.Runtime.Remoting.Contexts;
using System.Web.Mvc;
using WebProject.ModelAccessLayer.Model;
using WebProject.Domain.Entities;
using WebProject.Domain.Entities.User;
using System;
using WebProject.Domain;
using System.Data.Entity;
using System.Linq;




namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        readonly BusinessLogic.BusinessLogic _businessLogic = new BusinessLogic.BusinessLogic();

        public static AllCategories AllCategories { get; private set; }

        // GET: Home
        public ActionResult ThanksForOrder() => View();
        public ActionResult Error() => View();
        public ActionResult Error404() => View();
        public ActionResult Index()
        {
            /*
            using (var dbContext = new Domain.Context())
            {
                UserEF A = new UserEF()
                {
                    Name = "Alex",
                    Email = "Spekel2003@gmail.com",
                    PhoneNumber = "37367361356",
                    Password = "password",
                    LogTime = DateTime.Now,
                    RegTime = DateTime.Now,
                };
                dbContext.Users.Add(A);
                dbContext.SaveChanges();

            };
            using (var dbContext = new Domain.Context())
            {
                var z = dbContext.Users.Take(10).ToList();


                if (z != null)
                {
                    foreach (var item in z)
                        Console.WriteLine($"Hello, World! Id: {item.Id}, Name: {item.Name}");
                }
                else
                {
                    Console.WriteLine("No entities found.");
                }
            };
            */
            AllCategories = _businessLogic.ProductBL.GetCategoriesView();

            return View(_businessLogic.ProductBL.GetAllProducts());
        }
        public ActionResult Search(string text)
        {
            AllProducts searchResults = _businessLogic.ProductBL.GetProductByName(text);

            return (text == null) ? View(searchResults) : View(_businessLogic.ProductBL.GetProductByName(text));
        }
    }
}

