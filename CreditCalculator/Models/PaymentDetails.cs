using System;
using System.Collections.Generic;

namespace CreditCalculator.Models
{
    public class PaymentDetails
    {
        public int PaymentNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public double PrincipalPayment { get; set; }
        public double InterestPayment { get; set; }
        public double RemainingBalance { get; set; }
    }
}

