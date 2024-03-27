using System;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class CardCreditinals
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

        // Constructors
        public CardCreditinals() { }

        public CardCreditinals(string cardNumber, DateTime date, string cvv)
        {
            CardNumber = cardNumber;
            Date = date;
            CVV = cvv;
        }
    }
}
