using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Details is required.")]
        public string Details { get; set; }

        [Required(ErrorMessage = "ShortDescription is required.")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "FullDescription is required.")]
        public string FullDescription { get; set; }

        [Required(ErrorMessage = "PhotoUrl is required.")]
        public string[] PhotoUrl { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        public int Amount { get; set; }
    }
}
