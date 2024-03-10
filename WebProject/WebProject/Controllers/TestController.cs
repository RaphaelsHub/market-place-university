using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult CS()
        {
            ProductSale PC = new ProductSale();
            PC.NameProduct = "PC";
            PC.Price = 900;
            PC.ProductDetails = "Ryzen 5560X";
            PC.PhotoPath = "PhotoPath";
            PC.ProducDescription = "Very Fast";

            ViewBag.ProductDetails = PC.ProductDetails;
            ViewBag.ProductName = PC.NameProduct;
            ViewBag.ProductPrice = PC.Price;
            ViewBag.ProductsPhotoPath = PC.PhotoPath;
            ViewBag.ProducDescription = PC.ProducDescription;

            return View();
        }
    }
}