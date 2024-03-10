using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class ProductSale
    {
        public string NameProduct {  get; set; }
        public string ProductDetails {  get; set; }
        public string ProducDescription { get; set; }
        public decimal Price { get; set; }
        public string PhotoPath { get; set; }
    }
}
