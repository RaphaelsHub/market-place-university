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
        static CartData listOfProducts;


        // GET: Cart
        public ActionResult Buy()
        {

            listOfProducts = Test();

            return View(listOfProducts);
        }

        // GET: Order
        public ActionResult MakeAnOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MakeAnOrder(OrderInfo orderInfo, CardCreditinals cardCreditinals)
        {
            if (ModelState.IsValid)
            {
                OrderModel orderModel = new OrderModel(orderInfo, cardCreditinals);

                // Здесь можно выполнить дополнительные операции, связанные с обработкой заказа 



                return RedirectToAction("ThanksForOrder", "Home");
            }

            return View(new OrderModel(orderInfo, cardCreditinals));
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

        public CartData Test1()
        {
            var product = new HomeController().GetProducts();
            CartData cartData = new CartData();
            cartData.productList.Add(Tuple.Create(product[2], 1));
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