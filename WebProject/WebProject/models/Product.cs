﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Product
    {
        //[Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Details is required.")]
        public string Details { get; set; }

        [Required(ErrorMessage = "ShortDescription is required.")]
        [StringLength(100, MinimumLength = 14, ErrorMessage = "Short Description must be at least 14 characters long")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "FullDescription is required.")]
        [StringLength(200, MinimumLength = 20, ErrorMessage = "Full Description must be at least 20 characters long")]
        public string FullDescription { get; set; }

        // [Required(ErrorMessage = "PhotoUrl is required.")]
        public LinkedList<string> PhotoUrl { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        public int Amount { get; set; }
    }
}
