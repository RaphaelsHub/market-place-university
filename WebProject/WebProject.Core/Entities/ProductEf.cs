using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Framework.XamlTypes;
using Microsoft.Win32;

namespace WebProject.Core.Entities
{
    public class ProductEf
    {
        [Key]
        public int IdProduct { get; set; }
        
        [Required(ErrorMessage = "Please enter the product name")]
        [StringLength(63, MinimumLength = 4, ErrorMessage = "The name must be between 4 and 63 characters")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Please enter the start amount")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Please enter an integer number")]
        public int StartAmount { get; set; }
        
        [Required(ErrorMessage = "Please enter the current amount")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Please enter an integer number")]
        public int CurrentAmount { get; set; }
        
        [Required(ErrorMessage = "Please enter the short description")]
        [StringLength(127, MinimumLength = 32, ErrorMessage = "The short description must be between 32 and 127 characters")]
        public string ShortDescription { get; set; }
        
        [Required(ErrorMessage = "Please enter the full description")]
        [StringLength(512, MinimumLength = 127, ErrorMessage = "The full description must be between 127 and 512 characters")]
        public string FullDescription { get; set; }
        
        [Required(ErrorMessage = "Please enter the start price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive number")]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "Please enter the date of the post")]
        public DateTime DatePost { get; set; }
        
        public bool IsVisible { get; set; }
        public bool IsSoldOut { get; set; }
        public bool IsBoosted { get; set; }

        public byte[][] Image { get; set; }
        
        //public List<Filter> Filters { get; set; }
        
        public Category Category { get; set; }
        //public Ratting Ratting { get; set; }
        
        
        
        public int Views { get; set; }
        public int Likes { get; set; }
    }
}