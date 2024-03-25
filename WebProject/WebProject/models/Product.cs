using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public string Details {  get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string PhotoUrl { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
