using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using CreditCalculator.Models;

namespace CreditCalculator.Controllers
{
    public class AdditionalCalculationController : Controller
    {
        public IActionResult DayCalculation()
        {
            var model = new AdditionalCalculationModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Calculate(AdditionalCalculationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("DayCalculation", model);
            }

            double dailyInterestRate = model.InterestRatePerDay / 100;
            double remainingBalance = model.LoanAmount;
            DateTime paymentDate = DateTime.Now;

            var paymentDetailsList = new List<PaymentDetails>();
            double totalInterestPaid = 0;
            int paymentNumber = 1;

            while (remainingBalance > 0)
            {
                double interestPayment = remainingBalance * dailyInterestRate * model.PaymentIntervalDays;
                double principalPayment = model.PaymentIntervalDays * model.LoanAmount / model.LoanTermDays;

                
                if (principalPayment > remainingBalance)
                {
                    principalPayment = remainingBalance;
                }

                remainingBalance -= principalPayment;
                totalInterestPaid += interestPayment;

                var paymentDetails = new PaymentDetails
                {
                    PaymentNumber = paymentNumber,
                    PaymentDate = paymentDate,
                    PrincipalPayment = principalPayment,
                    InterestPayment = interestPayment,
                    RemainingBalance = remainingBalance
                };

                paymentDetailsList.Add(paymentDetails);

                paymentDate = paymentDate.AddDays(model.PaymentIntervalDays);
                paymentNumber += 1;
            }

            var calculationResults = new CalculationResultsModel
            {
                Payments = paymentDetailsList,
                TotalInterestPaid = totalInterestPaid
            };

            return View("DayCalculationResults", calculationResults);
        }
    }
}