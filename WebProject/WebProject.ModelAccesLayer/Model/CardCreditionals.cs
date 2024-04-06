using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace WebProject.ModelAccessLayer.Model
{
    public class CardCreditionals
    {
        [Display(Name = "Card Number")]
        [Required(ErrorMessage = "Please enter the card number")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Card Number must be 16 characters long")]
        public string CardNumber { get; set; }

        [Display(Name = "Expiration Date")]
        [Required(ErrorMessage = "Please enter the expiration date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "CVV")]
        [Required(ErrorMessage = "Please enter the CVV")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "CVV must be 3 characters long")]
        public string CVV { get; set; }
    }
}
