using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankingSite.Models
{
    public class CreditCardForm
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Age In Years")]
        public int Age { get; set; }
        
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Annual Income")]
        public decimal AnnualIncome { get; set; }

        [Display(Name = "Card 1 Credit Limit")]
        public decimal CreditCardLimit1 { get; set; }

        [Display(Name = "Card 2 Credit Limit")]
        public decimal CreditCardLimit2 { get; set; }

        [Display(Name = "Card 3 Credit Limit")]
        public decimal CreditCardLimit3 { get; set; }

        [Display(Name = "Airline Rewards Membership Number")]
        public string AirlineRewardNumber { get; set; }

    }
}