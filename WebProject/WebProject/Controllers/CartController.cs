using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Buy()
        {
            ProductController productController = new ProductController();
            var listOfProducts = Test();

            return View(listOfProducts);
        }

        public CartData Test()
        {
            var product = new HomeController().GetProducts();
            CartData cartData = new CartData();
            cartData.productList.Add(Tuple.Create(product[2], 2));
            cartData.productList.Add(Tuple.Create(product[1], 5));
            cartData.productList.Add(Tuple.Create(product[3], 3));
            cartData.productList.Add(Tuple.Create(product[1], 5));
            cartData.SumPrice = 100;
            cartData.DeliveryPrice = 25;
            cartData.FinalPrice = 125;

            return cartData;
        }
    }
}