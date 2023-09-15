using System;
using System.Collections.Generic;

namespace CreditCalculator.Models
{
    public class CalculationResultsModel
    {
        public List<PaymentDetails> Payments { get; set; }
        public double TotalInterestPaid { get; set; }
    }
}