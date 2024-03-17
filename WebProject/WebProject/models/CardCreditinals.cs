using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class CardCreditinals
    {
        public string CardNumber { get; set; }
        public string Date { get; set; }
        public string CVV { get; set; }
        public CardCreditinals() { }

        public CardCreditinals(string cardNumber, string date, string cvv)
        {
            this.CardNumber = cardNumber;
            this.Date = date;
            this.CVV = cvv;
        }
    }

}